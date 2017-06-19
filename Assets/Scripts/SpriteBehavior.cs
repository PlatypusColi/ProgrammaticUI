using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpriteBehavior : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	Vector3 initial_pos;
	GameObject dragging_elem;

	public void OnBeginDrag(PointerEventData event_data)
	{
		initial_pos = this.transform.position;
		this.GetComponent<Image> ().color = Color.gray;
		dragging_elem = UIManager.instance.CreateSprite (initial_pos, this.gameObject.name);
	}

	public void OnDrag(PointerEventData event_data)
	{
		if (dragging_elem != null)
		{
			dragging_elem.transform.position = Input.mousePosition;
		}
	}

	public void OnEndDrag(PointerEventData event_data)
	{
		float image_size = UIManager.instance.image_size;

		if ((Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl))
		    && (dragging_elem.transform.position - initial_pos).magnitude > image_size)
			dragging_elem = null;
		else
		{
			this.transform.position = dragging_elem.transform.position;
			Destroy (dragging_elem);
			dragging_elem = null;
		}
		this.GetComponent<Image> ().color = Color.white;
	}
}
