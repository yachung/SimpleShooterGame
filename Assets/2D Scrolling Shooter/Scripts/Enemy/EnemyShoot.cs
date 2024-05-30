using UnityEngine;

// �� ���ּ��� ź��߻縦 ó���ϴ� ��ũ��Ʈ.
public class EnemyShoot : MonoBehaviour
{
    // �ʵ�
    // �߻� ����
    [SerializeField] private float shootInterval = 1.5f;
    [SerializeField] private float bulletSpeed = 3f;
    [SerializeField] private GameObject bulletPrefab;

    // �÷��̾��� Ʈ�������� �����ϴ� ����
    private Transform refPlayer;

    // ��� �ð��� ����ϴ� ����
    private float elapsedTime = 0f;

    private void Awake()
    {
        // �÷��̾� ���� ������Ʈ�� �˻��� �ڿ� refPlayer�� Ʈ������ ����
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            refPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > shootInterval)
        {
            Shoot();
            elapsedTime = 0f;
        }
    }

    // �߻� �޼ҵ�.
    private void Shoot()
    {
        // ����.
        if (refPlayer == null)
            return;

        // �÷��̾��� ��ġ�� ���ϴ� ���� ���ϱ�.
        Vector3 direction = refPlayer.position - transform.position;

        // �������� �̿��� ź���� �����ϰ�,
        var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // rigidbody2d ������Ʈ�� �ӵ�(������/����) ����.
        float speed = Random.Range(bulletSpeed * 0.8f, bulletSpeed * 1.2f);
        newBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
    }
}
