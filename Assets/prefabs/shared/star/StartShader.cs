using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var material = GetComponent<Renderer>().material;
        material.SetFloat("RunShader", 1);
    }

    // Update is called once per frame
    void Update()
    {
    }
}