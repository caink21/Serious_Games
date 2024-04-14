using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{    
    public Animator doorAnim;
    public GameObject objectToEnable;
    public float delayInSeconds = 1.5f;

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetTrigger("open");
            StartCoroutine(EnableObjectAfterDelay());
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

