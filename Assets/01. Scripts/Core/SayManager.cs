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


    public TypingEffect typing;
    public GameObject sayObj;
    public bool show;
    public int sayIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Say(int id, bool npc)
    {
        //string sayData = "";
        //if (say.isAni)
        //{
        //    say.setMsg("");
        //    return;
        //}
        //else
        //{
        //    sayData = sayManager.GetSay(id, sayIndex);
        //}



        //if (sayData == null)
        //{
        //    show = false;
        //    sayIndex = 0;
        //    return;
        //}

        //if (npc)
        //{
        //    say.setMsg(sayData.Split(':')[0]);
        //}
        //else
        //{
        //    say.setMsg(sayData);
        //}

        //show = true;
        //sayIndex++;
    }
}
