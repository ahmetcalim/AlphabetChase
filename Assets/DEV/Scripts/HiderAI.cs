using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HiderAI : AI
{
    public override void Start()
    {
        gameObject.AddComponent<RescueBehaviour>();
        base.Start();
    }
}
