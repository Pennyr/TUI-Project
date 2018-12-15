using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_EncData : MonoBehaviour
{
    public GameObject B_chestObject;
    private GameObject userMenu;
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>();

    // Use this for initialization
    void Start ()
	{
	    userMenu = this.transform.parent.parent.GetChild(3).gameObject;
	    Debug.Log("Message from A_RawData: " + userMenu.name);

        childGameObjects.Add("sendKeyDis", userMenu.transform.GetChild(2).gameObject);    // send raw data to user B
	    childGameObjects.Add("sendKey", userMenu.transform.GetChild(3).gameObject);    // send raw data to user B
	    childGameObjects.Add("sendEncDis", userMenu.transform.GetChild(4).gameObject);    // send raw data to hacker
	    childGameObjects.Add("sendEnc", userMenu.transform.GetChild(5).gameObject);    // send raw data to hacker

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

    void EndofMoveAnimation()
    {
        Debug.Log("Message from A_EncData: EndofMoveAnimation");
        B_chestObject.SetActive(true);
        // René communicate with chest - blink key hole led, lid should be closed
    }

    void EndofDecryptAnimation()
    {
        Debug.Log("Message from A_EncData: EndofDecryptAnimation");
        B_chestObject.SetActive(false);
        this.gameObject.SetActive(false);

        childGameObjects["sendKeyDis"].SetActive(false);
        childGameObjects["sendKey"].SetActive(true);

        childGameObjects["sendEncDis"].SetActive(false);
        childGameObjects["sendEnc"].SetActive(true);
    }
}
