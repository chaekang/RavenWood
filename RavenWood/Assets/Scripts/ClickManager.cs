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
        // 100����: ����
        talkData.Add(100, "������ �⵿��ϰ� ���ִ�.");
        talkData.Add(200, "�� �� ���� å�� �ܶ� �����ִ�.");
        talkData.Add(300, "���⿡�� �ܼ��� ã�� ����� �� ����.");
        talkData.Add(400, "���� ��� ������ �ʴ´�.");
        talkData.Add(500, "���� ���� ���� ���� �ö� ���� �ʴ�.");
        talkData.Add(600, "������ ����ߴ� ������ �ִ� Ź���̴�.");
        talkData.Add(700, "���ְ� ����ϴ� å���̴�.");
        talkData.Add(800, "ǫ���� ���̴� �����̴�.");
        talkData.Add(900, "���� ��Ź�̴�.");

        // 10����: �⵿���
        talkData.Add(10, "ó���ϴ� �� ������ġ�̴�.");
        talkData.Add(20, "���� ���������̴�.");
        talkData.Add(30, "��밨�� �������� �����̴�.");
        talkData.Add(40, "���縦 ���µ� ���Ǿ��� ���̴�.");
        talkData.Add(50, "�������� �ð��� ���� ���� �ʾҴ�.");
    }

    public string GetTalk(int id)
    {

        return talkData[id];

    }
}
