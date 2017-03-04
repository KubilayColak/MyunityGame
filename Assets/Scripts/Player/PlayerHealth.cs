using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public GameObject damageScreen;
    public Image blood;
    bool isDead = false;
    float damaged;

    void Update()
    {
        if (damaged >= 2)
        {
            damageScreen.SetActive(false);
            blood.CrossFadeAlpha(1, 0, false);
        }
        damaged += Time.deltaTime;
    }

    public void TakeDamage (int amount)
    {
        if (!isDead)
        {
            MyData.curHealth -= amount;
            damageScreen.SetActive(true);
            blood.CrossFadeAlpha(0, 2f, false);
            damaged = 0;
            if (MyData.curHealth <= 0)
            {
                isDead = true;
                MyManager.isDead = true;
            }
        }
    }
}
