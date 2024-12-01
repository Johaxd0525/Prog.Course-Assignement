using Unity.VisualScripting;
using UnityEngine;

public class Grill : MonoBehaviour
{
    public Material CookedMaterial;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("RawPatty"))
        {
            collision.collider.GetComponent<MeshRenderer>().material = CookedMaterial;
            collision.collider.tag = "FriedPatty";
        }
    }

    
}
