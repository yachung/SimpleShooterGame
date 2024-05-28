using UnityEngine;

public class BGScroller : MonoBehaviour
{
    // ��ũ�� ������ ������ �� �ֵ��� �ϴ� ������
    public enum Direction
    {
        Up,
        Down
    }

    // ��� ��ũ�� ���� ���� ����
    [SerializeField] private Direction direction = Direction.Down;

    [SerializeField] private float speed = 0.1f;

    // �޽� �������� �����ϴ� ��Ƽ������ Offset ���� �����ؾ� ��.
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        // ��ũ�ѿ� ������ ���� ��ȣ�� ����
        float finalScroll = direction == Direction.Down ? speed : -speed;

        // ��Ƽ������ �����ϴ� �ؽ����� offset�� �� Y���� ����
        meshRenderer.material.mainTextureOffset += new Vector2(0f, finalScroll) * Time.deltaTime;
    }
}
