using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float speed = 1f;
	private Vector3 newPosition;
	
	void Start () 
	{
		newPosition = transform.position;
	}	

	void Update () 
	{
		newPosition.x += speed * Time.deltaTime;
		transform.position = newPosition;
	}
}
