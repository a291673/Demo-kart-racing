using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSoundStart : MonoBehaviour
{
    public GameObject engineLoop;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(lifeTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator lifeTime()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
        Instantiate(engineLoop);
        
    }
}
