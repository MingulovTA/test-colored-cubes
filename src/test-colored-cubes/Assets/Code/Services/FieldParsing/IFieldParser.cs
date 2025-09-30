using Code.Gameplay;

namespace Code.Services.FieldParsing
{
    public interface IFieldParser
    {
        Field Parse(string[] data);
    }
}