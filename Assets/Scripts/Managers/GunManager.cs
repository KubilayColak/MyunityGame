using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour
{

    void Update()
    {
        RaycastHit screenRayInfo;
        Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0)), out screenRayInfo);
        transform.LookAt(screenRayInfo.point);
    }
}
