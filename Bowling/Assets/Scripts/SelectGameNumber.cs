using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameNumber : MonoBehaviour
{
    GameObject scoreManager;
    private void Start()
    {
        scoreManager = GameObject.Find("ScoreManager");
    }
    public void OnBtnGameNumber3Click()
    {
        scoreManager.GetComponent<ScoreManager>().SetSelectFrame(3);
        UIManager.Instance.ShowPanel("SelectGameMode");
        UIManager.Instance.ClosePanel("SelectGameNumber");
    }
    public void OnBtnGameNumber6Click()
    {
        scoreManager.GetComponent<ScoreManager>().SetSelectFrame(6);
        UIManager.Instance.ShowPanel("SelectGameMode");
        UIManager.Instance.ClosePanel("SelectGameNumber");
    }
    public void OnBtnGameNumber10Click()
    {
        scoreManager.GetComponent<ScoreManager>().SetSelectFrame(10);
        UIManager.Instance.ShowPanel("SelectGameMode");
        UIManager.Instance.ClosePanel("SelectGameNumber");
    }
}
