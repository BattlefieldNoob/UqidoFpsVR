using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour,IHitZone
{
	public float Value = 10;
	
	public void Hit(GameObject hitBy, Vector3 worldSpaceHitPoint)
	{
		transform.parent.GetComponentInParent<ITarget>().ZoneHit(gameObject,Value,hitBy,worldSpaceHitPoint);
	}
}
