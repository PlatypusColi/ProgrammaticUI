using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
	public GameObject game_obj_w_events;
	// Use this for initialization
	void Start ()
	{
		if (game_obj_w_events == null) {
			Debug.Log ("Must set game_obj_w_events");
			this.enabled = false;
		} else
			game_obj_w_events.GetComponent<Events> ().MouseLeftClick += HandleEvent;
	}

	public void HandleEvent(GameObject sender, string event_message)
	{
		Debug.Log (sender.name + " sent us an event: " + event_message);
	}
}
