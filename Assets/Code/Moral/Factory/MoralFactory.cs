using Interfaces;
using Player;
using UnityEngine;
using WorldData;
using Extensions;


namespace Moral
{
    public class MoralFactory : IMoralFactory
    {
        #region Fields

        private MoralData _moralData;
        private MoralView _moralView;
        private IMoralProvider moralProvider;

        #endregion

        #region Constructor

        public MoralFactory(MoralData moralData, IMoralProvider moralProvider)
        {
            _moralData = moralData;
            this.moralProvider = moralProvider;
        }

        #endregion

        #region Methods

        public IController Create(PlayerView playerView)
        {
            var moralModel = new MoralModel(_moralData.MoralStruct);
            _moralView = new GameObject(nameof(Moral)).GetOrAddComponent<MoralView>();
            _moralView.transform.parent = playerView.transform;
            var moralController = new MoralController(moralModel, _moralView, this.moralProvider);
            return moralController;
        }

        public MoralView GetMoralView()
        {
            return _moralView;
        }

        #endregion
    }
}
