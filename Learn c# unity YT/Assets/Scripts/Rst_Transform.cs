using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rst_Transform : MonoBehaviour
{

    private Vector3 originalPosition;

    // Use this for initialization
    void Start ()
    {
        Vector3 originalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Debug.Log("A transform: x = " + this.transform.position.x + " y = " + this.transform.position.y + " z = " + originalPosition.z);
        Debug.Log("A original: x = " + originalPosition.x + " y = " + originalPosition.y + " z = " + originalPosition.z);
    }

    void ResetPosA()
    {
        this.transform.localPosition = originalPosition;
        Debug.Log("reset A to: x = " + this.transform.position.x.ToString() + " y = " + this.transform.position.y.ToString());
    }

}





