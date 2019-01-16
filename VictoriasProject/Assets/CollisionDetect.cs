using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter called.");
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay occurring.");
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit called.");
    }
}
