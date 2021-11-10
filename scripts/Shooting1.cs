using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting1 : MonoBehaviour
{
    public Transform Aim;
    public Transform Aimg;
    public GameObject Svirkstas;
    public Transform aimTransform;
    private SFXManager sfxMan;
    public float bulletForce = 20f;
    //animacijai
    public Vector3 mousePos;
    public SpriteRenderer gun;
    public Camera cam;

    public float attackDelay;
    private float timeBtwAttack;
    void Start(){
        sfxMan = FindObjectOfType<SFXManager>();
    }
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }
    void Update()
    {
        //Animacijai
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        //Vector3 AimDirection = (mousePosition - transform.position).normalized;
        //float angle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg;
        //aimTransform.eulerAngles = new Vector3(0, 0, angle);

        if (timeBtwAttack <= 0 && Time.timeScale!=0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                sfxMan.playerBlow.Play();
                Shoot();
                timeBtwAttack = attackDelay;
            }
        }
       else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    // Animacijai
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
        GameObject syringe = Instantiate(Svirkstas, Aimg.position, Aimg.rotation);
        Rigidbody2D rb = syringe.GetComponent<Rigidbody2D>();
        rb.AddForce(Aimg.up * bulletForce, ForceMode2D.Impulse);
    }
}
