using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloon : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            if(player != null)
            {
                    player.blueBallon();
                    Destroy(gameObject);
            }
        }
    }
}
