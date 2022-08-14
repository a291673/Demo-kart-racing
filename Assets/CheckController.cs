using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckController : MonoBehaviour
{
    private int checks = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            checks++;
            if(checks == 2)
            {
                LapController addlad = GameObject.Find("FinLine").GetComponent<LapController>();
                addlad.addLaps();
                checks = 0;
            }
            
        }
    }
}
