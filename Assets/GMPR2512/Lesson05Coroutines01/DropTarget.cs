using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson05Coroutines01
{
    public class DropTarget : MonoBehaviour
    {
        [SerializeField] private Color _hitColor = Color.darkMagenta;
        [SerializeField] private float _hideDelay = 0.1f, _resetDelay = 2f;

        private bool _isHit = false;
        private SpriteRenderer _spriteRenderer;
        private Color _originalColor;

        void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalColor = _spriteRenderer.color;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ball") && !_isHit)
            {
                Debug.Log($"'{collision.gameObject.name}' has collided with '{gameObject.name}'");

                _isHit = true;
                _spriteRenderer.color = _hitColor;
                Invoke(nameof(HideTarget), _hideDelay);
            }
        }

        void HideTarget()
        {
            gameObject.SetActive(false);
            Invoke(nameof(ResetTarget), _resetDelay);
        }

        void ResetTarget()
        {
            _spriteRenderer.color = _originalColor;
            gameObject.SetActive(true);
            _isHit = false;
        }
    }
}
