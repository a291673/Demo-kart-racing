using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            if(player != null)
            {
                    player.SpeedBoostOn();
            }
        }
    }
}
