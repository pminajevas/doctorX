using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBarrel : MonoBehaviour
{
    public GameObject openText;
    private ParticleSystem particle;
    public Transform barrel;

    private SpriteRenderer sr;
    public GameObject Whatever;

    private bool playerEntered = false;
    
    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerEntered == true)
        {
            Instantiate(Whatever, barrel.position, barrel.rotation);
            StartCoroutine(Break());
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            openText.SetActive(true);
            playerEntered = true;       
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            openText.SetActive(false);
            playerEntered = false;
        }
    }

    private IEnumerator Break()
    {
        sr.enabled = false;
        particle.Play();
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);

        Destroy(gameObject);
    }
}
