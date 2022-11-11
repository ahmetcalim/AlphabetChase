using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashSceneHandler : MonoBehaviour
{
    public float time;
    public float currentTime;
    private bool started;
    public Image loadingImage;
    private void FixedUpdate()
    {
        if (currentTime < time)
        {
            currentTime += Time.deltaTime;
            loadingImage.fillAmount = currentTime / time;
        }
        else
        {
            if (!started)
            {
                started = true;
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
