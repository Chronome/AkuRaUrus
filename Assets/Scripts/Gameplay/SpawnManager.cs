using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private Vector2 spawnPos = new Vector2(10, -3.5f);
    private float startDelay = 3;
    // private float repeatRate = 3f;


    private PlayerControl PlayerControlScript;
    
    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("SpawnObjects", startDelay, repeatRate);
        Invoke("SpawnObjects", startDelay);
        PlayerControlScript = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void SpawnObjects()
    {
        int index = Random.Range(0, objectPrefabs.Length);
        if(PlayerControlScript.gameOver == false)
        {
            Instantiate(objectPrefabs[index], spawnPos, objectPrefabs[index].transform.rotation);
        }

        if(PlayerControlScript.score < 100)
        {
            Invoke("SpawnObjects", Random.Range(2.0f, 3.0f));
        }
        
        else if(PlayerControlScript.score > 100 && PlayerControlScript.score < 500)
        {
            Invoke("SpawnObjects", Random.Range(1.0f, 2.0f));
        }
        
        else if(PlayerControlScript.score > 500)
        {
            Invoke("SpawnObjects", Random.Range(0.5f, 1.5f));
        }
    }
}
