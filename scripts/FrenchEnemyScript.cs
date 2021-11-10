using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenchEnemyScript : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int CurrentHealth;
    public int MaxHealth = 100;

    public HealthBar healthBar;
    public GameObject HP;
    private bool playerInRange;
    private bool isAlive;
    private bool playerHit;
    private float moveCooldown=1;
    public bool movingRight;
    public float moveTime = 2;
    public int damage=20;
    //random vektoriaus kurimas
    private Vector2 randomMove;
    private Vector2 randomPerSec;
    //pomirtines fanfaros
    public GameObject HealedText;
    private bool FanfarosDone = false;
    private float smugis;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        HealedText.SetActive(false);
        playerInRange = false;
        isAlive = true;
        // Health
        HP.SetActive(false);
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        //Movement
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Health
        healthBar.SetHealth(CurrentHealth);

        if (CurrentHealth <= 0){
            isAlive = false;
        }
        // Skaiciuoja kur reikia eit priesui
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement= direction;
        moveTime-=Time.deltaTime;
        if(moveTime > 0){
            movingRight = true;
        }
        if(moveTime < 0){
            movingRight = false;
        }
        if (moveTime < -2){
            moveTime = 2;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            playerInRange = true;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "syringe"){
            HP.SetActive(true);
        }
        if(col.gameObject.tag == "Player"){
            col.gameObject.GetComponent<player_movement>().TakeDamage(damage);
            playerHit=true;
            smugis = 1;
        }
        if (FanfarosDone == true)
            Destroy(this.gameObject);
    }

    // Juda link zaidejo
     void moveCharacter(Vector2 direction){
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    private void randomVector2()
    {
        randomMove = new Vector2(UnityEngine.Random.Range(100f, 200f), UnityEngine.Random.Range(100f, 200f)).normalized;
        randomPerSec = randomMove * 2;

        
    }
    private void FixedUpdate(){
        smugis -= Time.deltaTime;
        anim.SetFloat("attack", smugis);
        if (playerInRange && isAlive && !playerHit)
        {
            moveCharacter(movement);
            anim.SetBool("moving", true);
        }
        else if(playerInRange && isAlive && playerHit){
            if(moveCooldown>0){
                anim.SetBool("moving", false);
                moveCooldown -=Time.deltaTime;
            }else{
                moveCooldown=1;
                playerHit=false;
            }
        }
        else if (isAlive)
        {
            if (movingRight == true)
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
            if (movingRight == false)
            {
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            }
        }
        else if (isAlive == false && FanfarosDone == false)
        {
            randomVector2();
            StartCoroutine(Death());
        }
        else
        {
            transform.position = new Vector2(transform.position.x + (randomPerSec.x * Time.deltaTime), transform.position.y + (randomPerSec.y * Time.deltaTime));       
        }

    }
    private void attack()
    {
        smugis = 1;

    }

    private IEnumerator Death()
    {   
        damage=0;
        HealedText.SetActive(true);
        HP.SetActive(false);
        yield return new WaitForSeconds(1);
        HealedText.SetActive(false);
        transform.position = new Vector2(transform.position.x + (randomPerSec.x * Time.deltaTime), transform.position.y + (randomPerSec.y * Time.deltaTime));
        FanfarosDone = true;
    }
}
