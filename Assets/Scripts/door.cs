using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{    
    public Animator doorAnim;
    public bool isOpened = false;
    public GameObject objectToEnable;
    public float delayInSeconds = 1.5f;

    private bool triggered = false;

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        doorAnim.ResetTrigger("close");
    //        doorAnim.SetTrigger("open");
    //        StartCoroutine(EnableObjectAfterDelay());
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpened)
        {
            // Play the door opening animation
            doorAnim.SetBool("IsOpen", true);
            isOpened = true;
            StartCoroutine(EnableObjectAfterDelay());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpened)
        {
            // Play the door closing animation
            doorAnim.SetBool("IsOpen", false);
            isOpened = false;
        }
    }

    IEnumerator EnableObjectAfterDelay()
    {
        // Wait for specified delay
        yield return new WaitForSeconds(delayInSeconds);
        // Enable the object
        objectToEnable.SetActive(true);
    }
}

