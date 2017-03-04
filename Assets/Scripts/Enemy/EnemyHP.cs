using UnityEngine;
using UnityEngine.UI;


public class EnemyHP : MonoBehaviour
{
    public int enemyMaxHP = 100;
    private float enemyCurHP;
    public Image healthBar;
    public Text healthText;
    public bool isHeadshot = false;

    void Start()
    {
       enemyCurHP = enemyMaxHP;
    }

    private void Update()
    {
        healthText.text = "HP: " + enemyCurHP + "/" + enemyMaxHP;
        healthBar.fillAmount = enemyCurHP / (float)enemyMaxHP;
    }

    public void TakeDamage(int amount)
    {
        enemyCurHP -= amount;
        if(enemyCurHP <= 0)
        {
            Destroy(gameObject);
            if (isHeadshot)
            {
                MyData.score += 300;
                MyData.headshots++;
            }
            else
            {
                MyData.score += 100;
            }
            MyData.kills++;
        }
    }
}