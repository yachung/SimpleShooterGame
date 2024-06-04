using System;
using UnityEngine;

// �� ĳ���� �׷��� ������ �ð� ���ݸ��� �����ϴ� �� ������ ��ũ��Ʈ.
public class EnemySpawner : MonoBehaviour
{
    // �� ĳ���� ����(���� �߿� ����) ����.
    [Serializable]
    public class EnemySpawnInfo
    {
        // ������ �� ĳ���� �׷� ������.
        [SerializeField] private GameObject prefab;

        // �����ϱ���� ����� ���� �ð�(����: ��).
        [SerializeField] private float spawnTime;

        // Getter.
        public GameObject Prefab { get { return prefab; } }
        public float SpwanTime { get { return spawnTime; } }
    }

    // �� ĳ���� ���� ���� �迭 ����.
    [SerializeField] private EnemySpawnInfo[] spawnInfo;

    // �� ���� �� ����� �迭 �ε���.
    private int currentIndex = 0;

    private void Awake()
    {
        Invoke("Spawn", spawnInfo[currentIndex].SpwanTime);
    }

    // ������ �� �׷��� �����ϴ� �Լ�.
    private void Spawn()
    {
        // �������� ���� ����.
        Instantiate(spawnInfo[currentIndex].Prefab, transform.position, Quaternion.identity);

        // �迭 �ε��� ������Ʈ.
        currentIndex = (currentIndex + 1) % spawnInfo.Length;

        // ���� Spawn �Լ� ȣ�� ���.
        Invoke("Spawn", spawnInfo[currentIndex].SpwanTime);
    }
}