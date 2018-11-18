using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{
    public FiducialController tangible; // fiducial for this user
    private Animator MenuAnimator; //-menu Animator

    public GameObject userB;

    private List<GameObject> children;

    // Use this for initialization
    void Start()
    {
        int index = 0;
        //-On Game Start
        //-init vars
        MenuAnimator = this.GetComponent<Animator>();

        foreach (Transform tf in this.transform.parent)
        {
            children.Add(this.transform.parent.GetChild(index).gameObject);
            index++;
        }
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

    void TransmitRawData()
    {
        Debug.Log("Transmit Raw Data");

        // game object child (user and hacker) set active true
        this.transform.parent.GetChild(1).gameObject.SetActive(true);
        this.transform.parent.GetChild(2).gameObject.SetActive(true);
        
        // blink chest
    }

    void TransmitEncryptedData()
    {
        Debug.Log("Transmit Encrypted Data");

        // game object child (user and hacker) set active true
        this.transform.parent.GetChild(3).gameObject.SetActive(true);
        this.transform.parent.GetChild(4).gameObject.SetActive(true);
    }

    void TransmitKey()
    {
        Debug.Log("Transmit Key");

        // game object child (user and hacker) set active true
        this.transform.parent.GetChild(5).gameObject.SetActive(true);
        this.transform.parent.GetChild(6).gameObject.SetActive(true);
    }

    /* not used*/
    void Encrypt()
    {
        Debug.Log("Encrypt");
    }

    void Decrypt()
    {
        Debug.Log("Decrypt");
    }
    /* not used*/
    

}
