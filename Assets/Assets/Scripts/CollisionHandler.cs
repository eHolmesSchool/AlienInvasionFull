using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] public int health=3;
    [SerializeField] GameObject ExplosionFX;

    GameObject Judge;
    ScoreCounter scoreCounter;

    private void Start()
    {
        Judge = GameObject.Find("Judge");
        scoreCounter = Judge.GetComponent<ScoreCounter>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Enemy" || gameObject.tag == "BadBullet" || gameObject.tag == "Boss") //if we are an enemy
        {
            if (other.gameObject.CompareTag("Bullet")|| other.gameObject.CompareTag("Barrier")) //if we hit a player bullet or barrier
            {
                if (health >= 1) 
                {
                    health--;
                }
                if (health <= 0)
                {
                    if(gameObject.tag == "Enemy")
                    {
                        scoreCounter.killCount++;
                    }
                    if (gameObject.tag == "Boss")
                    {
                        scoreCounter.bossKillCount++;
                    }
                    Destroy(gameObject);
                }
            }
            if (other.gameObject.CompareTag("Player"))
            {
                //Lose the game
                Destroy(gameObject);
            }
        }

        if (gameObject.tag == "Player")//If we are a player
        {
            if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "BadBullet" || other.gameObject.tag == "Boss")
            {
                Instantiate(ExplosionFX, other.transform.position, Quaternion.identity);
                health--;
                if (health <= 0)
                {
                    scoreCounter.playerStatus = 0; //set our status to a Loss for displaying proper message
                }
                Debug.unityLogger.Log(scoreCounter.playerStatus);
            }
        }



        if (gameObject.tag == "Bullet") //If we are a Bullet. Player bullets are Bullets. Enemy Bullets are Tagged as Enemy
        {
            if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "BadBullet" || other.gameObject.tag == "Boss")
            {
                Destroy(gameObject);
                Instantiate(ExplosionFX, other.transform.position, Quaternion.identity);
            }
            if (other.gameObject.CompareTag("Barrier"))
            {
                Destroy(gameObject);
            }
        }
    }
}
