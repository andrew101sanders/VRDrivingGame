using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedometerUpdate : MonoBehaviour {

    public GameObject Speedometer;
    private float speed;

	void Start () {
        Speedometer.GetComponent<TextMeshPro>().text = "0 Mph";
    }
    void FixedUpdate()
    {
            speed = GetComponent<Move>().acceleration;
            speed *= 90;
            speed = Mathf.Round(speed);
            Speedometer.GetComponent<TextMeshPro>().text = speed + " Mph";
    }
}
