using System;
using Code.Gameplay;

namespace Code.Services.FieldParsing
{
    public class FieldParser : IFieldParser
    {
        public Field Parse(string[] data)
        {
            var field = new Field(data[1].Length, data.Length);

            for (int i = 0; i < field.Height; i++)
            {
                string line = data[i];

                if (field.Width!=line.Length)
                    throw new Exception("Invalid file format. Characters count in the lines must be the same");
            
                for (int j = 0; j < field.Width; j++)
                {
                    if (char.IsDigit(line[j]))
                    {
                        field.Table[j, i] = line[j] - '0';
                    }
                    else
                    {
                        throw new Exception("Invalid file format. All characters must be numbers.");
                    }
                }
            }

            return field;
        }
    }
}
