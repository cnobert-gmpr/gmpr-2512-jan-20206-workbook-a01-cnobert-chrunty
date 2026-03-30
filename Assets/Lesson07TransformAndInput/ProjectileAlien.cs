using PlasticGui.WorkspaceWindow;
using PlasticPipe.PlasticProtocol.Messages;
using UnityEngine;

namespace GMPR2512.Lesson07TransformAndInput
{
    public class ProjectileAlien : MonoBehaviour
    {
        [SerializeField] private GameObject _splosionPrefab;
        private float _speed = 10;
        private Vector2 _direction = Vector2.up;

        internal Vector2 Direction{ set => _direction = value; }
        internal float Speed { set => _speed = value; }

        void Update()
        {
            transform.Translate(_direction.normalized * _speed * Time.deltaTime, Space.World);
        }
        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.tag == "Player")
            {
                Instantiate(_splosionPrefab, transform.position, transform.rotation);
                Destroy(collider.gameObject);
                Destroy(gameObject);
            }            
            if(collider.tag == "Obstacle")
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
