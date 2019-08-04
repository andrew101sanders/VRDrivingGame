using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using Valve.VR.InteractionSystem;

public class ButtonEffect : MonoBehaviour
{
    public void OnButtonDown(Hand fromHand)
    {
        ColorSelf(Color.green);
        fromHand.TriggerHapticPulse(1000);
        StartCoroutine(Loadscene());
    }

    public void OnButtonUp(Hand fromHand)
    {
        ColorSelf(Color.red);
    }

    private void ColorSelf(Color newColor)
    {
        Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
        for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
        {
            renderers[rendererIndex].material.color = newColor;
        }
    }

    IEnumerator Loadscene()
    {
        AsyncOperation aload = SceneManager.LoadSceneAsync("DrivingScene");
        while (!aload.isDone)
        {
            yield return null;
        }
    }
}
