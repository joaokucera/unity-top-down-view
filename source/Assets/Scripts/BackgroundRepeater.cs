using UnityEngine;
using System.Collections;

public class BackgroundRepeater : MonoBehaviour {

	private Transform cameraTransform;
	private float spriteWidth;
	
	void Start () 
	{
		// Armazendo o transform da main camera.
		cameraTransform = Camera.main.transform;

		// Armazendo a largura do background.
		SpriteRenderer spriteRenderer = renderer as SpriteRenderer;
		spriteWidth = spriteRenderer.sprite.bounds.size.x;
	}

	void Update () 
	{
		if (transform.position.x + spriteWidth < cameraTransform.position.x) 
		{
			Vector3 newPosition = transform.position;
			newPosition.x += spriteWidth * 2;

			transform.position = newPosition;
		}



	}
}
