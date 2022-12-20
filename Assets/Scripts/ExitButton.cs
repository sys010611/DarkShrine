using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    Button btn;

    void Awake()
    {
        btn = this.GetComponent<Button>();

        if (btn != null)
        {
            btn.onClick.AddListener(CloseGame);
        }
    }

    void CloseGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // 어플리케이션 종료
        #endif
    }

}
