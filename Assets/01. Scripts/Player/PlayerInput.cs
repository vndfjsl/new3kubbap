using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // 해당항목들은 Project Settings - Input Manager에 등록되어 있음
    public float xMove { get; private set; }
    public bool isGet { get; private set; }
    public bool isUse { get; private set; }
    public bool isOpenInven { get; private set; }

    void Update()
    {
        if(GameManager.TimeScale <= 0) // 게임시간 멈춰놓을때
        {
            xMove = 0;
            isGet = false;
            isUse = false;
            isOpenInven = false;
            return;
        }

        xMove = Input.GetAxisRaw("Horizontal");
        isGet = Input.GetButtonDown("Get");
        isUse = Input.GetButtonDown("Use");
        isOpenInven = Input.GetButtonDown("Inven");
    }
}
