using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubiaiVisasPuses : MonoBehaviour
{
    public float xSpeed = 0;
    public float ySpeed = 0;
    public int damage = 20;
    public float destroyTime =5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x += xSpeed * Time.deltaTime;
        position.y += ySpeed * Time.deltaTime;
        transform.position = position;
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
