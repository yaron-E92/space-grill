using UnityEngine;
using VContainer;

namespace SpaceGrill.Utility
{
    public class ScoreTrackerBehaviour : MonoBehaviour
    {
        public int Score {  get; private set; } = 0;

        [SerializeField]
#if TMPROEXISTS
        private TMPro.TextMeshPro _textField;
        private const int FontSize = 2000;
        private const int TopRightCornerXTranslate = 53;
#else
        private UnityEngine.UI.Text _textField;
        private const int FontSize = 257;
        private const int TopRightCornerXTranslate = 52;
#endif

        private string ScoreText => $"Score: {Score}";

        [Inject]
        public void Construct()
        {
#if TMPROEXISTS
            _textField = gameObject.AddComponent<TMPro.TextMeshPro>();
            _textField.fontStyle = TMPro.FontStyles.Bold;
            _textField.sortingOrder = 1;
#else
            _textField = gameObject.AddComponent<UnityEngine.UI.Text>();
            _textField.font = Font.CreateDynamicFontFromOSFont("LiberationSans", FontSize);
            _textField.fontStyle = UnityEngine.FontStyle.Bold;
#endif
            _textField.fontSize = FontSize;
            _textField.text = ScoreText;
            gameObject.transform.Translate(new Vector3(TopRightCornerXTranslate, 0, 0));
        }

        public void IncrementScore()
        {
            Score++;
            _textField.text = ScoreText;
        }
    }
}
