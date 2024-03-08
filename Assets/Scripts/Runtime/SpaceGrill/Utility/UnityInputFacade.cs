using UnityEngine;

namespace SpaceGrill.Utility
{
    public class UnityInputFacade : IPlayerInput
    {
        public float MouseScrollDelta => Input.mouseScrollDelta.y;

        public float GetHorizontalAxis => Input.GetAxis("Horizontal");

        public float GetVerticalAxis => Input.GetAxis("Vertical");

        public bool IsBPressed => Input.GetKeyDown(KeyCode.B);

        public bool IsSpacePressed => Input.GetKeyDown(KeyCode.Space);

        public bool IsLeftPressed => Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);

        public bool IsRightPressed => Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);

        public bool IsUpPressed => Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);

        public bool IsDownPressed => Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);

        public bool IsDirectionalPressed => IsLeftPressed || IsRightPressed || IsUpPressed || IsDownPressed;

        public bool IsDimensionNumberPressed => Input.GetKeyDown(KeyCode.Alpha1) ||
            Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3);

        public bool IsQPressed => Input.GetKeyDown(KeyCode.Q);

        public bool IsEPressed => Input.GetKeyDown(KeyCode.E);

        public bool IsTranslationKeyPressed => IsDirectionalPressed || IsQPressed || IsEPressed;

        public int GetDimensionNumber()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                return 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                return 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                return 3;
            }
            return -1;
        }
    }
}
