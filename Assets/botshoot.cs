using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botshoot : MonoBehaviour {

    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    private AudioSource[] clips;
    // Use this for initialization
    void Start () {
        if (barrelLocation == null)
            barrelLocation = transform;
        clips = GetComponents<AudioSource>();
    }

    public void shoot()
    {
        if (clips != null)
        {
            clips[UnityEngine.Random.Range(0, clips.Length - 1)].Play();
        }
        GameObject tempFlash;
        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
        tempFlash.transform.parent = barrelLocation;
        Destroy(tempFlash, .1f);
    }

}
