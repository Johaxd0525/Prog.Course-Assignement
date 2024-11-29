using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class clickplace : MonoBehaviour
{

    public Transform cloneObj;
    public int foodValue;
  
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        if (gameObject.name== "FriedPatty")
        Instatiate(cloneObj, new Vector3(0, 0.10f, 0));

        if (gameObject.name == "RawPatty")
            Instatiate(cloneObj, new Vector3(0, 0.12f, 0));

        if (gameObject.name == "Ketchup")
            Instatiate(cloneObj, new Vector3(0, 0.14f, 0));

        if (gameObject.name == "Mustard")
            Instatiate(cloneObj, new Vector3(0, 0.16f, 0));

        if (gameObject.name == "Onions")
            Instatiate(cloneObj, new Vector3(0, 0.18f, 0));

        if (gameObject.name == "BurgerBun.Bottom")
            Instatiate(cloneObj, new Vector3(0, 0.20f, 0));

        if (gameObject.name == "BurgerBun.Crown")
            Instatiate(cloneObj, new Vector3(0, 0.22f, 0));

        gameflow.plateValue += foodValue;
        Debug.Log(gameflow.plateValue+"  "+gameflow.orderValue);
    }
}
