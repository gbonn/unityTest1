using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	
	public GameObject borderPrefab;
	
	// Use this for initialization
	void Start () {
		Debug.Log ("Hello!");
		for (int numVertBorderElements = 0; numVertBorderElements < 4; numVertBorderElements++) {
			Instantiate (borderPrefab, new Vector3 (-2, numVertBorderElements * 4, 0), Quaternion.identity);
			Instantiate (borderPrefab, new Vector3 (12, numVertBorderElements * 4, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
	}
}
