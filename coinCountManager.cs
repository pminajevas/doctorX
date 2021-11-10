using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCountManager : MonoBehaviour
{

    public Text coinsCounter;
    // visiskai nereikalingas kintamasis, bet be jo neveikia scriptas :D
    private int cvalue = 15;
    public int totalCoins=0;
    void Start()
    {
        totalCoins = 0;
        coinsCounter.text = "x : " + totalCoins.ToString();
    }  

    public void AddCoins(int cvalue)
    {
        totalCoins += cvalue;
        coinsCounter.text = "x : " + totalCoins.ToString();

    }
}
