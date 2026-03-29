using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson05Coroutines01
{
    public class Bumper : MonoBehaviour
    {
        [SerializeField] float _bumperForce = -10f, _litDuration = 0.2f;
        [SerializeField] private Color _litColor = Color.white;

        private bool _isLit = false;
        private Color _originalColor;
        private SpriteRenderer _spriteRenderer;

        void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalColor = _spriteRenderer.color;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ball"))
            {
                Vector2 normal = Vector2.zero;
                Rigidbody2D ballRB = collision.collider.GetComponent<Rigidbody2D>();
                if (ballRB != null)
                {
                    if (collision.contactCount > 0)
                    {
                        ContactPoint2D contact = collision.GetContact(0);
                        normal = contact.normal;
                    }
                    else if (normal == Vector2.zero)
                    {
                        Vector2 direction = (collision.rigidbody.position - (Vector2)transform.position).normalized;
                        normal = direction;
                    }
                    Vector2 bumpVelocity = normal * _bumperForce;
                    collision.rigidbody.AddForce(bumpVelocity, ForceMode2D.Impulse);
                }
            }
            Debug.Log($"'{collision.gameObject.name}' has collided with '{gameObject.name}'");
            if (!_isLit)
            {
                StartCoroutine(TriggerLitEffect());
            }
        }

        private IEnumerator TriggerLitEffect()
        {
            _isLit = true;
            _spriteRenderer.color = _litColor;
            yield return new WaitForSeconds(_litDuration);
            _spriteRenderer.color = _originalColor;
            _isLit = false;
        }
    }
}