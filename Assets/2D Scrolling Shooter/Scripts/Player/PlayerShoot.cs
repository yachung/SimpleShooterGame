using UnityEngine;
using UnityEngine.Events;

// �÷��̾��� �߻縦 �����ϴ� ��ũ��Ʈ
public class PlayerShoot : MonoBehaviour
{
    // ź�� �߻� - ���� ����
    // �ڵ����� �߻�ǵ��� ����� ����
    // ź���� �߻�Ǵ� ����
    [SerializeField] private float shootInterval = 0.2f;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;

    // ź���� �߻��� �� �߻���ų �̺�Ʈ (Ÿ��: ����Ƽ �̺�Ʈ)
    public UnityEvent OnShoot;

    // �� ��� ���� (���� �ð� ���)
    private float elapsedTime = 0f;

    private void Awake()
    {
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
        // ź�� �߻� �̺�Ʈ ����
        OnShoot?.Invoke();

        // �ִϸ��̼� Ʈ���� ����.
        //refAnimator.SetTrigger("Shoot");

        // ź�� �߻�.
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("<color=red> bulletPrefab ������ �������� �ʾҽ��ϴ�. </color>");
        }
    }
}