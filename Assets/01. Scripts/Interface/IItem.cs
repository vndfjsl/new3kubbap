using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    public void Use();
    public void Drop(Vector3 pos);
    public void Get();
}