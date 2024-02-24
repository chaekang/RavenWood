using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ClickManager clickManager;
    public GameObject talkPanel;        // ���� ����â
    public GameObject Inventory;        // �κ��丮 UI
    public Text timerText;              // ���� �ð� Ȯ�� �ؽ�Ʈ
    private float timeRemaining;        // �ܿ� �ð� ���� ����
    public TextMeshProUGUI talkText;    // ����â�� �ߴ� �ؽ�Ʈ
    public GameObject scanObject;       // �÷��̾ ������ ���
    public bool isAction;               // ���� ����� ����
    public bool isInventoryActivate;    // �κ��丮 Ȱ��ȭ ���� Ȯ�� ����

    private float panelHideDelay = 5f;

    private void Awake()
    {
        Inventory.SetActive(false);
        isInventoryActivate = false;
        timeRemaining = 600.0f;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText.text = timeString;
        }
        else
        {
            timerText.text = "���� �ð� �ʰ�(���ӿ���)";
        }
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id);

        talkPanel.SetActive(isAction);

        if (isAction)
        {
            Invoke("DelayedHidePanel", panelHideDelay);
        }
    }

    public void ShowInventory()
    {
        Inventory.SetActive(true);
        isInventoryActivate = true;
    }

    void Talk(int id)
    {
        int talkIndex = 0;
        string talkData = clickManager.GetTalk(id);

        if (talkIndex > 0)
        {
            isAction = false;
            return;
        }

        talkText.text = talkData;
        isAction = true;
        talkIndex++;
    }

    void DelayedHidePanel()
    {
        talkPanel.SetActive(false);
        isAction = false;
    }
}
