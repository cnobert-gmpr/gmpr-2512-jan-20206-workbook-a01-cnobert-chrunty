using UnityEngine;
using UnityEngine.InputSystem;


namespace GMPR2512.Lesson07TransformAndInput
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 5, _rotationSpeed = 200;
        [SerializeField] private float _minRotation = -25, _maxRotation = 25;
        [SerializeField] private float _player_bounds = 8;
        [SerializeField] private float projectile_speed = 10;
        [SerializeField] private GameObject _projectilePrefab, _bigShotProjectilePrefab;
        [SerializeField] private GameObject projectileStartPosition;
        [SerializeField] private GameObject projectileSecondStartPosition;
        private bool _left_firing = true;
        private InputAction _moveAction, _rotateAction, _fireAction, _big_shotAction;

        void Awake()
        {
            _moveAction = InputSystem.actions.FindAction("Player/Move");
            _rotateAction = InputSystem.actions.FindAction("Player/Rotate");
            _fireAction = InputSystem.actions.FindAction("Player/Jump");
            _big_shotAction = InputSystem.actions.FindAction("Player/Fire2");
        }
        // Unity will keep the input actions disabled by default
        // for efficiency reasons. So, we need to enable/disable them.
        // It's best practice to include the methods below.
        void OnEnable()
        {
            _moveAction?.Enable();
            _rotateAction?.Enable();
            if(_fireAction != null)
            {
                _fireAction.Enable();
                _fireAction.performed += FireButtonPressed;
            }
            if(_big_shotAction != null)
            {
                _big_shotAction.Enable();
                _big_shotAction.performed += BigShotPressed;
            }
        }
        void OnDisable()
        {
            _moveAction?.Disable();
            _rotateAction?.Disable();
            _fireAction?.Disable();
            _big_shotAction?.Disable();
        }
        void Update()
        {
            Movement();
            KeepInBounds();
            Rotation();
        }
        void Movement()
        {
            Vector2 moveDirection = _moveAction.ReadValue<Vector2>();
            moveDirection.y = 0;
            Vector2 translation = moveDirection.normalized * _movementSpeed * Time.deltaTime;
            transform.Translate(translation, Space.World);
        }
        void KeepInBounds()
        {
            Vector3 pos = transform.position;
            if(pos.x < -_player_bounds)
                pos.x = -_player_bounds;
            if(pos.x > _player_bounds)
                pos.x = _player_bounds;
            transform.position = pos;
        }
        void Rotation()
        {
            float rotationValue = _rotateAction.ReadValue<float>() * _rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotationValue);
            //clamp rotations
            Vector3 eulers = transform.eulerAngles;
            // convert to signed range (-180 to 180)
            if(eulers.z > 180) eulers.z -= 360;
            eulers.z = Mathf.Clamp(eulers.z, _minRotation, _maxRotation);
            transform.eulerAngles = eulers;
        }
        void FireButtonPressed(InputAction.CallbackContext context)
        {
            _process_shot(_projectilePrefab);
        }
        void BigShotPressed(InputAction.CallbackContext context)
        {
            _process_shot(_bigShotProjectilePrefab);
        }
        void _process_shot(GameObject projectilePrefab)
        {
            if (_left_firing)
            {
                GameObject theProjectile = 
                    Instantiate(projectilePrefab, projectileStartPosition.transform.position, transform.rotation);
                Projectile projectileScript = theProjectile.GetComponent<Projectile>();
                projectileScript.Speed = projectile_speed;
                projectileScript.Direction = transform.up;
            }
            else
            {
                GameObject theProjectile = 
                    Instantiate(projectilePrefab, projectileSecondStartPosition.transform.position, transform.rotation);
                Projectile projectileScript = theProjectile.GetComponent<Projectile>();
                projectileScript.Speed = projectile_speed;
                projectileScript.Direction = transform.up;
            }
            _left_firing = !_left_firing;
        }
    }
}
