using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameMode : MonoBehaviour
{
    public void OnBtnBackClick()
    {
        UIManager.Instance.ClosePanel("SelectGameMode");
        UIManager.Instance.ShowPanel("SelectGameNumber");
    }
}
