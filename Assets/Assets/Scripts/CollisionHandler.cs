using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] public int health=3;
    [SerializeField] GameObject ExplosionFX;
    // Update is called once per frame

    public void OnTriggerEnter2D(Collider2D other)
    {
        Console.WriteLine("collide");
        if (gameObject.tag == "Enemy") //if we are an enemy
        {
            if (other.gameObject.CompareTag("Bullet")|| other.gameObject.CompareTag("Barrier"))
            {
                if (health >= 1)
                {
                    health--;
                }
                if (health <=0)
                {
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
            if (health <= 0)
            {
                if (other.gameObject.CompareTag("Enemy"))
                {
                    Instantiate(ExplosionFX, other.transform.position, Quaternion.identity);
                    //Lose the Game
                    Destroy(gameObject);
                }
            }
        }

        if (gameObject.tag == "Bullet") //If we are a Bullet. Player bullets are Bullets. Enemy Bullets are Tagged as Enemy
        {
            
            if (other.gameObject.CompareTag("Enemy"))
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
