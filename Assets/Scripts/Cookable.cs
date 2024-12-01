using System;
using UnityEngine;

public class Cookable : MonoBehaviour
{
    public Transform camera;

    float distToCamera;
    public bool onTray = false;

    public void SetCamera(Transform camera)
    {
        if (!onTray)
        {
            distToCamera = Vector3.Distance(camera.position, transform.position);
            this.camera = camera;
        }
    }

    internal void MoveToCamera(Transform camera)
    {
        transform.position = Vector3.Lerp(transform.position, camera.position + camera.forward * 1.5f, Time.deltaTime * 16f);
    }

    internal void MoveToTray(Tray tray)
    {
        transform.position = tray.transform.position + tray.cookablesOnTray.Count * Vector3.up * 0.02f + Vector3.up * 0.1f;
        onTray = true;
        transform.rotation = Quaternion.Euler(-90, 0, 0);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

        camera = null;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (camera)
        {
            GetComponent<Rigidbody>().useGravity = false;

            MoveToCamera(camera);
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
