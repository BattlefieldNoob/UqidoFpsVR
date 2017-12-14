using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private Rigidbody _rigidbody;

	public float HitForceMultiplier = 1;
	
	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_rigidbody.AddForce(transform.forward*60,ForceMode.Impulse);
		Invoke(nameof(Destroy),0.3f);
	}

	
	private void Destroy()
	{
		Destroy(gameObject);
	}

	private void OnCollisionEnter(Collision other)
	{		
		other.rigidbody?.AddForceAtPosition(_rigidbody.velocity*HitForceMultiplier,other.contacts[0].point);
		//transform.DOKill();
		Destroy(gameObject);
	}
}
