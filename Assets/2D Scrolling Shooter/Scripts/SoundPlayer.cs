using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // 소리 파일 (AudioClip)
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip explosionClip;

    // 유니티에서 소리파일을 재생할 때 사용할 수 있는 컴포넌트
    private AudioSource audioPlayer;

    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void PlayShootSound()
    {
        audioPlayer.PlayOneShot(shootClip);
    }

    public void PlayExplosionSound()
    {
        audioPlayer.PlayOneShot(explosionClip);
    }
}