using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// CODE ici commenté car sources d'erreurs sur Unity apres avoir changé de scene.

//public class EventTriggerMod : MonoBehaviour
//{
//	public delegate void EventDelegate(BaseEventData event_data);
//
//	public void EventMethod(BaseEventData base_event)
//	{
//		Debug.Log (((PointerEventData)base_event).pointerEnter.name + " trigger an event");
//	}
//	// Use this for initialization
//	void Start ()
//	{
//		EventTrigger event_trigger = this.GetComponent<EventTrigger> ();
//		EventTrigger.Entry entry = new EventTrigger.Entry ();
//		entry.eventID = EventTriggerType.PointerEnter;
//		entry.callback = new EventTrigger.TriggerEvent ();
//		UnityAction<BaseEventData> callback = new UnityAction<BaseEventData> (EventMethod);
//		entry.callback.AddListener (callback);
//		event_trigger.triggers.Add (entry);
//	}
//	
//	// Update is called once per frame
//	void Update ()
//	{
//		
//	}
//}
//