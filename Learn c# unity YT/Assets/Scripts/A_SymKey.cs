using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_SymKey : MonoBehaviour {

    public GameObject B_chestObject;
    private GameObject userMenu;
    private GameObject keyMenu;
    private GameObject ActionMenu;
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>();

    // Use this for initialization
    void Start()
    {
        keyMenu = this.transform.parent.parent.GetChild(2).gameObject;
        userMenu = this.transform.parent.parent.GetChild(3).gameObject;
        ActionMenu = this.transform.parent.parent.GetChild(4).gameObject;
        Debug.Log("Message from A_RawData: " + userMenu.name + " " + keyMenu.name + " " + ActionMenu.name);

        childGameObjects.Add("sendKeyDis", userMenu.transform.GetChild(2).gameObject);    // send raw data to user B
        childGameObjects.Add("sendKey", userMenu.transform.GetChild(3).gameObject);    // send raw data to user B
        childGameObjects.Add("EncChestStill", ActionMenu.transform.GetChild(7).gameObject);    // send raw data to hacker


        this.gameObject.GetComponent<Animator>().SetBool("A_Unlock_Chest", false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void EndofMoveAnimation()
    {
        childGameObjects["EncChestStill"].SetActive(true);
    }

    void EndofKeyUnlockAnimation()
    {
        childGameObjects["EncChestStill"].SetActive(false);
    }

    void EndofDecryptAnimation()
    {
        childGameObjects["sendKeyDis"].SetActive(true);
        childGameObjects["sendKey"].SetActive(false);
        userMenu.SetActive(false);
        this.gameObject.SetActive(false);
        keyMenu.SetActive(true);
    }
}
