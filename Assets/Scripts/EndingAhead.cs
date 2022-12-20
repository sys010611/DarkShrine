using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAhead : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    public GameObject directionalLight;
    Light globalLight;

    private void Awake()
    {
        globalLight = directionalLight.GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Destroy(enemy);
            StartCoroutine("FogRemove");
            StartCoroutine("SkyBrighten");
        }
    }

    IEnumerator FogRemove()
    {
        while(RenderSettings.fogDensity > 0)
        {
            RenderSettings.fogDensity -= 0.0001f;
            yield return null;
        }
        
    }

    IEnumerator SkyBrighten()
    {
        for (byte i = 0; i < 129; i++)
        {
            RenderSettings.skybox.SetColor("_Tint", new Color32(i,i,i,128));
            globalLight.intensity = (float)i * 0.015f;
            yield return new WaitForSeconds(0.07f);
        }
    }

    private void OnApplicationQuit()
    {
        //RenderSettings.skybox.SetColor("_Tint", new Color(1,1,1));
        RenderSettings.skybox.SetColor("_Tint", new Color(0,0,0));
    }
}
