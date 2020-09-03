using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlay = false;

    [SerializeField] int scorePerHit = 70;
    private int totalScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        
    }

    public void updateScore() {
        totalScore += scorePerHit;
        scoreText.SetText(totalScore.ToString());
    }

    public void resetScore() { 
        //totalScore = 0;
        //scoreText.SetText(totalScore.ToString());
        //print("reset score");
        Destroy(gameObject);
    }

    public bool isAutoPlayEnabled() {
        return isAutoPlay;
    }
}
