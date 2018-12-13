using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_RawData : MonoBehaviour
{
    public GameObject B_chestObject;
    private GameObject userMenu;
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>();
    private bool animEnd;

	// Use this for initialization
	void Start ()
	{
	    userMenu = this.transform.parent.parent.GetChild(3).gameObject;
        Debug.Log("Message from A_RawData: " + userMenu.name);
        
	    childGameObjects.Add("sendRawDis", userMenu.transform.GetChild(0).gameObject);    // send encrypted data to user B
	    childGameObjects.Add("sendRaw", userMenu.transform.GetChild(1).gameObject);    // send encrypted data to user B
        childGameObjects.Add("sendKeyDis", userMenu.transform.GetChild(2).gameObject);    // send raw data to user B
	    childGameObjects.Add("sendKey", userMenu.transform.GetChild(3).gameObject);    // send raw data to user B
        childGameObjects.Add("sendEncDis", userMenu.transform.GetChild(4).gameObject);    // send raw data to hacker
	    childGameObjects.Add("sendEnc", userMenu.transform.GetChild(5).gameObject);    // send raw data to hacker


	    this.gameObject.GetComponent<Animator>().SetBool("reset", false);
	    this.gameObject.GetComponent<Animator>().SetBool("reveal", false);

    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (B_chestObject.gameObject.GetComponent<chestBScript>().initialOnce)
	    {
	        this.gameObject.GetComponent<Animator>().SetBool("reveal", true);
        }
    }

    void EndofAnimation()
    {
        Debug.Log("Message from A_RawData: EndofAnimation");
        this.gameObject.GetComponent<Animator>().SetBool("reset", true);
        B_chestObject.SetActive(true);

        childGameObjects["sendRawDis"].SetActive(true);
        childGameObjects["sendRaw"].SetActive(false);

        childGameObjects["sendKeyDis"].SetActive(false);
        childGameObjects["sendKey"].SetActive(true);

        childGameObjects["sendEncDis"].SetActive(false);
        childGameObjects["sendEnc"].SetActive(true);
        
    }
}
