using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateExample : MonoBehaviour
{
	delegate void ExampleDelegate(int a, int b);

	void AddDelegate(int a, int b)
	{
		Debug.Log ("Adding: " + (a + b));
	}

	void MultDelegate(int a, int b)
	{
		Debug.Log ("Multing: " + (a * b));
	}

	void Start ()
	{
		ExampleDelegate method_to_use = MultDelegate;

		method_to_use.Invoke (5, 5);
		method_to_use = AddDelegate;
		method_to_use.Invoke (5, 5);
	}
}
