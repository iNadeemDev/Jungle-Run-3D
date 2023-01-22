using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public float sen;
    private Transform player;
    void Start()
    {
        player = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sen * Time.deltaTime;
        player.Rotate(Vector3.up, mouseX);
    }
}