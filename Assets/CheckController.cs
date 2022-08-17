using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag=="Player")
        {
            LapController addlad = GameObject.Find("FinLine").GetComponent<LapController>();
            addlad.addLaps1();
        }
    }
}
