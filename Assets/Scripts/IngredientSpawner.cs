using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject ingredientParent;

    public void SpawnIngredients()
    {
        Instantiate( ingredientParent, transform.position, transform.rotation);
    }
}
