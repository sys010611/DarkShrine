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
        for (byte i = 0; i < 255; i++)
        {
            image.color = new Color32(0, 0, 0, i);
            yield return new WaitForSeconds(0.001f);
        }
        SceneManager.LoadScene("Intro");
    }
}
