using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Color highlightColor; // ���õ� �̹��� ����
    public PlayerMove playerMove;

    void Start()
    {
        highlightColor = new Color32(255, 156, 0, 255);
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Selected);
        playerMove = GetComponent<PlayerMove>();
    }


    private void Selected()
    {
        // ���� �̹����� �� �ܰ� �θ� GameObject ��������
        Transform parentTransform = transform.parent;

        Image parentImage = parentTransform.GetComponent<Image>();
        parentImage.color = highlightColor;
        playerMove.selectedItem= this.gameObject;
    }
}
