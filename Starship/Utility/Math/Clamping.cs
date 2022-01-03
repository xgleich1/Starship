namespace Starship.Utility.Math
{
    public static class Clamping
    {
        public static float Clamp(this float value, float minimum, float maximum)
        {
            if (value < minimum)
            {
                return minimum;
            }

            if (value > maximum)
            {
                return maximum;
            }

            return value;
        }
    }
}