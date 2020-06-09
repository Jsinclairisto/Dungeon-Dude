using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCode : MonoBehaviour
{
    void Awake()
    {
        Physics2D.IgnoreLayerCollision(11,13,true);
    }

}
