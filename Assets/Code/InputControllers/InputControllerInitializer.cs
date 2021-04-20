using Interfaces;


namespace InputControllers
{
    class InputControllerInitializer : IInitializable
    {
        #region Fields

        private IInputProvider _verticalInput;
        private IInputProvider _horizontalInput;

        #endregion

        #region Constructor

        public InputControllerInitializer()
        {
            _verticalInput = new VerticalInputController();
            _horizontalInput = new HorizontalInputController();
        }

        #endregion

        #region Methods

        public (IInputProvider horizontal, IInputProvider vertical) GetInput()
        {
            (IInputProvider horizontal, IInputProvider vertical) result = (_horizontalInput, _verticalInput);
            return result;
        }

        public void Initialize()
        {

        }

        #endregion
    }
}
