using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SwarmMovement : MonoBehaviour
{
    [SerializeField] float xSpeed = 1f;
    [SerializeField] float ySpeed = 1f;
    
    // Update is called once per frame
    void Update()
    {
        GameObject ourGameObject = gameObject;
        ProcessDeath(ourGameObject);
        ProcessMovement();
    }

    private static void ProcessDeath(GameObject ourGameObject)
    {
        if (ourGameObject.transform.childCount <= 0)
        {
            Destroy(ourGameObject);
        }
    }

    private void ProcessMovement()
    {
        if (transform.childCount > 0)
        {
            transform.Translate(xSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            xSpeed = 0;
        }
    }

    public void BorderCollision(Enemy enemy)
    {
        Debug.unityLogger.Log("COLLSION");
        xSpeed += 0.5f;
        xSpeed = -xSpeed;
        transform.Translate(0, -ySpeed, 0);
    }
}

