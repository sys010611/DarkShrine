using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Inactive", 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void Inactive()
    {
        gameObject.SetActive(false);
    }
}
