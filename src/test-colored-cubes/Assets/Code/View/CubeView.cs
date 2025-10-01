using UnityEngine;

namespace Assets.Code.View
{
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        private int _offsetX;
        private int _offsetY;

        public int OffsetX => _offsetX;
        public int OffsetY => _offsetY;

        public void Init(int offfsetX, int offsetY)
        {
            _offsetX = offfsetX;
            _offsetY = offsetY;
            transform.localPosition = new Vector3(_offsetX,0,3-_offsetY);
        }

        public void SetColor(Color color)
        {
            _meshRenderer.material.color = color;
        }
    }
}
