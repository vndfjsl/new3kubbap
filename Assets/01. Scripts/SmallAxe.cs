using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAxe : Item
{
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

    // Update is called once per frame
    void Update()
    {

    }
}
