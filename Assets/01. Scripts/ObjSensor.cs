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
        Debug.Log("�÷��̾���� �浹 : " + collision.gameObject.name);
        Item i = collision.gameObject.GetComponent<Item>();
        if (i != null)
        {
            Debug.Log("���� ������ �߰� : " + collision.gameObject.name);
            frontItems.Add(i);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("�÷��̾���� �浹 ���� : " + collision.gameObject.name);
        Item i = collision.gameObject.GetComponent<Item>();
        if (frontItems.Contains(i)) frontItems.Remove(i);
    }
}
