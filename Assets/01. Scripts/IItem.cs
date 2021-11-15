using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    void Get();
    void Drop(Vector3 pos);
    public void Use();
}
