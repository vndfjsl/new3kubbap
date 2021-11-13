using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    // import(�ܺο���)



    // export(�ܺη�)

    public int dialogCode;

    // inner(���ΰ�)

    /// <summary>false = ���� dialog, �б� x</summary>
    private bool isRead = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isRead) return;

        if(collision.gameObject.CompareTag("PLAYER"))
        {
            isRead = true;
            DialogManager.ShowDialog(dialogCode);
        }
    }
}