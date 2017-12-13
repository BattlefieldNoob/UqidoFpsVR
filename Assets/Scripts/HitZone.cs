using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour,IHitZone
{
	public float Value = 10;

	public ITarget TargetManager;
	
	public void Hit(GameObject hitBy, Vector3 worldSpaceHitPoint)
	{
		TargetManager?.ZoneHit(gameObject,Value,hitBy,worldSpaceHitPoint);
	}
}
