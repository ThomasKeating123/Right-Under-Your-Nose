using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public string levelName;
    public string buttonName;
    public bool levelEnabled;

    public TMP_Text buttonText;

    private void Start()
    {
        buttonText.text = buttonName;

        if (levelEnabled == true) GetComponent<Button>().interactable = true;
        else if (levelEnabled == false) GetComponent<Button>().interactable = false;
    }

    public void OnClick()
    {
        if ((levelName != null || levelName != "") && SceneUtility.GetBuildIndexByScenePath(levelName) >= 0) SceneManager.LoadScene(levelName);
    }

}
