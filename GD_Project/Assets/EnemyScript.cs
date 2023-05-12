using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // variable for enemy health
    public float health = 50f;
    public int points = 25;

    // whenever enemy got shot with gun the health will decrease
    public void GetDamage(float damage){
        health -= damage;

        //if the health of the enemy fall below 0 the gameobject will be distroyed
        if(health <=0){
            //calling instance of EmemyScript to update score
            ScoreHandler.instance.Update_Score(points);
            Destroy(this.gameObject);
        }
    }
}
