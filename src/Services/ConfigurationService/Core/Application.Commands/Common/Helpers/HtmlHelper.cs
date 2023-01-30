using Application.Commands.Contracts.Common;
using Ganss.Xss;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Commands.Common.Helpers;
public class HtmlHelper : IHtmlHelper
{
    #region Public Methods

    public bool HasHTMLTags(string input)
    {
        Regex _regexTag = new Regex(@"<(\s*[(\/?)\w+]*)");
        return (!string.IsNullOrEmpty(input) && _regexTag.IsMatch(input)) ||
            (!string.IsNullOrEmpty(input) && Constants.Constants.BlackListCharacters.Contains(input.Substring(0, 1)));
    }

    public bool HasURL(string input)
    {
        string _regPattern = @"(?:(?:https?|ftp|file):\/\/|www\.|ftp\.)(?:\([-A-Z0-9+&@#/%=~_|$?!:,.]*\)|[-A-Z0-9+&@#/%=~_|$?!:,.])*[\w@?^=%&\/~+#-]";
        Regex _regexTag = new Regex(_regPattern);
        return (!string.IsNullOrEmpty(input) && _regexTag.IsMatch(input.ToLower()));
    }

    public string RemoveHTMLtags(string html)
    {
        HtmlDocument _htmlDoc;
        string _result;
        bool _isValid = true;
        if (string.IsNullOrEmpty(html))
        {
            return html;
        }

        _htmlDoc = new HtmlDocument();
        _htmlDoc.LoadHtml(html);
        _result = _htmlDoc.DocumentNode.InnerText.Trim();

        if (_htmlDoc.ParseErrors.GetEnumerator().MoveNext())
            _isValid = false;

        //in case of error we need to return empty string instead of faulty data with html tags
        if (!_isValid && string.IsNullOrEmpty(_result))
        {
            return string.Empty;
        }
        else
        {
            if (Constants.Constants.BlackListCharacters.Contains(_result.Substring(0, 1)))
            {
                _result = _result.Remove(0, 1);
            }
        }

        return _result;
    }

    public string RemoveLink(string html)
    {
        if (html.Contains(".") || html.Contains("www") || html.Contains("http"))
            html = "<a href='#' style='text-decoration:none; color:#000;cursor: default;'>" + html;
        return html;
    }

    public string Sanitize(string html)
    {
        HtmlSanitizer _sanitizedHtml = new HtmlSanitizer();

        _sanitizedHtml.AllowedAttributes.Add("Id");
        _sanitizedHtml.AllowedCssProperties.Add("border-radius");

        return _sanitizedHtml.Sanitize(html);
    }

    #endregion Public Methods
}
