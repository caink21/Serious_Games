using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject GameOverUI;

    public TextMeshProUGUI TextMeshRight;
    public TextMeshProUGUI TextMeshWrong;

    public string GameOverInfoRight;
    public string GameOverInfoWrong;

    public GameObject imageCanvas;
    public GameObject imageCanvas2;
    public  Sprite Dinoimage;
    public  Sprite Dinoimage2;

    void Start()
    {
        TextMeshRight.text = GameOverInfoRight;
        TextMeshWrong.text = GameOverInfoWrong;
    }

    public void ChangeText(string Information_right, string information_wrong )
    {
        TextMeshRight.text = Information_right;
        TextMeshWrong.text = information_wrong;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                ShowImage();
                ChangeText(GameOverInfoRight, GameOverInfoWrong);
                GameOverUI.SetActive(true);
                Time.timeScale = 0f;
                GameIsOver = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
        }
    }

    private void ShowImage()
    {
        if(imageCanvas != null)
        {
            Image imageComponent= imageCanvas.GetComponent<Image>();
            if(imageComponent != null) 
            {
                imageComponent.sprite = Dinoimage;
                imageCanvas.SetActive(true);
            }
            else
            {
                Debug.LogError("No Image");
            }
        }

        if (imageCanvas2 != null)
        {
            Image imageComponent = imageCanvas2.GetComponent<Image>();
            if (imageComponent != null)
            {
                imageComponent.sprite = Dinoimage2;
                imageCanvas2.SetActive(true);
            }
            else
            {
                Debug.LogError("No Image");
            }
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
