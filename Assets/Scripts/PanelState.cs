using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelState
{
    public GameObject obj;
    public bool objState;

    public PanelState(GameObject panel, bool state)
    {
        obj = panel;
        objState = state;
    }
}
