using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingThrow : MonoBehaviour
{
    public SpriteRenderer gun;
    public Camera cam;
    public Transform Aim;
    public GameObject Svirkstas;
    public Transform aimTransform;
    private SFXManager sfxMan;
    public float bulletForce = 20f;
    public Vector3 mousePos;
    public float attackDelay;
    private float timeBtwAttack;
    void Start(){
        sfxMan = FindObjectOfType<SFXManager>();
    }
    private void Awake()
    {
      //  aimTransform = transform.Find("Aim");
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

       if (timeBtwAttack <= 0)
        {
            if (Input.GetButtonDown("Fire1") && Time.timeScale!=0)
            {
                sfxMan.playerThrow.Play();
                Shoot();
                timeBtwAttack = attackDelay;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
       
    }
    private void FixedUpdate()
    {
        Vector3 lookDir = (mousePos - Aim.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        Aim.localEulerAngles = new Vector3(0, 0, angle);
        if(angle <= 0 && angle >= -180)
        {
            gun.flipY = false;
        }
        else
        {
            gun.flipY = true;
        }
    }

    void Shoot()
    {
        GameObject syringe = Instantiate(Svirkstas, Aim.position, Aim.rotation);
        Rigidbody2D rb = syringe.GetComponent<Rigidbody2D>();
        rb.AddForce(Aim.up * bulletForce, ForceMode2D.Impulse);
    }
}