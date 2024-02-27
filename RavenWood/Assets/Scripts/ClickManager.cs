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
        //0����: ħ��
        talkData.Add(1,"��ݱ��� ���� �����ִ� ������ ħ���̴�.");
        talkData.Add(2, "ȣ�� �׸��� �׷��� �ִ� ���ڴ�.");
        talkData.Add(3, "���� ��α�� ������ �߱����̴�.");
        talkData.Add(4, "���縦 ���� ä�� �ŷ��� ������ �����ִ� ��δ�.");
        talkData.Add(5, "�ƹ����Գ� �׿��ִ� ���ڴ�. ���� �ָ� �� �� ���� �� ����.");
        talkData.Add(6, "���� ����ִ�. �������� ���� �ָ� �� �� ���� �� ����.");
        talkData.Add(7, "���� ��������� ����ִ�. ���� �ָ� �� �� ���� �� ����.");
        talkData.Add(8, "������ �ִ� å���̴�.");


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

        // 1000����: ��Ʈâ ������ ������Ʈ
        talkData.Add(1000, "�ص��� ����� ��\n\n�غ�\n1. ��Ƽ�� �츰 �� �� ��\n2. ������ī �� �Ѹ�\n3. �丶�� �� ��\n4. �� �� ��");
        talkData.Add(2000, "�Ĺ� ����\n\n001. ������ī\n���ڽĹ����� �Ĺ� �� �ϳ���, ������ ���ĸ��� ���� ���Ű� Ư¡�̴�.\n" +
            "������ ����� ���� ��������, �߸� ����ϸ� ������ ���� ���� �ִ�.");
        talkData.Add(3000, "�� ���� ���� ����� 10�� ���� ������ �̸��� �� �� �ִ�.\n���� �ϻ󿡼� ���� ���� �� �ִ� ���� ���� �� �ֱ� ������ ���� �����ϴ�.\n" +
            "������ ���ÿ� ���� ���� ��Ḧ ���̽��� ���� �ص����� ���� �� �ִٴ� Ư¡�� �ִ�.");
    }

    public string GetTalk(int id)
    {

        return talkData[id];

    }
}
