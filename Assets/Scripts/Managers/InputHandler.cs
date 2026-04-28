using Abstraction;

namespace Managers 
{
    public class InputHandler : PersistentSingleton<InputHandler>
    {
        public InputSystem_Actions InputActions { get; private set; } = new();

        protected override InputHandler CreateInstance() => this;



        private void OnEnable() 
        {
            if (InputActions == null)
                InputActions = new();
            InputActions.Enable();
        }

        private void OnDisable() => InputActions.Disable();
    }
}