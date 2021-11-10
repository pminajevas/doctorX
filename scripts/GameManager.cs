using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;

public class GameManager : MonoBehaviour
{
    EasyFileSave myFile;
    bool level1;
    bool level2;
    bool level3;
    bool level4;
    float speed;
    int maxHealth;
    int mask;
    int savedCoinBalance;
    bool hasDart;
    bool hasShotgun;
    public player_movement player;
    public GameObject load;
    bool loadactive=false;
    // Start is called before the first frame update
    void Start()
    {
        myFile = new EasyFileSave();
    }

    // Update is called once per frame
    void Update()
    {
        if (myFile.Load()){
            load.SetActive(true);
        }else{
            load.SetActive(false);
        }
    }
    public void Save(){
        level1 = player.level1;
        level2 = player.level2;
        level3 = player.level3;
        level4 = player.level4;
        speed = player.speed;
        maxHealth = player.maxHealth;
        savedCoinBalance = player.savedCoinBalance;
        mask = player.mask;
        hasDart = player.hasDart;
        hasShotgun = player.hasShotgun;
        myFile.Add("level1", level1);
        myFile.Add("level2", level2);
        myFile.Add("level3", level3);
        myFile.Add("level4", level4);
        myFile.Add("speed", speed);
        myFile.Add("maxHealth", maxHealth);
        myFile.Add("mask", mask);
        myFile.Add("hasDart", hasDart);
        myFile.Add("hasShotgun", hasShotgun);
        myFile.Add("savedCoinBalance", savedCoinBalance);
        myFile.Save();
        load.SetActive(true);

    }
    public void Load(){
        if (myFile.Load()){
            level1 = myFile.GetBool("level1");
            level2 = myFile.GetBool("level2");
            level3 = myFile.GetBool("level3");
            level4 = myFile.GetBool("level4");
            speed = myFile.GetFloat("speed");
            savedCoinBalance = myFile.GetInt("savedCoinBalance");
            maxHealth = myFile.GetInt("maxHealth");
            mask = myFile.GetInt("mask");
            hasDart = myFile.GetBool("hasDart");
            hasShotgun = myFile.GetBool("hasShotgun");
            savedCoinBalance = myFile.GetInt("savedCoinBalance");
            player.savedCoinBalance = savedCoinBalance;
            player.level1 = level1;
            player.level2 = level2;
            player.level3 = level3;
            player.level4 = level4;
            player.speed = speed;
            player.maxHealth = maxHealth;
            player.mask = mask;
            player.hasDart = hasDart;
            player.hasShotgun = hasShotgun;
        }
    }
}
