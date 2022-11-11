using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : Player
{
    public bool catched;
    private CatchBehaviour catchBehaviour;
   
    public void Start()
    {
        
        catchBehaviour = GetComponent<CatchBehaviour>();
    }
    public void Catch()
    {
        if (!catched)
        {
            ParticleManager.Instance.EmitSmoke(transform.position);
            catched = true;
            catchBehaviour.Catch();
            Display();
        }
    }
    public void Hide()
    {
        foreach (var item in GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            item.enabled = false;
        }
    }
    public void Display()
    {
        foreach (var item in GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            item.enabled = true;
        }
    }
}
