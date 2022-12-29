using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    public GameManager gameManager;
    public Player player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            gameManager._RequiredBellCount -= player._AttainedBellCount;
            player._AttainedBellCount = 0;
        }
    }
}
