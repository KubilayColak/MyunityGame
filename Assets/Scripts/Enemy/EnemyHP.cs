using UnityEngine;
using UnityEngine.UI;


public class EnemyHP : MonoBehaviour
{
    private GameObject objSpawn;
    private int SpawnerID;
    public int enemyMaxHP = 100;
    public float enemyCurHP;
    public Image healthBar;
    public Text healthText;
    public bool isHeadshot = false;
    public bool isDead = false;

    Animator anim;

    void Start()
    {
        enemyCurHP = enemyMaxHP;
        anim = GetComponent<Animator>();
        objSpawn = (GameObject)GameObject.FindWithTag("Spawner");
    }

    void Update()
    {
        healthText.text = "HP: " + enemyCurHP + "/" + enemyMaxHP;
        healthBar.fillAmount = enemyCurHP / (float)enemyMaxHP;
    }

    public void TakeDamage(int amount)
    {
        enemyCurHP -= amount;
        if (!isDead && enemyCurHP <= 0)
        {
            objSpawn.BroadcastMessage("killEnemy", SpawnerID);
            isDead = true;
            if (isHeadshot)
            {
                anim.SetBool("Headshot Death", true);
                MyData.score += 300;
                MyData.headshots++;
                Destroy(gameObject, 6);
            }
            else
            {
                anim.SetBool("Death", true);
                MyData.score += 100;
                Destroy(gameObject, 6);
            }
            MyData.kills++;
        }
    }

    void setName(int sName)
    {
        SpawnerID = sName;
    }
}