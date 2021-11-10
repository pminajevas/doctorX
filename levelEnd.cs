using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelEnd : MonoBehaviour
{
    public AudioSource levelend;
    private AudioSource camera;
    // Start is called before the first frame update
    void Start()
    {
        camera= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject end;
    public player_movement player;
    public void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            levelend.Play();
            camera.Stop();
            end.SetActive(true);
            if(SceneManager.GetActiveScene().name == "Lyon"){
                player.level3=true;
            }
            if(SceneManager.GetActiveScene().name == "Marseille"){
                player.level2=true;
            }
            if(SceneManager.GetActiveScene().name == "Orleans"){
                player.level4=true;
            }
            Time.timeScale = 0f;
            GameObject CoinManager = GameObject.Find("CoinManager");
            coinCountManager coinCountManager = CoinManager.GetComponent<coinCountManager>();
            player.savedCoinBalance += coinCountManager.totalCoins;
        }
    }
    public void Continue(){
        SceneManager.LoadScene("LevelMap");
        Time.timeScale = 1f;
    }
}
