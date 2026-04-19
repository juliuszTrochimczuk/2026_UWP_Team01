using Managers;
using UI;

namespace Presenters
{
    public class CoinsPresenter
    {
        private CoinsCounter view;

        public CoinsPresenter(CoinsCounter view)
        {
            this.view = view;

            CoinsManager.Instance.OnCoinsChangedAddListener(HandleCoinsChanged);

            HandleCoinsChanged();
        }

        private void HandleCoinsChanged()
        {
            var coinsCounter = CoinsManager.Instance.Coins.ToString();
            view.UpdateCoinsCounter(coinsCounter);
        }

        public void Disconnect()
        {
            CoinsManager.Instance.OnCoinsChangedRemoveListener(HandleCoinsChanged);
        }
    }
}
