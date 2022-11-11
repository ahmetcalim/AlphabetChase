using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToHideBehaviour : MonoBehaviour
{
    private TMPro.TextMeshProUGUI txt;
    private float timeLeft = 6f;
    private string prefix;
    
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TMPro.TextMeshProUGUI>();
        switch (PlayerHandler.Instance.player.playerType)
        {
            case Player.PlayerType.HIDE:
                prefix = "Time To Hide ";
                break;
            case Player.PlayerType.SEEK:
                prefix = "Starting In ";
                break;
            default:
                break;
        }

        PlayerHandler.Instance.seeker.closedEyes.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (PlayerHandler.Instance.player.playerType == Player.PlayerType.SEEK)
            {
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 30f, Time.deltaTime * 12f);
            }
            if (timeLeft > 0f && timeLeft <= 2f)
            {
                txt.text = prefix + 1;

            }
            if (timeLeft > 2f && timeLeft < 4f)
            {
                txt.text = prefix + 2;

            }
            if (timeLeft > 4f && timeLeft <= 6f)
            {
                txt.text = prefix + 3;

            }
        }
        else
        {
            //StartTheGame
            if (txt.enabled)
            {
                CameraFollow.Instance.setDefaultFOV = true;
                txt.enabled = false;
                GameManager.Instance.StartTheGame();
            }
        }
    }
}
