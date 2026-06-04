using UnityEngine;

public class ChestAnimationHandler : MonoBehaviour
{
    private Animator animator;
    private ChestController chest;
    private void Awake()
    {
        chest = GetComponent<ChestController>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        chest.OnChestOpened += PlayAnimation;
    }

    private void OnDisable()
    {
        chest.OnChestOpened -= PlayAnimation;
    }

    private void PlayAnimation()
    {
        animator.SetTrigger("OpenChest");
    }
}
