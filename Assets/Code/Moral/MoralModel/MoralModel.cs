using Interfaces;


namespace Moral
{
    public class MoralModel 
    {
        #region Fields

        public IMoral MoralStruct;

        #endregion

        #region Constructor

        public MoralModel(IMoral moralStruct)
        {
            MoralStruct = moralStruct;
        }

        #endregion
    }
}
