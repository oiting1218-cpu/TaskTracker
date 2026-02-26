namespace TaskTracker.Api.Helpers
{
    public class NumberHelper
    {
        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new ArgumentException("Divider cannot be zero.");
            return a / b;
        }
    }
}
