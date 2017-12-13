using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Target : MonoBehaviour,ITarget
{

	[SerializeField] private Transform _body;

	[SerializeField] private Transform _collidersContainer;
	
	private bool _canBeHitted = true;

	private Sequence _hitSequence;

	public Vector3 HitRotation;
	
	
	
	private void Start()
	{
		if(_body==null || _collidersContainer==null)
			DestroyImmediate(gameObject);
		
		foreach (Transform hitZone in _collidersContainer)
		{
			hitZone.GetComponent<HitZone>().TargetManager = this;
		}
		
		var originalRotation = _body.localRotation.eulerAngles;
		_hitSequence = DOTween.Sequence();
		_hitSequence.Pause();
		_hitSequence.AppendCallback(() => _canBeHitted = false);
		_hitSequence.Append(_body.DOLocalRotate(HitRotation, 0.3f));
		_hitSequence.AppendInterval(3f);
		_hitSequence.Append(_body.DOLocalRotate(originalRotation, 0.3f));
		_hitSequence.AppendCallback(() => _canBeHitted = true);
		_hitSequence.SetAutoKill(false);
	}

	public void ZoneHit(GameObject zone, float points, GameObject hitBy, Vector3 worldSpaceHitPoint)
	{
		if (_canBeHitted)
		{
			EventManager.Instance.OnPointsEarned.Invoke(points);
			_hitSequence.Restart();
		}
	}
}
