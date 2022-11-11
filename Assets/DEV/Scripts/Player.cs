using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerType { HIDE, SEEK}
    public PlayerType playerType;
    public int rescued;
    public int found;
    public Animator animator;
    public float animationSpeed;
    public void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        
    }
    private void FixedUpdate()
    {
        animator.speed = animationSpeed;
        
        
    }
    public void AddRescued()
    {
        rescued++;
    }
}
