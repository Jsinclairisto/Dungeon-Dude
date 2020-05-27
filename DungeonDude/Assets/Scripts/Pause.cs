using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private int pauseAmount = 0;
    public GameObject Player2;
    PlayerMovement playerMovement;
    public Rigidbody2D rbPause;

    void Start()
    {
        playerMovement = Player2.GetComponent<PlayerMovement>();
        rbPause = playerMovement.rb;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            pauseAmount++;
            if(pauseAmount % 2 == 0)
            {
                Time.timeScale = 1;
                rbPause.isKinematic = false;
                //isPaused = true;
            }
            else
            {
                Time.timeScale = 0.0f;
                //isPaused = false;
            }
        }

    }
}
