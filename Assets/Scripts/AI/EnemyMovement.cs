using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace AI 
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float horizontalOffset;
        [SerializeField] private SplineContainer path;

        private float3 previousNearest = float3.zero;
        private Vector3 lastPoint;

        void Awake() 
        {
            Vector3 lastPoint = path.transform.TransformPoint(path.Spline.EvaluatePosition(1));
            this.lastPoint = new(lastPoint.x, transform.position.y, lastPoint.z);
        }

        private void Update()
        {
            var localPoint = path.transform.InverseTransformPoint(transform.position);

            SplineUtility.GetNearestPoint(path.Spline, localPoint, out var nearest, out var ratio, 10, 4);

            var tangent = SplineUtility.EvaluateTangent(path.Spline, ratio);

            var rotation = Quaternion.LookRotation(tangent);
            transform.rotation = rotation;

            if (Vector3.SqrMagnitude(previousNearest - nearest) >= 0.0001)
            {
                Vector3 globalNearest = path.transform.TransformPoint(nearest);
                Vector3 perpendicular = Vector3.Cross(tangent, Vector3.up);
                Vector3 position = globalNearest + (perpendicular.normalized * horizontalOffset);
                transform.position = new(position.x, transform.position.y, position.z);

                previousNearest = nearest;
            } 
            else
                Debug.LogWarning("Same nearest point twice in a row! Previous: " + previousNearest + ", New: " + nearest);

            if (Vector3.Distance(transform.position, lastPoint) >= 0.5f)
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        }
    }
}