using UnityEngine;
using System.Collections;

public class ZombieBehavior : MonoBehaviour
{
    public float speed;
    float dis;
    float attackSpeed;
    public int damage;

    Transform Player;
    public Animator anim;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 playerY = Player.position;
        playerY.y = 0.0f; 
        transform.LookAt(playerY);
        dis = (Vector3.Distance(transform.position, Player.position));
        if (dis >= 6)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if (dis <= 6)
        {
            anim.SetBool("Walking", false);
            speed = 0;
            attackSpeed += Time.deltaTime;
        }
        if (this.GetComponent<EnemyHP>().isDead)
        {
            speed = 0;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player" && attackSpeed >= 1 && !this.GetComponent<EnemyHP>().isDead)
        {
            Player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}