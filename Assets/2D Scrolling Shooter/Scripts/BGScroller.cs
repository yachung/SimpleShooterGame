using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;

    // �޽� �������� �����ϴ� ��Ƽ������ Offset ���� �����ؾ� ��.
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        // ��Ƽ������ �����ϴ� �ؽ����� offset�� �� Y���� ����
        meshRenderer.material.mainTextureOffset += new Vector2(0f, speed) * Time.deltaTime;
    }
}
