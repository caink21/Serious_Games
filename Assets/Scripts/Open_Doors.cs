using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Doors : MonoBehaviour
{
    public Animator doorAnim;
    public bool isOpened = false;
    public GameObject objectToEnable = null;
    public float delayInSeconds = 1.5f;

    [SerializeField] AudioClip dinoClip;
    [SerializeField] AudioClip doorClip;

    private bool triggered = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            if (other.CompareTag("Player") && !isOpened)
            {
                AudioSource.PlayClipAtPoint(doorClip, transform.position);
                //doorAnim.SetTrigger("open");
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
        if (objectToEnable == null)
        {
            yield return null;
        }
        else
        {
            AudioSource.PlayClipAtPoint(dinoClip, transform.position);            
            // Wait for specified delay
            yield return new WaitForSeconds(delayInSeconds);
            // Enable the object
            objectToEnable.SetActive(true);
        }
    }
}
