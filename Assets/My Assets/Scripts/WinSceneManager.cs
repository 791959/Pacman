using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinSceneManager : MonoBehaviour {

    public Text m_scoreText;
    public Text m_highScoreText;
    public Text m_life;
	// Use this for initialization
	void Start () {
        m_scoreText.text = "Total Score：" + GameManager.m_score;
        m_highScoreText.text = "Highest Score：" + GameManager.m_highScore;
        m_life.text = "Life：" + PacmanMove.m_life;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
