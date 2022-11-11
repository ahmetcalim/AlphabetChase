using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject InGamePanel;
    [SerializeField]
    private GameObject SelectionPanel;
    [SerializeField]
    private GameObject HiderSuccessPanel;
    [SerializeField]
    private GameObject SeekerSuccessPanel;
    [SerializeField]
    private GameObject HiderFailPanel;
    [SerializeField]
    private GameObject SeekerFailPanel;
    [SerializeField]
    private GameObject CountDown;
    [SerializeField]
    private TMPro.TextMeshProUGUI gameTimeLeft;
    [SerializeField]
    private GameObject gameTimeLeftObj;

    [SerializeField]
    private TMPro.TextMeshProUGUI rescued, found;
    [SerializeField]
    private TMPro.TextMeshProUGUI coinDisplay;
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void DisplaySuccessPanel()
    {
        if (gameTimeLeftObj.activeSelf)
        {
            gameTimeLeftObj.SetActive(false);
        }
        switch (PlayerHandler.Instance.player.playerType)
        {
            case Player.PlayerType.HIDE:

                HiderSuccessPanel.SetActive(true);
                rescued.text = PlayerHandler.Instance.player.rescued.ToString();

                break;
            case Player.PlayerType.SEEK:
                SeekerSuccessPanel.SetActive(true);
                found.text = PlayerHandler.Instance.player.found.ToString();
                break;
            default:
                break;
        }
    }
    public void DisplayFailPanel()
    {
        if (gameTimeLeftObj.activeSelf)
        {
            gameTimeLeftObj.SetActive(false);
        }
        switch (PlayerHandler.Instance.player.playerType)
        {
            case Player.PlayerType.HIDE:
                HiderFailPanel.SetActive(true);
                break;
            case Player.PlayerType.SEEK:
                SeekerFailPanel.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void EnableSelectionPanel( bool enabled)
    {
        SelectionPanel.SetActive(enabled);
    }
    public void EnableCountDown()
    {

        CountDown.SetActive(true);
    }
    public void UpdateGameTimer(float time)
    {
        if (!gameTimeLeftObj.activeSelf)
        {
            gameTimeLeftObj.SetActive(true);
        }
        gameTimeLeft.text = time.ToString("F0") + "S";
    }
    public void UpdateCoinDisplay()
    {
        coinDisplay.text = CoinManager.Instance.coin.ToString();
    }
   
}
