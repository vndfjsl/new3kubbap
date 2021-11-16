using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSensor : MonoBehaviour
{
    private PlayerEquipment equip; // 외부에서 가져올것

    public List<Item> frontItems = new List<Item>(); // 외부에 내보낼것
    public List<Interaction> frontObjects = new List<Interaction>();


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
        Item item = collision.gameObject.GetComponent<Item>();
        if (item != null)
        {
            frontItems.Add(item);
        }

        Interaction inter = collision.gameObject.GetComponent<Interaction>();
        if(inter != null)
        {
            frontObjects.Add(inter);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Item item = collision.gameObject.GetComponent<Item>();
        if (frontItems.Contains(item)) frontItems.Remove(item);

        Interaction inter = collision.gameObject.GetComponent<Interaction>();
        if (frontObjects.Contains(inter)) frontObjects.Remove(inter);
    }
}
