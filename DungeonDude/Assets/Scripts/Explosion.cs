using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explodeEffect;
    
    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D col)
    {
       
        if(col.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Instantiate(explodeEffect, transform.position, Quaternion.identity);
            Debug.Log("Collided");
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(this.gameObject);
            Instantiate(explodeEffect, transform.position, Quaternion.identity);
        }
    }
}
