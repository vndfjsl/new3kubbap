//오민규
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : Interaction
{
    public override void ObjectAction(GameObject player)
    {
        Debug.Log("연못풍덩");
        player.GetComponent<PlayerAnimation>().WaterAction(true);
    }

    // import(외부에서)

    // export(외부로)

    // inner(내부값)

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
