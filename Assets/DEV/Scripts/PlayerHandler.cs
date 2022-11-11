using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHandler : MonoBehaviour
{
    public static PlayerHandler Instance { get; private set; }
    public Player player;
    public List<Hider> hiders;
    public Seeker seeker;
    private void Awake()
    {
        Instance = this;
    }
    public void SelectRandomHider()
    {
        player = hiders[Random.Range(0, hiders.Count)];
        player.gameObject.AddComponent<PlayerTrigger>();
        foreach (var item in hiders)
        {
            if (item != player)
            {
                
                item.gameObject.AddComponent<HiderAI>().move = true;
            }
        }
        seeker.gameObject.AddComponent<SeekerAI>().move = false;
        PreparePlayerToControl();
    }
    public void SelectSeeker()
    {
        player = seeker;
        player.gameObject.AddComponent<PlayerTrigger>();
        foreach (var item in hiders)
        {
            item.Hide();
            item.gameObject.AddComponent<HiderAI>().move = true;
        }
        PreparePlayerToControl();
    }
    public void PreparePlayerToControl()
    {
        CameraFollow.Instance.StartFollowing();
        Destroy(player.gameObject.GetComponent<NavMeshAgent>());
        player.gameObject.AddComponent<MovementController>();
        UIManager.Instance.EnableCountDown();
    }
}
