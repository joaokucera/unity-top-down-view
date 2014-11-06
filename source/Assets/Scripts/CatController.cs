using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour {

	private Animator animator;

	private Transform followTarget;
	private float moveSpeed;
	private float turnSpeed;
	private bool isZombie;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	void Death()
	{
		Destroy (gameObject);
	}

	void OnBecameInvisible()
	{
		if (!isZombie)
		{
			Destroy (gameObject);
		}
	}

	public void JoinConga(Transform followTarget, float moveSpeed, float turnSpeed)
	{
		this.followTarget = followTarget;
		this.moveSpeed = moveSpeed;
		this.turnSpeed = turnSpeed;

		isZombie = true;

		collider2D.enabled = false;
		animator.SetBool ("InConga", true);
	}

	void Update()
	{
		if (isZombie)
		{
			// Direção.
			Vector3 currentPosition = transform.position;
			Vector3 moveDirection = followTarget.position - currentPosition;

			// Rotação.
			float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Slerp(transform.rotation,
			                                      Quaternion.Euler(0,0,targetAngle),
			                                      turnSpeed * Time.deltaTime);

			// Ditância.
			float distanceToTarget = moveDirection.magnitude;
			if (distanceToTarget > 0)
			{
				if (distanceToTarget > moveSpeed)
				{
					distanceToTarget = moveSpeed;
				}

				moveDirection.Normalize();

				Vector3 target = moveDirection * distanceToTarget + currentPosition;

				transform.position = Vector3.Lerp(currentPosition,
				                                  target,
				                                  moveSpeed * Time.deltaTime);
			}
		}
	}
}