using PlasticGui.WorkspaceWindow;
using PlasticPipe.PlasticProtocol.Messages;
using UnityEngine;

namespace GMPR2512.Lesson07TransformAndInput
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private bool _projectile_effects_on = false;
        [SerializeField] private GameObject _splosionPrefab;
        private float _speed = 10;
        private Vector2 _direction = Vector2.up;
        internal bool EffectsOn { set => _projectile_effects_on = value; }
        internal Vector2 Direction{ set => _direction = value; }
        internal float Speed { set => _speed = value; }

        void Update()
        {
            transform.Translate(_direction.normalized * _speed * Time.deltaTime, Space.World);
            if (_projectile_effects_on)
            {
                transform.Rotate(0, 0, 360 * Time.deltaTime);
            }
        }
        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.tag == "Alien")
            {
                Instantiate(_splosionPrefab, transform.position, transform.rotation);
                Destroy(collider.gameObject);
                Destroy(gameObject);
            }
            else if(collider.tag == "Obstacle")
            {
                Instantiate(_splosionPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if(collider.tag == "Bounds")
            {
                Destroy(gameObject);
            }
        }
    }
}
