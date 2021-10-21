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
    public bool show;
    public int sayIndex;
    Dictionary<int, string[]> sayData;

    // Start is called before the first frame update
    void Start()
    {
        sayData = new Dictionary<int, string[]>();
        GeData();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            show = false;
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

        show = true;
        sayIndex++;
    }

    public void Action(GameObject scanObj)
    {
        sObj = scanObj;
        objData objData = sObj.GetComponent<objData>();
        Say(objData.id, objData.npc);
        sayPanel.SetBool("isShow", show);
    }
}
