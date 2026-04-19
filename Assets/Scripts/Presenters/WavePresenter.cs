using Managers;
using UI;

namespace Presenters
{
    public class WavePresenter
    {
        private WaveCounter view;

        public WavePresenter(WaveCounter view)
        {
            this.view = view;

            WaveManager.Instance.OnWaveStartAddListener(HandleWaveChanged);

            HandleWaveChanged();
        }

        private void HandleWaveChanged()
        {
            var maxWave = WaveManager.Instance.WaveCount.ToString();
            var activeWave = (WaveManager.Instance.CurrentWaveIndex + 1).ToString();
            view.UpdateWaveCounter(activeWave, maxWave);
        }

        public void Disconnect()
        {
            WaveManager.Instance.OnWaveStartRemoveListener(HandleWaveChanged);
        }
    }
}
