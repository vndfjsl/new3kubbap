using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSensor : MonoBehaviour
{
    private PlayerEquipment equip; // 외부에서 가져올것

    public List<Item> frontItems = new List<Item>(); // 외부에 내보낼것


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
        Debug.Log("플레이어와의 충돌 : " + collision.gameObject.name);
        Item i = collision.gameObject.GetComponent<Item>();
        if (i != null)
        {
            Debug.Log("전방 아이템 발견 : " + collision.gameObject.name);
            frontItems.Add(i);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("플레이어와의 충돌 해제 : " + collision.gameObject.name);
        Item i = collision.gameObject.GetComponent<Item>();
        if (frontItems.Contains(i)) frontItems.Remove(i);
    }
}
