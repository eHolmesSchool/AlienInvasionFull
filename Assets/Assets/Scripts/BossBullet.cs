using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] float xSpeed = 1;
    [SerializeField] float ySpeed = -1;
    private void Start()
    {
        if (gameObject.transform.parent.GetComponentInParent<SwarmMovement>().xSpeed >0)
        {
            xSpeed = -xSpeed;
        }
    }

    void Update()
    {
        transform.position += Vector3.right * xSpeed * Time.deltaTime;
        transform.position += Vector3.down * ySpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Border"))
        {
            if (xSpeed > 0)
            {
                xSpeed += 0.5f;
            }
            else
            {
                xSpeed -= 0.5f;
            }
            xSpeed = -xSpeed;
        }
    }
}
