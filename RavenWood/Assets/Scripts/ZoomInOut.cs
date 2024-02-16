using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    GameObject scanObject;
    public float ObjectDistance;

    public PlayerMove playerMove;

    //public List<Transform> fixedPositions;  // ī�޶� ������ų ��ġ ���� ����Ʈ
    //private int currentPositionInedex = 0;  // ���� ��� ���� ��ġ�� �ε���

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                scanObject = hit.collider.gameObject;

                // ������Ʈ�� �÷��̾� ������ �Ÿ�
                float distance = Vector3.Distance(transform.position, scanObject.transform.position);

                if (distance < ObjectDistance)
                {
                    if (scanObject.CompareTag("Zoom"))
                    {
                        SwitchCameraPosition();
                    }
                }
            }
        }
    }

    private void SwitchCameraPosition()
    {
        ObjectData objData = scanObject.GetComponent<ObjectData>();

        if (objData != null && objData.isZoom)
        {
            transform.position = objData.savedPosition;
            playerMove.DisableRotation();
        }
    }
}
