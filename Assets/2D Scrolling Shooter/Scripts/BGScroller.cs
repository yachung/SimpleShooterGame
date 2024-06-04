using UnityEngine;

// ����� ��ũ�� ��Ű�� ��ũ��Ʈ.
public class BGScroller : MonoBehaviour
{
    // ��ũ�� ������ ������ �� �ֵ��� �ϴ� ������.
    public enum Direction
    {
        Up,
        Down
    }

    // ��� ��ũ�� ���� ���� ����.
    [SerializeField] private Direction direction = Direction.Down;

    // ����� �귯���� �� �� ����ϴ� ���� ��.
    [SerializeField] private float speed = 0.1f;

    // �޽� �������� �����ϴ� ��Ƽ������ Offset ���� �����ؾ� ��.
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        // ��ũ�ѿ� ������ ���� ��ȣ�� ����.
        float finalScrol = direction == Direction.Down ? speed : -speed;

        // ��Ƽ������ �����ϴ� �ؽ�ó�� Offset �� �� Y ���� ����.
        meshRenderer.material.mainTextureOffset 
            += new Vector2(0f, finalScrol) * Time.deltaTime;
    }
}