using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenchEnemyRanged : MonoBehaviour
{
    private SFXManager sfxMan;
    public int CurrentHealth;
    public int MaxHealth = 100;

    public HealthBar healthBar;
    public GameObject HP;
    public Animator anim;
    private bool playerInRange;
    private bool isAlive;
    public float shotTimer=3.1f;
    public GameObject HealedText;
    private bool FanfarosDone = false;
    private Vector2 randomMove;
    private Vector2 randomPerSec;


    private float characterVelocity = 0.5f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    public GameObject bubis;
 

    // Start is called before the first frame update
    void Start()
    {
        // Health
        HealedText.SetActive(false);
        isAlive=true;
        HP.SetActive(false);
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        sfxMan = FindObjectOfType<SFXManager>();

    }
    void calcuateNewMovementVector(){
     movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
     movementPerSecond = movementDirection * characterVelocity;
     }

    // Update is called once per frame
    void Update()
    {
        // Health
        healthBar.SetHealth(CurrentHealth);

        if (CurrentHealth <= 0){
            isAlive = false;
        }

        ///anim.SetBool("Sneeze", )

        //Judejimas ir saudymas
        if(isAlive){
            if(playerInRange){
            if (shotTimer>=3f){
                calcuateNewMovementVector();
            }else if(shotTimer>0.5f){
                transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), 
                transform.position.y + (movementPerSecond.y * Time.deltaTime));
                anim.SetFloat("Horizontal", movementDirection.x);
                anim.SetFloat("Vertical", movementDirection.y);
                anim.SetFloat("Speed", movementDirection.sqrMagnitude);
            }else if(shotTimer>0){
                anim.SetBool("Sneeze", true);
                sfxMan.enemyAttack.Play();
            }else if(shotTimer <= 0){
                Instantiate(bubis, transform.position, Quaternion.identity);
                shotTimer = 4;
                anim.SetBool("Sneeze", false);
            }

            shotTimer-=Time.deltaTime;
            }
        }else if(isAlive == false && FanfarosDone == false){
            randomVector2();
            StartCoroutine(Death());
        }
        
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            playerInRange = true;
        }
    }
    void OnCollisionEnter2D(Collision2D col){
        if (FanfarosDone == true){
            Destroy(this.gameObject);
        }
    }
    private void randomVector2()
    {
        randomMove = new Vector2(UnityEngine.Random.Range(100f, 200f), UnityEngine.Random.Range(100f, 200f)).normalized;
        randomPerSec = randomMove * 2;
       
    }
    private IEnumerator Death()
    {   
        HealedText.SetActive(true);
        HP.SetActive(false);
        yield return new WaitForSeconds(1);
        HealedText.SetActive(false);
        transform.position = new Vector2(transform.position.x + (randomPerSec.x * Time.deltaTime), transform.position.y + (randomPerSec.y * Time.deltaTime));
        FanfarosDone = true;
    }
}
