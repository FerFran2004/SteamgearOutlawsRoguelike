using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float CameraSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Hola");
            transform.position += Vector3.right * CameraSpeed * Time.deltaTime;
            

        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Hola 2");
            transform.position += Vector3.left * CameraSpeed * Time.deltaTime;

        }
    }
}
