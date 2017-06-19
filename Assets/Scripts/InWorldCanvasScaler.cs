using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWorldCanvasScaler : MonoBehaviour
{
	public float pixels_per_unit = 25f;

	public void OnValidate()
	{
		transform.localScale = new Vector3 (1 / pixels_per_unit,
			1 / pixels_per_unit, 1);
	}
}
