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
        Debug.Log("도끼를 얻었다.");
    }

    public override void Drop(Vector3 playerPos)
    {
        base.Drop(playerPos);
        Debug.Log("도끼를 내려놓았다.");
    }

    public override void Use()
    {
        if (col.isBroken == true) //처음 왼쪽 도끼질
        {
            col.digCount++;
            StartCoroutine(hit());
            Debug.Log("!");
        }

        //if (col.isTiger) //호랑이 패는 부분 도끼로
        //{
        //    col.tigetCount++;
        //    StartCoroutine(hit1());
        //}

        //if (col.getAxetwo) //파란천 부시기
        //{
        //    Destroy(col.blue);
        //}
        base.Use();
        Debug.Log("도끼를 사용했다.");
    }

    private IEnumerator hit() //빨게졌다가 돌아오는 피격 표현
    {
        col.tree.GetComponent<SpriteRenderer>().color = Color.red;
        yield return ws;
        col.tree.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
