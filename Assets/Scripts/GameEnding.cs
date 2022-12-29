using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    public Player player;
    Transform cam;
    float camRotationSpeed = 10f;
    float rotateTime = 2f;
    PlayerInput input;
    public GameObject endingText;
    public GameObject endingFadeOut;
    Image image;

    // Start is called before the first frame update
    void Awake()
    {
        image = endingFadeOut.GetComponent<Image>();
        cam = player.transform.GetChild(0);
        input = player.GetComponent<PlayerInput>();
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
        yield return new WaitForSeconds(1f);
        endingText.SetActive(true);
        yield return new WaitForSeconds(5f);
        for (byte i = 0; i < 255; i++)
        {
            image.color = new Color32(0, 0, 0, i);
            yield return new WaitForSeconds(0.0001f);
        }
        SceneManager.LoadScene("Intro");
    }
}
