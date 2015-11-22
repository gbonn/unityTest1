/*
 * This file contains the logic that produces shapes.
 * It is attached to a GameObject under the parent
 * GameLogic object.
 */

using UnityEngine;
using System.Collections;

public class ShapeProducer : MonoBehaviour {

	// These prefabs are attached to the shape prefabs defined in
	// the Unity editor, one for each shape that can drop.
	public GameObject fallingCubePrefab;
	public GameObject fallingSpherePrefab;
	public GameObject fallingCapsulePrefab;

	// This controls how fast shapes are created.
	private float spawnIntervalS = 1.0f;

	// Use this for initialization
	void Start () {
		// Begin the asynchronous shape spawn chain.
		Invoke("SpawnShape", 0.0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	// This function spawns shapes. It is called by the Unity engine via Invoke()
	void SpawnShape() {
		// Get lists of all the colors and shapes we have.
		GameObject[] possibleShapes = {fallingCubePrefab, fallingSpherePrefab, fallingCapsulePrefab};
		string[] possibleShapeNames = {"CUBE", "SPHERE", "CAPSULE"};

		// Choose a horizontal starting place for the shape to fall from. The y and z
		// positions are always fixed.
		// TODO: Determine range programmaticaly.
		float x = Random.Range(1.0f, 9.0f);

		// Choose a shape at random
		int randShapeIdx = Random.Range (0, possibleShapes.Length);

		// Instantiate the random shape at the random x value.
		// TODO: Could give a random twist via the quaternion...
		GameObject newShape = (GameObject)Instantiate(possibleShapes[randShapeIdx], new Vector3(x, 12, 0), Quaternion.identity);
		newShape.name = possibleShapeNames [randShapeIdx];
		// Assign a random color to the shape.
		newShape.GetComponent<Renderer> ().material.SetColor("_EmissionColor", GetRandomColor());

		// Setup the next call to this function.
		Invoke("SpawnShape", spawnIntervalS);
	}

	// This function is called by the UI slider to set the spawn interval.
	public void SetSpawnInterval(float interval) {
		// TODO: I'm not sure how Unity/C# handles asynchronous access to data. I assume
		// writing to the spawnIntervalS float is atomic, but some googling may be in
		// order...
		spawnIntervalS = interval;
	}

	// This function returns a random color from a preset list.
	private Color GetRandomColor() {
		Color[] possibleColors = new Color[] {Color.blue, Color.green, Color.red, Color.yellow, Color.cyan, Color.magenta, Color.gray, Color.white};
		return possibleColors[Random.Range(0, possibleColors.Length)];
	}

}
