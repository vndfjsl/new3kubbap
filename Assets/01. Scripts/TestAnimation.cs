using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestAnimation : MonoBehaviour
{
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Fun();
        }
    }

    private void Fun()
    {
        sr.DOFade(1, 0.5f);
    }
}
