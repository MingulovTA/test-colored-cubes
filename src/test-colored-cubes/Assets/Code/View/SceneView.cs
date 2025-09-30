using System.Collections.Generic;
using Code.Gameplay;
using UnityEngine;

namespace Code.View
{
    public class SceneView : MonoBehaviour
    {
        [SerializeField] private TextMesh _tmPrefab;
        [SerializeField] private Transform _carietView;
    
        private List<TextMesh> _tms = new List<TextMesh>();

        private Field _field;
        private Cariet _cariet;
        private Game _game;

        private void Awake()
        {
            _game = Main.Instance.Game;
            _field = _game.Field;
            _cariet = _game.Cariet;
        }

        private void OnEnable()
        {
            _game.OnStep += ShowCariet;
            ShowField();
            ShowCariet();
        }

        private void OnDisable()
        {
            _game.OnStep -= ShowCariet;
        }

        private void ShowField()
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
}
