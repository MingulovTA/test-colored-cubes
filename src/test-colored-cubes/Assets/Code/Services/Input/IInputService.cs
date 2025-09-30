using System;

namespace Code.Services.Input
{
    public interface IInputService
    {
        event Action<int,int> OnMove;
        void Think();
    }
}