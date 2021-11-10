using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public int Heal = 20;
    private ParticleSystem ParticleSystem;
    private AudioSource healthpick;

    private void Awake()
    {
        ParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        ParticleSystem.Play();
        healthpick= GameObject.FindGameObjectWithTag("pickup").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            healthpick.Play();
            GameObject Ciuvas = GameObject.Find("Ciuvas");
            player_movement player_movement = Ciuvas.GetComponent<player_movement>();
            player_movement.Heal(Heal);
            Destroy(gameObject);
        }
    }
}
