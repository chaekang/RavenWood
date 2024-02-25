using UnityEngine;

public class DragAbleObject : MonoBehaviour
{
    Vector3 mousePosition;
    bool isDragging = false;
    float clickTime = 0f;
    float dragDelay = 0.5f; // �����̱� ���� �ּ� Ŭ�� �ð�
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
            // ���콺�� �̵� �������� ����ĳ��Ʈ ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                // �浹�� ��ü�� Collider�� ������
                Collider hitCollider = hitInfo.collider;
                // ���� �浹�� ��ü�� Collider�� �ڽ��� Collider�� �ƴϸ� �̵��� ����
                if (hitCollider != collider)
                    return;
            }

            // �浹�� ������ �̵� �����ϹǷ� ��ġ ����
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        EndDragging();
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    void StartDragging()
    {
        rigidbody.mass = 0.1f;
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void EndDragging()
    {
        rigidbody.mass = 5f;
        rigidbody.useGravity = true;
        rigidbody.constraints &= ~RigidbodyConstraints.FreezeRotation;
    }
}
