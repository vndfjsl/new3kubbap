using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject selectEffect;
    private List<Slot> slots = new List<Slot>();
    private CanvasGroup inventoryPanel;
    private bool isOpen = false;
    private int selectingIndex;
    private Slot selectingItem = new Slot();

    private void Awake()
    {
        inventoryPanel = GetComponent<CanvasGroup>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponentsInChildren<Slot>(slots);
    }

    public static void OpenInventory()
    {

    }

    public static void CloseInventory()
    {

    }

    public static void InsertItem(Item item)
    {

    }

    public static void DeleteItem(Item item)
    {

    }

    public void SelectItem()
    {

    }

    public int GetItemCount()
    {
        return slots.Count;
    }
}
