using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour, IItem
{
    public Transform handleTrm;
    public bool isGround;

    protected Rigidbody2D rigid;
    public Vector3 originRotation;

    // extern
    public int itemNumber;
    [HideInInspector] public Sprite itemImage;

    protected void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        itemImage = GetComponent<SpriteRenderer>().sprite;
        rigid.velocity = Vector2.zero;
        rigid.bodyType = RigidbodyType2D.Kinematic;
        isGround = true;
    }

    protected void Start()
    {
        originRotation = transform.rotation.eulerAngles;
        Debug.Log(originRotation.z);
    }

    public virtual void Get()
    {
        isGround = false;
        rigid.bodyType = RigidbodyType2D.Kinematic;
    }

    public virtual void Drop(Vector3 playerPos)
    {
        rigid.bodyType = RigidbodyType2D.Dynamic;
        gameObject.transform.parent = null;
        // gameObject.transform.position = playerPos + new Vector3(0,6f,0);

        RotateOrigin();

        rigid.velocity += new Vector2(0, 4f);
        rigid.gravityScale = 1f;
    }

    public void RotateOrigin()
    {
        gameObject.transform.localRotation = Quaternion.Euler(originRotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("GROUND"))
        {
            isGround = true;
            rigid.velocity = Vector2.zero;
            rigid.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}