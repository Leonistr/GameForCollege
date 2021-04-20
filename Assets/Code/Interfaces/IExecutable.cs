namespace Interfaces
{
    interface IExecutable : IController
    {
        void Execute(float deltaTime);
    }
}
