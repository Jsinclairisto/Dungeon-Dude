using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int score = 0;
    
    void OnTriggerEnter2D(Collider2D col)
    {
       
        if(col.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("Collided");
        }
    }
}
