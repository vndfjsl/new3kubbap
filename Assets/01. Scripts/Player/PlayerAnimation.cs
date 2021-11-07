using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;

    private int hashSpeed = Animator.StringToHash("speed");
    private int hashIsWalk = Animator.StringToHash("isWalk");

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetSpeed();
    }

    private void SetSpeed()
    {
        anim.SetFloat(hashSpeed, Mathf.Abs(rigid.velocity.x));
        anim.SetBool(hashIsWalk, rigid.velocity.x != 0 ? true : false);
    }
}
