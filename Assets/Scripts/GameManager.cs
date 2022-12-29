using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public GameObject[] Bells = new GameObject[8];
    public GameObject[] Monkeys = new GameObject[8];
    public int requiredBellCount = 3;
    public GameObject gate;
    public Text requiredBellText;
    public UI ui;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() //setting 3 bells, 3 monkeys
    {
        Cursor.lockState = CursorLockMode.Locked; //lock cursor

        //shuffle array
        for (int j = 0; j < 8; j++)
        {
            int a = Random.Range(0, 8);
            int b = Random.Range(0, 8);
            GameObject temp = Bells[a];
            Bells[a] = Bells[b];
            Bells[b] = temp;
        }
        //enable bells
        for (int i = 0; i < 3; i++)
            Bells[i].SetActive(true);

        for (int k = 0; k < 8; k++)
        {
            int a = Random.Range(0, 8);
            int b = Random.Range(0, 8);
            GameObject temp = Monkeys[a];
            Monkeys[a] = Monkeys[b];
            Monkeys[b] = temp;
        }
        //enable bells
        for (int p = 0; p < 3; p++)
            Monkeys[p].SetActive(true);
    }

    public void requiredBellCountChanged()
    {
        requiredBellText.text = requiredBellCount.ToString();
        if(requiredBellCount == 0)
        {
            //escapable
            gate.SetActive(false);
            audioSource.Play();
            ui.BarrierDisabled();
        }

        else
        {
            ui.MoreBellsMessage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.gameObject.SetActive(true);
        }
    }

    public void PlayerDetected()
    {
        enemy.speed = 8f;
    }

    public void PlayerNotDetected()
    {
        enemy.speed = 4f;
    }

    public int _RequiredBellCount
    {
        set
        {
            requiredBellCount = value;
            requiredBellCountChanged();
        }

        get
        {
            return requiredBellCount;
        }
    }


}
