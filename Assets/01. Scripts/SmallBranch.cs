using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBranch : Item
{
    public override void Get()
    {
        base.Get();
        Debug.Log("나뭇가지를 얻었다.");
    }

    public override void Drop(Vector3 playerPos)
    {
        base.Drop(playerPos);
        Debug.Log("나뭇가지를 내려놓았다.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        Debug.Log("나뭇가지를 사용했다.");
    }
}
