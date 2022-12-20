using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameEnding : MonoBehaviour
{
    public Player player;
    Transform cam;
    float camRotationSpeed = 10f;
    float rotateTime = 2f;
    PlayerInput input;

    // Start is called before the first frame update
    void Awake()
    {
        cam = player.transform.GetChild(0);
        input = player.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            input.DeactivateInput();
            StartCoroutine("camRotate");
        }
    }

    IEnumerator camRotate()
    {
        while (rotateTime > 0)
        {
            cam.Rotate(Vector3.left * Time.deltaTime * camRotationSpeed);
            rotateTime -= Time.deltaTime;
            yield return null;
        }
        
    }
}
