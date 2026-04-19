using Managers;
using UI;

namespace Presenters
{
    public class NextWavePresenter
    {
        private NextWaveCounter view;

        public NextWavePresenter(NextWaveCounter view)
        {
            this.view = view;

            WaveManager.Instance.OnWaveStartAddListener(HandleWaveChanged);

            HandleWaveChanged();
        }

        private void HandleWaveChanged()
        {
            var enemyCount = WaveManager.Instance.NextWave.SpawnCount.ToString();
            var enemyType = WaveManager.Instance.NextWave.EnemyType;
            view.UpdateNextWaveCounter(enemyType, enemyCount);
        }

        public void Disconnect()
        {
            WaveManager.Instance.OnWaveStartRemoveListener(HandleWaveChanged);
        }
    }
}
