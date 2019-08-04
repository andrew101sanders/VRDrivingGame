using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PickupWeapon : MonoBehaviour
{

    public SteamVR_Action_Boolean action;
    public GameObject hand;
    public GameObject gunInCar;
    public GameObject gunInHand;
    public GameObject lastCarGun;
    public GameObject lastHandGun;
    public bool gunPickedUp = false;

    // Update is called once per frame
    void Update()
    {

        if (action.changed && action.state && gunInCar != null && gunInHand != null && gunInCar.GetComponent<Interactable>().isHovering)
        {
            if (lastCarGun != null)
            {
                lastCarGun.SetActive(true);
            }
            if (lastHandGun != null)
            {
                lastHandGun.SetActive(false);
            }

            gunInHand.SetActive(true);
            hand.GetComponent<Hand>().mainRenderModel.gameObject.SetActive(false);
            gunInCar.SetActive(false);
            lastCarGun = gunInCar;
            lastHandGun = gunInHand;
            gunInCar.GetComponent<Interactable>().endHover();
            gunPickedUp = true;
        }
        else if (gunPickedUp == true && action.changed && action.state)
        {
            hand.GetComponent<Hand>().mainRenderModel.gameObject.SetActive(true);
            lastCarGun.SetActive(true);
            lastHandGun.SetActive(false);
            gunPickedUp = false;
        }
    }
}
