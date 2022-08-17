using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    public void speedBoostPUON(){
        PlayerMovement pm = gameObject.GetComponent<PlayerMovement>();
            if(pm != null)
            {
                    pm.SpeedBoostOn();
            }
    }
    
}
