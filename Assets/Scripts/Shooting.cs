using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPfb;

    public float bulletForce = 20;

    public float laserRange = 10f;
    public LineRenderer LineRenderer;
    public LayerMask mask;
    public List<string> names;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameEnd == false) {
            if (GameManager.gamePauseStatus == false) {
                if (Input.GetButtonDown("Fire1"))
                {
                    Shoot();
                }

                if (Input.GetButtonDown("Fire2"))
                {
                    Debug.Log("Laser");
                    Laser();
                }

                if (Input.GetButtonDown("Fire3"))
                {
                    Debug.Log("Bomb");
                    Bomb();
                }
            }
        }

    }

    void Shoot()
    {
        // Shoot a bullet
        GameObject bullet = Instantiate(bulletPfb, firePoint.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        // Destroy bullet after 1 second
        Destroy(bullet, 1f);
    }

    void Laser()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, laserRange, mask);

        LineRenderer.SetPosition(0, transform.position);
        LineRenderer.SetPosition(1, transform.position + transform.forward * laserRange);

        names.Clear();

        foreach (RaycastHit hit in hits)
        {
            names.Add(hit.transform.name);
        }
    }

    void Bomb()
    {
        //Physics.OverlapSphere;
    }
}
