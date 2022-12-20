using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyTrigger : MonoBehaviour
{
    GameObject monkey;

    private void Awake()
    {
        monkey = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            monkey.SetActive(true);
        }

        Invoke("Inactive", 10);
    }

    void Inactive()
    {
        gameObject.SetActive(false);
    }
}
