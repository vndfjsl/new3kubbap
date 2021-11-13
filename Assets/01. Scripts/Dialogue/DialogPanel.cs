using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DialogPanel : MonoBehaviour
{
    // import(�ܺο���)

    public Image dialogProfileImage;
    public TMP_Text dialogText;





    // export(�ܺη�)










    // inner(���ΰ�)

    private List<TextVO> textList;
    private RectTransform panelTrm;
    private RectTransform textTransform;
    private WaitForSeconds typingspeedWs = new WaitForSeconds(0.2f);
    private Dictionary<int, Sprite> profileDictionary =
        new Dictionary<int, Sprite>();

    [SerializeField] private bool isShowNextText = false; // �������� �Ѱܵ��ȴ�
    [SerializeField] private bool isShow = false;
    private int currentIndex; // ���� ��ȭ index

    private Action DialogEnd = null;

    private void Awake()
    {
        panelTrm = GetComponent<RectTransform>();
        textTransform = dialogText.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (!isShow) return; // �̹� â�� ���������� x

        if(Input.GetKeyDown(KeyCode.Space) && isShowNextText) // Typing �������� + �����̽� ������
        {
            // Count = 3�̶�� ġ�� index = 0~2 -> 3�̻��̸� ��ȭâ ����(���ðԾ���)
            if(currentIndex >= textList.Count)
            {
                // �г� off(scale 0)
                panelTrm.DOScale(new Vector3(0, 0, 1), 0.8f).OnComplete(() =>
                {
                    GameManager.TimeScale = 1f;
                    isShow = false;
                    if (DialogEnd != null) // ���� �̺�Ʈ�� ������ ����
                    {
                        DialogEnd();
                    }
                });
            }
            else // �ƴϴ�! ���� �Ҹ��� ���Ҵ�!
            {
                Typing(textList[currentIndex]);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space)) // ��ȭ�� �ȳ������� ��ŵ�� ������!
        {
            isShowNextText = true; // �������� �Ѱܵ� �ȴ�
        }
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

        // �г� on(scale 0)
        panelTrm.DOScale(new Vector3(1, 1, 1), 0.8f).OnComplete(() =>
        {
            Typing( textList[currentIndex] );
            
            isShow = true;
        });
    }

    public void Typing(TextVO dialog)
    {
        int index = dialog.icon;
        if (!profileDictionary.ContainsKey(index)) // �������� �ȵ�������
        {
            // Resources ������ profile(index) ��� �̸��� �������� ã�Ƽ�
            Sprite profile = Resources.Load<Sprite>($"profile{index}");
            profileDictionary.Add(index, profile); // �ְ�
        }

        dialogProfileImage.sprite = profileDictionary[index]; // �г� ������ ��ü

        dialogText.text = dialog.msg;
        isShowNextText = false; // ��ŵ������ true��
        StartCoroutine(TypingProcess());
    }

    private IEnumerator TypingProcess() // �ѹ�������� ������Ÿ�ٴ��� yield return
    {
        dialogText.ForceMeshUpdate();
        dialogText.maxVisibleCharacters = 0;

        int totalVisibleChar = dialogText.textInfo.characterCount; // ���� ȭ�鿡���� ���ڼ�
        for(int i=1; i<=totalVisibleChar; i++)
        {
            dialogText.maxVisibleCharacters = i;

            if(isShowNextText) // ��ŵ������ �޽��� �ٶ�(��ŵ�� Space)
            {
                dialogText.maxVisibleCharacters = totalVisibleChar; // �޽��� Ǯ��¡
                break;
            }
            yield return typingspeedWs;
        } // for�� ����� �ؽ�Ʈ �ٳ��°���(yield return���� ���ݾ�����)
        currentIndex++; // �����ؽ�Ʈ
        isShowNextText = true;
    }
}
