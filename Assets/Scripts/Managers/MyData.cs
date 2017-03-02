using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MyData : MonoBehaviour {

    static public int maxAmmo = 120;
    static public int curAmmo;

    public int maxHealth = 100;
    static public int curHealth;
    public Text health;
    public Text ammo;

    private void Start()
    {
        curAmmo = maxAmmo;
        curHealth = maxHealth;
    }

    void Update()
    {
        health.text = curHealth.ToString();
        ammo.text = curAmmo.ToString();
    }
}
