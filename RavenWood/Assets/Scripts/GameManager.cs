using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ClickManager clickManager;
    public ZoomInOut zoom;

    public PlayerMove playerMove;
    public MakePotion makePotion;

    public GameObject talkPanel;        // 인포창 UI
    public GameObject hintPanel;        // 힌트창 UI
    public GameObject startPanel;       // 시작 패널
    public GameObject gameOver;         // 게임 오버 패널

    public Text timerText;              // 제한 시간 확인 텍스트
    private float timeRemaining;        // 잔여 시간 관리 변수
    bool isTimerRunning = true;         // 타이머 진행 여부

    public TextMeshProUGUI talkText;    // 게임창에 뜨는 텍스트
    public TextMeshProUGUI hintText;    // 힌트창에 뜨는 텍스트
    public GameObject scanObject;       // 플레이어가 조사한 대상
    public bool isAction;               // 상태 저장용 변수

    private float panelHideDelay = 3f;

    private void Awake()
    {
        timeRemaining = 1200.0f;
    }

    void Update()
    {
        if (isTimerRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText.text = timeString;
        }
        else if (timeRemaining <= 0)
        {
            GameOver();
        }
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isClue);

        // 인포창
        if (!objData.isClue)
        {
            if (isAction)
            {
                talkPanel.SetActive(isAction);
                Invoke("DelayedHidePanel", panelHideDelay);
            }
        }
        // 힌트창
        else
        {
            playerMove.DisableRotation();
            hintPanel.SetActive(isAction);
        }
    }



    void Talk(int id, bool isClue)
    {
        string talkData = clickManager.GetTalk(id);

        if (id < 1000)
        {
            talkText.text = talkData;
        }
        else
        {
            hintText.text = talkData;
        }
        isAction = true;

    }

    public void DelayedHidePanel()
    {
        talkPanel.SetActive(false);
        isAction = false;
    }

    public void BackButton()
    {
        // 힌트창
        if (isAction)
        {
            isAction = false;
            hintPanel.SetActive(isAction);
            playerMove.EnableRotation();
        }
    }

    public void OutOfHands()
    {
        talkText.text = "손이 부족하다";
        talkPanel.SetActive(true);
        Invoke("DelayedHidePanel", panelHideDelay);
    }

    public void NeedFire()
    {
        talkText.text = "불을 먼저 붙여야 할 것 같다.";
        talkPanel.SetActive(true);
        Invoke("DelayedHidePanel", panelHideDelay);
    }

    public void NeedIngredient()
    {
        talkText.text = "재료를 넣고 섞어야할 것 같다.";
        talkPanel.SetActive(true);
        Invoke("DelayedHidePanel", panelHideDelay);
    }

    public void TurnOffStartPanel()
    {
        startPanel.SetActive(false);
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timeString;
    }

    public void PotionEnding()
    {
        if (makePotion.isPerfect)
        {
            StopTimer();
            timerText.color = Color.green;
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        StopTimer();
        timerText.color = Color.red;
        gameOver.SetActive(true);
    }
}
