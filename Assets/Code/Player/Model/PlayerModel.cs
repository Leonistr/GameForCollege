using Interfaces;


namespace Player
{
    public class PlayerModel
    {
        #region Fields

        public IPlayer PlayerStruct;

        #endregion

        #region Constructor

        public PlayerModel(IPlayer playerStruct)
        {
            PlayerStruct = playerStruct;
        }

        #endregion
    }
}
