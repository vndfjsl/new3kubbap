using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IItem
{
    public ItemType type;
    
    private SpriteRenderer sr;

    private void Awake()
    {
        
        sr = GetComponent<SpriteRenderer>();
    }

    public Sprite GetItemSprite()
    {
        return sr.sprite;
    }

    public virtual void DropItem(Vector2 pos)
    {

    }

    public virtual void UseItem()
    {

    }

    public virtual void GetItem()
    {

    }

    public virtual void Save(bool getItem)
    {

    }

    public void Use()
    {
        throw new System.NotImplementedException();
    }


    public void Get()
    {
        throw new System.NotImplementedException();
    }

    public void Drop(Vector3 pos)
    {
        throw new System.NotImplementedException();
    }
}
