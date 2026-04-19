using Core;
using UI;

namespace Presenters
{
    public class HealthPresenter
    {
        private BaseHealth model;
        private HealthBar view;

        public HealthPresenter(BaseHealth model, HealthBar view)
        {
            this.model = model;
            this.view = view;

            this.model.OnHealthChangeAddListener(HandleHealthChanged);

            HandleHealthChanged(model);
        }

        private void HandleHealthChanged(BaseHealth model)
        {
            float fillPercentage = (float)model.CurrentHealth / (float)model.MaxHealth;
            view.UpdateHealthBar(fillPercentage);
        }

        public void Disconnect()
        {
            model.OnHealthChangeRemoveListener(HandleHealthChanged);
        }
    }
}
