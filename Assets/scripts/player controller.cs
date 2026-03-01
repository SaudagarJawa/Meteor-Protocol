using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class movementscript : MonoBehaviour
{

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public float jumpforce;
    public GameObject LoseScreenUI;
    public int score, highscore;
    public Text scoreUI, highscoreUI;
    string HIGHSCORE = "HIGHSCORE";
    void Start()
    {
        highscore = PlayerPrefs.GetInt(HIGHSCORE);
    }

    // Update is called once per frame
    void Update()
    {
       PlayerJump();
    }

    void PlayerJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpforce;
        }
    }

    void addscore()
    {
        score++;   
        scoreUI.text = "score:" + score.ToString();
    }
    void playerlose()
    {
        if (score > highscore)
        {
            highscore=score;
            PlayerPrefs.SetInt(HIGHSCORE, highscore);
        }      
        highscoreUI.text = "Highscore: " + highscore.ToString();
        Time.timeScale=0;
        LoseScreenUI.SetActive(true);   
    }
    public void RestartGame()
    {
        Time.timeScale=1;   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            playerlose();
        }
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("score"))
        {
            addscore();
        }
    }
}
