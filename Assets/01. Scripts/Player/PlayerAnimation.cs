using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;

    private int hashIsWalk = Animator.StringToHash("isWalk");
    private int hashIsSlow = Animator.StringToHash("isSlow");
    private int hashIsUseAxe = Animator.StringToHash("isUseAxe");

    public GameObject[] LArmNotWaters;
    public GameObject[] RArmNotWaters;

    public GameObject[] waterSprites;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetSpeed();
        Debug.Log("1" + RArmNotWaters[0].activeSelf);
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
        for(int i=0; i<2; i++)
        {
            waterSprites[i].SetActive(value);
            LArmNotWaters[i].SetActive(!value);
            RArmNotWaters[i].SetActive(!value);
            Debug.Log(RArmNotWaters[i].activeSelf);
        }
    }
}
