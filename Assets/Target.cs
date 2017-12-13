using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Target : MonoBehaviour,ITarget
{

	private Transform body;
	
	private bool canBeHitted = true;

	private Sequence hitSequence;

	public Vector3 hitRotation;
	
	private void Start()
	{
		body = transform.Find("Target_Mesh");
		var originalRotation = body.localRotation.eulerAngles;
		hitSequence = DOTween.Sequence();
		hitSequence.Pause();
		hitSequence.AppendCallback(() => canBeHitted = false);
		hitSequence.Append(body.DOLocalRotate(hitRotation, 0.3f));
		hitSequence.AppendInterval(3f);
		hitSequence.Append(body.DOLocalRotate(originalRotation, 0.3f));
		hitSequence.AppendCallback(() => canBeHitted = true);
		hitSequence.SetAutoKill(false);
		hitSequence.SetLoops(-1);
	}

	public void ZoneHit(GameObject zone, float points, GameObject hitBy, Vector3 worldSpaceHitPoint)
	{
		EventManager.Instance.OnPointsEarned.Invoke(points);
		//hitSequence.Rewind(false);
		hitSequence.Play();
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
