using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//The only difference between this script and Enemy is in OnCollisionEnter2d where we change the fact that the BorderCollision script is Not on a parent but on This object.


public class BossEnemy : MonoBehaviour
{
    [SerializeField] float fireRate = 5;
    [SerializeField] GameObject BadBullet;
    System.Random rnd = new System.Random();
    float random;

    // Update is called once per frame
    void Update()
    {
        float xPos = gameObject.transform.position.x;
        float yPos = gameObject.transform.position.y;
        float zPos = gameObject.transform.position.z;

        random = rnd.Next(1, 1001); //rolls a d1000
        if (random <= fireRate)
        {
            Instantiate(BadBullet, new Vector3(xPos, yPos, zPos), Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Border")) 
        { 
            GetComponent<SwarmMovement>().BorderCollision();
        }
    }
}
