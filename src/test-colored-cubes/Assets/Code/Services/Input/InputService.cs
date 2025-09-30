using System;
using UnityEngine;

namespace Code.Services.Input
{
    public class InputService : IInputService
    {
        public event Action<int,int> OnMove;
    
        public void Think()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
                OnMove?.Invoke(0,1);
        
            if (UnityEngine.Input.GetKeyDown(KeyCode.S))
                OnMove?.Invoke(0,-1);
        
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
                OnMove?.Invoke(-1,0);

            if (UnityEngine.Input.GetKeyDown(KeyCode.D))
                OnMove?.Invoke(1,0);
        }
    }
}
