using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallNorigae : Item
{
    public override void Get()
    {
        base.Get();
        Debug.Log("�븮���� �����.");
        DialogManager.ShowDialog(4);
    }

    public override void Drop(Vector3 playerPos)
    {
        base.Drop(playerPos);
        Debug.Log("�븮���� �������Ҵ�.");
    }

    public override void Use()
    {
        Debug.Log("�븮���� ����ߴ�.");
    }
}
