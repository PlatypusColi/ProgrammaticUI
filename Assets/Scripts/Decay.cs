using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decay : MonoBehaviour
{
	public float decay_sec = 1.0f;
	float elapsed_sec = 0f;
	Image ui_image;

	void Start ()
	{
		ui_image = GetComponent<Image> ();
		Destroy (this.gameObject, decay_sec);
	}
	
	void Update ()
	{
		ui_image.color = new Color (ui_image.color.r, ui_image.color.g, ui_image.color.b, (decay_sec - elapsed_sec) / decay_sec);

		float scale = 1 + (elapsed_sec * 2);
		ui_image.transform.localScale = new Vector3 (scale, scale, scale);
		elapsed_sec += Time.deltaTime;
	}
}
