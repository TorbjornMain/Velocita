﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "Assets/Powerup")]
public class Powerup : ScriptableObject {
    public PowerupEntity spawnObject;
    public PowerupEntity spawnMatchObject;
    public RacerColor matchColor;
    public Sprite powerupImage;
    public Sprite matchBonusImage;

    public void Use(HoverboardController player)
    {
        PowerupEntity g = null;
        if (player.GetComponent<PlayerController>().colour != matchColor)
            g = Instantiate(spawnObject);
        else
            g = Instantiate(spawnMatchObject);
        g.p = player;
        g.transform.position = player.transform.position;
        g.transform.rotation = player.transform.rotation;

    }
}
