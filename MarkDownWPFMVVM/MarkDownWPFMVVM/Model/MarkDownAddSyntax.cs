using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkDownWPFMVVM.Model
{
    public class MarkDownAddSyntax
    {
        public string Header(string text, int position)
        {
            return AddTextInBegin("#", text, position);
        }
        public string HorizontalRule(string text, int position)
        {
            return AddTextInBegin("---", text, position);
        }
        public string Email(string text, int position)
        {
            return AddTextToDesiredLocation("<Enter email adress>", text, position);
        }
        public string Http(string text, int position)
        {
            return AddTextToDesiredLocation("http://", text, position);
        }

        public string Bold(string text, int position, int length)
        {
            if (length == 0)
               return AddTextToDesiredLocation("**Enter your text**", text, position);

            else if(length >0)
                return AddTextBetweenSelected("**", text, position, length);

            return text;
        }
        public string Italic(string text, int position, int length)
        {
            if (length == 0)
                return AddTextToDesiredLocation("_Enter your text_", text, position);

            else if (length > 0)
                return AddTextBetweenSelected("_", text, position, length);

            return text;
        }
        public string Strikethrough(string text, int position, int length)
        {
            if (length == 0)
                return AddTextToDesiredLocation("~~Enter your text~~", text, position);

            else if (length > 0)
                return AddTextBetweenSelected("~~", text, position, length);

            return text;
        }
        public string CodeSpan(string text, int position, int length)
        {
            if (length == 0)
                return AddTextToDesiredLocation("`Enter your text`", text, position);

            else if (length > 0)
                return AddTextBetweenSelected("`", text, position, length);

            return text;
        }
        public string Blockquote(string text, int position, int length)
        {
            if (length == 0)
                return AddTextToDesiredLocation(">Blockquote", text, position);

            else if (length > 0)
                return AddTextToDesiredLocation(">", text, position);

            return text;
        }

        private string AddTextBetweenSelected(string addText, string text, int position, int length)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if (position < 0)
                return text;

            if (text.Length == position)
                position--;

            string before = text.Substring(0, position);
            string after = text.Substring(position, text.Length - position);

            string selected = after.Substring(0, length);
            string afterSelected = after.Substring(length, after.Length - length);
            string f= string.Format("{0}{1}{2}{1}{3}", before, addText, selected, afterSelected);
            return f;
        }
        private string AddTextInBegin(string addText, string text, int position)
        {

            if (string.IsNullOrEmpty(text))
                return text = addText;

            if (position < 0)
                return text;

            // если позиция курсора находится в конце строки на символе '\n'
            if (text.Length == position)
                position--;

            // ищю начало строки(ищю символ '\n')
            for (int i = position; i >= 0; i--)
            {
                if (i == 0)
                    return string.Format("{0}{1}", addText, text);

                if (text[i] == '\n')
                {
                    string before = text.Substring(0, i + 1);
                    string after = text.Substring(i + 1, text.Length - 1 - i);

                    return string.Format("{0}{1}{2}", before, addText, after);
                }
            }

            return text;
        }
        private string AddTextToDesiredLocation(string addText, string text, int position)
        {
            if (string.IsNullOrEmpty(text))
                return text = addText;

            if (position < 0)
                return text;

            string before = text.Substring(0, position);
            string after = text.Substring(position, text.Length - position);

            return string.Format("{0}{1}{2}", before, addText, after);
        }
    }
}
