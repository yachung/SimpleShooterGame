using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;

    // 메시 렌더러가 관리하는 머티리얼의 Offset 값을 조정해야 함.
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        // 머티리얼이 관리하는 텍스쳐의 offset값 중 Y값을 조정
        meshRenderer.material.mainTextureOffset += new Vector2(0f, speed) * Time.deltaTime;
    }
}
