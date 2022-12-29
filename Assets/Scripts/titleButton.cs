using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class titleButton : MonoBehaviour
{
    Button btn;

    // Start is called before the first frame update
    void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ToTitle);
    }

    void ToTitle()
    {
        SceneManager.LoadScene("Intro");
    }
}
