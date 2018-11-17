using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{
    public FiducialController tangible;
    public GameObject userB;
    private Animator MenuAnimator; //-menu Animator



    // Use this for initialization
    void Start()
    {

        MenuAnimator = this.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        MenuAnimator.SetFloat("rotation", tangible.AngleDegrees);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Trigger Enter");
        MenuAnimator.SetBool("select", true);

    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit");
        MenuAnimator.SetBool("select", false);
    }

    void TransmitKey()
    {
        Debug.Log("Transmit Key");
    }

    void TransmitRawData()
    {
        Debug.Log("Transmit Raw Data");
    }

    void TransmitEncryptedData()
    {
        Debug.Log("Transmit Encrypted Data");
    }

    void Encrypt()
    {
        Debug.Log("Encrypt");
    }

    void Decrypt()
    {
        Debug.Log("Decrypt");
    }

    //TODO
    /*
     * USER BLINK UNTIL FIDUCIAL
     * STOP PARTICLE UNTIL FIDUCIAL
     * RAW DATA TO USER ON MENU SELECT. FIX TO USER AND HACKER. 
     * RAW DATA TO HACKER ON MENU SELECT. FIX TO USER AND HACKER.
     * ENCCRYPTED SEND ON ARDUINO
     * KEYUSER ON MENU
     * KEYHACKER ON MENU
     * REMOVE TRANSMIT ENCRYPTED FROM ANIMATION 
     */

}
