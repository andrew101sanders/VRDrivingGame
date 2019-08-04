using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour {
    public GameObject Eye1;
    public GameObject Eye2;
    private GameObject player;
    public GameObject gun;
    private bool close;
    public float currentHue = .162f;


    // Use this for initialization
    void Start () {
        player = transform.parent.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (close)
        {
            Eye1.GetComponent<Light>().color = Color.HSVToRGB(currentHue, 1, 1);
            Eye2.GetComponent<Light>().color = Color.HSVToRGB(currentHue, 1, 1);
            currentHue -= .0027f * Time.deltaTime * 12;
            if (currentHue <= 0 || currentHue > .162f)
            {
                currentHue = .162f;
                damagePlayer();
            }
        }

        if (Vector3.Magnitude(transform.position - player.transform.position) < 15f)
        {
            close = true;
        }
        else
        {
            close = false;
            currentHue = .162f;
            Eye1.GetComponent<Light>().color = Color.HSVToRGB(currentHue, 1, 1);
            Eye2.GetComponent<Light>().color = Color.HSVToRGB(currentHue, 1, 1);
        }

    }

    void damagePlayer()
    {
        player.GetComponent<HPBar>().Damage();
        gun.GetComponent<botshoot>().shoot();
    }
}
