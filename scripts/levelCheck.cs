using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelCheck : MonoBehaviour
{
    bool level1;
    bool level2;
    bool level3;
    bool level4;
    public player_movement levels;
    public GameObject locked;
    public GameObject mars;
    public GameObject lyon;
    public GameObject orlean;
    public GameObject paris;
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;
    public GameObject ownedBlow;
    public GameObject buyBlow;
    public GameObject ownedShot;
    public GameObject buyShot;
    public Text health;
    public Text faceMask;
    public Text agility;
    public GameObject hea;
    public GameObject fac;
    public GameObject agi;
    public GameObject heamax;
    public GameObject facmax;
    public GameObject agimax;
    public Text totalCoins;
    public AudioSource buy;
    void Start(){
        Time.timeScale=1f;
        GameObject.FindGameObjectWithTag("music").GetComponent<MusicClass>().PlayMusic();
    }
    void Update()
    {       
        level1=levels.level1;
        level2=levels.level2;
        level3=levels.level3;
        level4=levels.level4;
        if(level1){
            lock1.SetActive(false);
        }else{
            lock1.SetActive(true);
        }
         if(level2){
            lock2.SetActive(false);
        }else{
            lock2.SetActive(true);
        }
         if(level3){
            lock3.SetActive(false);
        }else{
            lock3.SetActive(true);
        }
         if(level4){
            lock4.SetActive(false);
        }else{
            lock4.SetActive(true);
        }
        if(levels.hasDart){
            buyBlow.SetActive(false);
            ownedBlow.SetActive(true);
        }else{
            buyBlow.SetActive(true);
            ownedBlow.SetActive(false);
        }
        if(levels.hasShotgun){
            buyShot.SetActive(false);
            ownedShot.SetActive(true);
        }else{
            buyShot.SetActive(true);
            ownedShot.SetActive(false);
        }
        totalCoins.text = ""+levels.savedCoinBalance;
        health.text= ""+levels.maxHealth;
        faceMask.text = "level "+levels.mask;
        agility.text = ""+levels.speed;
        if(levels.maxHealth<500){
            hea.SetActive(true);
            heamax.SetActive(false);
        }else{
            hea.SetActive(false);
            heamax.SetActive(true);
        }
        if(levels.mask<5){
            fac.SetActive(true);
            facmax.SetActive(false);
        }else{
            fac.SetActive(false);
            facmax.SetActive(true);
        }
        if(levels.speed<1.7f){
            agi.SetActive(true);
            agimax.SetActive(false);
        }else{
            agi.SetActive(false);
            agimax.SetActive(true);
        }
    }

    public void Level1(){
        if(!level1){
            locked.SetActive(true);
        }else{
            mars.SetActive(true);
        }
    }
    public void Level2(){
        if(!level2){
            locked.SetActive(true);
        }else{
            lyon.SetActive(true);
        }
    }
    public void Level3(){
        if(!level3){
            locked.SetActive(true);
        }else{
            orlean.SetActive(true);
        }
    }
    public void Level4(){
        if(!level4){
            locked.SetActive(true);
        }else{
            paris.SetActive(true);
        }
    }
    public void LoadLevel1(){
        SceneManager.LoadScene("Marseille");
    }
    public void LoadLevel2(){
        SceneManager.LoadScene("Lyon");
    }
    public void LoadLevel3(){
        SceneManager.LoadScene("Orleans");
    }
    public void LoadLevel4(){
        SceneManager.LoadScene("Paris");
    }
    public void BackToMenu(){
        SceneManager.LoadScene("Menu");
    }
    public void BuyShotgun(){
        if(levels.savedCoinBalance>=5){
            levels.hasShotgun=true;
            levels.savedCoinBalance-=5;
            buy.Play();
        }
    }
    public void BuyBlow(){
        if(levels.savedCoinBalance>=3){
            levels.hasDart=true;
            levels.savedCoinBalance-=3;
            buy.Play();
        }
    }
    public void BuyHealth(){
        if(levels.savedCoinBalance>=2 && levels.maxHealth<500){
            levels.maxHealth+=50;
            levels.savedCoinBalance-=2;
            buy.Play();
        }
    }
    public void BuyMask(){
        if(levels.savedCoinBalance>=3 && levels.mask<5){
            levels.mask+=1;
            levels.savedCoinBalance-=3;
            buy.Play();
        }
    }
    public void BuyAgility(){
        if(levels.speed<1.7f && levels.savedCoinBalance>=5){
            levels.speed+=0.1f;
            levels.savedCoinBalance-=5;
            buy.Play();
        }
    }
}
