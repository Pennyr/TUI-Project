using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start() {
        while (true)
        {
            yield return new WaitForSeconds(2);

            byte[] state = { 0x53 };

            GameObject.FindGameObjectWithTag("Send").GetComponent<Arduino>().sendMessage(state);
            Debug.Log("Message Sent");
            yield return new WaitUntil(() => GameObject.Find("Send").GetComponent<Arduino>().getReceived());
            Debug.Log("Message Recieved");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}
