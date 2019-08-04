//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;
using System.Collections;

namespace Valve.VR
{
    /// <summary>
    /// Automatically activates an action set on Start() and deactivates the set on OnDestroy(). Optionally deactivating all other sets as well.
    /// </summary>
    public class SteamVR_ActivateActionSetOnLoad : MonoBehaviour
    {
        public SteamVR_ActionSet[] actionSets;

        public SteamVR_Input_Sources forSources = SteamVR_Input_Sources.Any;

        public bool disableAllOtherActionSets = false;

        public bool activateOnStart = true;
        public bool deactivateOnDestroy = true;


        private void Start()
        {
            for(int i = 0; i < actionSets.Length; i++)
            {
                if (actionSets[i] != null && activateOnStart)
                {
                    //Debug.Log(string.Format("[SteamVR] Activating {0} action set.", actionSet.fullPath));
                    actionSets[i].Activate(forSources, 0, disableAllOtherActionSets);
                }
            }

        }

        private void OnDestroy()
        {
            for (int i = 0; i < actionSets.Length; i++)
            {
                if (actionSets[i] != null && deactivateOnDestroy)
                {
                    //Debug.Log(string.Format("[SteamVR] Deactivating {0} action set.", actionSet.fullPath));
                    actionSets[i].Deactivate(forSources);
                }
            }
        }
    }
}