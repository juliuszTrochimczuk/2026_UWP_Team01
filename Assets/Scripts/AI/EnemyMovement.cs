using UnityEngine;
using UnityEngine.Splines;

namespace AI
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 4f;

        private SplineContainer path;
        private float splineLength;

        private Enemy enemy;
        private float currentT;
        private bool finished;

        private void Awake()
        {
            enemy = GetComponent<Enemy>();
        }

        private void Update()
        {
            if (finished || path == null)
                return;

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

        public void SetPath(SplineContainer path)
        {
            this.path = path;
            splineLength = path.Spline.GetLength();
        }

    }
}
