namespace SpaceGrill.Utility
{
    public interface IPlayerInput
    {
        float MouseScrollDelta { get; }
        float GetHorizontalAxis { get; }
        float GetVerticalAxis { get; }
        bool IsBPressed { get; }
        bool IsSpacePressed { get; }
        bool IsLeftPressed { get; }
        bool IsRightPressed { get; }
        bool IsUpPressed { get; }
        bool IsDownPressed { get; }
        bool IsDirectionalPressed { get; }
        bool IsDimensionNumberPressed { get; }
        bool IsQPressed { get; }
        bool IsEPressed { get; }
        bool IsTranslationKeyPressed { get; }

        int GetDimensionNumber();
    }
}
