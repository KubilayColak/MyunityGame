using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet, bmuzzle;
    public int bulletSpeed = 30;
    float shootSpeed = 1;
    RaycastHit hit;

    void Start()
    {
        hit = new RaycastHit();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !MyManager.isPause && shootSpeed >= 0.1 && MyData.curAmmo > 0)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                GameObject clone = (GameObject)Instantiate(bullet, bmuzzle.transform.position, bullet.transform.rotation) as GameObject;
                clone.GetComponent<Rigidbody>().velocity = (hit.point - bmuzzle.transform.position).normalized * bulletSpeed;
                
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.transform.gameObject.GetComponent<EnemyHP>().TakeDamage(MyData.damage);
                    hit.transform.gameObject.GetComponent<EnemyHP>().isHeadshot = false;
                    print("BodyShot");
                }
                else if (hit.collider.gameObject.tag == GameObject.FindWithTag("Head").tag)
                {
                    hit.transform.GetComponent<EnemyHP>().TakeDamage(MyData.damage * 2);
                    hit.transform.GetComponent<EnemyHP>().isHeadshot = true;
                    print("HeadShot");
                }
                else
                {
                }
            }
            shootSpeed = 0;
            MyData.curAmmo--;
        }
        shootSpeed += Time.deltaTime;
    }
}