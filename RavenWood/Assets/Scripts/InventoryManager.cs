using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventorySlotPrefab; // �κ��丮 ���� ������
    public List<Transform> slotTransforms; // ������ Transform ����Ʈ
    public List<GameObject> inventorySlots = new List<GameObject>(); // �κ��丮 ���� ����Ʈ

    public void AddToInventory(Sprite itemImage)
    {
        // �κ��丮 ������ �� ���ִ��� Ȯ��
        if (inventorySlots.Count < 10)
        {
            // ����ִ� ������ ã�Ƽ� ������Ʈ �߰�
            for (int i = 0; i < 10; i++)
            {
                if (inventorySlots[i] == null)
                {
                    GameObject slot = Instantiate(inventorySlotPrefab, slotTransforms[i]);
                    slot.GetComponent<Image>().sprite = itemImage;
                    inventorySlots[i] = slot;
                    break; // ���� �Ҵ� �� �ݺ��� ����
                }
            }
        }
        else
        {
            Debug.Log("�κ��丮�� �� á���ϴ�.");
        }
    }
}