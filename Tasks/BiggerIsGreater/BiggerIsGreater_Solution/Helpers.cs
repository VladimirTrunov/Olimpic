namespace BiggerIsGreater_Solution
{
    public static class Helpers
    {
        public static string EjectString(this string a, int idxFrom, int idxTo)
        {
            return a.Substring(idxFrom, idxTo - idxFrom + 1);
        }
    }
}
