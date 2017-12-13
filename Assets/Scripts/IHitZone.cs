using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitZone
{
	void Hit(GameObject hitBy, Vector3 worldSpaceHitPoint);
}
