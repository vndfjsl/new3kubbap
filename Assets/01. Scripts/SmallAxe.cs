using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAxe : Item
{
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

    // Update is called once per frame
    void Update()
    {

    }
}
