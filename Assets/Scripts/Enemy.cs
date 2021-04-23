using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject turret;

    public int health;
    public float speed;
    public int ennemyValue;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("ded");
        GameManager.score += ennemyValue;
        Destroy(gameObject);
    }

    void Start()
    {
        EnnemyType();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, turret.transform.position, step * 3);
    }

    void EnnemyType()
    {
        int ennemyType = Random.Range(1, 4);
        if (ennemyType == 1)
        {
            Debug.Log("Ennemy 1");

            health = 100;
            speed = 4;
            ennemyValue = 10;

            this.GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (ennemyType == 2)
        {
            Debug.Log("Ennemy 2");

            health = 200;
            speed = 3;
            ennemyValue = 30;

            this.GetComponent<Renderer>().material.color = new Color(255, 165, 0, 1);
        }

        if (ennemyType == 3)
        {
            Debug.Log("Ennemy 3");

            health = 400;
            speed = 1;
            ennemyValue = 50;

            this.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Turret turret = hitInfo.GetComponent<Turret>();
        if (turret != null)
        {
            Destroy(this.gameObject);
            turret.looseHealth();
        }
    }
}
