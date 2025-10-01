using UnityEngine;

namespace Code.Gameplay
{
    public class Field
    {
        private int[,] _table;
        private int _width;
        private int _height;
    
        public int[,] Table => _table;
        public int Width => _width;
        public int Height => _height;

        public Field(int width, int height)
        {
            _width = width;
            _height = height;
            _table = new int[width, height];
        }

        public Color GetColorOf(int x, int y)
        {
            if (x < 0)
                x += Width;
            if (x >= Width)
                x -= Width;
        
            if (y < 0)
                y += Height;
            if (y >= Height)
                y -= Height;
            return StaticData.Colors[_table[x, y]];
        }
    }
}