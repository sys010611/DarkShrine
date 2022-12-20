using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip stepGrass;
    public AudioClip stepStone;

    void PlaySound(string ground)
    {
        switch (ground)
        {
            case "grass":
                audioSource.clip = stepGrass;
                break;
            case "stone":
                audioSource.clip = stepStone;
                break;
        }
        audioSource.Play();
    }
}
