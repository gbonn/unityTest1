using UnityEngine;
using System.Collections;

public class SliderTextBoxScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateSliderTextBox (float sliderVal) {
		GetComponent<UnityEngine.UI.Text>().text = sliderVal.ToString();
	}
}
