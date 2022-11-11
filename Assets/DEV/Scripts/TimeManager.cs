using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    private float timeLeft = 30f;
    public bool timeOn;
    private void Awake()
    {
        Instance = this;
    }
    public void StartTimer()
    {
        timeOn = true;
    }
    private void FixedUpdate()
    {
        if (timeOn && GameManager.Instance.IsGameRunning())
        {
            if (timeLeft > 0)
            {

                timeLeft -= Time.deltaTime;

                UIManager.Instance.UpdateGameTimer(timeLeft);
            }
            else
            {
                switch (PlayerHandler.Instance.player.playerType)
                {
                    case Player.PlayerType.HIDE:
                        GameManager.Instance.Win();
                        break;
                    case Player.PlayerType.SEEK:
                        GameManager.Instance.Fail();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
