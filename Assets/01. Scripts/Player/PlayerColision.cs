using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColision : MonoBehaviour
{
    public GameObject tree;
    public GameObject Fire; //�����ϴ� ��ü
    public bool isBroken = false;
    public bool isFired = false;
    public bool getWater = false;
    public bool isRed = false;
    public bool getAxetwo = false;
    public bool isYellow = false;
    public bool isMove = false;
    public bool isMoveTwo = false;
    public bool isMoveThree = false;
    public bool loadScene = false;
    public bool isSike = false; //������ ��� �ִ��� üũ�ϴ� �ҿ����ڵ�
    public int digCount = 0; //���� ����
    private PlayerAnimation anim; //�ִϸ��̼�
    public GameObject blue;
    public GameObject red;
    public GameObject yellow;
    public GameObject sky_one;
    public GameObject sky_two;
    public GameObject panel;
    public SkillCheck skill;
    public GameObject a;

    private void Awake()
    {
        anim = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        if (digCount > 2) //3�� �̻� ������ ������ �μ���
        {
            tree.SetActive(false);
            //SceneManager.LoadScene(2);
        }

        if (!GameManager.instance.input.isSlow && getWater) //���� ��� �ִ°�? �̰� �߰��� �ӵ� ������ Ǯ���� �� ����ִ°� ���ִ� ��
        {
            getWater = false;
            anim.WaterAction(false);
            DialogManager.ShowDialog(12);
        }
    }

    public void StopFire() //���� ����
    {
        Fire.gameObject.SetActive(false);
        a.SetActive(true);
    }

    public void HandFucntion() //���� õ �νñ� �̰� ���� ���� õ �νô°�
    {
        if (getWater && GameManager.instance.input.isSlow && isRed) //�� �κ� ����
        {
            Destroy(red);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tree")) //������ ������� �ֵθ��� ���ū�� Ʈ�簡 �ȴ� �׸��� ���⼭ ��ȣ�ۿ��ϸ� ������ �μ��� �� �ִ�
        {
            isBroken = true;
            Debug.Log("2");
        }

        if (collision.gameObject.CompareTag("fire")) //������ ���� ���´�
        {
            Debug.Log("���Ͷ�");
            if (Fire != null && !isFired)
            {
                Fire.gameObject.SetActive(true);
                DialogManager.ShowDialog(5);
                Invoke("StopFire", 5);
            }
        }

        if (collision.gameObject.CompareTag("red")) //����õ�� ����ִ�
        {
            isRed = true;
        }

        if (collision.gameObject.CompareTag("blue"))//�Ķ�õ�� ����ִ�
        {
            getAxetwo = true;
            Debug.Log("1");
        }

        if (collision.gameObject.CompareTag("yellow")) //���õ�� ����ִ�
        {
            isYellow = true;
        }

        if (collision.gameObject.CompareTag("sike"))//�ڷ���Ʈ ���� ������
        {
            isSike = true;
            panel.SetActive(true);
            skill.CircleFunctionStart(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Tel")) //���� ����� �̵�
        {
            isMove = true;

        }

        if (collision.gameObject.CompareTag("Tell"))
        {
            isMoveTwo = true;

        }
        if (collision.gameObject.CompareTag("Telll"))
        {
            isMoveThree = true;

        }
        if (collision.gameObject.CompareTag("Tellll"))
        {
            loadScene = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tree")) //�������� ��������? �ƹ��ϵ� ���Ͼ �ص� ����������
        {
            isBroken = false;
        }

        if (collision.gameObject.CompareTag("red"))
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

        if (collision.gameObject.CompareTag("sike"))//�ڷ���Ʈ ���� ������
        {
            isSike = false;
        }

        if (collision.gameObject.CompareTag("Tel"))
        {
            isMove = false;

        }

        if (collision.gameObject.CompareTag("Tell"))
        {
            isMoveTwo = false;

        }

        if (collision.gameObject.CompareTag("Telll"))
        {
            isMoveThree = false;

        }

        if (collision.gameObject.CompareTag("Tellll"))
        {
            loadScene = false;

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("water")) //�����̿� ������ �ȴ� �����̿� ������ ���ޱ� Ȱ��ȭ
        {
            getWater = true;
        }
    }
}
