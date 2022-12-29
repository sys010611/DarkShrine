using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    RaycastHit hit;
    LayerMask layermask;
    float maxDistance = 10f;

    bool outsideFlag = false;

    public Enemy enemy;
    public GameManager gameManager;
    public UI ui;
    
    public int attainedBellCount = 0;

    AudioSource audioSource;
    Rigidbody rigidBody;

    PlayerInput input;

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        layermask = LayerMask.GetMask("SafeZone");
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsPlayerOnSafeZone();
    }

    private void IsPlayerOnSafeZone()
    {
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, maxDistance, layermask))
        {
            outsideFlag = false;
        }
        else
        {
            outsideFlag = true;
            StartCoroutine("CheckLocation");
        }
    }

    IEnumerator CheckLocation()
    {
        yield return new WaitForSeconds(2.0f);
        if (outsideFlag == true)
        {
            gameManager.PlayerDetected();
        }
        else
            gameManager.PlayerNotDetected();
    }

    public void PlayerCaught()
    {
        StopCoroutine("CheckLocation");
        transform.LookAt(enemy.transform);
        transform.GetChild(0).localEulerAngles = new Vector3(-45, 0, 0);
        input.DeactivateInput();
    }

    public void BellAttainingSound()
    {
        audioSource.Play();
    }

    public int _AttainedBellCount
    {
        set
        {
            attainedBellCount = value;
            ui.BellCountChanged();
        }
        
        get
        {
            return attainedBellCount;
        }
    }
}