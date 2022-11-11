using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public int coin;
    private void Start()
    {
        coin = PlayerPrefs.GetInt("Coin");
        UIManager.Instance.UpdateCoinDisplay();
    }

    public void AddCoin()
    {
        coin += 10;
        PlayerPrefs.SetInt("Coin", coin);

        UIManager.Instance.UpdateCoinDisplay();
    }
}
