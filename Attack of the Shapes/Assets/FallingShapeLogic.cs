using UnityEngine;
using System.Collections;

public class FallingShapeLogic : MonoBehaviour {

	private static 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Behaviour haloBehaviour = gameObject.GetComponent ("Halo") as Behaviour;
		haloBehaviour.enabled = !haloBehaviour.enabled;
	}
}
