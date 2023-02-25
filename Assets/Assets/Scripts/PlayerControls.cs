using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class PlayerControls : MonoBehaviour
{

    //Variables
    [SerializeField] float xControlSpeed = 1f;
    [SerializeField] float xMoveLimit = 1f;

    

    GameObject player;

    void Start()
    {
        player = new GameObject();
        Transform transform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
    }

    void ProcessMovement()
    {
        float xThrow = Input.GetAxis("Horizontal"); //gets a number BETWEEN -1 to 1 from left and right controls
        float xOffset = (xThrow * xControlSpeed) * Time.deltaTime; //multiplies that by a Spees variable
        float xNewPos = transform.localPosition.x + xOffset; //Determines the xco-ord we are going to
        float xClampedPos = Mathf.Clamp(xNewPos, -xMoveLimit, xMoveLimit); //Limits movement to a maximum and minimum

        transform.position = new Vector2(xClampedPos, transform.localPosition.y) ;
    }

}
