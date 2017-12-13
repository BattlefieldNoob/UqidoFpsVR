using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Transform _emissionTransform;

    private void Start()
    {
        _emissionTransform = transform.Find("Emission");
        GetComponentInParent<SteamVR_TrackedController>().TriggerClicked += (sender, args) =>
        {
            Shot();
        };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
          Shot();
        }
    }


    void Shot()
    {
        RaycastHit hit;
        var ray=new Ray(_emissionTransform.position,_emissionTransform.forward);
        Debug.DrawRay(ray.origin,ray.GetPoint(10),Color.green,0.3f);
        if (Physics.Raycast(ray, out hit))
        {
            hit.collider.GetComponent<HitZone>()?.Hit(gameObject, hit.point);
        }
    }
}