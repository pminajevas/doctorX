using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickSound : MonoBehaviour
{
    public AudioSource click;
    public AudioSource back;
    public void playClick(){
        click.Play();
    }
    public void returnMenu(){
        back.Play();
    }

}
