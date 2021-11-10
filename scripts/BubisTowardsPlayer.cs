using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubisTowardsPlayer : MonoBehaviour
{
    public float speed=  1;
    private Transform player;
    private Vector3 target;
    public int damage = 20;
    public float destroyTime =5f;
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player").transform;
         target = (player.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += target * speed * Time.deltaTime;
        destroyTime=destroyTime-Time.deltaTime;
        if(destroyTime<0){
        Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            other.gameObject.GetComponent<player_movement>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
