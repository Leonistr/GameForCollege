using Interfaces;
using Player;


namespace Moral
{
    public class MoralInitializer : IInitializable
    {
        #region Fields

        private IMoralFactory _moralFactory;
        private IController _moralController;
        private MoralView _moralView;
        private IMoralProvider moralProvider;

        #endregion

        #region Constructor

        public MoralInitializer(IMoralFactory moralFactory, PlayerView playerView, IMoralProvider moralProvider)
        {
            _moralFactory = moralFactory;
            this.moralProvider = moralProvider;
            _moralController = _moralFactory.Create(playerView);
            _moralView = _moralFactory.GetMoralView();
        }

        #endregion

        #region Methods

        public IController GetController()
        {
            return _moralController;
        }

        public MoralView GetMoralView()
        {
            return _moralView;
        }

        public void Initialize()
        {
            
        }

        #endregion
    }
}
