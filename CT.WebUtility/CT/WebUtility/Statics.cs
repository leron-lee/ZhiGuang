namespace CT.WebUtility
{
    using System;
    using System.Text.RegularExpressions;

    public static class Statics
    {
        public static class RegexPatterns
        {
            public static readonly Regex ClearWords = new Regex("^[a-zA-Z]+", RegexOptions.Compiled);
            public static readonly Regex FileExt = new Regex(@".+?(\.[^\\/\.]+)\?*.*$", RegexOptions.IgnoreCase);
            public static readonly Regex FilterHtml = new Regex(@"(<[^>]*?>)|[\r\n]", RegexOptions.Compiled);
            public static readonly Regex HasFileName = new Regex(@"[^\\/]+?\.([^\\/\.]+)$", RegexOptions.IgnoreCase);
            public static readonly Regex HtmlTagBr = new Regex("<br[^>]*?>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            public static readonly Regex Number = new Regex(@"^-?^\d+(\.\d+)?$", RegexOptions.Compiled);
            public static readonly Regex Re10 = new Regex("''", RegexOptions.Compiled);
            public static readonly Regex Re11 = new Regex(@"[\\/]$", RegexOptions.Compiled);
            public static readonly Regex Re12 = new Regex(@"\\[^\\]*$", RegexOptions.Compiled);
            public static readonly Regex Re13 = new Regex("省|市", RegexOptions.Compiled);
            public static readonly Regex Re14 = new Regex("^.*<div class=\"contents\">(.*?)</div>$", RegexOptions.Compiled);
            public static readonly Regex Re15 = new Regex("^(.*)<div class=\"contents\">(.*?)</div>$", RegexOptions.Compiled);
            public static readonly Regex Re21 = new Regex(@"[\\/]([^\\/]+\.[^\.\\/]+)$", RegexOptions.Compiled);
            public static readonly Regex Re22 = new Regex(@"\{\$T_.+?\}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            public static readonly Regex Re23 = new Regex("(?<FullTplTag><!--.*?#include .*?file=\"(?<FilePath>[^\"]*?)\".*?-->)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            public static readonly Regex Re24 = new Regex(@"^/_inc/[^\.]*?\.inc$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            public static readonly Regex Re25 = new Regex("# ?", RegexOptions.Compiled);
            public static readonly Regex Re26 = new Regex("textarea>", RegexOptions.IgnoreCase);
            public static readonly Regex Re28 = new Regex(@"^\.", RegexOptions.Compiled);
            public static readonly Regex Re29 = new Regex(@"[^a-zA-Z\d]", RegexOptions.Compiled);
            public static readonly Regex Re3 = new Regex("[^0-9, ]", RegexOptions.Compiled);
            public static readonly Regex Re30 = new Regex(@"\.xml$", RegexOptions.Compiled);
            public static readonly Regex Re5 = new Regex(@"\s*\++\s*", RegexOptions.Compiled);
            public static readonly Regex Re6 = new Regex(@"\++", RegexOptions.Compiled);
            public static readonly Regex Re7 = new Regex(@"\s+", RegexOptions.Compiled);
            public static readonly Regex Re8 = new Regex(@"^\+|\+$", RegexOptions.Compiled);
            public static readonly Regex Re9 = new Regex("'", RegexOptions.Compiled);
            public static readonly Regex RepeatNewline = new Regex(@"[\r\n]+", RegexOptions.Compiled);
            public static readonly Regex ServerMapPath = new Regex(@".+:[\\/]{1,2}[^\\/]", RegexOptions.Compiled);
            public static readonly Regex ShowIp = new Regex(@"\d+\.\d+$", RegexOptions.Compiled);
            public static readonly Regex ShowIp2 = new Regex(@"\d+$", RegexOptions.Compiled);
        }
    }
}

