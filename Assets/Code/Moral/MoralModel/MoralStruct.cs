using System;
using Interfaces;


namespace Moral
{
    [Serializable]
    public struct MoralStruct : IMoral
    {
        #region Fields

        public float MoralAmount;
        public MoralStatus MoralStatus;
        public float MoralDamage;

        #endregion

        #region Properties

        float IMoral.Damage { get => MoralDamage;}
        float IMoral.MoralAmount { get => MoralAmount; set => MoralAmount = value; }
        MoralStatus IMoral.MoralStatus { get => MoralStatus; set => MoralStatus = value; }

        #endregion
    }
}
