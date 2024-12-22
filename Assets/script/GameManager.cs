using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gamestarted;
    public GameObject platformspowner;
    int score = 0;
    int highscore;
    public GameObject gameplayui;
    public GameObject menuUI;
    public Text scoretext;
    public Text highscoretext;
    AudioSource audiosource;
    public AudioClip[] gamemusic;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audiosource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoretext.text = "Best Score : " + highscore;
    }

    // Update is called once per frame
    void Update()
    {
    if (!gamestarted)
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameStart();
        }
    }
    }
    public void GameStart()
    {
    gamestarted = true;

        platformspowner.SetActive(true);
        gameplayui.SetActive(true);
        menuUI.SetActive(false);
        audiosource.clip = gamemusic[1];
        audiosource.Play();
        StartCoroutine("UpdateScore");
    }
    public void GameOver()
    {
        platformspowner.SetActive(false);
        StopCoroutine("UpdateScore");
        savehighscore();
   
        Invoke("RelodLevel",1f);
    }
    void RelodLevel()
    {
        SceneManager.LoadScene("game");
    }
    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score++;
            scoretext.text = score.ToString();
            //print(score);
        }
    }
    public void Incrementscore()
    {
        score += 2;
        scoretext.text = score.ToString();
        audiosource.PlayOneShot(gamemusic[2],0.4f);
    }
    void savehighscore()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            if(score > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }
}
