using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class KeyListener : MonoBehaviour {

	public KeyCode [] keys;

		[SerializeField]
		private UnityEvent onPress = new UnityEvent();

	void Update ()
	{
		for (int i = 0; i < keys.Length; i++)
		{
			if (Input.GetKeyUp(keys[i]))
			{
				onPress.Invoke();
			}
		}
		
	}
		
}
