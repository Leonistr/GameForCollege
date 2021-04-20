using Interfaces;


namespace InputControllers
{
    class InputController : IExecutable
    {
        #region Fields

        private readonly IInputProvider _horizontalInputController;
        private readonly IInputProvider _verticalInputProvider;

        #endregion

        #region Constructor

        public InputController((IInputProvider vertical, IInputProvider horizontal) input)
        {
            _horizontalInputController = input.horizontal;
            _verticalInputProvider = input.vertical;
        }

        #endregion

        #region Methods

        public void Execute(float deltaTime)
        {
            _horizontalInputController.GetAxis();
            _verticalInputProvider.GetAxis();
        }

        #endregion
    }
}
