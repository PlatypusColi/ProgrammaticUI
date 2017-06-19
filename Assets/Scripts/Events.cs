using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CustomEvent(GameObject sender, string event_message);

public class Events : MonoBehaviour
{
	public event CustomEvent MouseOver;
	public event CustomEvent MouseLeftClick;

	// Update is called once per frame
	void Update ()
	{
		RectTransform my_rect = this.GetComponent<RectTransform> ();
		Rect on_screen_rect = my_rect.rect;
		on_screen_rect.Set (on_screen_rect.x + this.transform.position.x, 
			on_screen_rect.y + this.transform.position.y, on_screen_rect.width, on_screen_rect.height);
		if (on_screen_rect.Contains (Input.mousePosition))
		{
			if (MouseOver != null)
				MouseOver (this.gameObject, "The mouse pointer's over me");
			if (Input.GetMouseButtonDown (0))
			{
				if (MouseLeftClick != null)
					MouseLeftClick (this.gameObject, "I've been clicked on");
			}
		}
	}
}
