using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananCol : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            updateHud hud = gameObject.Find("Canvas").GetComponent<updateHud>();
            hud.bananaGain();
            Destroy(gameObject);
        }
    }
}
