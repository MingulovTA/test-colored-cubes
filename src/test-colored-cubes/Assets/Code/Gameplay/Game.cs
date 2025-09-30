using System;
using Code.Services.Input;

namespace Code.Gameplay
{
    public class Game
    {
        private Cariet _cariet;
        private Field _field;
        private IInputService _inputService;

        public Cariet Cariet => _cariet;
        public Field Field => _field;
        
        public event Action OnStep; 

        public Game(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Start(Field field)
        {
            _field = field;
            _cariet = new Cariet(_field,StaticData.CarietWidth,StaticData.CarietHeight);
            _inputService.OnMove += PlayerMoveHandler;
        }

        public void Dispose()
        {
            _inputService.OnMove -= PlayerMoveHandler;
        }

        private void PlayerMoveHandler(int dx, int dy)
        {
            _cariet.Move(dx,dy);
            OnStep?.Invoke();
        }
    }
}