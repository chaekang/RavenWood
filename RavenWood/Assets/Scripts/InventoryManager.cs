using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Drawing;

public class InventoryManager : MonoBehaviour
{
    public GameObject Inventory;        // �κ��丮 UI
    public bool isInventoryActivate;    // �κ��丮 Ȱ��ȭ ���� Ȯ�� ����

    public List<Transform> slotTransforms; // ������ Transform ����Ʈ
    public List<Image> inventorySlots = new List<Image>(); // �κ��丮 ���� ����Ʈ
    public List<Image> itemImageList = new List<Image>(); // ������ �̹��� ����Ʈ

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
    }

    public void AddToInventory(GameObject itemObject)
    {
        Image itemImage = GetItemImage(itemObject.name);

        // ����ִ� ������ ã�Ƽ� ������Ʈ �߰�
        for (int i = 0; i < 10; i++)
        {
            if (inventorySlots[i] == null)
            {
                Image slotImage = Instantiate(itemImage, slotTransforms[i]);
                inventorySlots[i] = slotImage;
                break; // ���� �Ҵ� �� �ݺ��� ����
            }
        }
    }

    private Image GetItemImage(string itemName)
    {
        foreach (Image image in itemImageList)
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