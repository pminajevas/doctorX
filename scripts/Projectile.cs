using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private SFXManager sfxMan;
    public int damage = 20;
    void Start()
    {
        sfxMan = FindObjectOfType<SFXManager>();
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "melee")
        {
            GameObject FrenchEnemy = col.gameObject;
            FrenchEnemyScript FrenchEnemyScript = FrenchEnemy.GetComponent<FrenchEnemyScript>();
            FrenchEnemyScript.CurrentHealth -= damage;
            sfxMan.enemyHurt.Play();
            Destroy(this.gameObject);
            FrenchEnemyScript.HP.SetActive(true);

        }
        if (col.gameObject.tag == "ranged")
        {
            GameObject FrenchEnemy = col.gameObject;
            FrenchEnemyRanged FrenchEnemyRanged = FrenchEnemy.GetComponent<FrenchEnemyRanged>();
            FrenchEnemyRanged.CurrentHealth -= damage;
            sfxMan.enemyHurt.Play();
            Destroy(this.gameObject);
            FrenchEnemyRanged.HP.SetActive(true);
        }
        if (col.gameObject.tag == "macron")
        {
            GameObject FrenchEnemy = col.gameObject;
            FrenchMacronBoss FrenchMacronBoss = FrenchEnemy.GetComponent<FrenchMacronBoss>();
            FrenchMacronBoss.CurrentHealth -= damage;
            sfxMan.enemyHurt.Play();
            Destroy(this.gameObject);
        }
        if(col.gameObject.tag =="collision"){
            Destroy(this.gameObject);
        }
    }
}
