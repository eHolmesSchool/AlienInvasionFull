using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{

    [SerializeField] GameObject Bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = gameObject.transform.position.x;
        float yPos = gameObject.transform.position.y;
        float zPos = gameObject.transform.position.z;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Object.Instantiate(Bullet, new Vector3(xPos, yPos, zPos), Quaternion.identity);
        }
    }
}
