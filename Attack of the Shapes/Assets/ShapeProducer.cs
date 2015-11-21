using UnityEngine;
using System.Collections;

public class ShapeProducer : MonoBehaviour {

	public GameObject fallingCubePrefab;
	public GameObject fallingSpherePrefab;
	public GameObject fallingCapsulePrefab;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnShape", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SpawnShape() {
		GameObject[] possibleShapes = new GameObject[] {fallingCubePrefab, fallingSpherePrefab, fallingCapsulePrefab};

		float x = Random.Range(-2.0f, 8.0f);
		GameObject newShape = (GameObject)Instantiate(possibleShapes[Random.Range(0, possibleShapes.Length)], new Vector3(x, 12, 0), Quaternion.identity);
		newShape.GetComponent<Renderer> ().material.SetColor("_EmissionColor", GetRandomColor());
	}

	private Color GetRandomColor() {
		Color[] possibleColors = new Color[] {Color.blue, Color.green, Color.red, Color.yellow, Color.cyan, Color.magenta, Color.gray, Color.white};
		return possibleColors[Random.Range(0, possibleColors.Length)];
	}

}
