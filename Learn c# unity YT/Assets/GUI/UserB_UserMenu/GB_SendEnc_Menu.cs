using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//UserA:UserMenu-send-encrypted
public class GB_SendEnc_Menu : MonoBehaviour {

    private GameObject UserMenu;

    // Use this for initialization
    void Start()
    {
        UserMenu = this.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
            UserMenu.transform.GetChild(7).gameObject.SetActive(true); //show key to lock open chest
            UserMenu.transform.GetChild(6).gameObject.SetActive(true); //show chest to lock
    }

    //animate send key menu icon on hover
    void OnMouseOver()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Mouse", true);
    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Mouse", false);
    }
}
