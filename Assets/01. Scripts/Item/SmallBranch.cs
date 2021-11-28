//�迹����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBranch : Item
{
    public override void Get()
    {
        base.Get();
        Debug.Log("���������� �����.");
        DialogManager.ShowDialog(4);
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
        Debug.Log("���������� ����ߴ�.");

        if (GameManager.Instance.col.isYellow) //���õ�� �νŴ�
        {
            Destroy(GameManager.Instance.col.yellow);
            DialogManager.ShowDialog(11);
            return;
        }
        if (!GameManager.Instance.col.isFired)
        {
            GameManager.Instance.col.isFired = true;
            DialogManager.ShowDialog(8);
        }

    }
}
