using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{
    private float pointerRotation;
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>();
    /*
    public FiducialController tangible; // fiducial for this user
    private Animator MenuAnimator; //-menu Animator

    public GameObject userB;

    private List<GameObject> children;
    */
    // Use this for initialization
    void Start()
    {
        /*
        int index = 0;
        //-On Game Start
        //-init vars
        MenuAnimator = this.GetComponent<Animator>();

        foreach (Transform tf in this.transform.parent)
        {
            children.Add(this.transform.parent.GetChild(index).gameObject);
            index++;
        }
        */
        childGameObjects.Add("sendRaw", this.transform.GetChild(0).gameObject);    // send encrypted data to user B
        childGameObjects.Add("sendKey", this.transform.GetChild(1).gameObject);    // send raw data to user B
        childGameObjects.Add("sendEnc", this.transform.GetChild(2).gameObject);      // send raw data to hacker
        childGameObjects.Add("rawDataUserB", this.transform.GetChild(3).gameObject);    // send encrypted data to user B
        childGameObjects.Add("rawDataHkr", this.transform.GetChild(4).gameObject);      // send encrypted data to hacker
        childGameObjects.Add("encDataUserB", this.transform.GetChild(5).gameObject);    // send encrypted data to user B
        childGameObjects.Add("encDataHkr", this.transform.GetChild(6).gameObject);      // send encrypted data to hacker
        childGameObjects.Add("keyUserB", this.transform.GetChild(7).gameObject);        // send key to user B
        childGameObjects.Add("keyHkr", this.transform.GetChild(8).gameObject);          // send key to hacker
        childGameObjects.Add("encData", this.transform.GetChild(9).gameObject);         // data encryption animation
        childGameObjects.Add("decryData", this.transform.GetChild(10).gameObject);       // data decryption animation
    }
    
    // Update is called once per frame
    void Update()
    {
        //MenuAnimator.SetFloat("rotation", tangible.AngleDegrees);
        pointerRotation = this.transform.parent.GetChild(1).transform.localRotation.eulerAngles.z;
        //Delete// Debug.Log(pointerRotation);
        if (pointerRotation > 60 && pointerRotation < 85)
        {
            childGameObjects["sendRaw"].GetComponent<Animator>().enabled = true;
            childGameObjects["sendKey"].GetComponent<Animator>().enabled = false;
            childGameObjects["sendEnc"].GetComponent<Animator>().enabled = false;
        }
        else if (pointerRotation > 84 && pointerRotation < 110)
        {
            childGameObjects["sendRaw"].GetComponent<Animator>().enabled = false;
            childGameObjects["sendKey"].GetComponent<Animator>().enabled = true;
            childGameObjects["sendEnc"].GetComponent<Animator>().enabled = false;
        }
        else if (pointerRotation > 109 && pointerRotation < 121)
        {
            childGameObjects["sendRaw"].GetComponent<Animator>().enabled = false;
            childGameObjects["sendKey"].GetComponent<Animator>().enabled = false;
            childGameObjects["sendEnc"].GetComponent<Animator>().enabled = true;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter");

        //MenuAnimator.SetBool("select", true);
    }

   
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit");

      //  MenuAnimator.SetBool("select", false);
    }
    /*
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

    */
    

}
