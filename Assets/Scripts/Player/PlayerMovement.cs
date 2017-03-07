using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform target, center, child;
    public GameObject arrows;
    Vector3 initialMousePos, curMousePos;
    float dis;
    public int speed;
    bool canMove = false;
    
    void Update()
    {
        if (!EnemySpawner.Spawn && !MyManager.isPause && !MyManager.isDead)
        {
            arrows.SetActive(true);
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            target = FindClosest().transform;
            dis = (Vector3.Distance(transform.position, target.position));
            if (Input.GetMouseButtonDown(0) && mousePos <= 3.825)
            {
                canMove = true;
            }
            if (canMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
                gameObject.GetComponentInChildren<MouseCamera>().enabled = false;
                arrows.SetActive(false);
            }
            if (dis <= 0.05)
            {
                canMove = false;
                transform.position = center.position;
                gameObject.GetComponentInChildren<MouseCamera>().enabled = true;
                EnemySpawner.Spawn = true;
                MyData.round++;
            }
        }
    }

    GameObject FindClosest()
    {
        GameObject[] target;
        target = GameObject.FindGameObjectsWithTag("Center");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        float dist = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
        Vector3 v3Pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
        v3Pos = Camera.main.ScreenToWorldPoint(v3Pos);
        foreach (GameObject go in target)
        {
            float diff = (Vector3.Distance(v3Pos, go.transform.position));
            float curDistance = diff;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}