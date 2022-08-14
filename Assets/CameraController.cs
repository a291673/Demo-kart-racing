using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public GameObject child;
    private float speed = 5.0f;
    // Start is called before the first frame update
    void Awake()
    {   
        Player = GameObject.FindGameObjectWithTag("Player");
        child = Player.transform.Find("Camera Constrain").gameObject;
    }

    private void FixedUpdate() 
    {
        follow();

    }

    private void follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(Player.gameObject.transform.position - new Vector3(1,1,1));
    }
}
