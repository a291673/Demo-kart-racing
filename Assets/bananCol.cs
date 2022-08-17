using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bananCol : MonoBehaviour
{
    

    private void Awake() {
        //textBan.text = "Some new line of text.";
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            player.bananGain();
            Destroy(gameObject);
        }
    }
}
