using UnityEngine;

namespace GMPR2512.Lesson07TransformAndInput
{
    public class ArmadaLeader : MonoBehaviour
    {
        [SerializeField] private int _numberOfShips = 8;
        [SerializeField] private GameObject _alienShipPrefab;
        [SerializeField] private float _speed = 1.0f;
        [SerializeField] private Vector2 _direction = new Vector2(-1, 0);
        

        void Start()
        {
            InstantiateAlienShips();
        }
        void Update()
        {
            transform.Translate(_direction.normalized * _speed * Time.deltaTime);
        }
        void InstantiateAlienShips()
        {
            for(int i = 0; i < _numberOfShips; i++)
            {
                Vector3 position = transform.position + new Vector3(i * 1.5f, 0, 0);
                Instantiate(_alienShipPrefab, position, transform.rotation, transform);
            }
        }
        public void ChangeDirection()
        {
            _direction *= -1;
        }
        public void DropDown()
        { 
            transform.Translate(Vector2.up * 0.5f );
        }
    }
}
