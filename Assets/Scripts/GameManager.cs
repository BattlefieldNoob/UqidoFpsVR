using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private float _points = 0;

	private void Start () {
		EventManager.Instance.OnPointsEarned.AddListener(PointEarned);
	}

	private void PointEarned(float value)
	{
		_points += value;
		EventManager.Instance.OnPointsUpdated.Invoke(_points);
	}
}
