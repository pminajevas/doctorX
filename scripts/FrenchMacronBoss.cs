using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenchMacronBoss : MonoBehaviour
{
    private SFXManager sfxMan;
    public int CurrentHealth;
    public int MaxHealth = 1000;
    private bool playerInRange;
    public HealthBar healthBar;
    public GameObject HP;

    private Transform player;
    private Vector3 target;

    private float timeBtwCharge;
    private bool chargeDirection;
    public float chargeSpeed = 5f;
    public float moveSpeed = 2f;
    private bool stop=false;
    public bool moving;
    public GameObject gamend;
    private float shotTimer=1;

    public GameObject bubis;
    public GameObject bubiaivisur;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float timeattack=1;
    private int damage=10;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sfxMan = FindObjectOfType<SFXManager>();
        // Health
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        chargeDirection=false;

        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Health
        healthBar.SetHealth(CurrentHealth);

        if(CurrentHealth<=0){
            gamend.SetActive(true);
            Destroy(this.gameObject);
            Time.timeScale = 0f;
        }
        if(playerInRange){
        // 1 Levelis
        if(stop){
            shotTimer-=Time.deltaTime;
                if (shotTimer<0){
                shotTimer=1;
                anim.SetBool("hit", true);
                stop =false;
            }
        }else{
                if (CurrentHealth>=700){
            if(timeBtwCharge>2){
                anim.SetBool("charge", false);
                anim.SetBool("hit", false);
                moving =true;
                Vector3 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                direction.Normalize();
                movement= direction;
            }else if(timeBtwCharge<2 && timeBtwCharge >0.7){
                moving=false;
                sfxMan.enemyCharge.Play();
            }
            else if(timeBtwCharge<0.7 && timeBtwCharge > 0){
                if(chargeDirection==false){
                            anim.SetBool("charge", true);
                            player = GameObject.FindGameObjectWithTag("Player").transform;
                    target = (player.position - transform.position).normalized;
                    chargeDirection=true;
                }
                transform.position += target * chargeSpeed * Time.deltaTime;
            }
            else if(timeBtwCharge<=0){
                        timeBtwCharge = Random.Range(2f, 6f);
                chargeDirection= false;
                
            }
            timeBtwCharge-=Time.deltaTime;
        }
        //2 levelis
        if(CurrentHealth< 700 && CurrentHealth>=300){
            Destroy(GetComponent<Rigidbody2D>());
            moving=false;
            if(timeBtwCharge>2){
                if(shotTimer<=0){
                            anim.SetBool("spray", true);
                            Instantiate(bubis, transform.position, Quaternion.identity);
                    shotTimer = 0.2f;
                    sfxMan.enemyAttack.Play();
                }
                shotTimer-=Time.deltaTime;
            }else if(timeBtwCharge<2 && timeBtwCharge>1){
                        anim.SetBool("spray", false);
                        sfxMan.enemyCharge.Play();
            }else if(timeBtwCharge<1 && timeBtwCharge>0){
                if(chargeDirection==false){
                            anim.SetBool("charge", true);
                            player = GameObject.FindGameObjectWithTag("Player").transform;
                    target = (player.position - transform.position).normalized;
                    chargeDirection=true;
                }
                transform.position += target * chargeSpeed * Time.deltaTime;
            }else if(timeBtwCharge<=0){
                        anim.SetBool("charge", false);
                        timeBtwCharge = Random.Range(2f, 6f);
                chargeDirection= false;
            }
            timeBtwCharge-=Time.deltaTime;

        }

        //3 levelis
        if (CurrentHealth<300) {
            if(timeBtwCharge>2){
                if(shotTimer<=0){
                            anim.SetBool("ready", false);
                            anim.SetBool("sneeze", true);
                    GameObject go = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go.GetComponent<BubiaiVisasPuses>().xSpeed = 3;
                    GameObject go1 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go1.GetComponent<BubiaiVisasPuses>().xSpeed = 3; 
                    go1.GetComponent<BubiaiVisasPuses>().ySpeed = 3; 
                    GameObject go2 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go2.GetComponent<BubiaiVisasPuses>().ySpeed = 3; 
                    GameObject go3 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go3.GetComponent<BubiaiVisasPuses>().ySpeed = 3; 
                    go3.GetComponent<BubiaiVisasPuses>().xSpeed = -3; 
                    GameObject go4 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go4.GetComponent<BubiaiVisasPuses>().xSpeed = -3; 
                    GameObject go5 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go5.GetComponent<BubiaiVisasPuses>().xSpeed = -3;
                    go5.GetComponent<BubiaiVisasPuses>().ySpeed = -3;
                    GameObject go6 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go6.GetComponent<BubiaiVisasPuses>().ySpeed = -3; 
                    GameObject go7 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go7.GetComponent<BubiaiVisasPuses>().ySpeed = -3;
                    go7.GetComponent<BubiaiVisasPuses>().xSpeed = 3;   


                    GameObject go8 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go8.GetComponent<BubiaiVisasPuses>().ySpeed = Random.Range(-3,3);
                    go8.GetComponent<BubiaiVisasPuses>().xSpeed = Random.Range(-3,3);
                    GameObject go10 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go10.GetComponent<BubiaiVisasPuses>().ySpeed = Random.Range(-3,3);
                    go10.GetComponent<BubiaiVisasPuses>().xSpeed = Random.Range(-3,3);
                    GameObject go11 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go11.GetComponent<BubiaiVisasPuses>().ySpeed = Random.Range(-3,3);
                    go11.GetComponent<BubiaiVisasPuses>().xSpeed = Random.Range(-3,3);
                    GameObject go12 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go12.GetComponent<BubiaiVisasPuses>().ySpeed = Random.Range(-3,3);
                    go12.GetComponent<BubiaiVisasPuses>().xSpeed = Random.Range(-3,3);
                    GameObject go13 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go13.GetComponent<BubiaiVisasPuses>().ySpeed = Random.Range(-3,3);
                    go13.GetComponent<BubiaiVisasPuses>().xSpeed = Random.Range(-3,3);      
                    GameObject go14 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go14.GetComponent<BubiaiVisasPuses>().ySpeed = Random.Range(-3,3);
                    go14.GetComponent<BubiaiVisasPuses>().xSpeed = Random.Range(-3,3);    
                    GameObject go15 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go15.GetComponent<BubiaiVisasPuses>().ySpeed = Random.Range(-3,3);
                    go15.GetComponent<BubiaiVisasPuses>().xSpeed = Random.Range(-3,3);    
                    GameObject go16 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go16.GetComponent<BubiaiVisasPuses>().ySpeed = Random.Range(-3,3);
                    go16.GetComponent<BubiaiVisasPuses>().xSpeed = Random.Range(-3,3);    
                    GameObject go17 = (GameObject)Instantiate(bubiaivisur, transform.position, Quaternion.Euler(0,0,0));
                    go17.GetComponent<BubiaiVisasPuses>().ySpeed = Random.Range(-3,3);
                    go17.GetComponent<BubiaiVisasPuses>().xSpeed = Random.Range(-3,3);     
                    shotTimer = 1;
                    sfxMan.bossAttack.Play();
                }
                shotTimer-=Time.deltaTime;
            }else if(timeBtwCharge<2 && timeBtwCharge>1){
                sfxMan.enemyCharge.Play();
            }else if(timeBtwCharge<1 && timeBtwCharge>0){
                        anim.SetBool("sneeze", false);
                        anim.SetBool("charge", true);
                        if (chargeDirection==false){
                    player = GameObject.FindGameObjectWithTag("Player").transform;
                    target = (player.position - transform.position).normalized;
                    chargeDirection=true;
                }
                transform.position += target * chargeSpeed * Time.deltaTime;
            }else if(timeBtwCharge<=0){
                timeBtwCharge = Random.Range(2f, 6f);
                chargeDirection= false;
                        anim.SetBool("charge", false);
                        anim.SetBool("ready", true);
                    }
            timeBtwCharge-=Time.deltaTime;
        }
        }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player"){
            stop= true;
            col.gameObject.GetComponent<player_movement>().TakeDamage(damage);
        }
    }
    void moveCharacter(Vector2 direction){
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime)); 
    }
    private void FixedUpdate(){
        if(moving==true){
            moveCharacter(movement);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            playerInRange = true;
        }

    }
}
