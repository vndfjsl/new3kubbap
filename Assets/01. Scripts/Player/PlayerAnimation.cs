using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;
    private PlayerColision col;

    private int hashIsWalk = Animator.StringToHash("isWalk");
    private int hashIsSlow = Animator.StringToHash("isSlow");
    private int hashIsUseAxe = Animator.StringToHash("isUseAxe");

    public SpriteRenderer[] LArmNotWaters;
    public SpriteRenderer[] RArmNotWaters;
    public SpriteRenderer[] waterSprites;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<PlayerColision>();
    }

    // Update is called once per frame
    void Update()
    {
        SetSpeed();
    }

    private void SetSpeed()
    {
        anim.SetBool(hashIsWalk, rigid.velocity.x != 0 ? true : false);
    }

    public void SetSlow(bool value)
    {
        anim.SetBool(hashIsSlow, value);
    }

    public void SetUse(bool value)
    {
        anim.SetBool(hashIsUseAxe,value);
    }

    public void WaterAction(bool value)
    {
        col.getWater = value;
        for(int i=0; i<2; i++)
        {
            waterSprites[i].color = new Color(1, 1, 1, value ? 1 : 0);
            LArmNotWaters[i].color = new Color(1,1,1, value ? 0 : 1);
            RArmNotWaters[i].color = new Color(1, 1, 1, value ? 0 : 1);
        }
    }
}
