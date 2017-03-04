using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour {
    
    void Update () {
        Destroy(gameObject, 5);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag != "Bullet")
        {
            if (coll.gameObject.tag != "Player")
            {
                Destroy(gameObject);
            }
        }
    }
}
