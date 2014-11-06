using UnityEngine;
using System.Collections;

public class CatSpawner : MonoBehaviour {

	public GameObject catPrefab;
	public float spawnTime = 2f;

	private Camera mainCamera;
	private float xMax, yMax;

	void Start () 
	{
		mainCamera = Camera.main;
		xMax = mainCamera.orthographicSize * mainCamera.aspect;
		yMax = mainCamera.orthographicSize;

		InvokeRepeating ("SpawnCat", spawnTime, spawnTime);
	}

	private void SpawnCat()
	{
		//Debug.Log ("Um gato foi criado depois de " + Time.timeSinceLevelLoad + " segundos.");

		Vector3 cameraPosition = mainCamera.transform.position;
		Vector3 catPosition = new Vector3 (cameraPosition.x + Random.Range (-xMax, xMax),
		                                  Random.Range (-yMax, yMax),
		                                  0);

		// Criando um novo gato.
		Instantiate (catPrefab, catPosition, Quaternion.identity);
	}

}
