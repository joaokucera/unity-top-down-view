using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
	
	public float moveSpeed;
	public float turnSpeed;

	private Vector2 moveDirection;

	[SerializeField] private PolygonCollider2D[] colliders;
	private int currentColliderIndex = 0;

	void Start()
	{
		moveDirection = Vector2.right;
	}

	void Update () {
	
		Vector2 currentPosition = transform.position;

		if (Input.GetButtonDown("Fire1"))
		{
			Vector2 moveTowards = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			moveDirection = moveTowards - currentPosition;
			moveDirection.Normalize();
		}

		Vector2 target = moveDirection + currentPosition;
		transform.position = Vector3.Lerp (currentPosition, target, moveSpeed * Time.deltaTime);

		float targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Slerp (transform.rotation, 
		                                       Quaternion.Euler (0, 0, targetAngle), 
		                                       turnSpeed * Time.deltaTime);
	}

	public void SetColliderForSprite(int spriteNumber)
	{
		colliders [currentColliderIndex].enabled = false;

		currentColliderIndex = spriteNumber;
		colliders [currentColliderIndex].enabled = true;
	}
}
