using UnityEngine;
using System.Collections;

public class ZombieAnimator : MonoBehaviour {

	public Sprite[] sprites;
	public float framesPerSecond;

	private SpriteRenderer spriteRenderer;

	void Start()
	{
		if (sprites.Length == 0)
		{
			Debug.LogError("O array de sprites está vazio!");
		}

		spriteRenderer = renderer as SpriteRenderer;
	}

	void Update()
	{
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % sprites.Length;

		spriteRenderer.sprite = sprites [index];
	}
}