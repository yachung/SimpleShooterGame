using UnityEngine;
using UnityEngine.Events;

// �÷��̾��� �߻縦 �����ϴ� ��ũ��Ʈ.
public class PlayerShoot : MonoBehaviour
{
    // ź�� �߻� - ���� ����.
    // �ڵ����� �߻�ǵ��� ����� ����.
    // ź���� �߻�Ǵ� ����.
    [SerializeField] private float shootInterval = 0.2f;
    
    // �÷��̾� ź�� ������.
    [SerializeField] private GameObject bulletPrefab;

    // ź�� �߻� ��ġ Ʈ������.
    [SerializeField] private Transform firePosition;

    // ź���� �߻��� �� �߻���ų �̺�Ʈ (Ÿ��: ����Ƽ �̺�Ʈ).
    public UnityEvent OnShoot;

    // �� ��� ���� (���� �ð� ���).
    private float elapsedTime = 0f;

    private void Awake()
    {
        // �ڵ����� �ݺ� ����ǵ��� ����.
        //InvokeRepeating("Shoot", 0f, shootIntervale);

        //CancelInvoke("Shoot");
    }

    private void Update()
    {
        // Ÿ�̸� ������Ʈ.
        elapsedTime += Time.deltaTime;
        
        // Ÿ�̸Ӱ� �߻� ���� �ð���ŭ ��������,
        if (elapsedTime > shootInterval)
        {
            // �߻��ϰ�,
            Shoot();

            // Ÿ�̸� �ʱ�ȭ.
            elapsedTime = 0f;
        }
    }

    // �߻� �Լ�.
    private void Shoot()
    {
        // ź�� �߻� �̺�Ʈ ����.
        OnShoot?.Invoke();

        //if (OnShoot != null)
        //{
        //    OnShoot.Invoke();
        //}

        // ź�� �߻�.
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, firePosition.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("<color=red> bulletPrefab ������ �������� �ʾҽ��ϴ�. </color>");
        }
    }
}