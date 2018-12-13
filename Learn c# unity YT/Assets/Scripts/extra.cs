using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extra : MonoBehaviour {

    /*
    void EnableSelectorAnimator(bool b1, bool b2, bool b3)
    {
        
        childGameObjects["sendKey"].GetComponent<Animator>().enabled = b2;
        childGameObjects["sendEnc"].GetComponent<Animator>().enabled = b3;
        childGameObjects["sendRaw"].GetComponent<Animator>().enabled = b1;
    }
    */
    /*
    void EnableSelectorAnimator(bool b1, bool b2, bool b3)
    {
        Debug.Log("Here 1. b1: " + b1 + " b2: " + b2 + " b3: " + b3);
        childGameObjects["sendKey"].GetComponent<Animator>().enabled = b2;
        childGameObjects["sendEnc"].GetComponent<Animator>().enabled = b3;
        //Debug.Log("Here 2");
        if (childGameObjects["sendRaw"].GetComponent<Animator>().enabled && !b1) // if animation enabled and turn off then disable
        {
            Debug.Log("Here 3");
            IsAnimationActive("sendRaw");
            childGameObjects["sendRaw"].GetComponent<Animator>().enabled = false;
            //Debug.Log("Here 4");
        }
        else // enable
        {
            Debug.Log("Here 5");
            childGameObjects["sendRaw"].GetComponent<Animator>().enabled = true;
        }
    }
    */
    /*
    private bool IsAnimationActive(string objINanim)
    {
        Debug.Log("ActiveSelf: " + childGameObjects[objINanim].GetComponent<Animator>().gameObject.activeSelf.ToString()
                                 + "NormalizedTime: " + childGameObjects[objINanim].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime.ToString());
        if (childGameObjects[objINanim].GetComponent<Animator>().gameObject.activeSelf &&
            //childGameObjects["rawDataUserB"].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(anim) &&
            childGameObjects[objINanim].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            StartCoroutine(Example(childGameObjects[objINanim].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime));
            Debug.Log("Busy");
            return true;
        }
        return false;
    }
    */
    /*
    private IEnumerator Example(float time)
    {
        yield return new WaitForSeconds(time);
    }
    */
    /*
    private bool IsAnimationActive(string objINanim)
    {
        Debug.Log("ActiveSelf: " + childGameObjects[objINanim].GetComponent<Animator>().gameObject.activeSelf.ToString()
                                 + "NormalizedTime: " + childGameObjects[objINanim].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime.ToString());
        if (childGameObjects[objINanim].GetComponent<Animator>().gameObject.activeSelf &&
            //childGameObjects["rawDataUserB"].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(anim) &&
            childGameObjects[objINanim].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            StartCoroutine(Example(childGameObjects[objINanim].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime));
            Debug.Log("Busy");
            return true;
        }
        return false;
    }
    */
    /*
     
    IsAnimationActive("A_RawToB_Anim");

    if (pointerRotation > 59 && pointerRotation < 85)
    {
        //Debug.Log("Animation State = " + childGameObjects["sendRaw"].GetComponent<Animator>().enabled.ToString());

        if (childGameObjects["sendRaw"].GetComponent<Animator>().enabled == false)
        {
            Debug.Log("Duck");
            EnableSelectorAnimator(true, false, false);
            //childGameObjects["sendRaw"].GetComponent<Animator>().Play("A_MenuRawShake");


        }
    }

    if (pointerRotation > 85 && pointerRotation < 110)
    {
        if (!childGameObjects["sendKey"].GetComponent<Animator>().enabled)
            EnableSelectorAnimator(false, true, false);
    }

    if (pointerRotation > 110 && pointerRotation < 121)
    {
        if (!childGameObjects["sendEnc"].GetComponent<Animator>().enabled)
            EnableSelectorAnimator(false, false, true);
    }

    */
}
