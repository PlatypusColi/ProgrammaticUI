using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitEffectConstructor : MonoBehaviour
{
	public Sprite sprite_to_use;
	public bool has_rdm_mov;
	public float decay_time;

	// Use this for initialization
	void Start ()
	{
		Decay decay_script = this.GetComponent<Decay> ();
		if (decay_script != null) 
		{
			decay_script.decay_sec = decay_time;
		}

		if (has_rdm_mov)
		{
			this.gameObject.AddComponent<MoveInRdmDir> ();
		}

		Image image_script = this.GetComponent<Image> ();
		image_script.sprite = sprite_to_use;
	}
}
