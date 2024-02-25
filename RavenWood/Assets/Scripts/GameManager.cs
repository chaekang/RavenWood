using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ClickManager clickManager;
<<<<<<< Updated upstream
    public GameObject talkPanel;        // ���� ����â
<<<<<<< Updated upstream
=======
    public PlayerMove playerMove;
    public GameObject talkPanel;        // ����â UI
    public GameObject hintPanel;        // ��Ʈâ UI
    public GameObject Inventory;        // �κ��丮 UI
    public Text timerText;              // ���� �ð� Ȯ�� �ؽ�Ʈ
    private float timeRemaining;        // �ܿ� �ð� ���� ����
>>>>>>> Stashed changes
=======
    public GameObject hintPanel;        // ��Ʈâ UI
>>>>>>> Stashed changes
    public TextMeshProUGUI talkText;    // ����â�� �ߴ� �ؽ�Ʈ
    public TextMeshProUGUI hintText;    // ��Ʈâ�� �ߴ� �ؽ�Ʈ
    public GameObject scanObject;       // �÷��̾ ������ ���
    public bool isAction;               // ���� ����� ����

    private float panelHideDelay = 5f;

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isClue);

        // ����â
        if (!objData.isClue)
        {
            if (isAction)
            {
                talkPanel.SetActive(isAction);
                Invoke("DelayedHidePanel", panelHideDelay);
            }
        }
        // ��Ʈâ
        else
        {
            playerMove.DisableRotation();
            hintPanel.SetActive(isAction);
        }
    }

<<<<<<< Updated upstream
    void Talk(int id)
=======
    public void ShowInventory()
    {
        Inventory.SetActive(true);
        isInventoryActivate = true;
    }

    void Talk(int id, bool isClue)
>>>>>>> Stashed changes
    {
        string talkData = clickManager.GetTalk(id);

        if (!isClue)
        {
            talkText.text = talkData;
        }
        else
        {
            hintText.text = talkData;
        }
        isAction = true;

    }

    void DelayedHidePanel()
    {
        talkPanel.SetActive(false);
        isAction = false;
    }

    public void BackButton()
    {
        // ��Ʈâ
        if (isAction)
        {
            isAction = false;
            hintPanel.SetActive(isAction);
            playerMove.EnableRotation();
        }
    }
}
