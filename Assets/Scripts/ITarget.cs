using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{

    void ZoneHit(GameObject zone, float points, GameObject hitBy, Vector3 worldSpaceHitPoint);
}
