using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Clues : MonoBehaviour
{
    public GameObject ClueText;

    void Start()
    {
        ClueText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
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
