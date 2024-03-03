using UnityEngine;
using System.Collections;

public class DragAbleObject : MonoBehaviour
{
    Vector3 mousePosition;
    bool isDragging = false;
    float clickTime = 0f;
    float dragDelay = 0.5f; // �����̱� ���� �ּ� Ŭ�� �ð�
    Vector3 startPosition;
    new Rigidbody rigidbody;
    new Collider collider;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
        clickTime = Time.time;
        startPosition = transform.position; // ���� ������ ���
    }

    private void OnMouseDrag()
    {
        // ���� �ð� �̻� ������ �ִ��� Ȯ��
        if (!isDragging && Time.time - clickTime > dragDelay)
        {
            isDragging = true;
            StartDragging();
        }

        if (isDragging)
        {
            // �浹 ���θ� �˻��Ͽ� �̵��� ����
            if (isColliding())
            {
                return;
            }

            // �浹�� ������ �̵� �����ϹǷ� ��ġ ����
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        StartCoroutine(EndDraggingWithDelay());
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    void StartDragging()
    {
        rigidbody.mass = 0.1f;
        rigidbody.useGravity = false;
    }

    IEnumerator EndDraggingWithDelay()
    {
        rigidbody.mass = 5f;
        rigidbody.useGravity = true;

        yield return new WaitForSeconds(1f);

        if (transform.position.y < 0)
        {
            transform.position = startPosition;
        }
    }

    bool isColliding()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, collider.bounds.extents);
        foreach (Collider col in colliders)
        {
            if (col.tag == "Room" && col != collider && isDragging)
            {
                Vector3 direction = col.ClosestPoint(transform.position) - transform.position;
                Debug.Log("Collided with object at direction: " + direction.normalized);

                // �浹�� ������ �ݴ� �������� ���� ���ϱ� ���� ������ ������Ŵ
                Vector3 forceDirection = -direction.normalized;

                isDragging = false;

                // ���� ���� ������ ������ �� �ֵ��� ���� (�� ���������� 10�� ���� ����)
                float forceMagnitude = 10f;

                // Rigidbody�� ���� ����
                rigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);

                // �浹�� ��ġ�� �̵���Ű�� ����
                return false;
            }
        }
        return false;
    }
}
