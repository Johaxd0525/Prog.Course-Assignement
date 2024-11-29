using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class meatcon : MonoBehaviour
{
    public Transform cloneObj;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameObject.name == "RawPatty")
            Instantiate(cloneObj, new Vector3(-3, 0.1f, 0), cloneObj.rotation);
    }
}
