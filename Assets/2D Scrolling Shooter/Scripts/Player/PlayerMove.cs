using UnityEngine;

// ���콺 �巡��(�����-��ġ)�� ����ؼ� �÷��̾ �̵���Ű�� ��ũ��Ʈ.
public class PlayerMove : MonoBehaviour
{
    // �ּ�/�ִ� ������ ������ �� ����� Ŭ���� ����.
    // �츮�� ������ Ŭ������ ����Ƽ�� ��.
    // �� Ŭ������ �ν����Ϳ� �����Ϸ���, ��������� �Ʒ� �±׸� �߰��ؾ���.
    [System.Serializable]
    class ClampValue
    {
        // ������ ������ �� ����� �ּҰ�.
        [SerializeField] private float min;

        // ������ ������ �� ����� �ִ밪.
        [SerializeField] private float max;

        public float Min { get { return min; } }
        public float Max { get { return max; } }

        // ���� ���� ���� min�� max ������ ������ �������ִ� �Լ�.
        public float Clamp(float target)
        {
            return Mathf.Clamp(target, min, max);
        }
    }

    // �÷��̾ �̵��� �� ������ ������ �ӵ� ��.
    [SerializeField] private float lagSpeed = 5f;

    // x ��ġ�� ����� ���� ����.
    [SerializeField] private ClampValue clampX;

    // y ��ġ�� ����� ���� ����.
    [SerializeField] private ClampValue clampY;

    // ī�޶� ������ ���� ����.
    private Camera mainCamera;

    // �÷��̾�� �巡�� ��ġ�� ������ ��.
    private Vector3 offset;

    // Ʈ������ ���� ����.
    private Transform refTransform;

    private void Awake()
    {
        // ���� ī�޶� ������ ����.
        mainCamera = Camera.main;

        // Ʈ������ ����.
        refTransform = transform;
    }

    private void Update()
    {
        // ���콺 Ŭ���� ������ �� ���콺 Ŭ�� ��ġ�� �÷��̾��� ��ġ�� ���������� ���.
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ��ġ�� 3���� ���� ��ǥ�� ��ȯ.
            Vector3 clickPosition
                = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = refTransform.position.z;

            // ������ ��� �� ����.
            offset = refTransform.position - clickPosition;
        }

        // ���콺 Ŭ�� �� �ݺ�.
        if (Input.GetMouseButton(0))
        {
            // ���콺 ��ġ�� 3���� ���� ��ǥ�� ��ȯ.
            Vector3 clickPosition
                = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = refTransform.position.z;

            // �������� ������ �̵��ؾ��� ���� ��ġ�� �ϴ� ����.
            Vector3 targetPosition = clickPosition + offset;

            // x ���� ��ġ�� ȭ���� ����� �ʵ��� ����.
            //targetPosition.x = Mathf.Clamp(targetPosition.x, clampX.Min, clampX.Max);
            targetPosition.x = clampX.Clamp(targetPosition.x);

            // y���� ��ġ�� ����.
            //targetPosition.y = Mathf.Clamp(targetPosition.y, clampY.Min, clampY.Max);
            targetPosition.y = clampY.Clamp(targetPosition.y);

            // 3�������� ��ȯ�� ��ģ ��ġ�� �÷��̾��� ��ġ�� ����.
            //refTransform.position = clickPosition + offset;
            refTransform.position = Vector3.Lerp(
                refTransform.position,
                targetPosition,
                Time.deltaTime * lagSpeed
            );
        }

        // Ŭ�� ���� �� �� ����.
        if (Input.GetMouseButtonUp(0))
        {
            offset = Vector3.zero;
        }
    }
}