using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Move : MonoBehaviour
{

    public float Speed = 10f;
    public float TurnSpeed = 1f;
    public float acceleration = 0.0f;
    public float accelerationRate = 0.2f;
    public float steeringAcceleration = 0.0f;
    public float steeringAccelerationRate = 2f;
    public GameObject SteeringWheel;
    public SteamVR_Action_Boolean pedal, brake, left, right;

    // Update is called once per frame
    void Update()
    {
        //Forward
        if (Input.GetKey(KeyCode.W) || pedal.state)
        {
            if (acceleration < 1 && acceleration >= 0)
            {
                if (acceleration + accelerationRate * Time.deltaTime >= 1)
                {
                    acceleration = 1;
                }
                else acceleration += accelerationRate * Time.deltaTime;
            }
        }

        //Backward
        else if (Input.GetKey(KeyCode.S) || brake.state)
        {
            if (acceleration > 0)
            {
                if (acceleration - accelerationRate * 2 * Time.deltaTime <= -1)
                {
                    acceleration = -1;
                }
                else acceleration -= accelerationRate * 2 * Time.deltaTime;
            }
            

        }
        //Not moving
        else
        {
            if (acceleration > 0.05)
            {
                acceleration -= accelerationRate / 2 * Time.deltaTime;
            }
            else acceleration = 0;
            
        }
        transform.Translate(Vector3.forward * acceleration * Speed * Time.deltaTime);
        GetComponents<AudioSource>()[1].volume = .2f + (acceleration / 4);
        //Steering
        if (Input.GetKey(KeyCode.D) || right.state)
        {
            if (steeringAcceleration < 1 && steeringAcceleration >= 0)
            {
                if (steeringAcceleration + steeringAccelerationRate * Time.deltaTime >= 1)
                {
                    steeringAcceleration = 1;
                }
                else steeringAcceleration += steeringAccelerationRate * Time.deltaTime;
            }

            else if (steeringAcceleration < 0)
            {
                if (steeringAcceleration + steeringAccelerationRate * Time.deltaTime >= 1)
                {
                    steeringAcceleration = 1;
                }
                else steeringAcceleration += steeringAccelerationRate * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.A) || left.state)
        {
            if (steeringAcceleration > -1 && steeringAcceleration <= 0)
            {
                if (steeringAcceleration - steeringAccelerationRate * Time.deltaTime <= -1)
                {
                    steeringAcceleration = -1;
                }
                else steeringAcceleration -= steeringAccelerationRate * Time.deltaTime;
            }
            else if (steeringAcceleration > 0)
            {
                if (steeringAcceleration - steeringAccelerationRate * Time.deltaTime <= -1)
                {
                    steeringAcceleration = -1;
                }
                else steeringAcceleration -= steeringAccelerationRate * Time.deltaTime;
            }
        }

        else
        {
            if (steeringAcceleration > 0.05)
            {
                steeringAcceleration -= steeringAccelerationRate / 2 * Time.deltaTime;
            }
            else if (steeringAcceleration < -0.05)
            {
                steeringAcceleration += steeringAccelerationRate / 2 * Time.deltaTime;
            }
            else steeringAcceleration = 0;
        }

        turn();
        //  rotateWheel();
        SteeringWheel.transform.rotation = Quaternion.Euler(-17.5f, -180f, steeringAcceleration * 90);
    }

    void turn()
    {
        if ((transform.position + new Vector3(TurnSpeed * steeringAcceleration * Time.deltaTime, 0, 0)).x <= 51.876 && (transform.position + new Vector3(TurnSpeed * steeringAcceleration * Time.deltaTime, 0, 0)).x >= 47.959)
            transform.Translate(new Vector3(TurnSpeed * steeringAcceleration * Time.deltaTime, 0, 0));
        else if (transform.position.x >= 51.876)
        {
            transform.position = new Vector3(51.8f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= 47.959)
        {
            transform.position = new Vector3(48f, transform.position.y, transform.position.z);
        }
    }

    void rotateWheel()
    {
        if (steeringAcceleration < 0.05f && steeringAcceleration > -0.05f)
        {

            SteeringWheel.transform.rotation.eulerAngles.Set(0, 30f, 0);
        }
        else
        {

        }
    }
}
