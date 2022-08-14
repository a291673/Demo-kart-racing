using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class updateHud : MonoBehaviour
{
    private int bananas = 0;
    private int laps = 0;

    public TMP_Text bananChange;
    public TMP_Text lapChange;
    
    void Start()
    {
        bananChange.text= "X" + bananas;
    }

    // Update is called once per frame
    void Update()
    {
        bananChange.text= "X" + bananas;
    }

    public void bananaGain()
    {
        bananas++;
    }
    public void lapsGain()
    {
        laps++;
    }
}
