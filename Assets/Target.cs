using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour,ITarget
{

	private Transform body;
	
	private bool canBeHitted = true;

	private void Start()
	{
		body = transform.Find("Target_Mesh");
	}

	public void ZoneHit(GameObject zone, float points, GameObject hitBy, Vector3 worldSpaceHitPoint)
	{
		EventManager.Instance.OnPointsEarned.Invoke(points);
		StartCoroutine(HitCoroutine());
		
	}

	IEnumerator HitCoroutine()
	{
		canBeHitted = false;
		while (body.rotation != Quaternion.Euler(-90, 0, 0))
		{
			body.localRotation = Quaternion.RotateTowards(body.localRotation, Quaternion.Euler(-90, 0, 0), Time.deltaTime * 10);
			yield return new WaitForEndOfFrame();
		}
		
		yield return new WaitForSeconds(3f);
		
		while (body.rotation != Quaternion.Euler(0, 0, 0))
		{
			body.localRotation = Quaternion.RotateTowards(body.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5);
			yield return new WaitForEndOfFrame();
		}
		canBeHitted = true;
	}
}
