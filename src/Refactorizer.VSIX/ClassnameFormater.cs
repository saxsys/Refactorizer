namespace Refactorizer.VSIX
{
    internal class ClassnameFormater
    {
        public static string FullName(string namespaceName, string className)
        {
            return $"{namespaceName}.{className}";
        }
    }
}