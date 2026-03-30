using UnityEngine;

namespace GMPR2512.Lesson07TransformAndInput
{
    public class Alien : MonoBehaviour
    {
        [SerializeField] private int _upperRandomFiringRange;
        [SerializeField] private float _speed = 10;
        [SerializeField] private GameObject _projectilePrefab;

        void Update()
        {
            int rando = Random.Range(1, _upperRandomFiringRange);
            if(rando == 1)
            {
                Vector3 firingPosition = this.gameObject.transform.GetChild(0).position;
                GameObject theProjectile = Instantiate(_projectilePrefab, firingPosition, transform.rotation);
                theProjectile.GetComponent<ProjectileAlien>().Speed = _speed;
                theProjectile.GetComponent<ProjectileAlien>().Direction = transform.up;

            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.tag == "Bounds")
            {
                ArmadaLeader leaderScript = transform.parent.GetComponent<ArmadaLeader>();
                leaderScript.ChangeDirection();
                leaderScript.DropDown();
            }
        }
    }
}
