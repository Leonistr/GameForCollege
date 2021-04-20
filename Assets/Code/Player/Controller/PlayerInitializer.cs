using Interfaces;


namespace Player
{
    class PlayerInitializer : IInitializable
    {
        #region Fields

        private IPlayerFactory _playerFactory;
        private IController _playerController;
        private PlayerView _playerView;
        private IMoralProvider moralProvider;

        #endregion

        #region Constructor

        public PlayerInitializer(IPlayerFactory playerFactory, (IInputProvider horizontal, IInputProvider vertical) input, IMoralProvider moralProvider)
        {
            this.moralProvider = moralProvider;
            _playerFactory = playerFactory;
            _playerController = _playerFactory.Create(input);
            _playerView = _playerFactory.GetPlayerView();
        }

        #endregion

        #region Methods

        public PlayerView GetPlayerView()
        {
            return _playerView;
        }

        public IController GetController()
        {
            return _playerController;
        }

        public void Initialize()
        {
            
        }

        #endregion  
    }
}
