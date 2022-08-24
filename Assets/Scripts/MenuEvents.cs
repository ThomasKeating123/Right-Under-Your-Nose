using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuEvents : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject levelMenu;

    private void Start()
    {
        startMenu.SetActive(true);
        levelMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) if (levelMenu.activeSelf) OnBackClick();
    }

    public void OnStartClick()
    {
        SwitchStates();
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnBackClick()
    {
        SwitchStates();
    }

    public void SwitchStates()
    {
        startMenu.SetActive(!startMenu.activeSelf);
        levelMenu.SetActive(!levelMenu.activeSelf);
    }
}
