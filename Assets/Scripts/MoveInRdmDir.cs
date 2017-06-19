using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInRdmDir : MonoBehaviour 
{
	Vector2 dir;
	float max_range = 5;

	// Use this for initialization
	void Start ()
	{
		dir = new Vector2 (Random.Range (-max_range, max_range), Random.Range (-max_range, max_range));
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Translate (dir.x, dir.y, 0); 
	}
}
