using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColision : MonoBehaviour
{
    public GameObject tree;
    public GameObject Fire;
    public bool isBroken = false;
    public bool isFired = false;
    public bool getWater = false;
    public bool isRed = false;
    public bool getAxetwo = false;
    public bool isYellow = false;
    public bool isMove = false;
    public int digCount = 0;
    private PlayerMove move;
    public GameObject blue;
    public GameObject red;
    public GameObject yellow;
    public GameObject sky_one;
    public GameObject sky_two;
    public GameObject panel;
    public SkillCheck skill;

    [SerializeField] private float time = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (digCount > 2) //3번 이상 쳐맞으면 나무가 부셔진당
        {
            tree.SetActive(false);
            //SceneManager.LoadScene(2);
        }

        if(!GameManager.instance.input.isSlow && getWater) //물을 들고 있는가? 이게 중간에 속도 느린거 풀리면 물 들고있는거 없애는 거
        {
            getWater = false;
            Debug.Log("1");
        }

        if (time > UnityEngine.Random.Range(3, 10))
        {
            Debug.Log("1");
            panel.SetActive(true);
            skill.BossCheck();
            time = 0;
        }
    }

    public void StopFire() //불 꺼
    {
        Fire.gameObject.SetActive(false);
    }

    public void HandFucntion() //빨간 천 부시기 이거 쓰면 빨간 천 부시는거
    {
        if (getWater && GameManager.instance.input.isSlow && isRed) //이 부분 물에
        { 
            Destroy(red);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tree")) //나무에 닿았을때 휘두르면 브로큰이 트루가 된다
        {
            isBroken = true;
        }

        if (collision.gameObject.CompareTag("fire")) //닿으면 불이 나온다 아잇 어
        {
            Debug.Log("나와라");
            if (Fire != null && !isFired)
            {
                Fire.gameObject.SetActive(true);
                Invoke("StopFire", 5);
            }
        }

        if(collision.gameObject.CompareTag("red"))
        {
            isRed = true;
        }

        if (collision.gameObject.CompareTag("blue"))
        {
            getAxetwo = true;
        }

        if(collision.gameObject.CompareTag("yellow"))
        {
            isYellow = true;
        }

        if (collision.gameObject.CompareTag("sike"))//텔레포트 검은 구덩이
        {
            GameManager.instance.input.isDownArrow = true;
        }

        if(collision.gameObject.CompareTag("Tel"))
        {
            isMove = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tree")) //나무에서 떨어지몀ㄴ? 아무일도 안일어남 밑도 마찬가지임
        {
            isBroken = false;
        }

        if(collision.gameObject.CompareTag("red"))
        {
            isRed = false;
        }

        if (collision.gameObject.CompareTag("blue"))
        {
            getAxetwo = false;
        }

        if (collision.gameObject.CompareTag("yellow"))
        {
            isYellow = false;
        }

        if (collision.gameObject.CompareTag("sike"))//텔레포트 검은 구덩이
        {
            GameManager.instance.input.isDownArrow = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("water")) //웅덩이에 닿으면 된다 웅덩이에 닿으면 물받기 활성화
        {
            Debug.Log("물을 받음");
            getWater = true;
        }
    }
}
