using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_EncData : MonoBehaviour
{
    public GameObject B_chestObject;

	// Use this for initialization
	void Start ()
	{
	    this.gameObject.GetComponent<Animator>().SetBool("A_Unlock", false);
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (B_chestObject.gameObject.GetComponent<chestBScript>().B_KeyIn)
	    {
	        this.gameObject.GetComponent<Animator>().SetBool("A_Unlock", true);
        }
    }

    void EndofAnimation()
    {
        Debug.Log("Message from A_EncData: EndofAnimation");
        B_chestObject.SetActive(true);
    }
}
