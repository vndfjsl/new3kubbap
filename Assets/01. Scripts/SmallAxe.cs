using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAxe : Item
{
    private PlayerColision col;
    private WaitForSeconds ws;
    private float delay = 0.3f;

    private void Start()
    {
        ws = new WaitForSeconds(delay);
    }

    public override void Get()
    {
        base.Get();
        Debug.Log("������ �����.");
    }

    public override void Drop(Vector3 playerPos)
    {
        base.Drop(playerPos);
        Debug.Log("������ �������Ҵ�.");
    }

    public override void Use()
    {
        if (col.isBroken == true) //ó�� ���� ������
        {
            col.digCount++;
            StartCoroutine(hit());
            Debug.Log("!");
        }

        //if (col.isTiger) //ȣ���� �д� �κ� ������
        //{
        //    col.tigetCount++;
        //    StartCoroutine(hit1());
        //}

        //if (col.getAxetwo) //�Ķ�õ �νñ�
        //{
        //    Destroy(col.blue);
        //}
        base.Use();
        Debug.Log("������ ����ߴ�.");
    }

    private IEnumerator hit() //�������ٰ� ���ƿ��� �ǰ� ǥ��
    {
        col.tree.GetComponent<SpriteRenderer>().color = Color.red;
        yield return ws;
        col.tree.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
