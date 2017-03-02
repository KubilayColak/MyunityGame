using UnityEngine;
using System.Collections;

public class EnemyMoveTowards : MonoBehaviour
{
    public float MoveSpeed = 7;
    public float MaxDist = 10;
    public float MinDist = 5;

    Transform Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //function lookAt();
            }
        }
    }
}
