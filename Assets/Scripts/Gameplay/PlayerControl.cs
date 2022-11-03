using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public UIManager uiManager;
    public GameObject tutorialUI;
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public AudioClip CostumePop;
    public AudioClip PaperSound;

    private float Timer;
    public float jumpForce;
    public int score;
    
    
    [SerializeField]
    bool isOnGround = true;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        uiManager = GameObject.Find("ScoreCanvas").GetComponent<UIManager>();
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0)
        {
            ResumeGame();
            tutorialUI.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector2.up * jumpForce);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }

        if (Timer > 1f && !gameOver)
        {
            AddScore(1);
            Timer = 0;
        }

        
        
    }
    
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        else if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            AddScore(5);
            playerAudio.PlayOneShot(PaperSound, 1.0f);
        }

        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("game Over!!");
            playerAnim.SetBool("Hit_Bool", true);
            playerAudio.PlayOneShot(CostumePop, 1.0f);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        uiManager.UpdateScore(score);
    }

    private void PauseGame ()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}