using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public PlayerInput input;
    public LayerMask whatIsSlot;

    private void Update()
    {
        if (input.isMouseTouch)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            pos.z = 0;

            Collider2D col = Physics2D.OverlapCircle(pos, 0.5f, whatIsSlot);

            if(col != null)
            {
                Slot s = col.gameObject.GetComponent<Slot>();
                if (s != null) s.OnMouseDown();
                Debug.Log(col.gameObject.name);
            }
        }
    }
}
