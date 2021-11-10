using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public int value = 1;
    private ParticleSystem particle;
    public AudioSource pickup;
    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }
    void Start()
    {
        particle.Play();
        pickup= GameObject.FindGameObjectWithTag("coin").GetComponent<AudioSource>();
    }
  
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
            {
            pickup.Play();
            GameObject coinManager = GameObject.Find("CoinManager");
            
            coinCountManager coinCountManager = coinManager.GetComponent<coinCountManager>();
            coinCountManager.AddCoins(value);
            Destroy(this.gameObject);
            }
        
        

    }
}
