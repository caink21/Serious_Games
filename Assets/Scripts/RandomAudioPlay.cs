using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPlay : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        StartCoroutine(PlayAudio());
    }

    IEnumerator PlayAudio()
    {
        int number = Random.Range(5, 20);

        yield return new WaitForSeconds(number);

        audioSource.Play();

        yield return new WaitForSeconds(21);
    }
}
