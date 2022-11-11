using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueBehaviour : MonoBehaviour
{
    private Hider hider;
    private CatchBehaviour catchBehaviour;
    private void Start()
    {
        hider = GetComponent<Hider>();
        catchBehaviour = GetComponent<CatchBehaviour>();
    }
    public void Rescue()
    {
        ParticleManager.Instance.EmitCoinParticle(transform.position);
        catchBehaviour.cage.SetActive(false);
        hider.catched = false;
        hider.Display();
        GetComponent<HiderAI>().StartMoving();

    }
}
