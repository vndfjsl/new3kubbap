using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogPanel : MonoBehaviour
{
    // import(�ܺο���)

    public GameObject nextDialogButton;
    public GameObject typingEffect;
    public Image dialogProfileImage;
    public AudioClip typingClip;
    public Text dialogText;





    // export(�ܺη�)










    // inner(���ΰ�)

    private List<TextVO> textList;
    private RectTransform rectTrm;
    private RectTransform textTransform;
    private WaitForSeconds typingspeedws = new WaitForSeconds(0.2f);
    private Dictionary<int, Sprite> proflieDictionary =
        new Dictionary<int, Sprite>();

    private bool isNextOn = false;
    private bool isShow = false;
    private int currentIndex; // ���� ��ȭ index

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
        GameManager.TimeScale = 0; // ��ȭ�����߿� �÷�������

        rectTrm.DOScale(new Vector3(1, 1, 1), 0.8f).OnComplete(() =>
        {
            Typing( textList[currentIndex] );
            isShow = true;
        });
    }

    public void Typing(TextVO dialog)
    {
        int index = dialog.icon;
        if(!proflieDictionary.ContainsKey(index)) // ������ �����ʵ鿡 ������
        {
            // Resources ������ proflie(index) ��� �̸��� �������� ã�Ƽ�
            Sprite profile = Resources.Load($"proflie{index}") as Sprite;
            proflieDictionary.Add(index, profile); // �ְ�
        }

        dialogProfileImage.sprite = proflieDictionary[index]; // �г� ������ ��ü

        dialogText.text = dialog.msg;
        nextDialogButton.SetActive(false);
        isNextOn = false; // �ȳ������
        StartCoroutine(TypingProcess());
    }

    private IEnumerator TypingProcess()
    {
        // TODO
        yield return null;
    }
}
