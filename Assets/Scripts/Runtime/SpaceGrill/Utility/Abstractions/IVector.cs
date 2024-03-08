namespace SpaceGrill.Utility
{
    public interface IVector
    {
        float X { get; }
        float Y { get; }

        void Translate(float x, float y);
        void TranslateToCoordinates(float x, float y);
        void TranslateToAnotherVector(IVector vector);
    }
}
