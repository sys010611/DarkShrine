using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float speed = 4f;
    public Player player;

    // Update is called once per frame
    void FixedUpdate()
    {
        Chase();
    }

    public void Chase()
    {
        transform.LookAt(player.transform.position);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            player.PlayerCaught();
            speed = 0;
            Invoke("GameQuit", 2f);
        }
           
    }

    void GameQuit()
    {
        SceneManager.LoadScene("GameOver");
    }
}

