using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OurButtonHandler : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Button button = this.GetComponent<Button> ();
		button.onClick.RemoveAllListeners ();
		button.onClick.AddListener (()=> HandleButton(button));
	}

	void HandleButton(Button button)
	{
		button.GetComponent<Image> ().color = Color.red;
	}
}
