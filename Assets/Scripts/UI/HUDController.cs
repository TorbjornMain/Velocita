﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    public Text speedText;
    public Text lapText;
    public Text maxLapText;
    public Image placeImage;
    public Image wrongWayImage;
    public Image fadeToBlack;
    public Image powerUpImage;
    public GameObject racingHUD;
    public GameObject doneHUD;
    public GameObject rollingHUD;
    public Sprite[] placeIcons;
    bool racing = false;
    public HoverboardController player;
    CameraController cam;
    [System.NonSerialized()]
    public PlayerSpawner ps;
    public LapGateUser playerLapGateUser;
    float wrongWayTime;
    public int numLaps; 
    public float resetTime = 2;
    PowerupManager pum;
    public Image playerCloseImagePrefab;
    public Image playerCloseBarImage;
    public float playerCloseLeftRight = 500;
    Image[] playerPosImages;
    // Update is called once per frame
    void Start()
    {
        pum = player.GetComponent<PowerupManager>();
        cam = player.GetComponent<CameraController>();
        if (pum == null)
            powerUpImage.color = new Color(0, 0, 0, 0);
        playerPosImages = new Image[4];
        for (int i = 0; i < cam.racerOffsets.Length; i++)
        {
            playerPosImages[i] = Instantiate(playerCloseImagePrefab);
            playerPosImages[i].rectTransform.SetParent(playerCloseBarImage.transform);
            playerPosImages[i].transform.localScale = new Vector3(1, 1, 1);

            switch ((RacerColor)i)
            {
                case RacerColor.Red:
                    playerPosImages[i].color = Color.red;
                    break;
                case RacerColor.Blue:
                    playerPosImages[i].color = Color.blue;
                    break;
                case RacerColor.Green:
                    playerPosImages[i].color = Color.green;
                    break;
                case RacerColor.Yellow:
                    playerPosImages[i].color = Color.yellow;
                    break;
                case RacerColor.White:
                    break;
                default:
                    break;
            }

        }
    }
    void Update () {
        if (racing)
        {
            for(int i = 0; i < playerPosImages.Length; i++)
            {
                if(cam.racerOffsets[i].dist > 0)
                {
                    playerPosImages[i].enabled = true;
                    playerPosImages[i].rectTransform.localPosition = new Vector3(playerCloseLeftRight * cam.racerOffsets[i].leftRight, 0, 0);
                    playerPosImages[i].transform.localScale = new Vector3(0.1f, (1-cam.racerOffsets[i].dist), 0.1f);
                }
                else
                {
                    playerPosImages[i].enabled = false;
                }
            }
            speedText.text = "Speed: " + Mathf.RoundToInt(player.speed * 3.6f).ToString() + "km/h";
            lapText.text = playerLapGateUser.lap.ToString();
            maxLapText.text = numLaps.ToString();
            int position = 0;
            wrongWayImage.enabled = Vector3.Dot(player.velocity, playerLapGateUser.trackDir) < 0 && player.velocity.magnitude > 10;
            if(wrongWayImage.enabled && ((PlayerController)player.controller).active)
            {
                wrongWayTime += Time.deltaTime;
                if(wrongWayTime > resetTime)
                {
                    ((PlayerController)player.controller).Deactivate();
                    iTween.ValueTo(gameObject, iTween.Hash("from", 0, "to", 1, "time", 0.5f, "onupdate", "UpdateFadeAlpha", "oncomplete", "PlayerReset"));
                }
            }
            else
            {
                wrongWayTime = 0;
            }
            if(pum != null)
            {
                if(pum.currentPowerup != null)
                {
                    powerUpImage.color = Color.white;
                    if (pum.currentPowerup.matchColor == ((PlayerController)player.controller).colour)
                    {
                        powerUpImage.sprite = pum.currentPowerup.matchBonusImage;
                    }
                    else
                    {
                        powerUpImage.sprite = pum.currentPowerup.powerupImage;
                    }
                }
                else
                {
                    powerUpImage.color = new Color(0, 0, 0, 0);
                }
            }

            position = ps.playerLaps.IndexOf(playerLapGateUser);
            placeImage.sprite = placeIcons[position];
        }
	}

    void PlayerReset()
    {
        player.SendMessage("ResetPlayer");
        player.transform.position = playerLapGateUser.lastGatePos;
        player.transform.forward = playerLapGateUser.trackDir;
        iTween.ValueTo(gameObject, iTween.Hash("from", 1, "to", 0, "time", 0.5f, "onupdate", "UpdateFadeAlpha", "oncomplete", "ResetComplete"));
    }

    void UpdateFadeAlpha(float f)
    {
        fadeToBlack.color = new Color(0,0,0,f);
    }

    void ResetComplete()
    {
        ((PlayerController)player.controller).active = true;
    }

    void FinishRolling()
    {
        racing = true;
        racingHUD.SetActive(true);
        rollingHUD.SetActive(false);
    }
    void FinishRace()
    {
        racingHUD.SetActive(false);
        doneHUD.SetActive(true);
        racing = false;
    }
}
