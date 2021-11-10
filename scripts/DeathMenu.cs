using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public AudioSource theme;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleEndMenu(){
        gameObject.SetActive(true);
        theme.Stop();
        Time.timeScale = 0f;
    }
    public void Restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ToMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelMap");
    }
}
