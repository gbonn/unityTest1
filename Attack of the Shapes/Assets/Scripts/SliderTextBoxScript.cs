/* This file controls the text box associated with a slider
 * control.
 */

using UnityEngine;
using System.Collections;

public class SliderTextBoxScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// This function is called when the slider changes and maps the
	// slider value to the text box.
	public void UpdateSliderTextBox (float sliderVal) {
		GetComponent<UnityEngine.UI.Text>().text = sliderVal.ToString();
	}
}
