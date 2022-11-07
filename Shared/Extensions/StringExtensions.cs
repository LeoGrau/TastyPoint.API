namespace TastyPoint.API.Shared.Persistence.Extensions;

public static class StringExtensions
{
    public static string ToSnakeCase(this string text)
    {
        static IEnumerable<char> Convert(CharEnumerator letterIt)
        {
            if (!letterIt.MoveNext()) yield break;
            yield return char.ToLower(letterIt.Current);

            while (letterIt.MoveNext())
            {
                if (char.IsUpper(letterIt.Current))
                {
                    yield return '_';
                    yield return Char.ToLower(letterIt.Current);
                }
                else
                    yield return letterIt.Current;
            }
        }

        return new string(Convert(text.GetEnumerator()).ToArray());
    }
}