using UnityEngine;
using UnityEngine.Splines;

namespace AI
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 4f;
        [SerializeField] private SplineContainer path;

        private Enemy enemy;
        private float currentT;
        private bool finished;

        private void Awake()
        {
            if (path == null)
                path = Object.FindFirstObjectByType<SplineContainer>();

            enemy = GetComponent<Enemy>();
            currentT = 0f;
        }

        private void Update()
        {
            if (finished || path == null)
                return;

            float splineLength = path.Spline.GetLength();
            if (splineLength > 0f)
                currentT += speed / splineLength * Time.deltaTime;

            if (currentT >= 1f)
            {
                currentT = 1f;
                finished = true;
                enemy?.ReachBase();
                return;
            }

            Vector3 worldPos = path.transform.TransformPoint(path.Spline.EvaluatePosition(currentT));
            transform.position = new Vector3(worldPos.x, transform.position.y, worldPos.z);
        }
    }
}
