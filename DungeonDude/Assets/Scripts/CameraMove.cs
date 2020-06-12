using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update

    //public Camera mainCamera;
    public PlayerMovement player;
    public float speed;
    public bool isAlive = true;
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(isAlive){
            speed += 0.001f;
        }
        else
        {
            speed = 0f;
        }

    }

}
