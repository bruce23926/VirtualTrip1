using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PPT : MonoBehaviour
{
    // Start is called before the first frame update
    int page = 1;
    RawImage img;
    public Texture t1, t2, t3, t4, t5, t6, t7;
    float timer = 0;
    void Start()
    {
        img = GetComponent<RawImage>();
        img.texture = t1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < Time.time)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                switch (page)
                {
                    case 1:
                        img.texture = t2;
                        page += 1;
                        break;
                    case 2:
                        img.texture = t3;
                        page += 1;
                        break;
                    case 3:
                        img.texture = t4;
                        page += 1;
                        break;
                    case 4:
                        img.texture = t5;
                        page += 1;
                        break;
                    case 5:
                        img.texture = t6;
                        page += 1;
                        break;
                    case 6:
                        img.texture = t7;
                        page += 1;
                        break;
                    default:
                        break;
                }
                timer = Time.time + 1;

            }
        }
        
        
    }
}
