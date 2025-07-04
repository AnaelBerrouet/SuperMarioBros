using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer smallRenderer;
    public PlayerSpriteRenderer bigRenderer;
    public bool big => bigRenderer.enabled;
    public bool small => smallRenderer.enabled;
    public bool dead => deathAnimation.enabled;

    private DeathAnimation deathAnimation;

    private void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
    }
    public void Hit()
    {
        if (big)
        {
            Shrink();
        }
        else
        {
            Death();
        }
    }

    private void Shrink()
    {
        smallRenderer.enabled = false;
        bigRenderer.enabled = true;
    }

    private void Death()
    {
        smallRenderer.enabled = false;
        bigRenderer.enabled = false;

        AnimatedSprite animatedSprite = GetComponentInChildren<AnimatedSprite>();
        animatedSprite.enabled = false;

        deathAnimation.enabled = true;

        GameManager.Instance.ResetLevel(3f);
    }
}
