using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 6;
    private PlayerControl playerControllerScript;
    private float leftBound = -10;
   
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = 6+(playerControllerScript.score/50);

        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle") || transform.position.x < leftBound && gameObject.CompareTag("Item"))
        {
            Destroy(gameObject);
        }
    }
}
