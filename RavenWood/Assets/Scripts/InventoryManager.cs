using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Drawing;

public class InventoryManager : MonoBehaviour
{
    public GameObject Inventory;        // �κ��丮 UI
    public bool isInventoryActivate;    // �κ��丮 Ȱ��ȭ ���� Ȯ�� ����

    public List<Transform> slotTransforms; // ������ Transform ����Ʈ
    public List<GameObject> inventorySlots = new List<GameObject>(); // �κ��丮 ���� ����Ʈ
    public List<Sprite> itemImageList = new List<Sprite>(); // ������ �̹��� ����Ʈ

    public ItemManager itemManager; // �����ۿ� �߰��� ��ũ��Ʈ

    private void Awake()
    {
        Inventory.SetActive(false);
        isInventoryActivate = false;
    }


    public void ShowInventory()
    {
        Inventory.SetActive(true);
        isInventoryActivate = true;
        for (int i = 0; i < 10; i++)
        {
            inventorySlots.Add(null); // ��Ҹ� null�� �ʱ�ȭ
        }
        AddToInventory("match");
    }

    public void AddToInventory(string itemObjectName)
    {
        Sprite itemImage = GetItemImage(itemObjectName);

        for (int i = 0; i < 10; i++)
        {
            if (inventorySlots[i] == null)
            {
                // ����ִ� ���Կ� GameObject ����
                GameObject slotGameObject = new GameObject(itemObjectName); 
                slotGameObject.transform.SetParent(slotTransforms[i]);
                slotGameObject.transform.localPosition = Vector3.zero;

                // ������Ʈ�� �̹��� �Ҵ�, ��ư �Ҵ�
                Image slotImage = slotGameObject.AddComponent<Image>();
                slotImage.sprite = itemImage;
                slotGameObject.AddComponent<Button>();

                // �̹��� �ʺ�� ���� ����
                RectTransform slotRectTransform = slotGameObject.GetComponent<RectTransform>();
                slotRectTransform.sizeDelta = new Vector2(80, 80);

                //itemManager ��ũ��Ʈ �ο�
                slotGameObject.AddComponent(itemManager.GetType());

                inventorySlots[i] = slotGameObject; // �κ��丮 ���Կ� GameObject �Ҵ�

                break; // ���� �Ҵ� �� �ݺ��� ����
            }
        }
    }


    private Sprite GetItemImage(string itemName)
    {
        foreach (Sprite image in itemImageList)
        {
            // ������ �̸��� �̹��� �̸��� �����ϰ� �ִ��� Ȯ��
            if (image.name.ToLower().Contains(itemName.ToLower()))
            {
                return image;
            }
        }
        return null;
    }
}