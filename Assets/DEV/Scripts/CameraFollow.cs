using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public static CameraFollow Instance { get; private set; }
	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;
	public bool follow;
	private Animator animator;
	public bool setDefaultFOV;
    private void Awake()
    {
		Instance = this;
    }
    private void Start()
    {
        
    }
	public void DisableAnimator()
	{
		animator = GetComponent<Animator>();
		animator.enabled = false;
	}
    void FixedUpdate()
	{
		if (!follow) return;
		target = PlayerHandler.Instance.player.transform;
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
        if (PlayerHandler.Instance.player.playerType == Player.PlayerType.SEEK)
        {
            if (setDefaultFOV)
            {
				Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60f, Time.deltaTime * 12f);
			}
        }
       

		//transform.LookAt(target);
	}
	public void StartFollowing()
	{
		follow = true;
	}
}
