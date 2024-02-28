using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePotion : MonoBehaviour
{
    public float rotateSpeed;

    // 0: ��, 1: ����, 2: ��, 3: ����, 4: �丶��, 5: �����
    public List<GameObject> ingredients = new List<GameObject>();



    void Boil()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
