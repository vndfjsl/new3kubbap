using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Image image;
    public Item slotItem;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void EmptySlot()
    {
        image.sprite = null;
        image.color = new Color(1, 1, 1, 0);
    }

    public void OnSlot(Sprite sr)
    {
        image.sprite = sr;
        image.color = new Color(1, 1, 1, 1);
    }
}
