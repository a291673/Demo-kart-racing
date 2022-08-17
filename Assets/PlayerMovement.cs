using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float moveInput;
    private float turnInput;

    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;
    public float maxSpeed = 10f;
    
    public bool speedBoost;

    public bool speedBoostPowerUp;
    public bool missilePowerUp;  

    public Rigidbody sphereRB;
    
    public GameObject engineStart;
    public GameObject engineLoop;

    public TextMeshProUGUI textBan;
    public TextMeshProUGUI textLap;
    public TextMeshProUGUI textWinLose;

    public Image boostIMG;

    private int score  = 0;
    private int lapsNo  = 1;

    void Start()
    {
        boostIMG.enabled = false;
        sphereRB.transform.parent = null;
        setBananaText();
        setLapText();
        setWinLoseText("");
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");
        
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;

        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instantiate(engineStart);
        }
        if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            DestroyAll("Sound");
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(speedBoostPowerUp)
            {
                boostIMG.enabled = false;
                SpeedBoostOn();
                speedBoostPowerUp = false;

            }
        }

            transform.position = sphereRB.transform.position + new Vector3(0,.1f,0);

        
        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        if(Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(0, newRotation * 2f, 0, Space.World);
        }
        else{
            transform.Rotate(0, newRotation, 0, Space.World);
        }
        
    }
    void DestroyAll(string tag)
    {
        GameObject[] sounds = GameObject.FindGameObjectsWithTag(tag);
        for(int i=0; i< sounds.Length; i++)
        {
            Destroy(sounds[i]);
        }
    }
        
    private void FixedUpdate() 
    {
        if(sphereRB.velocity.magnitude > maxSpeed)
        {
            sphereRB.velocity = Vector3.ClampMagnitude(sphereRB.velocity, maxSpeed);
        }
        else
        {
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);   
        }
    }

    void setBananaText()
    {
        textBan.text = "X " + score.ToString();
    }

    void setLapText()
    {
        if(lapsNo<3)
        {
            Debug.Log(lapsNo);
            textLap.text = "Lap: " + lapsNo.ToString();
        }
        else{
            setWinLoseText("Win");
            StartCoroutine(winScreenDownRoutine());
        }
    }
    void setWinLoseText(string s)
    {
        textWinLose.text = s;
    }

    void OnCollisionEnter (Collision other) { 
        if(other.gameObject.tag=="Grass") {
            maxSpeed = 5f;
        }

    }

    public void SpeedBoostOn()
    {
        maxSpeed = 40f;
        fwdSpeed = 40f;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    public void blueBallon()
    {
        boostIMG.enabled = true;
        speedBoostPowerUp = true;
    }

    public void bananGain()
    {
        score++;
        setBananaText();
    }
    public void lapGain()
    {
        lapsNo++;
        setLapText();
    }

    public IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        maxSpeed = 10f;
        fwdSpeed = 10f;
    }
    public IEnumerator winScreenDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("start");
    }
}
