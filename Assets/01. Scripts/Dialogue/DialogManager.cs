//오민규
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    // import(외부에서)

    public DialogPanel dialogPanel;


    // export(외부로)

    public static DialogManager instance;

    // inner(내부값)

    private Dictionary<int, List<TextVO>> dialogTextDictionary =
        new Dictionary<int, List<TextVO>>();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        TextAsset textJsonFile = Resources.Load("dialogText") as TextAsset;
        GameTextDataVO textData = JsonUtility.FromJson<GameTextDataVO>(textJsonFile.ToString());

        foreach (DialogVO dialog in textData.list)
        {
            dialogTextDictionary.Add(dialog.code, dialog.text);
        }
    }

    public static void ShowDialog(int codeIndex, Action callback = null) //델리게이트 콜백
    {
        // (x번째로 저장된 텍스트 >= 저장된 텍스트 수) = 버그
        if (codeIndex >= instance.dialogTextDictionary.Count) return;

        instance.dialogPanel.StartDialog(instance.dialogTextDictionary[codeIndex], callback);
    }
}
