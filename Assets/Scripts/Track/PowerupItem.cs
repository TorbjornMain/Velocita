using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerupItem : MonoBehaviour {

    public Powerup[] powerups;
    public float respawnTime = 1.0f;
    bool active = true;
    int index = 0;
    Light l;
    public ParticleSystem beacon;
    public Color[] beaconColours;
    public GameObject powerupImage;
    GameObject powerupImageInstance;

    void Start()
    {
        ControllerManager cm = FindObjectOfType<ControllerManager>();
        if (cm != null)
        {
            if(cm.TimeTrial)
            {
                gameObject.SetActive(false);
                return;
            }
        }
        l = GetComponent<Light>();
        StartCoroutine(resetPickup(0));
    }

    void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            PowerupManager p = other.GetComponent<PowerupManager>();
            if (p != null)
            {
                if (p.currentPowerup == null)
                {
                    p.currentPowerup = powerups[index];
                    active = false;
                    beacon.gameObject.SetActive(false);
                    Destroy(powerupImageInstance);
                    StartCoroutine(resetPickup(respawnTime));
                }
            }
        }
    }

    IEnumerator resetPickup(float time)
    {
        yield return new WaitForSeconds(time);
        active = true;
        index = Mathf.RoundToInt(Random.value * (powerups.Length - 1));
        powerupImageInstance = Instantiate(powerups[index].powerupImage);
        powerupImageInstance.transform.position = powerupImage.transform.position;
        powerupImageInstance.transform.SetParent(powerupImage.transform);
        beacon.gameObject.SetActive(true);
        ParticleSystem.MainModule m = beacon.main;
        m.startColor = beaconColours[(int)powerups[index].matchColor];
        switch (powerups[index].matchColor)
        {
            case RacerColor.Red:
                l.color = Color.red;
                break;
            case RacerColor.Blue:
                l.color = Color.blue;
                break;
            case RacerColor.Green:
                l.color = Color.green;
                break;
            case RacerColor.Yellow:
                l.color = Color.yellow;
                break;
        }
    }
}
