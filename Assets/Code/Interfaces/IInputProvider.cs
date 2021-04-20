using System;


namespace Interfaces
{
    public interface IInputProvider
    {
        event Action<float> OnAxisChange;

        void GetAxis();
    }
}
