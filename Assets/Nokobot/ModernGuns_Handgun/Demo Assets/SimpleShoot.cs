using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SimpleShoot : MonoBehaviour
{
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public SteamVR_Action_Boolean fire;
    public LayerMask lm;
    public GameObject hitob;
    public bool drawRay;
    private AudioSource[] clips;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
        clips = GetComponents<AudioSource>();
    }

    void Update()
    {
        if (fire.state && fire.changed)
        {
            GetComponent<Animator>().SetTrigger("Fire");
        }
    }

    void Shoot()
    {
        if (clips != null)
        {
            clips[UnityEngine.Random.Range(0, clips.Length - 1)].Play();
        }

        RaycastHit hit;
        Ray ray = new Ray(barrelLocation.position, barrelLocation.transform.right);
        if (drawRay)
        {
            Debug.DrawRay(barrelLocation.position, barrelLocation.transform.right, Color.red, 1f);
        }
        if (Physics.Raycast(ray, out hit, 100f, lm))
        {
            hitob = hit.transform.gameObject;
            if (hitob != null)
            {
                hitob.GetComponent<EnemyHP>().Damage(10f);
            }
        }
        else hitob = null;
        GameObject tempFlash;
        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
        tempFlash.transform.parent = barrelLocation;
        Destroy(tempFlash, .1f);
    }

}
