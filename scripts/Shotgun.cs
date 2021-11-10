using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Transform Aim;
    public Transform aim;
    public Transform aimLeft;
    public Transform aimRight;
    public Transform aim15Left;
    public Transform aim15Right;
    private SFXManager sfxMan;

    public GameObject Svirkstas;

    public Vector3 mousePos;
    public SpriteRenderer gun;
    public Camera cam;


    public float bulletForce = 20f;

    public float attackDelay;
    private float timeBtwAttack;

   void Start(){
        sfxMan = FindObjectOfType<SFXManager>();
    }
    
    
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (timeBtwAttack <= 0 && Time.timeScale!=0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                sfxMan.playerShotgun.Play();
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
        if (angle <= 0 && angle >= -180)
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
        GameObject syringe = Instantiate(Svirkstas, aim.position, aim.rotation);
        Rigidbody2D rb = syringe.GetComponent<Rigidbody2D>();
        rb.AddForce(aim.up * bulletForce, ForceMode2D.Impulse);

        GameObject syringeleft = Instantiate(Svirkstas, aimLeft.position, aimLeft.rotation);
        Rigidbody2D rbleft = syringeleft.GetComponent<Rigidbody2D>();
        rbleft.AddForce(aimLeft.up * bulletForce, ForceMode2D.Impulse);

        GameObject syringeright = Instantiate(Svirkstas, aimRight.position, aimRight.rotation);
        Rigidbody2D rbright = syringeright.GetComponent<Rigidbody2D>();
        rbright.AddForce(aimRight.up * bulletForce, ForceMode2D.Impulse);

        GameObject syringe15right = Instantiate(Svirkstas, aim15Right.position, aim15Right.rotation);
        Rigidbody2D rb15right = syringe15right.GetComponent<Rigidbody2D>();
        rb15right.AddForce(aim15Right.up * bulletForce, ForceMode2D.Impulse);

        GameObject syringe15left = Instantiate(Svirkstas, aim15Left.position, aim15Left.rotation);
        Rigidbody2D rb15left = syringe15left.GetComponent<Rigidbody2D>();
        rb15left.AddForce(aim15Left.up * bulletForce, ForceMode2D.Impulse);
    }
}

