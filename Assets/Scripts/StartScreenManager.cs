using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject dinosaur;
    private AudioSource audioSource;
    public AudioClip[] roars;
    private AudioClip roarClip;
    private Animator animator;

    private void Start()
    {
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();
        animator = dinosaur.GetComponent<Animator>();
    }

    public void StartGame()
    {
        animator.SetTrigger("Roar");
        roarClip = roars[UnityEngine.Random.Range(0, roars.Length)];
        audioSource.clip = roarClip;
        audioSource.Play();
        Invoke("LoadScene", 6f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
