using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public float scaleX;
    public float maxHealth;
    [SerializeField] GameObject body;

    private void Start()
    {
        maxHealth = body.GetComponent<CollisionHandler>().health;
        scaleX = transform.localScale.x;
    }
    void Update()
    {
        scaleX = body.GetComponent<CollisionHandler>().health;
        transform.localScale = new Vector3(scaleX / maxHealth, transform.localScale.y, transform.localScale.z) ;
    }
}
