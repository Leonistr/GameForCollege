using Interfaces;
using System;


namespace Player
{
    [Serializable]
    public struct PlayerStruct : IPlayer
    {
        #region Fields

        public float HP;
        public float Speed;
        public float TurningSpeed;

        #endregion

        #region Properties

        float IPlayer.HP { get => HP; set => HP = value; }
        float IPlayer.Speed { get => Speed; set => Speed = value; }

        float IPlayer.TurningSpeed => TurningSpeed;

        #endregion
    }
}
