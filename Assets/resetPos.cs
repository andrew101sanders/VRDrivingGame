using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class resetPos : MonoBehaviour
{
    public Transform desiredHeadPosition;
    public Transform steamCamera;
    public Transform cameraRig;
    public SteamVR_Action_Boolean resetButton;

    private void Start()
    {
        if (desiredHeadPosition != null)
        {
            ResetSeatedPos(desiredHeadPosition);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || (resetButton.state && resetButton.changed))
        {
            if (desiredHeadPosition != null)
            {
                ResetSeatedPos(desiredHeadPosition);
            }
        }
    }

    private void ResetSeatedPos(Transform desiredHeadPos)
    {
        if ((steamCamera != null) && (cameraRig != null))
        {
            float offsetAngle = steamCamera.rotation.eulerAngles.y;
            cameraRig.Rotate(0f, -offsetAngle, 0f);

            Vector3 offsetPos = steamCamera.position - cameraRig.position;
            cameraRig.position = (desiredHeadPos.position - offsetPos);
        }
    }
}