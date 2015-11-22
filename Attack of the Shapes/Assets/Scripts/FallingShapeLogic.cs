using UnityEngine;
using System.Collections;

public class FallingShapeLogic : MonoBehaviour {

	private static GameObject selectedShape = null;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Behaviour haloBehaviour = gameObject.GetComponent ("Halo") as Behaviour;

		if (selectedShape == null) {
			haloBehaviour.enabled = true;
			selectedShape = gameObject;
		} else {
			if (selectedShape == gameObject) {
				haloBehaviour.enabled = false;
				selectedShape = null;
			} else {
				if ((selectedShape.GetComponent<Renderer> ().material.GetColor("_EmissionColor") == gameObject.GetComponent<Renderer> ().material.GetColor("_EmissionColor")) &&
				    (selectedShape.name == gameObject.name)){
					Destroy(selectedShape);
					selectedShape = null;
					Destroy(gameObject);
				}

			}
		}
	}
}
