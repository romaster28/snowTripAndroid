using Sources.UserInterface.Elements.Common;
using UnityEngine;

namespace Sources.UserInterface.Elements.Game
{
    public class TutorialStepPlacedView : MonoBehaviour
    {
        [SerializeField] private ValueView _view;

        [SerializeField] private int _target;
        
        [SerializeField] private Color _acceptedColor = Color.green;
        
        public void UpdateProgress(int current, int total)
        {
            if (current >= _target)
                _view.View.color = _acceptedColor;
            
            _view.Update(current, total);
        }
    }
}