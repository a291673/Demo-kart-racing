using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    private bool speedBoostPU = false;
    private bool missilePW = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void speedBoostPUON(){
        PlayerMovement pm = gameObject.GetComponent<PlayerMovement>();
            if(pm != null)
            {
                    pm.SpeedBoostOn();
            }
    }
    public void missilePUON(){
        
    }
    
}
