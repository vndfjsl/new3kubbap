using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    public static Save instace;

    private void Awake()
    {
        if(instace != null)
        {
            Debug.LogError("중복중복");
        }
        instace = this;
    }
    void Start()
    { 
        GameInfo_load();
        DontDestroyOnLoad(this);
    }

   
    void OnDisable()
    {
        GameInfo_save(); 
    }

    public int stageNumber = 0;      //클리어한 스테이지 번호. 1,2,3,4,5      public void GameInfo_load()     {         //string v = PlayerPrefs.GetString( "game_info", "default");         stageClear = PlayerPrefs.GetInt("stageClear", 0);     }     public void GameInfo_save()     {         //PlayerPrefs.SetString("game_info", " ");         PlayerPrefs.SetInt("stageClear", stageClear);         PlayerPrefs.Save();  

    private void Update()
    {
        if(stageNumber == 1)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void GameInfo_load()
    {          //string v = PlayerPrefs.GetString( "game_info", "default"); ?/
        stageNumber = PlayerPrefs.GetInt("stageNum", stageNumber);
    }

    public void GameInfo_save()
    {         //PlayerPrefs.SetString("game_info", " ");
        PlayerPrefs.SetInt("stageNum", stageNumber); PlayerPrefs.Save();  //By default Unity writes preferences to disk during OnApplicationQuit()     }
    }
}
