using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickPow : MonoBehaviour
{
	public List<GameObject> hit_effects = new List<GameObject>();

	void Start ()
	{
		if (hit_effects.Count < 1)
		{
			Debug.Log ("You must add at least one hit effect");
			this.enabled = false;
		}
	}
	
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Vector3 click_pos = Input.mousePosition;
			GameObject pow_obj = Instantiate(hit_effects[Random.Range(0, hit_effects.Count)], click_pos, Quaternion.identity) as GameObject;
			pow_obj.transform.SetParent (this.transform);
		}
	}
}
