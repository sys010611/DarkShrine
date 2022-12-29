using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlayButton : MonoBehaviour
{
    Button btn;

    void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        btn = GetComponent<Button>();

        if (btn != null)
        { 
            btn.onClick.AddListener(SceneLoad);
        }
    }

    // Update is called once per frame
    void SceneLoad()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("InGame");
    }
}
