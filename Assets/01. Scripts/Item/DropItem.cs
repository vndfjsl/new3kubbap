using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            rigid.gravityScale = 0;
            if (!isGroundTouch)
            {
                rigid.velocity = Vector2.zero;
                isGroundTouch = true;
            }
        }
    }
}
