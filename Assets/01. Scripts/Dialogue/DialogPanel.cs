using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogPanel : MonoBehaviour
{
    // import(외부에서)

    public GameObject nextDialogButton;
    public GameObject typingEffect;
    public Image dialogProfileImage;
    public AudioClip typingClip;
    public Text dialogText;





    // export(외부로)










    // inner(내부값)

    private List<TextVO> textList;
    private RectTransform rectTrm;
    private RectTransform textTransform;
    private WaitForSeconds typingspeedws = new WaitForSeconds(0.2f);
    private Dictionary<int, Sprite> proflieDictionary =
        new Dictionary<int, Sprite>();

    private bool isNextOn = false;
    private bool isShow = false;
    private int currentIndex; // 현재 대화 index

    private Action DialogEnd = null;

    private void Awake()
    {
        rectTrm = GetComponent<RectTransform>();
        textTransform = dialogText.GetComponent<RectTransform>();
    }

    public void StartDialog(List<TextVO> list, Action callback = null)
    {
        DialogEnd = callback;
        this.textList = list;
        ShowDialog();
    }

    public void ShowDialog()
    {
        currentIndex = 0;
        GameManager.TimeScale = 0; // 대화진행중엔 플레이정지

        rectTrm.DOScale(new Vector3(1, 1, 1), 0.8f).OnComplete(() =>
        {
            Typing( textList[currentIndex] );
            isShow = true;
        });
    }

    public void Typing(TextVO dialog)
    {
        int index = dialog.icon;
        if(!proflieDictionary.ContainsKey(index)) // 저장한 프로필들에 없으면
        {
            // Resources 폴더의 proflie(index) 라는 이름을 가진놈을 찾아서
            Sprite profile = Resources.Load($"proflie{index}") as Sprite;
            proflieDictionary.Add(index, profile); // 넣고
        }

        dialogProfileImage.sprite = proflieDictionary[index]; // 패널 프로필 교체

        dialogText.text = dialog.msg;
        nextDialogButton.SetActive(false);
        isNextOn = false; // 안끝났어ㅓ
        StartCoroutine(TypingProcess());
    }

    private IEnumerator TypingProcess()
    {
        // TODO
        yield return null;
    }
}
