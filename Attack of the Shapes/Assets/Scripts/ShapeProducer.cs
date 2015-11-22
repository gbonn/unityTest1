using UnityEngine;
using System.Collections;

public class ShapeProducer : MonoBehaviour {

	public GameObject fallingCubePrefab;
	public GameObject fallingSpherePrefab;
	public GameObject fallingCapsulePrefab;

	public float spawnIntervalS = 1.0f;

	// Use this for initialization
	void Start () {
		Invoke("SpawnShape", 0.0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SpawnShape() {
		GameObject[] possibleShapes = {fallingCubePrefab, fallingSpherePrefab, fallingCapsulePrefab};
		string[] possibleShapeNames = {"CUBE", "SPHERE", "CAPSULE"};

		float x = Random.Range(1.0f, 9.0f);
		int randShapeIdx = Random.Range (0, possibleShapes.Length);

		GameObject newShape = (GameObject)Instantiate(possibleShapes[randShapeIdx], new Vector3(x, 12, 0), Quaternion.identity);
		newShape.name = possibleShapeNames [randShapeIdx];
		newShape.GetComponent<Renderer> ().material.SetColor("_EmissionColor", GetRandomColor());

		Invoke("SpawnShape", spawnIntervalS);
	}

	public void SetSpawnInterval(float interval) {
		spawnIntervalS = interval;
	}

	private Color GetRandomColor() {
		Color[] possibleColors = new Color[] {Color.blue, Color.green, Color.red, Color.yellow, Color.cyan, Color.magenta, Color.gray, Color.white};
		return possibleColors[Random.Range(0, possibleColors.Length)];
	}

}
