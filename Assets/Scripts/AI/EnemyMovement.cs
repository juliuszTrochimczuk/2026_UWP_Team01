using System;
using UnityEngine;
using UnityEngine.Splines;

namespace AI
{
    public class EnemyMovement : MonoBehaviour
    {
        [NonSerialized] public float speed = 4f;

        private SplineContainer path;
        private float splineLength;

        private float currentT;
        public float Progress => currentT;

        public void MoveEnemy()
        {
            if (currentT >= 1f)
            {
                currentT = 1f;
                return;
            }

            currentT += speed / splineLength * Time.deltaTime;

            Vector3 worldPos = path.transform.TransformPoint(path.Spline.EvaluatePosition(currentT));
            transform.position = new Vector3(worldPos.x, transform.position.y, worldPos.z);
        }

        public void SetPath(SplineContainer path)
        {
            this.path = path;
            splineLength = path.Spline.GetLength();
            currentT = 0f;
        }
    }
}
