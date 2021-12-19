namespace MyProfileSite.Core
{
    public static class Core
    {
        public static bool IsLocal = false;

        public static void UseLocal() => IsLocal = true;
    }
}