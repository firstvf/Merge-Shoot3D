public class FormatText 
{
    private static readonly string[] _formatNames = { "", "K", "M", "B", "T" };

    public static string FormatTextMoney(uint value)
    {
        int counter = 0;

        while (counter + 1 < _formatNames.Length && value >= 1000)
        {
            value /= 1000;
            counter++;
        }

       return value.ToString("#.##") + _formatNames[counter];
    }
}