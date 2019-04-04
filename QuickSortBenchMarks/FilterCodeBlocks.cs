using System;
using System.Text.RegularExpressions;
using System.Text;

namespace QuickSortBenchMarks
{
    public class FilterCodeBlocks
    {
        private static readonly string[] _codeBlockTagPre = { "<div class=\"cnblogs_code\"", "<div class=\"cnblogs_Highlighter\"", "<code" };
        private static readonly string[] _codeBlockTagPost = { "</div>", "</div>", "</code>" };

        private static Regex _codeTag = new Regex("(<pre(.*?)>)(.|\n)*?(</pre>)", RegexOptions.Compiled);

        private static string _startTag = "<pre";
        private static string _endTag = "</pre>";

        private static int _startTagLength => _startTag.Length;
        private static int _endTagLength => _endTag.Length;
        public FilterCodeBlocks()
        {

        }

        public string FilterCodeBlockByString(string content)
        {
            string result = "";
            while (true)
            {
                var startPos = content.IndexOf(_startTag, StringComparison.CurrentCulture);
                if (startPos == -1)
                    break;

                var content2 = content.Substring(startPos + _startTagLength, content.Length - startPos - _startTagLength);
                var endPos = content2.IndexOf(_endTag, StringComparison.CurrentCulture);
                result += content.Substring(0, startPos);
                content = content2.Substring(endPos + _endTagLength, content2.Length - endPos - _endTagLength);
            }
            result += content;
            return result;
        }

        public string FilterCodeBlocByRegex(string content)
        {
            return _codeTag.Replace(content, string.Empty);
        }

        public string FilterCodeBlockBySpanAndStringBuilder(ReadOnlySpan<char> content)
        {
            var result = new StringBuilder(content.Length);

            var contentSpan2 = new ReadOnlySpan<char>();
            var startPos = 0;
            var endPos = 0;

            var startTagSpan = _startTag.AsSpan();
            var endTagSpan = _endTag.AsSpan();
            while (true)
            {
                startPos = content.IndexOf(startTagSpan);
                if (startPos == -1)
                    break;

                contentSpan2 = content.Slice(startPos + _startTagLength, content.Length - startPos - _startTagLength);
                endPos = contentSpan2.IndexOf(endTagSpan);
                result.Append(content.Slice(0, startPos));
                content = contentSpan2.Slice(endPos + _endTagLength, contentSpan2.Length - endPos - _endTagLength);
            }
            result.Append(content);
            return result.ToString();

        }

        public string FilterCodeBlockBySpanAndValueStringBuilder(ReadOnlySpan<char> content)
        {
            Span<char> resultSpan = stackalloc char[content.Length];
            var result = new ValueStringBuilder(resultSpan);

            var contentSpan2 = new ReadOnlySpan<char>();
            var startPos = 0;
            var endPos = 0;

            var startTagSpan = _startTag.AsSpan();
            var endTagSpan = _endTag.AsSpan();
            while (true)
            {
                startPos = content.IndexOf(startTagSpan);
                if (startPos == -1)
                    break;

                contentSpan2 = content.Slice(startPos + _startTagLength, content.Length - startPos - _startTagLength);
                endPos = contentSpan2.IndexOf(endTagSpan);
                result.Append(content.Slice(0, startPos));
                content = contentSpan2.Slice(endPos + _endTagLength, contentSpan2.Length - endPos - _endTagLength);
            }
            result.Append(content);
            return result.ToString();
        }

        public string FilterCodeBlockBySpanAndToString(ReadOnlySpan<char> content)
        {
            string result = "";
            ReadOnlySpan<char> contentSpan2 = new ReadOnlySpan<char>();
            int startPos = 0;
            int endPos = 0;

            ReadOnlySpan<char> startTagSpan = _startTag.AsSpan();
            ReadOnlySpan<char> endTagSpan = _endTag.AsSpan();
            while (true)
            {
                startPos = content.IndexOf(startTagSpan);
                if (startPos == -1)
                    break;

                contentSpan2 = content.Slice(startPos + _startTagLength, content.Length - startPos - _startTagLength);
                endPos = contentSpan2.IndexOf(endTagSpan);
                result += content.Slice(0, startPos).ToString();
                content = contentSpan2.Slice(endPos + _endTagLength, contentSpan2.Length - endPos - _endTagLength);
            }
            result += content.ToString();
            return result;

        }

        public Memory<char> FilterCodeBlockBySpanAndMemoryChar(ReadOnlySpan<char> content)
        {
            string codeTag1 = "<pre>";
            ReadOnlySpan<char> span = codeTag1.AsSpan();

            int pos = content.IndexOf(span);

            ReadOnlySpan<char> span2 = content.Slice(pos, content.Length - pos);

            int pos2 = span2.IndexOf("</pre>");

            ReadOnlySpan<char> result = content.Slice(0, pos);

            ReadOnlySpan<char> result2 = content.Slice(pos + pos2, content.Length - pos - pos2);

            char[] res = new char[result.Length + result2.Length];

            int tag = 0;
            for (int i = 0; i < result.Length; i++)
            {
                res[i] = result[i];
            }

            tag = result.Length;
            for (int i = 0; i < result2.Length; i++)
            {
                res[tag + i] = result2[i];
            }

            return new Memory<char>(res);
        }

        public string FilterCodeBlockBySpanAndStringSpan(ReadOnlySpan<char> content)
        {
            string codeTag1 = "<pre>";
            ReadOnlySpan<char> span = codeTag1.AsSpan();

            int pos = content.IndexOf(span);

            ReadOnlySpan<char> span2 = content.Slice(pos, content.Length - pos);

            int pos2 = span2.IndexOf("</pre>");

            ReadOnlySpan<char> result = content.Slice(0, pos);

            ReadOnlySpan<char> result2 = content.Slice(pos + pos2, content.Length - pos - pos2);

            Span<char> res = stackalloc char[result.Length + result2.Length];

            int tag = 0;
            for (int i = 0; i < result.Length; i++)
            {
                res[i] = result[i];
            }

            tag = result.Length;
            for (int i = 0; i < result2.Length; i++)
            {
                res[tag + i] = result2[i];
            }

            return new string(res);
        }

        /*public ReadOnlySpan<char> FilterCodeBlock3(ReadOnlySpan<char> content)
        {
            
        }*/
    }

    public ref struct Test
    {
        private Span<Char> tests;
    }
}
