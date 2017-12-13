using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Transform _emissionTransform;
    public GameObject ProjectilePrefab;

    [Header("Audio")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _shotgunSfx;


    private SteamVR_TrackedController _controller;

    private void Start()
    {
        _emissionTransform = transform.Find("Emission");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Shot();
        }
    }

    public void Equip()
    {
        _controller = GetComponentInParent<SteamVR_TrackedController>();
        if (_controller)
        {
            _controller.TriggerClicked += ControllerOnTriggerClicked;
        }
    }

    public void Release()
    {
        _controller.TriggerClicked -= ControllerOnTriggerClicked;
    }

    private void ControllerOnTriggerClicked(object o, ClickedEventArgs clickedEventArgs)
    {
        Shot();
    }

    void Shot()
    {
        _audioSource.PlayOneShot(_shotgunSfx[UnityEngine.Random.Range(0,_shotgunSfx.Length-1)]);
        
        RaycastHit hit;
        var ray = new Ray(_emissionTransform.position, _emissionTransform.forward);
        Debug.DrawRay(ray.origin, ray.GetPoint(10), Color.green, 0.3f);
        if (Physics.Raycast(ray, out hit))
        {
            hit.collider.GetComponent<HitZone>()?.Hit(gameObject, hit.point);
        }
        _emissionTransform.GetComponentInChildren<ParticleSystem>().Play();
        Instantiate(ProjectilePrefab, _emissionTransform.position, _emissionTransform.rotation);
    }
}