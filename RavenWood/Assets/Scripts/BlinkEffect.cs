using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkEffect : MonoBehaviour
{
    private float initialBlinkInterval = 1.0f; // �ʱ� �����̴� ���� ����
    private Image image;
    public GameObject StartTextPanel;

    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        float blinkInterval = initialBlinkInterval;

        while (blinkInterval > 0.1f)
        {
            // ���̵�ƿ�
            while (image.color.a > 0)
            {
                Color color = image.color;
                color.a -= Time.deltaTime / blinkInterval;
                image.color = color;
                yield return null;
            }

            // ���� ���� 0���� ���� ��츦 �����ϱ� ���� 0���� ����
            Color zeroAlphaColor = image.color;
            zeroAlphaColor.a = 0;
            image.color = zeroAlphaColor;

            yield return new WaitForSeconds(blinkInterval);

            // ���̵���
            while (image.color.a < 1)
            {
                Color color = image.color;
                color.a += Time.deltaTime / blinkInterval;
                image.color = color;
                yield return null;
            }

            // ���� ���� 1���� Ŭ ��츦 �����ϱ� ���� 1�� ����
            Color fullAlphaColor = image.color;
            fullAlphaColor.a = 1;
            image.color = fullAlphaColor;

            // blinkInterval�� ���ҽ�ŵ�ϴ�.
            blinkInterval -= 0.3f;
        }
        StartTextPanel.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
