//���α�
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public CanvasGroup startCG;
    private float alphas = 1;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SkipStartScene", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        alphas = Mathf.Clamp(alphas - Time.deltaTime / 3, 0, 1);
        startCG.alpha = alphas;
    }

    public void SkipStartScene() //���ξ����� �Ѿ
    {
        SceneManager.LoadScene(1);
        Save.instace.stageNumber = 1;
    }
}
