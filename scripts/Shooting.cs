using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject arrowPrefab;
    private SFXManager sfxMan;
    public float bulletForce = 20f;
    void Start(){
        sfxMan = FindObjectOfType<SFXManager>();
    }
    void Update()
    {
       if (Input.GetButtonDown("Fire1"))
        {
            sfxMan.playerThrow.Play();
            Shoot();

        }
    }
    void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
