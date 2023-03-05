using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Central : MonoBehaviour
{
    float t = 300;
    public Text text;
    public GameObject[] targets;
    public int i = 0;
    bool final = false;
    public float width = 1;
    public float height = 1;
    bool end = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (t>0)
        {
            if (!final)
            {
                t = 120 - Time.time;
            } else
            {
                t = 180 - Time.time;
            }
        } else
        {
            if (!final)
            {
                final = true;
                t = 180;
            }
            else if (!end)
            {
                end = true;
            }
        }
                   
        
        text.text = t.ToString();

        if (i >= 4)
        {
            i = 0;
        }
    }
}
