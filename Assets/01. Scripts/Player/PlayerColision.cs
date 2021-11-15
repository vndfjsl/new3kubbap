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
    public int digCount = 0;
    private PlayerMove move;
    public GameObject blue;
    public GameObject red;
    public GameObject yellow;

    private void Update()
    {
        if (digCount > 2) //3�� �̻� �ĸ����� ������ �μ�����
        {
            tree.SetActive(false);
            //SceneManager.LoadScene(2);
        }

        if (!GameManager.instance.move.isSlow && getWater) //���� ��� �ִ°�? �̰� �߰��� �ӵ� ������ Ǯ���� �� ����ִ°� ���ִ� ��
        {
            getWater = false;
        }
    }

    public void StopFire() //�� ��
    {
        Fire.gameObject.SetActive(false);
    }

    public void HandFucntion() //���� õ �νñ� �̰� ���� ���� õ �νô°�
    {
        if (getWater && GameManager.instance.move.isSlow) //�� �κ� ����
        {
            Destroy(red);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tree")) //������ ������� �ֵθ��� ���ū�� Ʈ�簡 �ȴ�
        {
            isBroken = true;
        }

        if (collision.gameObject.CompareTag("fire")) //������ ���� ���´� ���� ��
        {
            Debug.Log("���Ͷ�");
            if (Fire != null && !isFired)
            {
                Fire.gameObject.SetActive(true);
                Invoke("StopFire", 5);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tree")) //�������� �������m��? �ƹ��ϵ� ���Ͼ �ص� ����������
        {
            isBroken = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("water")) //�����̿� ������ �ȴ� �����̿� ������ ���ޱ� Ȱ��ȭ
        {
            Debug.Log("���� ����");
            getWater = true;
        }
    }
}
