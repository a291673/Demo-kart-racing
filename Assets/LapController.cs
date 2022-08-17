using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapController : MonoBehaviour
{
    public bool check1 = false;
    public bool check2 = false;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag=="Player")
        {
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            if(player != null)
            {   
                if(check1 && check2)
                {
                    player.lapGain();
                    check1 = false;
                    check2 = false;
                }
            }
        }
    }

    public void addLaps1()
    {
        check1 = true;
        Debug.Log("check1");
    }
    public void addLaps2()
    {
        check2 = true;
        Debug.Log("check2");
    }
}
