using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DialogPanel : MonoBehaviour
{
    // import(외부에서)

    public Image dialogProfileImage;
    public TMP_Text dialogText;





    // export(외부로)










    // inner(내부값)

    private List<TextVO> textList;
    private RectTransform panelTrm;
    private RectTransform textTransform;
    private WaitForSeconds typingspeedWs = new WaitForSeconds(0.2f);
    private Dictionary<int, Sprite> profileDictionary =
        new Dictionary<int, Sprite>();

    [SerializeField] private bool isShowNextText = false; // 다음으로 넘겨도된다
    [SerializeField] private bool isShow = false;
    private int currentIndex; // 현재 대화 index

    private Action DialogEnd = null;

    private void Awake()
    {
        panelTrm = GetComponent<RectTransform>();
        textTransform = dialogText.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (!isShow) return; // 이미 창이 열려있으면 x

        if(Input.GetKeyDown(KeyCode.Space) && isShowNextText) // Typing 끝났으면 + 스페이스 누르면
        {
            // Count = 3이라고 치면 index = 0~2 -> 3이상이면 대화창 종료(나올게없음)
            if(currentIndex >= textList.Count)
            {
                // 패널 off(scale 0)
                panelTrm.DOScale(new Vector3(0, 0, 1), 0.8f).OnComplete(() =>
                {
                    GameManager.TimeScale = 1f;
                    isShow = false;
                    if (DialogEnd != null) // 종료 이벤트가 있으면 실행
                    {
                        DialogEnd();
                    }
                });
            }
            else // 아니다! 아직 할말이 남았다!
            {
                Typing(textList[currentIndex]);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space)) // 대화는 안끝났지만 스킵만 눌렀다!
        {
            isShowNextText = true; // 다음으로 넘겨도 된다
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
        GameManager.TimeScale = 0; // 대화진행중엔 플레이정지

        // 패널 on(scale 0)
        panelTrm.DOScale(new Vector3(1, 1, 1), 0.8f).OnComplete(() =>
        {
            Typing( textList[currentIndex] );
            
            isShow = true;
        });
    }

    public void Typing(TextVO dialog)
    {
        int index = dialog.icon;
        if (!profileDictionary.ContainsKey(index)) // 프로필이 안들어가있으면
        {
            // Resources 폴더의 profile(index) 라는 이름을 가진놈을 찾아서
            Sprite profile = Resources.Load<Sprite>($"profile{index}");
            profileDictionary.Add(index, profile); // 넣고
        }

        dialogProfileImage.sprite = profileDictionary[index]; // 패널 프로필 교체

        dialogText.text = dialog.msg;
        isShowNextText = false; // 스킵누르면 true됨
        StartCoroutine(TypingProcess());
    }

    private IEnumerator TypingProcess() // 한번만실행됨 여러번타다닥은 yield return
    {
        dialogText.ForceMeshUpdate();
        dialogText.maxVisibleCharacters = 0;

        int totalVisibleChar = dialogText.textInfo.characterCount; // 지금 화면에나온 글자수
        for(int i=1; i<=totalVisibleChar; i++)
        {
            dialogText.maxVisibleCharacters = i;

            if(isShowNextText) // 스킵누르면 메시지 다뜸(스킵은 Space)
            {
                dialogText.maxVisibleCharacters = totalVisibleChar; // 메시지 풀차징
                break;
            }
            yield return typingspeedWs;
        } // for문 벗어나면 텍스트 다나온거임(yield return으로 조금씩나옴)
        currentIndex++; // 다음텍스트
        isShowNextText = true;
    }
}
