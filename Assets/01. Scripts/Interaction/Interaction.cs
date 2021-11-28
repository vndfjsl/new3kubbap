//오민규
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour, IInteraction
{
    // import(외부에서)

    // export(외부로)

    // inner(내부값)

    public bool isColEvent = false;
    public abstract void ObjectAction(GameObject player = null);
}
