using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Screen : MonoBehaviour
{
    public static bool GameIsComplete = false;
    public GameObject Winner_Screen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Winner_Screen.SetActive(true);
            Time.timeScale = 0f;
            GameIsComplete = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GamePlayScene");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
