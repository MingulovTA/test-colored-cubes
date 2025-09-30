using System.IO;
using Code.Gameplay;
using Code.Services.FieldParsing;
using Code.Services.FileLoading;
using Code.Services.Input;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance => _main;
    private static Main _main;
    
    private IInputService _inputService;
    private IFileLoader _fileLoader;
    private IFieldParser _fieldParser;
    private Game _game;

    public Game Game => _game;

    private void Awake()
    {
        _main = this;
        Init();
    }

    private void Init()
    {
        _inputService = new InputService();
        _fileLoader = new FileLoader();
        _fieldParser = new FieldParser();
        _game = new Game(_inputService);
        
        var data = _fileLoader.LoadFromDisk(Path.Combine(Application.dataPath, StaticData.FileName));
        var field = _fieldParser.Parse(data);
        _game.Start(field);   
    }

    private void Update()
    {
        _inputService.Think();
    }

    private void OnDisable()
    {
        _game.Dispose();
    }
}
