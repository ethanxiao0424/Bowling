using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameMode : MonoBehaviour
{
    Movement movement;
    private void Start()
    {
        movement=GameObject.Find("Movement").GetComponent<Movement>();
    }
    public void OnBtnBackClick()
    {
        UIManager.Instance.ClosePanel("SelectGameMode");
        UIManager.Instance.ShowPanel("SelectGameNumber");
    }

    public void SelectWatch()
    {
        UIManager.Instance.ClosePanel("SelectGameMode");
    }
    public void SelectPhone()
    {
        UIManager.Instance.ClosePanel("SelectGameMode");
    }
    public void StartGame()
    {
        movement.StartMoveBall();
    }
}
