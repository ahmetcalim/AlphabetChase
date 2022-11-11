using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cage"))
        {
            if (PlayerHandler.Instance.player.playerType == Player.PlayerType.HIDE)
            {

                CoinManager.Instance.AddCoin();
                other.GetComponentInParent<RescueBehaviour>().Rescue();
                PlayerHandler.Instance.player.AddRescued();
            }
        }
        if (other.CompareTag("Coin"))
        {
            ParticleManager.Instance.EmitStars(other.transform.position);
            Destroy(other.gameObject);
            CoinManager.Instance.AddCoin();
        }
    }
}
