using UnityEngine;

namespace GMPR2512
{
    public class ShowGizmo : MonoBehaviour
    {
        [SerializeField] private Color _gizmoColor = Color.yellow;
        [SerializeField] private float _gizmoRadius = 0.5f;

        void OnDrawGizmos()
        {
            Gizmos.color = _gizmoColor;
            Gizmos.DrawSphere(transform.position, _gizmoRadius);
        }
    }
}
