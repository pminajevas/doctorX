using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TigerForge;

public class endGame : MonoBehaviour
{
    public AudioSource theme;
    public player_movement player;
    void Start(){
        myFile = new EasyFileSave();
        theme.Stop();

    }
    EasyFileSave myFile;
    public void endgame(){
        if(myFile.Load()){
            myFile.Delete();
        }
        SceneManager.LoadScene("Menu");
    }
}
