using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSensor : MonoBehaviour
{
    private PlayerEquipment equip; // �ܺο��� �����ð�

    public List<Item> frontItems = new List<Item>(); // �ܺο� ��������


    // Start is called before the first frame update
    void Start()
    {
        equip = GetComponent<PlayerEquipment>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item i = collision.gameObject.GetComponent<Item>();
        if (i != null)
        {
            frontItems.Add(i);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Item i = collision.gameObject.GetComponent<Item>();
        if (frontItems.Contains(i)) frontItems.Remove(i);
    }
}
