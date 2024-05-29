using UnityEngine;

// �÷��̾��� �ִϸ��̼� ���¸� �����ϴ� ��ũ��Ʈ
public class AnimationController : MonoBehaviour
{
    private Animator refAnimator;

    private void Awake()
    {
        refAnimator = GetComponent<Animator>();
    }

    // Animator�� Shoot Ʈ���Ÿ� �����ϴ� �Լ� - �������̽�
    public void SetShootTrigger()
    {
        refAnimator.SetTrigger("Shoot");
    }
}
