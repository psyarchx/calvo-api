namespace Calvo.CrossCutting.Helpers
{
    public static class ValidationHelper
    {
        public static bool IntegerLength(int value, int expected)
        {
            if (value.ToString().Length != expected)
                return false;

            return true;
        }
    }
}
