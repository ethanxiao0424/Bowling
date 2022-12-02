using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMain : MonoBehaviour
{
    public void OnBtnStartClick()
    {
        UIManager.Instance.ShowPanel("SelectGameNumber");
        gameObject.SetActive(false);
    }
}
