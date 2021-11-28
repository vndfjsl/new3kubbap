//�迹����
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
    private float checkAmount = 0.4f; // 1=100% 0.1=10% ����ũ
    private float checkAmountTwo = 0.1f;

    private float fillImageWidth; //�� ������ �������� �簢���̴�.

    public GameObject treeObj;
    void Start()
    {
        //CircleFunctionStart();

        fillImageWidth = fillImage.rectTransform.rect.width; //���̹����� ������ �����´�. ���̸�
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
                //// �����ȿ�������
                //Debug.Log(check.transform.localPosition.x);
                //Debug.Log(fillImage.rectTransform.rect.width);


                float fillPosition = fillImageWidth * fillImage.fillAmount; // �簢�� ���̿��ٰ� ���̹����� �� üũ�� ���װ� ���Ѵ�.
                if (fillPosition >= check.rectTransform.anchoredPosition.x - check.rectTransform.rect.width /2 //�������� üũ�̹������� ���̺��� ũ�� üũ�̹������� �۰ų� ����.
                    && fillPosition <= check.rectTransform.anchoredPosition.x)
                {
                    // ���� ó��
                    //Debug.Log("Success");
                    Destroy(treeObj.gameObject);
                    GameManager.instance.col.panel.SetActive(false);
                    fillImage.fillAmount = 0;
                    Debug.Log("Success");
                    successed++;
                }
                else //����ó��
                {
                    //Debug.Log("Fail"); 
                    GameManager.instance.col.panel.SetActive(false);
                    fillImage.fillAmount = 0;
                    Debug.Log("Fail");
                }

                

            }

            if (fillImage.fillAmount < 1f && checkStart) // �������� ���°�
            {
                fillImage.fillAmount += Time.deltaTime / 2;
            }

            if(successed ==7)//������ ������ ��
            {
                SceneManager.LoadScene(4);
            }

            if(failed == 10)
            {
                SceneManager.LoadScene(3);
            }
        }
    }

    public void CircleFunctionStart(GameObject obj) //������ ������� ������ ��ųüũ �Լ�
    {
        check.gameObject.SetActive(true);
        checkStart = true;
        treeObj = obj;
        check.fillAmount = checkAmount;

        float x = Random.Range(163, fillImageWidth);//200���� ��Ŀ�����Ǳ��� �߿��� ����.
                                                    //Debug.Log(x);

        check.transform.localPosition = new Vector3(x, 0, 0);
    }

    public void BossCheck() //��÷� �������� �ߴ� ��ųüũ �Լ�
    {
        check.gameObject.SetActive(true);

        check.fillAmount = checkAmountTwo;
        Debug.Log(fillImageWidth);
        float x = Random.Range(163, fillImageWidth);//200���� ��Ŀ�����Ǳ��� �߿��� ����.

        check.rectTransform.anchoredPosition = new Vector2(x, 0);
        //Debug.Log("position : " + check.transform.position.x);
        checkStart = true;
    }
}
