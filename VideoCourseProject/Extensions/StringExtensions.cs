namespace VideoCourseProject.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Removes the word "Controller" from the string.
    /// </summary>
    public static string RemoveController(this string value) => value.Replace("Controller", "");
}
