using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
    public GameObject bullet, bmuzzle;
    public int bulletSpeed = 30;
    float shootSpeed = 1;

    void Update ()
    {
        shootSpeed += Time.deltaTime;
        if(Input.GetMouseButton(0) && !MyManager.isPause && shootSpeed >= 0.1 && MyData.curAmmo > 0)
        {
            GameObject clone = (GameObject)Instantiate(bullet, bmuzzle.transform.position, bmuzzle.transform.rotation);
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
            shootSpeed = 0;
            MyData.curAmmo--;
        }
    }
}
