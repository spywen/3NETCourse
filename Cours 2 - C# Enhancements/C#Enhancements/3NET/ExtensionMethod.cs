namespace _3NET
{
    public static class ExtensionMethod
    {
        public static int LengthWithoutSpace(this string str)
        {
            return str.Replace(" ", "").Length;
        }
    }
}
