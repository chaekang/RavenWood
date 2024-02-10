using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    Dictionary<int, string> talkData;  // int: ������Ʈ id, string[]: ����

    private void Awake()
    {
        talkData = new Dictionary<int, string>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(100, "�� �� ���� å�� �ܶ� �����ִ�.");
    }

    public string GetTalk(int id)
    {

        return talkData[id];

    }
}
