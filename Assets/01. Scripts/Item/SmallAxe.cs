using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAxe : Item
{
    private WaitForSeconds ws;
    private float delay = 0.3f;

    private  void Start()
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
        if (GameManager.instance.col.isBroken == true) //ó�� ���� ������

        {
            GameManager.instance.col.digCount++;
            StartCoroutine(hit());
            Debug.Log("!");
        }

        //if (col.isTiger) //ȣ���� �д� �κ� ������
        //{
        //    col.tigetCount++;
        //    StartCoroutine(hit1());
        //}

        if (GameManager.instance.col.getAxetwo) //�Ķ�õ �νñ�
        {
            Destroy(GameManager.instance.col.blue);
        }
        base.Use();
        Debug.Log("������ ����ߴ�.");
    }

    private IEnumerator hit() //�������ٰ� ���ƿ��� �ǰ� ǥ��
    {
        GameManager.instance.col.tree.GetComponent<SpriteRenderer>().color = Color.red;
        yield return ws;
        GameManager.instance.col.tree.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
