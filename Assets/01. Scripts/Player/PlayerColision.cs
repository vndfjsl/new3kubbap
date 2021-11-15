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
        if (digCount > 2) //3�� �̻� �ĸ����� ������ �μ�����
        {
            tree.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tree")) //������ ������� �ֵθ��� ���ū�� Ʈ�簡 �ȴ�
        {
            isBroken = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tree")) //�������� �������m��? �ƹ��ϵ� ���Ͼ �ص� ����������
        {
            isBroken = false;
        }
    }
}
