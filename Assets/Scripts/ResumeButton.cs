using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    Button btn;
    // Start is called before the first frame update
    void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(DisableCursor);
    }

    void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; //lock cursor
        Cursor.visible = false;
    }
}
