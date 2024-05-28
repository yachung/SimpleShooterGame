using UnityEngine;

public class BGScroller : MonoBehaviour
{
    // 스크롤 방향을 지정할 수 있도록 하는 열거형
    public enum Direction
    {
        Up,
        Down
    }

    // 배경 스크롤 방향 지정 변수
    [SerializeField] private Direction direction = Direction.Down;

    [SerializeField] private float speed = 0.1f;

    // 메시 렌더러가 관리하는 머티리얼의 Offset 값을 조정해야 함.
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        // 스크롤에 적용할 값의 부호를 결정
        float finalScroll = direction == Direction.Down ? speed : -speed;

        // 머티리얼이 관리하는 텍스쳐의 offset값 중 Y값을 조정
        meshRenderer.material.mainTextureOffset += new Vector2(0f, finalScroll) * Time.deltaTime;
    }
}
