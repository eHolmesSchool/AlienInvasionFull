using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBullet : MonoBehaviour
{
    [SerializeField] float speed = -1;

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if (transform.position.y < speed *3)
        {
            Destroy(gameObject);
        }
    }
}
