using UnityEngine;

// ����� Ŭ���� ����ϴ� ���� �÷��̾�.
public class SoundPlayer : MonoBehaviour
{
    // �Ҹ� ���� (AudioClip).
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip explosionClip;

    // ����Ƽ���� �Ҹ� ������ ����� �� ����� �� �ִ� ������Ʈ.
    private AudioSource audioPlayer;

    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    // ����� ��� �Լ�.
    public void PlayShootSound()
    {
        audioPlayer.PlayOneShot(shootClip);
    }

    public void PlayExplosionSound()
    {
        audioPlayer.PlayOneShot(explosionClip);
    }
}