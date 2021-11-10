using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player_movement : MonoBehaviour
{
    public player_movement prefab;
    public bool hasDart = false;
    public bool hasShotgun = false;
    private bool isMoving = false;
    private SFXManager sfxMan;
    private AudioSource audioSrc;

    public float speed = 5.0f;
    public int maxHealth = 100;
    public int Hp = 20;
    public int currentHealth;
    public HealthBar healthBar;

    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;
    public Transform aimTransform;

    public DeathMenu deathMenu;


    public bool level1 = true;
    public bool level2 = false;
    public bool level3 = false;
    public bool level4 = false;
    public int mask = 1;



    Vector2 movement;
    Vector2 mousePos;

    public int savedCoinBalance;
    


    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }
    private void Start()
    {
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        // coins
        GameObject CoinManager = GameObject.Find("CoinManager");
        coinCountManager coinCountManager = CoinManager.GetComponent< coinCountManager >();
        savedCoinBalance = coinCountManager.totalCoins;
        speed = prefab.speed;
        maxHealth = prefab.maxHealth;
        hasDart = prefab.hasDart;
        hasShotgun = prefab.hasShotgun;
        mask = prefab.mask;

    }

    // Update is called once per frame
    void Update()
    {
        sfxMan = FindObjectOfType<SFXManager>();
        audioSrc = GetComponent<AudioSource>();
        //Movement and Animation
        if(Time.timeScale!=0){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        //Aim
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if(movement.x!=0 || movement.y!=0){
            isMoving=true;
        }else{
            isMoving=false;
        }
        if(Time.timeScale!=0){
        if(isMoving==true){
            if (!audioSrc.isPlaying){
                audioSrc.Play();
            }
        }
        if(isMoving==false){
            audioSrc.Stop();
        }
        }else{
            audioSrc.Stop();
        }
        if(currentHealth<=0){
            deathMenu.ToggleEndMenu();
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
    public void TakeDamage (int damage)
    {
        if(damage>0){
            sfxMan.playerHurt.Play();
            if(mask==1){
                damage-=2;
            }
            if(mask==2){
                damage-=4;
            }
            if(mask==3){
                damage-=6;
            }
            if(mask==4){
                damage-=8;
            }
            if(mask==5){
                damage-=10;
            }
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void Heal(int Hp)
    {
        if (currentHealth + Hp <= 100)
            currentHealth += Hp;
        else
            currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
}

 

