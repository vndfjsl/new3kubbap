//김예리나
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tiger : MonoBehaviour
{
    public GameObject tiger;
    public float tigetSpeed = 0.5f;
    [SerializeField] private float time = 0;
    public GameObject panel;
    public SkillCheck skill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.TimeScale == 0) return;
        tiger.transform.Translate(Vector3.right * tigetSpeed * Time.deltaTime); //오른쪽으로 이동
        time += Time.deltaTime;

        if (time > Random.Range(3, 10))
        {
            if (panel != null) panel.SetActive(true);
            if (skill != null) skill.BossCheck();
            time = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PLAYER"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
