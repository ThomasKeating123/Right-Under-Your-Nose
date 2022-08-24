using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public List<GameObject> Panels;
    private List<PanelState> panelStates;
    private bool ispaused;

    private void Start()
    {
        panelStates = new List<PanelState>();
        ispaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SwitchStates();
    }

    public void Continue()
    {
        SwitchStates();
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {

        Application.Quit();
    }

    public void OpenPauseMenu()
    {
        if (pauseMenu.activeSelf == false)
        {

            foreach (GameObject p in Panels)
            {
                panelStates.Add(new PanelState(p, p.activeSelf));
                p.SetActive(false);
            }

            pauseMenu.SetActive(true);
        }
    }

    public void ClosePauseMenu()
    {
        if (pauseMenu.activeSelf == true)
        {
            pauseMenu.SetActive(false);

            foreach (PanelState panel in panelStates)
            {
                panel.obj.SetActive(panel.objState);
            }

            panelStates.Clear();
        }
    }

    public void SwitchStates()
    {
        if (ispaused == false)
        {
            OpenPauseMenu();
            ispaused = true;
        }
        else if (ispaused == true)
        {
            ClosePauseMenu();
            ispaused = false;
        }
    }

}
