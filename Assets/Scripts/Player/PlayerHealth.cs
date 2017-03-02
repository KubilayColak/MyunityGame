using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public void TakeDamage (int amount)
    {
        MyData.curHealth -= amount;
        if(MyData.curHealth <= 0)
        {
            SceneManager.LoadScene("Home");
        }
    }
}
