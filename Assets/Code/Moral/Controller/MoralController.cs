using Interfaces;


namespace Moral
{
    public class MoralController : IExecutable, ICleanable, IInitializable
    {
        #region Fields

        private MoralModel moralModel;
        private MoralView moralView;
        private IMoralProvider moralProvider;

        #endregion

        #region Constructor

        public MoralController(MoralModel moralModel, MoralView moralView, IMoralProvider moralProvider)
        {
            this.moralModel = moralModel;
            this.moralView = moralView;
            this.moralProvider = moralProvider;
            this.moralProvider.GetDamage += GetDamage;
        }

        #endregion

        #region Methods

        private float GetDamage()
        {
            float damage = 0;
            if (moralModel.MoralStruct.MoralStatus == MoralStatus.High)
            {
                damage = 0;
            }
            else if (moralModel.MoralStruct.MoralStatus == MoralStatus.Medium)
            {
                damage = 0;
            }
            else if (moralModel.MoralStruct.MoralStatus == MoralStatus.Low)
            {
                damage = moralModel.MoralStruct.Damage;
            }
            return damage;
        }


        public void Clean()
        {
            
        }

        public void Execute(float deltaTime)
        {
            
            MoralStatusCheck();
            GetDamage();
        }

        public void MoralStatusCheck()
        {
            
            if (moralModel.MoralStruct.MoralAmount > 20)
            {
                moralModel.MoralStruct.MoralStatus = MoralStatus.High;
                
            }
            else if (moralModel.MoralStruct.MoralAmount < 20 && moralModel.MoralStruct.MoralAmount > 10)
            {
                moralModel.MoralStruct.MoralStatus = MoralStatus.Medium;
            }
            else if (moralModel.MoralStruct.MoralAmount < 10)
            {
                moralModel.MoralStruct.MoralStatus = MoralStatus.Low;
                
            }
            
        }

        public void Initialize()
        {
            
        }

        #endregion
    }
}
