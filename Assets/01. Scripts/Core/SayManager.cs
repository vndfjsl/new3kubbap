using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayManager : MonoBehaviour
{
    public static SayManager instance;
    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    public Animator sayPanel;
    public TypingEffect say;
    public GameObject sObj;
    public bool isTextReading;
    public int sayIndex;
    Dictionary<int, string[]> sayData;

    // Start is called before the first frame update
    void Start()
    {
        sayData = new Dictionary<int, string[]>();
        GeData();
    }

    void GeData()
    {
        sayData.Add(1, new string[] { "테스트 대사입니다.", "변하지 않는 마음이라는 건", "권태를 면하는 단순한 방법" });
        sayData.Add(10, new string[] { "" });
    }

    public string GetSay(int id, int sayIndex)
    {
        if (sayIndex == sayData[id].Length)
            return null;

        else
            return sayData[id][sayIndex];
    }
    public void Say(int id, bool npc)
    {
        string sayData = "";
        if (say.isAni)
        {
            say.setMsg("");
            return;
        }
        else
        {
            sayData = GetSay(id, sayIndex);
        }



        if (sayData == null)
        {
            isTextReading = false;
            sayIndex = 0;
            return;
        }

        if (npc)
        {
            say.setMsg(sayData.Split(':')[0]);
        }
        else
        {
            say.setMsg(sayData);
        }

        isTextReading = true;
        sayIndex++;
    }

    public void Action(GameObject scanObj)
    {
        sObj = scanObj;
        objData objData = sObj.GetComponent<objData>();
        Say(objData.id, objData.npc);
        sayPanel.SetBool("isShow", isTextReading);
    }
}
