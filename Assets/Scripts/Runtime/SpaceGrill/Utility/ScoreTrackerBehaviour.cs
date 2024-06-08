using UnityEngine;
using VContainer;

namespace SpaceGrill.Utility
{
    public class ScoreTrackerBehaviour : MonoBehaviour
    {
        public int Score {  get; private set; } = 0;

        [SerializeField]
        private TMPro.TextMeshPro _textField;

        private string ScoreText => $"Score: {Score}";

        private const int TopRightCornerXTranslate = 53;
        private const int FontSize = 2000;

        [Inject]
        public void Construct()
        {
            _textField.fontStyle = TMPro.FontStyles.Bold;
            _textField.fontSize = FontSize;
            _textField.text = ScoreText;
            _textField.sortingOrder = 1;
            gameObject.transform.Translate(new Vector3(TopRightCornerXTranslate, 0, 0));
        }

        public void IncrementScore()
        {
            Score++;
            _textField.text = ScoreText;
        }
    }
}
