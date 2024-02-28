using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Color highlightColor; // ���õ� �̹��� ����
    public bool isSelected;

    void Start()
    {
        highlightColor = new Color32(255, 156, 0, 255);
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Selected);
    }


    private void Selected()
    {
        // ���� �̹����� �� �ܰ� �θ� GameObject ��������
        Transform parentTransform = transform.parent;

        Image parentImage = parentTransform.GetComponent<Image>();
        parentImage.color = highlightColor;
        isSelected = true;
    }

    private void Update()
    {
        if (isSelected)
        {
            //���� ������Ʈ�� Ŭ���ߴ���, �ٸ� UI�� Ŭ���ߴ���, ��ȣ�ۿ��� ������ ������Ʈ�� Ŭ���ߴ��� Ȯ���ϴ� �ڵ� �ۼ� �ʿ�
        }
    }


}
