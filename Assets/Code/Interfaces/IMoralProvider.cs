using System;


namespace Interfaces
{
    public interface IMoralProvider
    {
        
        event Action<float> onPlayerHPChange;
        
        event Func<float> GetDamage;

        void GetPlayerHPChange();
        
    }
}
