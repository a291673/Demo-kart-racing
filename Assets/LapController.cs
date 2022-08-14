using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapController : MonoBehaviour
{
    public int lapsNo = 0;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag=="Player")
        {
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            if(player != null)
            {
                    if(lapsNo >2)
                    {
                        Debug.Log("win");
                    }
            }
        }
    }

    public void addLaps()
    {
        lapsNo++;
    }
}
