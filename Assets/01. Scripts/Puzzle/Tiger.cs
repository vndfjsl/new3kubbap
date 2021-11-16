using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tiger : MonoBehaviour
{
    public GameObject tiger;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiger.transform.Translate(Vector3.right * 0.005f); //오른쪽으로 이동
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PLAYER"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
