using System.Collections;
using System.Collections.Generic;
using IndieMarc.EnemyVision;
using UnityEngine;

public class Seeker : Player
{
    private SeekerAI seekerAI;
    public GameObject closedEyes;
    private void Start()
    {
        seekerAI = GetComponent<SeekerAI>();
        
    }
    public void StartSeeking()
    {
        seekerAI = GetComponent<SeekerAI>();
        foreach (var item in GetComponents<EnemyVision>())
        {
            item.enabled = true;
        }

        closedEyes.SetActive(false);
        switch (PlayerHandler.Instance.player.playerType)
        {
            case Player.PlayerType.HIDE:

                seekerAI.move = true;
                break;
            case Player.PlayerType.SEEK:
                GetComponent<MovementController>().move = true;
                break;
            default:
                break;
        }
    }
}
