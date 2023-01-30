namespace Application.Commands.Contracts.Common;

public interface IHtmlHelper
{
    #region Public Methods

    /// <summary>
    /// Checks if input string contains HTML tags
    /// </summary>
    /// <param name="input"></param>
    /// <returns>true or false</returns>
    bool HasHTMLTags(string input);

    /// <summary>
    /// Remove HTML tags
    /// </summary>
    /// <param name="html"></param>
    /// <returns></returns>
    string RemoveHTMLtags(string html);

    /// <summary>
    /// Sanitize
    /// </summary>
    /// <param name="html"></param>
    /// <returns></returns>
    string Sanitize(string html);

    /// <summary>
    /// Removes link from string. This is implemented to avoid link creation. The email clients add
    /// anchor tag by default for example. www.google.com become <a href="www.google.coms"/>
    /// </summary>
    /// <param name="html"></param>
    /// <returns></returns>
    string RemoveLink(string html);

    /// <summary>
    /// Checks if input string contains URL tags
    /// </summary>
    /// <param name="input"></param>
    /// <returns>true or false</returns>
    bool HasURL(string input);

    #endregion Public Methods
}