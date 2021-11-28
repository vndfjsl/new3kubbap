//ø¿πŒ±‘
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;// ΩÃ±€≈Ê
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null) return;
        instance = this;

        TextAsset dJson = Resources.Load("dialogText") as TextAsset;
    }

    private float timeScale;
    public PlayerColision col;
    public PlayerInput input;
    public static float TimeScale
    {
        get { return instance.timeScale; }
        set { instance.timeScale = Mathf.Clamp(value, 0, 1); }
    }



    void Start()
    {
        TimeScale = 1;
    }
}
