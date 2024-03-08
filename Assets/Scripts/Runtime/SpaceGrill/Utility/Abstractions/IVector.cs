namespace SpaceGrill.Utility
{
    public interface IVector
    {
        float X { get; }
        float Y { get; }

        float Magnitude { get; }

        void Translate(float x, float y);
        void Translate(IVector vector);
        void TranslateToCoordinates(float x, float y);
        void TranslateToAnotherVector(IVector vector);
    }
}
