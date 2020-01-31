using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSwapper : MonoBehaviour
{
    public Material[] colours;
    private int coloursLength;
    private Renderer material;

    void Awake()
    {
        material = gameObject.GetComponent<MeshRenderer>();
        coloursLength = colours.Length;

        material.material = colours[Random.Range(0, coloursLength)];
    }
}
