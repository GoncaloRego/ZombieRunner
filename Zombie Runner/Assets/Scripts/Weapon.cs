using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float shotDamage = 25f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] int zoomedFieldOfView = 15;
    [SerializeField] int normalFieldOfView = 60;
    [SerializeField] float zoomedSensitivity = 0.5f;
    [SerializeField] int normalSensitivity = 2;
    [SerializeField] Ammo ammoSlot;

    RigidbodyFirstPersonController firstPersonController;

    void Start()
    {
        firstPersonController = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        Zoom();
    }

    void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo();
        }
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null)
            {
                return;
            }

            CreateHitEffect(hit);
            target.TakeDamage(shotDamage);
        }
        else
        {
            return;
        }
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void CreateHitEffect(RaycastHit hit)
    {
        GameObject damageEffect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(damageEffect, 0.1f);
    }

    void Zoom()
    {
        if (Input.GetMouseButton(1))
        {
            fpsCamera.fieldOfView = zoomedFieldOfView;
            firstPersonController.mouseLook.XSensitivity = zoomedSensitivity;
            firstPersonController.mouseLook.YSensitivity = zoomedSensitivity;
        }
        else
        {
            fpsCamera.fieldOfView = normalFieldOfView;
            firstPersonController.mouseLook.XSensitivity = normalSensitivity;
            firstPersonController.mouseLook.YSensitivity = normalSensitivity;
        }
    }
}
