using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float cameraMovement;
    //public Camera mainCamera;
    public float speed;
    public bool isIncrease = true;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        SpeedUpdater();
    }

    private IEnumerator SpeedUpdater()
    {
        while(isIncrease)
        {
            yield return new WaitForSeconds(10f); // I used .2 secs but you can update it as fast as you want
            speed++;
        }
    }

}
