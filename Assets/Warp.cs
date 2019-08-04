using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject BackWarp;
    public GameObject cars;
    private GameObject score;
    private void Start()
    {
        score = GameObject.Find("score");
    }

    void OnTriggerEnter(Collider b)
    {
        if (b.tag == "Player")
        {
            if (score != null)
            {
                score.GetComponent<Scoring>().increaseLaps();
            }

            for (int c = 0; c < cars.transform.childCount; c++)
            {
                cars.transform.GetChild(c).transform.position = new Vector3(
                     cars.transform.GetChild(c).transform.position.x,
                     cars.transform.GetChild(c).transform.position.y,
    BackWarp.transform.position.z - (transform.position.z - cars.transform.GetChild(c).transform.position.z));
            }
        }

    }
}
