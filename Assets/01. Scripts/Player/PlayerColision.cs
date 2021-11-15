using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    public GameObject tree;
    public bool isBroken = false;
    public int digCount = 0;


    private void Update()
    {
        if (digCount > 2) //3번 이상 쳐맞으면 나무가 부셔진당
        {
            tree.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tree")) //나무에 닿았을때 휘두르면 브로큰이 트루가 된다
        {
            isBroken = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tree")) //나무에서 떨어지몀ㄴ? 아무일도 안일어남 밑도 마찬가지임
        {
            isBroken = false;
        }
    }
}
