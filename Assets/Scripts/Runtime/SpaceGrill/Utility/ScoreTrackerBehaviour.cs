using UnityEngine;
using VContainer;

namespace SpaceGrill.Utility
{
    public class ScoreTrackerBehaviour : MonoBehaviour
    {
        public int Score {  get; private set; } = 0;

        private string ScoreText => $"Score: {Score}";

        public TMPro.TextMeshPro _textField;

        [Inject]
        public void Construct()
        {
            _textField.fontStyle = TMPro.FontStyles.Bold;
            _textField.fontSize = 2000;
            _textField.text = ScoreText;
            _textField.sortingOrder = 1;
            gameObject.transform.Translate(new Vector3(53, 0, 0));
        }

        public void IncrementScore()
        {
            Score++;
            _textField.text = ScoreText;
        }
    }
}
