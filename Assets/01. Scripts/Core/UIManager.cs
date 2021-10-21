using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }


    public CanvasGroup dialoguePanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
          //  if (Inventory.IsOpen)
            {
                Inventory.CloseInventory();
            }
            //else
            //{
            //    Inventory.OpenInventory();
            //}
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("inven effect left");
           // if (Inventory.IsOpen)
            {
             //   Inventory.instance.LeftSelectItem();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("inven effect right");
           // if (Inventory.IsOpen)
            {
                //Inventory.instance.RightSelectItem();
            }
        }
    }

    public void OpenInventory(bool[] isItemGet)
    {
        for (int i = 0; i < 5; i++)
        {
           // inventoryItems[i].SetActive(isItemGet[i]);
        }

        // playerInventory.ViewIntentory();
    }
}
