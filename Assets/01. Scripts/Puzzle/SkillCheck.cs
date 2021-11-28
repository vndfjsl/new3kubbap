//김예리나
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillCheck : MonoBehaviour
{

    public Image fillImage;
    public Image check;
    public bool checkStart = false;
    public bool checkComplete = false;
    private int successed =0;
    private int failed = 0;
    public Image a;
    public Image b;
    private float checkAmount = 0.4f; // 1=100% 0.1=10% 범위크
    private float checkAmountTwo = 0.1f;

    private float fillImageWidth; //는 정보를 가져오는 사각형이다.

    public GameObject treeObj;
    void Start()
    {
        //CircleFunctionStart();

        fillImageWidth = fillImage.rectTransform.rect.width; //필이미지의 정보를 가져온다. 길이를
    }

    private void Update()
    {
        if (checkStart)
        {
            a.rectTransform.anchoredPosition = new Vector2(check.rectTransform.anchoredPosition.x - check.rectTransform.rect.width /2, a.rectTransform.anchoredPosition.y);
            b.rectTransform.anchoredPosition = new Vector2(check.rectTransform.anchoredPosition.x, a.rectTransform.anchoredPosition.y);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                checkComplete = true;
                checkStart = false;
                //// 범위안에들어오면
                //Debug.Log(check.transform.localPosition.x);
                //Debug.Log(fillImage.rectTransform.rect.width);


                float fillPosition = fillImageWidth * fillImage.fillAmount; // 사각형 길이에다가 필이미지의 그 체크할 ㄱ그걸 곱한다.
                if (fillPosition >= check.rectTransform.anchoredPosition.x - check.rectTransform.rect.width /2 //포지션은 체크이미지빼기 길이보다 크고 체크이미지보다 작거나 같다.
                    && fillPosition <= check.rectTransform.anchoredPosition.x)
                {
                    // 성공 처리
                    //Debug.Log("Success");
                    Destroy(treeObj.gameObject);
                    GameManager.instance.col.panel.SetActive(false);
                    fillImage.fillAmount = 0;
                    Debug.Log("Success");
                    successed++;
                }
                else //실패처리
                {
                    //Debug.Log("Fail"); 
                    GameManager.instance.col.panel.SetActive(false);
                    fillImage.fillAmount = 0;
                    Debug.Log("Fail");
                }

                

            }

            if (fillImage.fillAmount < 1f && checkStart) // 게이지가 차는것
            {
                fillImage.fillAmount += Time.deltaTime / 2;
            }

            if(successed ==7)//엔딩이 나뉘는 것
            {
                SceneManager.LoadScene(4);
            }

            if(failed == 10)
            {
                SceneManager.LoadScene(3);
            }
        }
    }

    public void CircleFunctionStart(GameObject obj) //나무와 닿았을때 나오는 스킬체크 함수
    {
        check.gameObject.SetActive(true);
        checkStart = true;
        treeObj = obj;
        check.fillAmount = checkAmount;

        float x = Random.Range(163, fillImageWidth);//200에서 앵커포지션까지 중에서 구함.
                                                    //Debug.Log(x);

        check.transform.localPosition = new Vector3(x, 0, 0);
    }

    public void BossCheck() //상시로 랜덤으로 뜨는 스킬체크 함수
    {
        check.gameObject.SetActive(true);

        check.fillAmount = checkAmountTwo;
        Debug.Log(fillImageWidth);
        float x = Random.Range(163, fillImageWidth);//200에서 앵커포지션까지 중에서 구함.

        check.rectTransform.anchoredPosition = new Vector2(x, 0);
        //Debug.Log("position : " + check.transform.position.x);
        checkStart = true;
    }
}
