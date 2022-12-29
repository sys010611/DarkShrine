using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    Image image;

    // Start is called before the first frame update
    void Awake()
    {
        image = transform.GetChild(2).GetComponent<Image>();
        Cursor.visible= true;
        Cursor.lockState = CursorLockMode.None;
        image.CrossFadeAlpha(0f, 1f, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("ToTitle");
        }
    }

    IEnumerator ToTitle()
    {
        image.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Intro");
    }
}
