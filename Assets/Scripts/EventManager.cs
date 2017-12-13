using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{

	public static EventManager Instance;
	
	public class FloatEvent : UnityEvent<float> {}

	public FloatEvent OnPointsEarned;

	public FloatEvent OnPointsUpdated;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			OnPointsEarned=new FloatEvent();
			OnPointsUpdated=new FloatEvent();
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
