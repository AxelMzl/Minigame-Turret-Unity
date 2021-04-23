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
        GameManager.life -= 1;
        if (GameManager.life <= 0)
        {
            GM.GetComponent<GameManager>().gameOver();
        }
    }

}
