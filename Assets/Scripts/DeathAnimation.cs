using System.Collections;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite deathSprite;

    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        UpdateSprite();
        DisablePhysics();
        StartCoroutine(Animate());
    }

    private void UpdateSprite()
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sortingOrder = 10;

        if (deathSprite != null)
        {
            spriteRenderer.sprite = deathSprite;
        }
    }

    private void DisablePhysics()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();

        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }

        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null) {
            playerMovement.enabled = false;
        }

        EntityMovement entityMovement = GetComponent<EntityMovement>();
        if (entityMovement != null) {
            entityMovement.enabled = false;
        }
    }

    private IEnumerator Animate()
    {
        float elapsed = 0f;
        float duration = 3f;
        float jumpVelocity = 10f;
        float gravity = -36f;

        Vector3 velocity = Vector3.up * jumpVelocity;

        while (elapsed < duration)
        {
            transform.position += velocity * Time.deltaTime;
            velocity.y += gravity * Time.deltaTime;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
