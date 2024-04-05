using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject imageCanvas;
    public GameObject imageCanvas2;
    public  Sprite Dinoimage;
    public  Sprite Dinoimage2;
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            ShowImage();   
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
}
