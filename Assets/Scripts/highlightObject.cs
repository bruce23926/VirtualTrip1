using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlightObject : MonoBehaviour
{
    MeshRenderer renderer;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void highLight() {
        renderer.material.SetColor("_OutlineColor", Color.yellow);
        //print("touched");
    }
}
