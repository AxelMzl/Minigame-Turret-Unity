using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject GM;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void looseHealth()
    {
        GameManager.turretLife -= 1;
        if (GameManager.turretLife <= 0)
        {
            GM.GetComponent<GameManager>().gameOver();
        }
    }

}
