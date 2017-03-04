using UnityEngine;
using System.Collections;

public class EnemyMoveTowards : MonoBehaviour
{
    public float speed;
    float dis;
    float attackSpeed;
    float waitSpeed = 10;
    public int damage;

    Transform Player;
    public Animator anim;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 playerY = Player.position;
        playerY.y = 0.0f; 
        transform.LookAt(playerY);
        
        print(attackSpeed);

        dis = (Vector3.Distance(transform.position, Player.position));
        if (dis >= 6)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if (dis <= 6)
        {
            anim.SetBool("Walking", false);
            speed = 0;  
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}