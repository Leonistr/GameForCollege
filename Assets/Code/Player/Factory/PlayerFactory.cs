using Interfaces;
using UnityEngine;
using WorldData;
using Extensions;
using Providers;


namespace Player
{
    public class PlayerFactory : IPlayerFactory
    {
        #region Fields

        private PlayerData _playerData;
        private PlayerView _playerView;
        private IMoralProvider _moralProvider;
        private RoomProvider _roomProvider;

        #endregion

        #region Constructor

        public PlayerFactory(PlayerData playerData, IMoralProvider moralProvider, RoomProvider roomProvider)
        {
            _playerData = playerData;
            this._moralProvider = moralProvider;
            this._roomProvider = roomProvider;
        }

        #endregion

        #region Methods

        public IController Create((IInputProvider horizontal, IInputProvider vertical) input)
        {
            var spawnPosition = GameObject.FindGameObjectWithTag("Spawn");
            var playerModel = new PlayerModel(_playerData.PlayerStruct);
            _playerView = Object.Instantiate(_playerData.Player, spawnPosition.transform.position, Quaternion.identity).GetOrAddComponent<PlayerView>();
            PlayerController playerController = new PlayerController(playerModel, _playerView, input, this._moralProvider);
            return playerController;
        }

        public PlayerView GetPlayerView()
        {
            return _playerView;
        }

        #endregion
    }
}
