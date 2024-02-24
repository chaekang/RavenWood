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
    public TextMeshProUGUI talkText;    // ����â�� �ߴ� �ؽ�Ʈ
    public GameObject scanObject;       // �÷��̾ ������ ���
    public bool isAction;               // ���� ����� ����
    public bool isInventoryActivate;    // �κ��丮 Ȱ��ȭ ���� Ȯ�� ����

    private float panelHideDelay = 5f;

    private void Awake()
    {
        Inventory.SetActive(false);
        isInventoryActivate = false;
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
