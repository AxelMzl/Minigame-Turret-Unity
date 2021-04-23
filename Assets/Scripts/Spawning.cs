using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject Enemy;
    public Camera cam;

    public Vector2 spawnPosition;
    public float spawnTimer = 2f;

    public float zoffset = 10;
    public int maxEnemy = 5;

    public bool play = false;
    // Start is called before the first frame update
    void Start()
    {
        play = true;

        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (play == true)
        {
            ennemyPosition();

            Instantiate(Enemy, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnTimer);
        }

    }

    void ennemyPosition()
    {
        int side = Random.Range(1, 5);
        int xcount = 20;
        int ycount = 20;

        //top
        if (side == 1)
        {
            xcount = Random.Range(-21, 21);
            ycount = Random.Range(11, 15);
        }
        //right
        if (side == 2)
        {
            xcount = Random.Range(21, 25);
            ycount = Random.Range(-11, 11);
        }
        //bottom
        if (side == 3)
        {
            xcount = Random.Range(-21, 21);
            ycount = Random.Range(-11, -15);
        }
        //left
        if (side == 4)
        {
            xcount = Random.Range(-21, -25);
            ycount = Random.Range(-11, 11);
        }

        spawnPosition = new Vector2(xcount, ycount);
    }
}
