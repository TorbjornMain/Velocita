using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    public Text speedText;
    public Text lapText;
    public Text lapLabelText;
    public Text maxLapText;
    public Image placeImage;
    public Image wrongWayImage;
    public Image fadeToBlack;
    public Image timeTrialClockSprite;
    public Image finalLap;
    public GameObject powerUpImage;
    GameObject powerUpImageInstance;
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
    int lap = 0;
    public int numLaps; 
    public float resetTime = 2;
    PowerupManager pum;
    public Image playerCloseImagePrefab;
    public Image playerCloseBarImage;
    public float playerCloseLeftRight = 500;
    public float ribbonPinScalar = 0.5f;
    public bool timeTrialMode = false;
    public Vector3 powerupImageScaleFactor = new Vector3(0.1f, 0.1f, 0.1f);
    Image[] playerPosImages;
    int position = 0;
    // Update is called once per frame
    void Start()
    {
        ControllerManager cm = FindObjectOfType<ControllerManager>();
        if(cm != null)
            timeTrialMode = cm.TimeTrial;
        pum = player.GetComponent<PowerupManager>();
        cam = player.GetComponent<CameraController>();
        playerPosImages = new Image[4];
        if (timeTrialMode)
            timeTrialClockSprite.gameObject.SetActive(true);
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
                    playerPosImages[i].transform.localScale = new Vector3(0.1f, (1-cam.racerOffsets[i].dist) * ribbonPinScalar, 0.1f);
                }
                else
                {
                    playerPosImages[i].enabled = false;
                }
            }
            speedText.text = "Speed: " + Mathf.RoundToInt(player.speed * 3.6f).ToString() + "km/h";
            if (!timeTrialMode)
            {
                if(lap != playerLapGateUser.lap)
                {
                    lap = playerLapGateUser.lap;
                    if (lap == numLaps)
                    {
                        finalLap.gameObject.SetActive(true);
                    }
                }
                lapText.text = playerLapGateUser.lap.ToString();
                maxLapText.text = numLaps.ToString();
            }
            else
            {
                lapText.text = "";
                maxLapText.text = "";
                playerLapGateUser.data.lapTimes.Sort();
                float bestLapTime = PlayerPrefs.GetFloat("bestLap");
                bestLapTime = bestLapTime == 0 ? Mathf.Infinity : bestLapTime;
                if (Mathf.Min(bestLapTime, playerLapGateUser.data.lapTimes.Count > 0 ? playerLapGateUser.data.lapTimes[0] : Mathf.Infinity) < bestLapTime)
                    StartCoroutine(flashClock());
                bestLapTime = Mathf.Min(bestLapTime, playerLapGateUser.data.lapTimes.Count > 0 ? playerLapGateUser.data.lapTimes[0] : Mathf.Infinity);
                if (bestLapTime == Mathf.Infinity) bestLapTime = 0;
                lapLabelText.text = ToMinuteSeconds(playerLapGateUser.lapTime) + "\n" + ToMinuteSeconds(bestLapTime);
                PlayerPrefs.SetFloat("bestLap", bestLapTime == 0 ? Mathf.Infinity : bestLapTime);
            }
            wrongWayImage.enabled = Vector3.Dot(player.velocity, playerLapGateUser.trackDir) < 0 && player.velocity.magnitude > 10;
            if(player.reset)
            {
                ((PlayerController)player.controller).Deactivate();
                iTween.ValueTo(gameObject, iTween.Hash("from", 0, "to", 1, "time", 0.5f, "onupdate", "UpdateFadeAlpha", "oncomplete", "PlayerReset"));
                player.reset = false;
            }
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
                    if (pum.currentPowerup.matchColor == ((PlayerController)player.controller).colour)
                    {
                        if(powerUpImageInstance == null)
                        {
                            powerUpImageInstance = Instantiate(pum.currentPowerup.matchBonusImage);
                            powerUpImageInstance.transform.position = powerUpImage.transform.position;
                            powerUpImageInstance.transform.rotation = powerUpImage.transform.rotation;
                            powerUpImageInstance.transform.SetParent(powerUpImage.transform);
                            powerUpImageInstance.transform.localScale = powerupImageScaleFactor;
                        }
                    }
                    else
                    {
                        if (powerUpImageInstance == null)
                        {
                            powerUpImageInstance = Instantiate(pum.currentPowerup.powerupImage);
                            powerUpImageInstance.transform.position = powerUpImage.transform.position;
                            powerUpImageInstance.transform.rotation = powerUpImage.transform.rotation;
                            powerUpImageInstance.transform.SetParent(powerUpImage.transform);
                            powerUpImageInstance.transform.localScale = powerupImageScaleFactor;
                        }
                    }
                }
                else
                {
                    if(powerUpImageInstance != null)
                    {
                        Destroy(powerUpImageInstance);
                    }
                }
            }
            if(position < ps.playerLaps.IndexOf(playerLapGateUser))
            {
                player.SendMessage("Overtaken");
            }
            else if(position > ps.playerLaps.IndexOf(playerLapGateUser))
            {
                player.SendMessage("Overtake");
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

    string ToMinuteSeconds(float time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = time - minutes * 60;
        return minutes.ToString() + ":" + seconds.ToString("00.00");
    }

    IEnumerator flashClock()
    {
        for(int i = 0; i < 3; i++)
        {
            timeTrialClockSprite.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            timeTrialClockSprite.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
