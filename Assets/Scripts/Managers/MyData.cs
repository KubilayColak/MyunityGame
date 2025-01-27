﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MyData : MonoBehaviour {

    static public int damage = 10;

    static public int maxAmmo = 1000;
    static public int curAmmo;
    static public int magSize = 30;
    static public int score;
    static public int kills;
    static public int headshots;
    static public int round;

    public int maxHealth = 100;
    static public int curHealth;
    public Text healthText, ammoText, scoreText, killsText, headshotsText, roundText, roundText2;

    void Start()
    {
        curAmmo = magSize;
        curHealth = maxHealth;
    }

    void Update()
    {
        healthText.text = curHealth.ToString();
        ammoText.text = curAmmo.ToString() + "/" + maxAmmo.ToString();
        scoreText.text = score.ToString();
        killsText.text = kills.ToString();
        headshotsText.text = headshots.ToString();
        roundText.text = round.ToString();
        roundText2.text = round.ToString();

        if (MyManager.isDead)
        {
            curHealth = 0;
        }
        if (maxAmmo <= 0)
        {
            maxAmmo = 0;
        }
    }
}
