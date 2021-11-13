using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    // import(외부에서)



    // export(외부로)

    public int dialogCode;

    // inner(내부값)

    /// <summary>false = 읽은 dialog, 읽기 x</summary>
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