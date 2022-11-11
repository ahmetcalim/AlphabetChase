using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isGameRunning;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        FB.Init("698520705081812");
        StartCoroutine(StartBeginningOfTheGame());
    }

    public bool IsGameRunning()
    {
        return isGameRunning;
    }
    IEnumerator StartBeginningOfTheGame()
    {
        isGameRunning = true;
        yield return new WaitForSeconds(2f);
        CameraFollow.Instance.DisableAnimator();
        UIManager.Instance.EnableSelectionPanel(true);
    }
    public void StartTheGame()
    {
        PlayerHandler.Instance.seeker.StartSeeking();
        TimeManager.Instance.StartTimer();
       
       
    }
    public void Win()
    {
        if (IsGameRunning())
        {
            isGameRunning = false;
        }
        UIManager.Instance.DisplaySuccessPanel();
    }
    public void Fail()
    {
        if (IsGameRunning())
        {
            isGameRunning = false;
        }
        UIManager.Instance.DisplayFailPanel();
    }
}
