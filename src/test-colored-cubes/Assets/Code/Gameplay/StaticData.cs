using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay
{
    public static class StaticData
    {
        public const string FileName = "example.txt";
        
        public const int CarietWidth = 1;
        public const int CarietHeight = 1;
        
        public static readonly Dictionary<int, Color> Colors = new Dictionary<int, Color>
        {
            {1, Color.red},
            {2, Color.yellow},
            {3, Color.blue},
            {4, new Color(.5f, 0, .5f, 1)},
        };
    }
}