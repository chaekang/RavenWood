using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SmoothCameraRotation : MonoBehaviour
{
    public Transform target; // ī�޶� �ٶ� ���
    public float rotationSpeed = 1.0f; // ȸ�� �ӵ�

    private Quaternion targetRotation; // ��ǥ ȸ����
    public bool isStart = false;

    void Start()
    {
        GameObject targetObject = GameObject.Find("TargetPlane"); // ����� GameObject�� ã���ϴ�.
        if (targetObject != null)
        {
            target = targetObject.transform; // ����� Transform�� �Ҵ��մϴ�.
        }
        else
        {
            Debug.LogError("Target GameObject not found!"); // ����� ã�� ���� ��� ������ ����մϴ�.
        }

        targetRotation = transform.rotation;
    }

    void Update()
    {
        if (isStart)
        {
            GameObject playerObject = GameObject.Find("Respawn");

            if (playerObject != null)
            {
                target = playerObject.transform;
            }
        }

        if (target != null)
        {
            // ����� �ٶ󺸴� ���� ���͸� ���մϴ�.
            Vector3 directionToTarget = target.position - transform.position;
            directionToTarget.y = 0f; // y�� ������ ȸ������ �ʵ��� �մϴ�.

            // ��ǥ ȸ������ ����� ���ϴ� �������� �����մϴ�.
            targetRotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
        }

        // ���� ȸ������ ��ǥ ȸ������ ���� �����մϴ�.
        Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // ī�޶��� ȸ������ ������Ʈ�մϴ�.
        transform.rotation = newRotation;
    }
}
