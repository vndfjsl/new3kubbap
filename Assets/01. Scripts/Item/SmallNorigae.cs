using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallNorigae : Item
{
    public override void Get()
    {
        base.Get();
        Debug.Log("노리개를 얻었다.");
        DialogManager.ShowDialog(4);
    }

    public override void Drop(Vector3 playerPos)
    {
        base.Drop(playerPos);
        Debug.Log("노리개를 내려놓았다.");
    }

    public override void Use()
    {
        Debug.Log("노리개를 사용했다.");
    }
}
