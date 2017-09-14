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
    public Image powerupImage;

    void Start()
    {
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
                    l.color = powerupImage.color = new Color(0, 0, 0, 0);
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
        powerupImage.sprite = powerups[index].powerupImage;
        powerupImage.color = Color.white;
        switch(powerups[index].matchColor)
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
