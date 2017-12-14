using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Someone : MonoBehaviour
{

	private Vector3 originalPosition;
	// Use this for initialization
	void Start ()
	{
		originalPosition = transform.position;
		StartCoroutine(RandomSomeone());
	}
	
	// Update is called once per frame
	IEnumerator RandomSomeone () {
		while (true)
		{
			var random=Random.Range(0f, 100f);
			if (random <= 10)
			{
				yield return transform.DOLocalMoveY(4, 10f).SetEase(Ease.Linear).WaitForCompletion();
				transform.position = originalPosition;
			}
			yield return new WaitForSeconds(4f);
		}
	}
}
