using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour {

    private Animation anim;
    private GameObject playerCar;
	void Start () {
        anim = GetComponent<Animation>();
        playerCar = transform.parent.parent.GetChild(0).gameObject;
        anim["Robotanim"].speed = 0f;
        anim["Robotanim"].time = 0f;
    }
	
	void Update () {
        Vector3 direction =  transform.parent.position-playerCar.transform.position;
        float angle = Vector3.SignedAngle(transform.parent.forward, direction, Vector3.up);
        angle += 180;
        if (angle > 348.75f || angle <= 11.25f)
        {
            anim["Robotanim"].time = 0f;
        }
        else if (angle <= 33.75f)
        {
            anim["Robotanim"].time = 1f;
        }
        else if (angle <= 56.25f)
        {
            anim["Robotanim"].time = 2f;
        }
        else if (angle <= 78.75f)
        {
            anim["Robotanim"].time = 3f;
        }
        else if (angle <= 101.25f)
        {
            anim["Robotanim"].time = 4f;
        }
        else if (angle <= 123.75f)
        {
            anim["Robotanim"].time = 5f;
        }
        else if (angle <= 146.25f)
        {
            anim["Robotanim"].time = 6f;
        }
        else if (angle <= 168.75f)
        {
            anim["Robotanim"].time = 7f;
        }
        else if (angle <= 191.25f)
        {
            anim["Robotanim"].time = 8f;
        }
        else if (angle <= 213.75f)
        {
            anim["Robotanim"].time = 9f;
        }
        else if (angle <= 236.25f)
        {
            anim["Robotanim"].time = 10f;
        }
        else if (angle <= 236.25f)
        {
            anim["Robotanim"].time = 11f;
        }
        else if (angle <= 258.75f)
        {
            anim["Robotanim"].time = 12f;
        }
        else if (angle <= 281.25f)
        {
            anim["Robotanim"].time = 13f;
        }
        else if (angle <= 303.75f)
        {
            anim["Robotanim"].time = 14f;
        }
        else if (angle <= 326.25f)
        {
            anim["Robotanim"].time = 15f;
        }
        else if (angle <= 348.75f)
        {
            anim["Robotanim"].time = 16f;
        }

    }
}
