using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceClamp : MonoBehaviour {
    public GameObject PlayerCar;
	
	// Update is called once per frame
	void LateUpdate () {
		for(int i = 1; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).position.z - PlayerCar.transform.position.z < -35)
            {
                transform.GetChild(i).position = new Vector3(transform.GetChild(i).position.x, transform.GetChild(i).position.y, PlayerCar.transform.position.z - 35);
            }
        }
	}
}
