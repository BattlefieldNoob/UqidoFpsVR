using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	
	void Start ()
	{
		transform.DOMove(transform.forward*20, 0.3f).OnComplete(() => Destroy(gameObject)).SetEase(Ease.Linear);
	}

	private void OnCollisionEnter(Collision other)
	{
		transform.DOKill();
		Destroy(gameObject);
	}
}
