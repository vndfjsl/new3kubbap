//¿À¹Î±Ô
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public PlayerState playerState;

    public Sprite[] changeBgs;
    public Image backgroundImage;

    private Dictionary<PlayerHeartState, Sprite> bgDictionary
     = new Dictionary<PlayerHeartState, Sprite>();

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    private void Start()
    {
        bgDictionary.Add(PlayerHeartState.Normal, changeBgs[0]);
        bgDictionary.Add(PlayerHeartState.Unstable, changeBgs[1]);
        bgDictionary.Add(PlayerHeartState.Fear, changeBgs[2]);
        bgDictionary.Add(PlayerHeartState.Revenge, changeBgs[3]);

    }

    public void InventoryUIActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public CanvasGroup dialoguePanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
          ////  if (Inventory.IsOpen)
          //  {
          //      Inventory.CloseInventory();
          //  }
            //else
            //{
            //    Inventory.OpenInventory();
            //}
        }

       
        

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    Debug.Log("inven effect left");
        //   // if (Inventory.IsOpen)
        //    {
        //     //   Inventory.instance.LeftSelectItem();
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    Debug.Log("inven effect right");
        //   // if (Inventory.IsOpen)
        //    {
        //        //Inventory.instance.RightSelectItem();
        //    }
        //}
    }

    public static void ActiveUI(GameObject gameObject, bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public static void ActiveCG(CanvasGroup cg, float alpha)
    {
        cg.alpha = alpha;
    }

    public void ChangeBackground(PlayerHeartState state)
    {
        backgroundImage.sprite = bgDictionary[state];
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
