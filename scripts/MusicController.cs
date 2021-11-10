using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource themeSong;
    // Start is called before the first frame update
    void Start()
    {
        themeSong.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
