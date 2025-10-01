using System.Collections.Generic;
using Code.Gameplay;
using UnityEngine;

namespace Code.View
{
    public class SceneView : MonoBehaviour
    {
        [SerializeField] private CubeView _cubeView;
        
        private List<CubeView> _cubeViews = new List<CubeView>();

        private Field _field;
        private Cariet _cariet;
        private Game _game;

        private void Awake()
        {
            _game = Main.Instance.Game;
            _field = _game.Field;
            _cariet = _game.Cariet;

            for (int i = 0; i < _cariet.Width; i++)
            for (int j = 0; j < _cariet.Height; j++)
            {
                CubeView cv = Instantiate(_cubeView, _cubeView.transform.parent);
                cv.Init(i,j);
                _cubeViews.Add(cv);
            }
            _cubeView.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _game.OnStep += ShowCariet;
            ShowCariet();
        }

        private void OnDisable()
        {
            _game.OnStep -= ShowCariet;
        }

        private void ShowCariet()
        {
            foreach (var cubeView in _cubeViews)
            {
                cubeView.SetColor(_field.GetColorOf(_cariet.Pos.x + cubeView.OffsetX,
                    -_cariet.Pos.y + cubeView.OffsetY));
            }
        }
    }
}
