using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionTransform : MonoBehaviour {

    Vector3 previousPos;
    Quaternion previousRot;

    void OnCollisionStay(Collision col)
    {
        ViveControllerInput input = GetComponent<ViveControllerInput>();

        Vector3 currentPos = transform.position;
        Vector3 relativePos = (previousPos - currentPos);

        Quaternion currentRot = transform.rotation;
        Quaternion r12 = (Quaternion.Inverse(currentRot) * previousRot);

        if (input.getPinch())
        {
            col.gameObject.GetComponent<Rigidbody>().useGravity = false;
            col.gameObject.transform.position -= relativePos;
        }

        if (!input.getPinch())
            col.gameObject.GetComponent<Rigidbody>().useGravity = true;

        if (input.getTouchPad())
            col.gameObject.transform.rotation *= r12;

        if (input.getGrip())
            col.gameObject.transform.localScale = relativePos;

        previousPos = currentPos;
        previousRot = currentRot;

    }

    void OnCollisionExit(Collision col)
    {
        col.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
