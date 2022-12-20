using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Player player;
    Transform bells;
    GameObject bell1;
    GameObject bell2;
    GameObject bell3;
    Text barrierDisabled;
    Text [] texts;

    // Start is called before the first frame update
    void Awake()
    {
        bells = transform.GetChild(0);
        bell1 = bells.GetChild(0).gameObject;
        bell2 = bells.GetChild(1).gameObject;
        bell3 = bells.GetChild(2).gameObject;

        texts = GetComponentsInChildren<Text>();   
    }

    void Start()
    {
        texts[4].color = new Color(1, 1, 1, 1);
        StartCoroutine("StartMessageFadeOut", texts[4]);
    }

    public void BellCountChanged()
    {
        if (player._AttainedBellCount == 0)
        {
            bell1.SetActive(false);
            bell2.SetActive(false);
            bell3.SetActive(false);
        }

        else if (player._AttainedBellCount == 1)
        {
            bell1.SetActive(true);
            bell2.SetActive(false);
            bell3.SetActive(false);
        }

        else if (player._AttainedBellCount == 2)
        {
            bell1.SetActive(true);
            bell2.SetActive(true);
            bell3.SetActive(false);
        }

        else if (player._AttainedBellCount == 3)
        {
            bell1.SetActive(true);
            bell2.SetActive(true);
            bell3.SetActive(true);
        }
    }

    public void BarrierDisabled()
    {
        texts[3].color = new Color(1,1,1,1);
        StartCoroutine("TextFadeOut", texts[3]);
    }

    public void MoreBellsMessage()
    {
        texts[0].color = new Color(1, 1, 1, 1);
        texts[1].color = new Color(1, 1, 1, 1);
        texts[2].color = new Color(1, 1, 1, 1);
        StartCoroutine("TextFadeOut", texts[0]);
        StartCoroutine("TextFadeOut", texts[1]);
        StartCoroutine("TextFadeOut", texts[2]);
    }

    IEnumerator TextFadeOut(Text text)
    {
        
        yield return new WaitForSeconds(3.0f);
        for (byte i = 255; i > 0; i-=3)
        {
            text.color = new Color32(255, 255, 255, i);
            yield return new WaitForSeconds(0.0001f);
        }
        text.color = new Color32(255, 255, 255, 0);
    }

    IEnumerator StartMessageFadeOut(Text text)
    {

        yield return new WaitForSeconds(15f);
        for (byte i = 255; i > 0; i -= 3)
        {
            text.color = new Color32(255, 255, 255, i);
            yield return new WaitForSeconds(0.0001f);
        }
        text.color = new Color32(255, 255, 255, 0);
    }
}
