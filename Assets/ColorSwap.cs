using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwap : MonoBehaviour {
    public Material[] colors;

	void Start () {
        swapcol();
    }

    public void swapcol()
    {
        Material[] mats = GetComponent<Renderer>().materials;
        mats[1] = colors[Random.Range(0, colors.Length - 1)];
        GetComponent<Renderer>().materials = mats;
    }
}
