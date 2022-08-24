using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhishingLevelManager : MonoBehaviour
{
    public GameObject successPanel;
    public TMP_Text successText;
    public GameObject introPanel;
    public GameObject task1Panel;
    public GameObject task1TaskPanel;
    public GameObject task1IntroPanel;

    //Tasl 1
    public List<TMP_Text> problems;
    public TMP_Text scoreText;
    public TMP_Text fromText;
    private int score;
    private int maxScore;
    private bool isFromClicked;
    private bool isTextClicked;
    private bool isLinkClicked;

    void Start()
    {
        maxScore = problems.Count;
    }

    public void UpdateScore()
    {
        scoreText.text = score + "/" + maxScore;
        if (score == maxScore)
        {
            StartCoroutine(Win());
        }
    }


    public void OnFromClick()
    {
        if (isFromClicked == false)
        {
            score++;
            problems[0].color = Color.red;
            UpdateScore();
            isFromClicked = true;
        }
    }

    public void OnTextClick()
    {
        if (isTextClicked == false)
        {
            score++;
            problems[1].color = Color.red;
            UpdateScore();
            isTextClicked = true;
        }
    }

    public void OnLinkClick()
    {
        if (isLinkClicked == false)
        {
            score++;
            problems[2].color = Color.red;
            UpdateScore();
            isLinkClicked = true;
        }
    }

    IEnumerator Win()
    {
        successText.text = "Well done, you have found all " + maxScore + " issues within the email. You have sucessfully completed the level.";
        yield return new WaitForSeconds(5);
        successText.text = "";

        SceneManager.LoadScene("Menu");
    }

    public void OnOkClick()
    {
        task1IntroPanel.SetActive(false);
        task1TaskPanel.SetActive(true);
    }

    public void Continue()
    {
        introPanel.SetActive(false);
        task1Panel.SetActive(true);
        successPanel.SetActive(true);
    }

    public void OnFromButtonClick()
    {
        fromText.gameObject.SetActive(!fromText.gameObject.activeSelf);
    }
}
