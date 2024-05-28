using UnityEngine;

// �÷��̾��� �߻縦 �����ϴ� ��ũ��Ʈ
public class PlayerShoot : MonoBehaviour
{
    // ź�� �߻� - ���� ����
    // �ڵ����� �߻�ǵ��� ����� ����
    // ź���� �߻�Ǵ� ����
    [SerializeField] private float shootInterval = 0.2f;

    [SerializeField] private GameObject bulletPrefab;

    // �ִϸ��̼� ����
    private Animator refAnimator;

    // �� ��� ���� (���� �ð� ���)
    private float elapsedTime = 0f;

    private void Awake()
    {
        // �ִϸ��̼� ������Ʈ �ʱ�ȭ
        refAnimator = GetComponent<Animator>();

        // �ڵ����� �ݺ� ���� �ǵ��� ����
        //InvokeRepeating("Shoot", 0f, shootInterval);
    }

    private void Update()
    {
        // Ÿ�̸� ������Ʈ
        elapsedTime += Time.deltaTime;
        if (elapsedTime > shootInterval)
        {
            Shoot();
            elapsedTime = 0f;
        }
    }

    // �߻� �Լ�
    private void Shoot()
    {
        // �ִϸ��̼� Ʈ���� ����.
        refAnimator.SetTrigger("Shoot");

        // ź�� �߻�.
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        else
        {
            Debug.Log("<color=red> bulletPrefab ������ �������� �ʾҽ��ϴ�. </color>");
        }
    }
}