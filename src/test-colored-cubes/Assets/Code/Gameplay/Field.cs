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
    }
}