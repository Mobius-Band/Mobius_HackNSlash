namespace HackNSlash.Scripts.Stats
{
    public class Ranker
    {
        public static char CalculateRank(float healthPercentage)
        {
            return healthPercentage switch
            {
                <= 25 => 'B',
                <= 75 => 'A',
                _ => 'S'
            };
        }
    }
}