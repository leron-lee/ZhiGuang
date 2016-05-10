namespace CT.WebUtility
{
    using System;

    public static class Javascript
    {
        public static void Alert(string Value)
        {
            Res.Write(string.Format("<script type=\"text/javascript\">alert('{0}');</script>", Value.Replace("'", @"\'")));
        }

        public static void AlertAndBack(string Value)
        {
            Res.WriteAndEnd(string.Format("<script type=\"text/javascript\">alert('{0}');history.back();</script>", Value.Replace("'", @"\'")));
        }

        public static void AlertAndClose(string Value)
        {
            Res.WriteAndEnd(string.Format("<script type=\"text/javascript\">alert('{0}');window.close();</script>", Value.Replace("'", @"\'")));
        }

        public static void AlertAndEnd(string Value)
        {
            Res.WriteAndEnd(string.Format("<script type=\"text/javascript\">alert('{0}');</script>", Value.Replace("'", @"\'")));
        }

        public static void AlertAndJump(string AlertMessage, string JumpLink)
        {
            Res.WriteAndEnd(string.Format("<script type=\"text/javascript\">alert('{0}');location.href='{1}';</script>", AlertMessage.Replace("'", @"\'"), JumpLink.Replace("'", @"\'")));
        }

        public static void Jump(string Value)
        {
            Res.WriteAndEnd(string.Format("<script type=\"text/javascript\">location.href='{0}';</script>", Value));
        }

        public static void Write(string Value)
        {
            Res.Write(string.Format("<script type=\"text/javascript\">{0}</script>", Value));
        }

        public static void WriteAndBack(string Value)
        {
            Res.WriteAndEnd(string.Format("<script type=\"text/javascript\">{0}history.back();</script>", Value));
        }

        public static void WriteAndClose(string Value)
        {
            Res.WriteAndEnd(string.Format("<script type=\"text/javascript\">{0}window.close();</script>", Value));
        }

        public static void WriteAndEnd(string Value)
        {
            Res.WriteAndEnd(string.Format("<script type=\"text/javascript\">{0}</script>", Value));
        }
    }
}

