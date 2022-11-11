using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance { get; private set; }
    [SerializeField]
    private GameObject starParticle;
    [SerializeField]
    private GameObject smokeParticle;
    [SerializeField]
    private GameObject coinParticle;
    private void Awake()
    {
        Instance = this;
    }
    public void EmitStars(Vector3 position)
    {
        Instantiate(starParticle, position, Quaternion.identity);
    }
    public void EmitSmoke(Vector3 position)
    {
        Instantiate(smokeParticle, position + new Vector3(0f, .5f, 0f), Quaternion.identity);
    }
    public void EmitCoinParticle(Vector3 position)
    {

        Instantiate(coinParticle, position + new Vector3(0f, .5f, 0f), Quaternion.identity);
    }
}
