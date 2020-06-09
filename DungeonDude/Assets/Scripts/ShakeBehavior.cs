using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehavior : MonoBehaviour
{
    //private Transform transform;

    private float dampingSpeed = 1.0f;
    public float shake = 0.3f;
    public bool clicked = false;
    public PlayerMovement player2;
    public float shakeAmount = 0.4f; 
    private float decreaseFactor = 1.0f;
    Vector3 initialPosition;
    
    // void Awake()
    // {
    //     if (transform == null)
    //     {
    //         transform = GetComponent(typeof(Transform)) as Transform;
    //     }
    // }
    // void OnEnable()
    // {
    //     initialPosition = transform.localPosition;
    // }

    // public IEnumerator Shake(float shakeDuration, float shakeMagnitude)
    // {
    //     while(shakeDuration > 0)
    //     {
    //         transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            
    //         shakeDuration -= Time.deltaTime * dampingSpeed;
    //     }
    //     shakeDuration = 0f;
    //     transform.localPosition = initialPosition;
        
    //     yield return null;
    // }

    void Update()
    {
        
        if (shake > 0f && clicked) {
            Debug.Log("Shake and clicked");
            transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
        } 
        else 
        {
            shake = 0.0f;
        }
        
        if (Input.GetKeyDown(KeyCode.J)){
            clicked = true;
            Debug.Log("ISCLICKED");
        }

       
    }

}
