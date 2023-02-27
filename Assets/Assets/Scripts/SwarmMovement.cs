using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SwarmMovement : MonoBehaviour
{
    [SerializeField] public float xSpeed = 1f;
    [SerializeField] float xAccel = 1f;
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
        if (ourGameObject.transform.position.y <= -20|| ourGameObject.transform.position.x <= -20|| ourGameObject.transform.position.x >= 20)
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

    public void BorderCollision()
    {
        if (xSpeed > 0)
        {
            xSpeed += xAccel;
        }else
        {
            xSpeed -= xAccel;
        }
        xSpeed = -xSpeed;
        transform.Translate(0, -ySpeed, 0);
    }
}

