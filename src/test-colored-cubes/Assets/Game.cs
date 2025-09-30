using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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

public class StaticData
{
    public static readonly Dictionary<int, Color> Colors = new Dictionary<int, Color>
    {
        {1, Color.red},
        {2, Color.yellow},
        {3, Color.blue},
        {4, new Color(.5f, 0, .5f, 1)},
    };
}

public class Game : MonoBehaviour
{
    [SerializeField] private TextMesh _tmPrefab;
    [SerializeField] private Transform _carietView;


    private Cariet _cariet;
    private Field _field;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            _cariet.Move(0,1);
        
        if (Input.GetKeyDown(KeyCode.S))
            _cariet.Move(0,-1);
        
        if (Input.GetKeyDown(KeyCode.A))
            _cariet.Move(-1,0);

        if (Input.GetKeyDown(KeyCode.D))
            _cariet.Move(1, 0);
        ShowCariet();
    }

    private void Start()
    {
        Load();
        _cariet = new Cariet(_field,1,1);
        Show();
        Debug.Log($"_field.Width = {_field.Width}");
        Debug.Log($"_field.Height = {_field.Height}");
    }

    private void Load()
    {
        string[] lines = File.ReadAllLines($"{Application.dataPath}/example.txt");

        _field = new Field(lines[1].Length, lines.Length);

        for (int i = 0; i < _field.Height; i++)
        {
            string line = lines[i];

            if (_field.Width!=line.Length)
                throw new Exception("Invalid file format. Characters count in the lines must be the same");
            
            for (int j = 0; j < _field.Width; j++)
            {
                if (char.IsDigit(line[j]))
                {
                    _field.Table[j, i] = line[j] - '0';
                }
                else
                {
                    throw new Exception("Invalid file format. All characters must be numbers.");
                }
            }
        }
    }

    private List<TextMesh> _tms = new List<TextMesh>();
    private void Show()
    {
        _tmPrefab.gameObject.SetActive(true);

        foreach (var textMesh in _tms)
            Destroy(textMesh.gameObject);
        _tms.Clear();
        
        
        
        for (int i = 0; i < _field.Height; i++)
        {
            for (int j = 0; j < _field.Width; j++)
            {
                var tm = Instantiate(_tmPrefab, _tmPrefab.transform.parent);
                int value = _field.Table[j, i];
                tm.text = value.ToString();
                tm.color = StaticData.Colors[value];
                tm.transform.localPosition = new Vector3(j*.2f,(_field.Height-1)*.2f-i*.2f,0);
                
                _tms.Add(tm);
            }
        }
        _tmPrefab.gameObject.SetActive(false);
    }

    private void ShowCariet()
    {
        _carietView.transform.position = new Vector3(_cariet.Pos.x*.2f,_cariet.Pos.y*.2f,0);
    }
}