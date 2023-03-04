using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDetect : MonoBehaviour
{
    // Start is called before the first frame update
    Camera camera;
    MeshRenderer renderer;
    Plane[] CameraFrustum;
    Collider collider;
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("Player").GetComponent<Camera>();
        renderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        var bounds = collider.bounds;
        CameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(CameraFrustum, bounds)) {
            renderer.sharedMaterial.color = new Color(255, 255, 0, 1);
        } else {
            renderer.sharedMaterial.color = new Color(0, 0, 0, 0);
        }
    }
}
