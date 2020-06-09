using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update

    //public Camera mainCamera;
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        speed += 0.001f;
        Debug.Log("Speed: " + speed);
        
    }

}
