using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBranch : Item
{
    public override void Get()
    {
        base.Get();
        Debug.Log("���������� �����.");
    }

    public override void Drop(Vector3 playerPos)
    {
        base.Drop(playerPos);
        Debug.Log("���������� �������Ҵ�.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        GameManager.Instance.col.isFired = true;

        if (GameManager.Instance.col.isYellow) //���õ�� �νŴ�
        {
            Destroy(GameManager.Instance.col.yellow);
        }
        Debug.Log("���������� ����ߴ�.");
        base.Use();
    }
}
