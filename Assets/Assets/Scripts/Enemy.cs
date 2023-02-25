using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime;

public class Enemy : MonoBehaviour
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
        Debug.unityLogger.Log("ENTER");
        if (collider.gameObject.CompareTag("Border"))
        {
            transform.parent.GetComponent<SwarmMovement>().BorderCollision(this);
        }
    }
}
