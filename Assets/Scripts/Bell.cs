using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            player._AttainedBellCount++;
            player.BellAttainingSound();
            gameObject.SetActive(false);
        }
    }
}
