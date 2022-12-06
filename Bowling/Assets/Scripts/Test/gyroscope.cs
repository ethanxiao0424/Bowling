using UnityEngine;
using System.Collections;

public class gyroscope : MonoBehaviour
{

    bool draw = false;
    bool gyinfo;
    Gyroscope go;
    void Start()
    {
        gyinfo = SystemInfo.supportsGyroscope;
        go = Input.gyro;
        go.enabled = true;
    }
    void Update()
    {
        if (gyinfo)
        {
            Vector3 a = go.attitude.eulerAngles;
            a = new Vector3(-a.x, -a.y, a.z); //�����ϥ�Ū�����שԨ��o�{����A��O�ۤv�վ�@�U�Ÿ�
            this.transform.eulerAngles = a;
            this.transform.Rotate(Vector3.right * 90, Space.World);
            draw = false;
        }
        else
        {
            draw = true;
        }
    }

    void OnGUI()
    {
        if (draw)
        {
            GUI.Label(new Rect(100, 100, 30,30), "�Ұʥ���");
        }
    }

}