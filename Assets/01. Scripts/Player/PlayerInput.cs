using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    // �ش��׸���� Project Settings - Input Manager�� ��ϵǾ� ����
    public float xMove { get; private set; }
    public bool isGet { get; private set; }
    public bool isUse { get; private set; }
    public bool isOpenInven { get; private set; }
    public bool isMouseTouch { get; private set; }
    public bool isSlow { get; private set; }
    public bool isSkip { get; private set; }

    public bool isDownArrow = false;
    public static int Tigermeeting = 0;
    private Vector2 twoVer = new Vector2(190, -2.37f);
    private Vector2 tigerPoint = new Vector2(249, -2.37f);
    private Vector2 first = new Vector2(59.93f, 0);
    private Vector2 Two = new Vector2(188, 0);
    private Vector2 Three = new Vector2(318, 0);
    private Vector2 playerPosition;

    void Update()
    {
        if(GameManager.TimeScale <= 0) // ���ӽð� ���������
        {
            xMove = 0;
            isGet = false;
            isUse = false;
            isOpenInven = false;
            isMouseTouch = false;
            isSlow = false;
            isSkip = false;
            return;
        }

        xMove = Input.GetAxisRaw("Horizontal");
        isGet = Input.GetButtonDown("Get");
        isUse = Input.GetButtonDown("Use");
        isOpenInven = Input.GetButtonDown("Inven");
        isMouseTouch = Input.GetMouseButtonDown(0);
        isSlow = Input.GetButton("Slow");
        isSkip = Input.GetButtonDown("Skip");

        if (Input.GetKeyDown(KeyCode.DownArrow))  // �̷κκ��� �Ʒ�Ű ������ �ٸ� ������ �̵��ϴ°�
        {
            //if (isDownArrow)
            //{
            //    Debug.Log("�̵����̵�");
            //    playerPosition = twoVer;
            //    transform.position = playerPosition;
            //}

            if(GameManager.instance.col.isMove)
            {
                playerPosition = first;
                transform.position = playerPosition;
                GameManager.instance.col.sky_one.SetActive(false);
                GameManager.instance.col.sky_two.SetActive(true);
            }

            if (GameManager.instance.col.isMoveTwo)
            {
                playerPosition = Two;
                transform.position = playerPosition;
            }

            if (GameManager.instance.col.isMoveThree)
            {
                playerPosition = Three;
                transform.position = playerPosition;
            }

            if(GameManager.instance.col.loadScene)
            {
                SceneManager.LoadScene(2);
                Invoke("Delay", 3f);
                Debug.Log(Tigermeeting);
            }
        }
    }

    private void Delay()
    {
        Tigermeeting++;
    }
}
