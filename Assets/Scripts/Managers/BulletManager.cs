using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour {

    public int damage;

    Vector3 targetpoint;
    int targetRange;
    Camera mainCamera;
    
	void Update () {
        Destroy(gameObject, 5);

        mainCamera = Camera.main;

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        targetpoint = ray.GetPoint(targetRange);
        gameObject.transform.LookAt(targetpoint);
}

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<EnemyHP>().Damage(damage);
        }

        if (coll.gameObject.tag != "Bullet")
        {
            if (coll.gameObject.tag != "Player")
            {
                Destroy(gameObject);
            }
        }
    }
}
