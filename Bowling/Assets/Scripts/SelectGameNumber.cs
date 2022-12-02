using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameNumber : MonoBehaviour
{
    public void OnBtnGameNumber3Click()
    {
        UIManager.Instance.ShowPanel("SelectGameMode");
        UIManager.Instance.ClosePanel("SelectGameNumber");
    }
    public void OnBtnGameNumber6Click()
    {
        UIManager.Instance.ShowPanel("SelectGameMode");
        UIManager.Instance.ClosePanel("SelectGameNumber");
    }
    public void OnBtnGameNumber10Click()
    {
        UIManager.Instance.ShowPanel("SelectGameMode");
        UIManager.Instance.ClosePanel("SelectGameNumber");
    }
}
