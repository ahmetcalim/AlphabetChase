using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{

    public void SelectHide()
    {
        PlayerHandler.Instance.SelectRandomHider();
        UIManager.Instance.EnableSelectionPanel(false);
    }
    public void SelectSeek()
    {
        PlayerHandler.Instance.SelectSeeker();

        UIManager.Instance.EnableSelectionPanel(false);
    }
}
