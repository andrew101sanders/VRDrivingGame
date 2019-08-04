using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDrive : MonoBehaviour
{
    public GameObject playercar;
    public float speed = 5f;
    void Start()
    {
        playercar = transform.parent.GetChild(0).gameObject;
    }
    
    void Update()
    {
        if (transform.position.z - playercar.transform.position.z < -35)
        {
            speed = playercar.GetComponent<Move>().acceleration * playercar.GetComponent<Move>().Speed+10f;
        }
        else if (transform.position.z - playercar.transform.position.z < -20)
        {
            speed = playercar.GetComponent<Move>().acceleration * playercar.GetComponent<Move>().Speed+6f;
        }
        else if (transform.position.z - playercar.transform.position.z < -10)
        {
            speed = playercar.GetComponent<Move>().acceleration * playercar.GetComponent<Move>().Speed+4f;
        }
        else if (transform.position.z - playercar.transform.position.z < -.5f)
        {
            speed = playercar.GetComponent<Move>().acceleration * playercar.GetComponent<Move>().Speed+2f;
        }
        else if (transform.position.z - playercar.transform.position.z > 60)
        {
            speed = playercar.GetComponent<Move>().acceleration * playercar.GetComponent<Move>().Speed-8f;
        }
        else if (transform.position.z - playercar.transform.position.z > 35)
        {
            speed = playercar.GetComponent<Move>().acceleration * playercar.GetComponent<Move>().Speed-6f;
        }
        else if (transform.position.z - playercar.transform.position.z > 20)
        {
            speed = playercar.GetComponent<Move>().acceleration * playercar.GetComponent<Move>().Speed-4f;
        }
        else if (transform.position.z - playercar.transform.position.z > 10)
        {
            speed = playercar.GetComponent<Move>().acceleration * playercar.GetComponent<Move>().Speed-3f;
        }
        else if (transform.position.z - playercar.transform.position.z > .5f)
        {
            speed = playercar.GetComponent<Move>().acceleration * playercar.GetComponent<Move>().Speed-2f;
        }
        else speed = playercar.GetComponent<Move>().Speed * playercar.GetComponent<Move>().acceleration;
            transform.Translate(Vector3.forward * 1 * speed * Time.deltaTime);

        if (transform.position.x >= 51.876)
        {
            transform.position = new Vector3(51.8f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= 47.959)
        {
            transform.position = new Vector3(48f, transform.position.y, transform.position.z);
        }
    }
}
