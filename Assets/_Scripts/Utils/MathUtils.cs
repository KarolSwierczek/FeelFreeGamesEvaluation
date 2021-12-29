namespace FeelFreeGames.Evaluation.Utils
{
    public static class MathUtils
    {
        public static int Mod(int k, int n)
        {
            return ((k %= n) < 0) ? k+n : k;
        }
    }
}