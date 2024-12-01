using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    public string[] trayOrder;

    public List<Cookable> cookablesOnTray;

    public TMPro.TextMeshPro BurgerText;
    public float timeUntilReset = 5;

    public IngredientSpawner spawner;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Cookable>())
        {
            if (collision.collider.GetComponent<Cookable>().onTray == false)
            {
                collision.collider.GetComponent<Cookable>().MoveToTray(this);
                cookablesOnTray.Add(collision.collider.GetComponent<Cookable>());

                if (cookablesOnTray.Count == trayOrder.Length)
                {
                    StartCoroutine(CheckIfBurgerGood());
                }

            }
        }
    }

    public IEnumerator CheckIfBurgerGood()
    {
        bool burgerGood = true;

        for (int i = 0; i < cookablesOnTray.Count; i++)
        {
            if (cookablesOnTray[i].tag != trayOrder[i])
            {
                burgerGood = false;
            }
        }

        if (burgerGood)
        {
            BurgerText.text = "Burger is good!";
        }
        else
        {
            BurgerText.text = "Burger is bad!";
        }


        yield return new WaitForSeconds(timeUntilReset);
    
        ResetTrayAndIngredients();
    }

    void ResetTrayAndIngredients()
    {
        for(int i = 0;i < cookablesOnTray.Count; i++)
        {
            Destroy(cookablesOnTray[i].gameObject);
        }

        cookablesOnTray.Clear();

        BurgerText.text = "";

        spawner.SpawnIngredients();

    }
}
