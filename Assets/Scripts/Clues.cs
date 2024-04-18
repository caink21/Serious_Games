using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Clues : MonoBehaviour
{
    public GameObject ClueText;
    public AudioClip ClueClip;

    void Start()
    {
        ClueText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(ClueClip, transform.position);
            ClueText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ClueText.SetActive(false);  
        }
    }
}
