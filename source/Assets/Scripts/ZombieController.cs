using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieController : MonoBehaviour {
	
	public float moveSpeed;
	public float turnSpeed;

	private Vector2 moveDirection;
	private List<Transform> congaLine = new List<Transform>();

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

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Cat"))
		{
			Transform target = congaLine.Count == 0 ? transform : congaLine[congaLine.Count - 1];

			collider.GetComponent<CatController>().JoinConga(target, moveSpeed, turnSpeed);

			congaLine.Add(collider.transform);

			Debug.Log("Capturou " + congaLine.Count + " gatos.");
		}
		else if (collider.CompareTag("Grandma"))
		{
			Debug.Log("Colidiu contra a vovó.");
		}
	}




}
