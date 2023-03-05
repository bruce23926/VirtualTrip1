using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTarget : MonoBehaviour
{
    public GameObject target;
    public Central central;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createTarget()
    {
        var k = central.i;
        if (central.targets[k] != null)
        {
            Destroy(central.targets[k]);
        }
        central.targets[k] = Instantiate(target, transform.position, Quaternion.Euler(0, 0, 0));
        central.i += 1;
    }
}
