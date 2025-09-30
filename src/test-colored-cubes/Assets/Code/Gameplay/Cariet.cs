using UnityEngine;

namespace Code.Gameplay
{
    public class Cariet
    {
        private Field _field;
        private Vector2Int _pos;
        private int _width;
        private int _height;

        public Vector2Int Pos => _pos;
        public int Width => _width;
        public int Height => _height;


        public Cariet(Field field, int width, int height)
        {
            _field = field;
            _width = width;
            _height = height;
        }

        public void Move(int dx, int dy)
        {
            _pos.x += dx;
            _pos.y += dy;

            if (_pos.x < 0)
                _pos.x += _field.Width;
            if (_pos.x >= _field.Width)
                _pos.x -= _field.Width;
        
            if (_pos.y < 0)
                _pos.y += _field.Height;
            if (_pos.y >= _field.Height)
                _pos.y -= _field.Height;
        }
    }
}