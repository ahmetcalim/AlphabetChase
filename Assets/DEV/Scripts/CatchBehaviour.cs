using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using static Player;

public class CatchBehaviour : MonoBehaviour
{
    public GameObject cage;
    
    public void Catch()
    {
        if (PlayerHandler.Instance.player.playerType == Player.PlayerType.SEEK)
        {

            CoinManager.Instance.AddCoin();
        }
        if (GetComponent<HiderAI>())
        {
            switch (PlayerHandler.Instance.player.playerType)
            {
                case PlayerType.HIDE:
                    break;
                case PlayerType.SEEK:
                    PlayerHandler.Instance.player.found = FindObjectsOfType<Hider>().Where(t => t.catched).ToArray().Length;
                    if (PlayerHandler.Instance.player.found == FindObjectsOfType<Hider>().Length)
                    {
                        GameManager.Instance.Win();
                    }
                    break;
                default:
                    break;
            }
            HiderAI ai = GetComponent<HiderAI>();
            ai.Stop();
            cage.SetActive(true);
        }
        else
        {
            if (GetComponent<MovementController>())
            {
                cage.SetActive(true);
                GetComponent<MovementController>().move = false;
                GameManager.Instance.Fail();
               
            }
        }
      
    }
}
