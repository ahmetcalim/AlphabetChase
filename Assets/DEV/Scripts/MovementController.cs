using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1.5f, turnSpeed = 5f;
    [SerializeField] DynamicJoystick dynamicJoystick;
    CharacterController characterController;
    Player player;
    public bool move;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        characterController = GetComponent<CharacterController>();
        characterController.enabled = true;
        dynamicJoystick = FindObjectOfType<DynamicJoystick>();
        switch (PlayerHandler.Instance.player.playerType)
        {
            case Player.PlayerType.HIDE:
                move = true;
                break;
            case Player.PlayerType.SEEK:
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dynamicJoystick != null)
            Move();
    }

    void Move()
    {
        if (!move) return;
        if (!GameManager.Instance.IsGameRunning()) return;
        float horizontal = dynamicJoystick.Horizontal;
        float vertical = dynamicJoystick.Vertical;
        Vector3 addedPos = new Vector3(horizontal * moveSpeed * Time.deltaTime, 0, vertical * moveSpeed * Time.deltaTime);
        //rb.velocity = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        //transform.forward = Vector3.Lerp(transform.forward, new Vector3(horizontal, transform.forward.y, vertical), Time.deltaTime * 12f);
        characterController.Move(new Vector3(horizontal, -9.81f, vertical) * Time.deltaTime * moveSpeed);
        player.animationSpeed = characterController.velocity.magnitude;

    }
}
