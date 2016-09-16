using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkDownWPFMVVM.Model
{
    public class MarkDownToHtmlConverter   
    {
        //no added yet 
        //Nested list 
        //Table
        //Reference link 
        //++++++++
        public string About()
        {
            string site = "http://www.website.com";
            string about =string.Format(@"
Operation name
Markdown syntax
HTML syntax
------

Bold
**bold**
<p><strong>bold</strong></p> 
------

Italic
_italic_
<p><em>italic</em></p> 
------

Header
#level 1
##level 2
###level 3
####level 4
#####level 5
######level 6
<h1>level 1</h1>
<h2>level 2</h2>
<h3>level 3</h3>
<h4>level 4</h4>
<h5>level 5</h5>
<h6>level 6</h6>
------

Strikethrough
~~strikethrough~~ 
<p><del>strikethrough</del></p> 
------

Code span
`code span` 
<p><code>code span</code></p> 
------

Inline link
[Visit web site](http://www.website.com)
<p><a href={1}{0}{1}>Visit Mobilefish</a></p>
------

Auto link
Visit http://www.website.com! Go go!
<p>Visit<a href=>{1}{0}{1}>http://www.website.com</a>! Go go!</p>
------ 

Email
My email is <spam@mail.com> 
<p>My email is <a href={1}mailto:spam@mail.com{1}>spam@mail.com</a></p>
------

Blockquote
A few famous Chinese sayings:
>A man is never too old to learn.
>Opportunity knocks at the door only once.
>Failure is mother of success. 

<p>A few famous Chinese sayings:</p>
<blockquote>
<p>A man is never too old to learn. </p>
<p>Opportunity knocks at the door only once.</p>
<p>Failure is mother of success.</p>
</blockquote> 
------

Unordered list
My shopping list:
* Bread
* Eggs
* Cheese
* Minced meat 
<p>My shopping list:</p>
<ul>
<li>Bread</li>
<li>Eggs</li>
<li>Cheese</li>
<li>Minced meat</li>
</ul> 
------

Ordered list
My shopping list:
1. Bread
2. Eggs
3. Cheese
4. Minced meat 
<p>My shopping list:</p>
<ol>
<li>Bread</li>
<li>Eggs</li>
<li>Cheese</li>
<li>Minced meat</li>
</ol> 
------
", site,'\u0022'); // '\u0022' - "
            return about;
        }


        private char[] _englishLetters;

        // использую List для простого добавления строки
        List<String> _list = new List<string>();
        public MarkDownToHtmlConverter()
        {
            int indexEnglish = 0;
            _englishLetters = new char[26 * 2];
            _englishLetters[indexEnglish++] = 'A';
            _englishLetters[indexEnglish++] = 'a';
            _englishLetters[indexEnglish++] = 'B';
            _englishLetters[indexEnglish++] = 'b';
            _englishLetters[indexEnglish++] = 'C';
            _englishLetters[indexEnglish++] = 'c';
            _englishLetters[indexEnglish++] = 'D';
            _englishLetters[indexEnglish++] = 'd';
            _englishLetters[indexEnglish++] = 'E';
            _englishLetters[indexEnglish++] = 'e';
            _englishLetters[indexEnglish++] = 'F';
            _englishLetters[indexEnglish++] = 'f';
            _englishLetters[indexEnglish++] = 'G';
            _englishLetters[indexEnglish++] = 'g';
            _englishLetters[indexEnglish++] = 'H';
            _englishLetters[indexEnglish++] = 'h';
            _englishLetters[indexEnglish++] = 'I';
            _englishLetters[indexEnglish++] = 'i';
            _englishLetters[indexEnglish++] = 'J';
            _englishLetters[indexEnglish++] = 'j';
            _englishLetters[indexEnglish++] = 'K';
            _englishLetters[indexEnglish++] = 'k';
            _englishLetters[indexEnglish++] = 'L';
            _englishLetters[indexEnglish++] = 'l';
            _englishLetters[indexEnglish++] = 'M';
            _englishLetters[indexEnglish++] = 'm';
            _englishLetters[indexEnglish++] = 'N';
            _englishLetters[indexEnglish++] = 'n';
            _englishLetters[indexEnglish++] = 'O';
            _englishLetters[indexEnglish++] = 'o';
            _englishLetters[indexEnglish++] = 'P';
            _englishLetters[indexEnglish++] = 'p';
            _englishLetters[indexEnglish++] = 'Q';
            _englishLetters[indexEnglish++] = 'q';
            _englishLetters[indexEnglish++] = 'R';
            _englishLetters[indexEnglish++] = 'r';
            _englishLetters[indexEnglish++] = 'S';
            _englishLetters[indexEnglish++] = 's';
            _englishLetters[indexEnglish++] = 'T';
            _englishLetters[indexEnglish++] = 't';
            _englishLetters[indexEnglish++] = 'U';
            _englishLetters[indexEnglish++] = 'u';
            _englishLetters[indexEnglish++] = 'V';
            _englishLetters[indexEnglish++] = 'v';
            _englishLetters[indexEnglish++] = 'W';
            _englishLetters[indexEnglish++] = 'w';
            _englishLetters[indexEnglish++] = 'X';
            _englishLetters[indexEnglish++] = 'x';
            _englishLetters[indexEnglish++] = 'Y';
            _englishLetters[indexEnglish++] = 'y';
            _englishLetters[indexEnglish++] = 'Z';
            _englishLetters[indexEnglish++] = 'z';

            //26 * 2 = h
        }

        public string ToHtml(string textMd)
        {

            // ищу подстроки создаю[] строк
            string[] separator = new string[] { "\r\n" };
            string[] massString = textMd.Split(separator, StringSplitOptions.None);

            // cначала поиск Email adrees потому что там идут символы < >
            for (int i = 0; i < massString.Length; i++)
                Email(ref massString[i]);


            //multilines конвертирование распространяется на несколько строк
            for (int i = 0; i < massString.Length; i++)
                _list.Add(massString[i]);

            Blockquote();

            UnorderedList();
            OrderedList();

            // обратно делаю массив строк
            massString = _list.ToArray();
            _list.Clear();

            // конвертирование в одной строке 
            for (int i = 0; i < massString.Length; i++)
            {
                //wasModification = false;

                HorizontalRule(ref massString[i]);

                Header(ref massString[i]);

                Strikethrough(ref massString[i]);
                Bold(ref massString[i]);

                Italic(ref massString[i]);
                CodeSpan(ref massString[i]);

                InlineLink(ref massString[i]);

                AutoLink(ref massString[i]);

                // добавляет в строку "<p>" и "</p>"если не было никаких преобразований
                //if (!wasModification)
                MadeSimpleHtmlString(ref massString[i]);

                // вставляю в строку символы separator
                massString[i] = string.Format("{0}\r\n", massString[i]);
            }

            // обратно из [] строк делаю одну строку
            return string.Concat(massString); 
        }
        // добавляет в строку "<p>" и "</p>" если не было никаких преобразований
        private void MadeSimpleHtmlString(ref string text)  
        {

            if (String.IsNullOrEmpty(text)
            || text.IndexOf("<p>") != -1
            || text.IndexOf("<blockquote>") != -1
            || text.IndexOf("</blockquote>") != -1
            || text.IndexOf("<ul>") != -1
            || text.IndexOf("</ul>") != -1
            || text.IndexOf("<ol>") != -1
            || text.IndexOf("</ol>") != -1
            || text.IndexOf("<li>") != -1
            || text.IndexOf("<h") != -1
            || text.IndexOf("<hr />") != -1
            )
            {
                return;
            }
            text = string.Format("<p>{0}</p>",text);
        }
        private void HorizontalRule(ref string text)
        {
            string whatSerch = null;

            if(text.IndexOf("---") != -1)
                whatSerch = "---";

            else if (text.IndexOf("- - -") != -1)
                whatSerch = "- - -";

            else if (text.IndexOf("___") != -1)
                whatSerch = "___";

            else if (text.IndexOf("***") != -1)
                whatSerch = "***";


            if (whatSerch != null)
            {
                int indexStart = text.IndexOf(whatSerch);
                string before = text.Substring(0, indexStart);

                if (whatSerch.Length > 1)
                    indexStart += whatSerch.Length - 1;

                string after = text.Substring(indexStart + 1, text.Length - 1 - indexStart);

                //если строка после символов HorizontalRule не пуста
                if (!string.IsNullOrEmpty(after))
                    return;

                else
                    text = "<hr />";
            }

            //// previous option // предыдущий вариант
            //if (text.IndexOf("---") != -1
            //|| text.IndexOf("- - -") != -1
            //|| text.IndexOf("***") != -1
            //|| text.IndexOf("___") != -1)
            //{
            //    text = "<hr />";
            //}
        }

        //double symbols
        private void Bold(ref string text) // жирный текст
        {
            Modify(ref text, "**", "<strong>", "</strong>");
        }
        private void Strikethrough(ref string text) // зачеркнутый текст
        {
            Modify(ref text, "~~", "<del>", "</del>");
        }
        //one symbol
        private void Italic(ref string text) // почеркнутый текст
        {
            Modify(ref text, "_", "<em>", "</em>");
        }
        private void CodeSpan(ref string text) // простой текст
        {
            Modify(ref text, "`", "<code>", "</code>");
        }

        private void Modify(ref string text, string whatSerch, string beginPart, string endPart)
        {
            int indexStart = text.IndexOf(whatSerch);

            if (indexStart != -1)
            {
                string before = text.Substring(0, indexStart);

                // previous option // предыдущий вариант
                //if (whatSerch.Length > 1)
                //    ++indexStart;

                // должна работать со строкой любого количества символов
                if (whatSerch.Length > 1)
                    indexStart += whatSerch.Length - 1;

                string after = text.Substring(indexStart + 1, text.Length - 1 - indexStart);

                int indexEnd = after.IndexOf(whatSerch);

                if (indexEnd != -1)
                {
                    string inside = after.Substring(0, indexEnd);

                    if (whatSerch.Length > 1)
                        ++indexEnd;

                    string end = after.Substring(indexEnd + 1, after.Length - 1 - indexEnd);

                    //
                    text = string.Format("{0}{1}{2}{3}{4}",
                                                before, beginPart, inside, endPart, end);
                    
                    // prev
                    //if (text.IndexOf("<p>") != -1
                    // || text.IndexOf("<h") != -1) 
                    //    text = string.Format("{0}{1}{2}{3}{4}",
                    //                            before, beginPart, inside, endPart, end);
                    //else
                    //    text = string.Format("<p>{0}{1}{2}{3}{4}</p>",
                    //                         before, beginPart, inside, endPart, end);
                    //wasModification = true;
                }
            }
        }

        private void Header(ref string text)
        {
            string substring = "######";

            int indexStart;

            for (int i = 6; i != 0; i--)
            {
                indexStart = text.IndexOf(substring);

                if (indexStart != -1)
                {
                    text = text.Replace(substring, "");
                    text = string.Format("<h{0}>{1}</h{0}>", i, text);
                }

                substring = substring.Remove(substring.Length - 1);
            }
        }

        private void InlineLink(ref string text)
        {

            int indexSquareBracketsStart = text.IndexOf('[');
            int indexSquareBracketsEnd = text.IndexOf(']');

            int indexRoundBracketsStart = text.IndexOf('(');
            int indexRoundBracketsEnd = text.IndexOf(')');

            if ((indexSquareBracketsStart != -1 && indexSquareBracketsEnd != -1)
                &&
                (indexRoundBracketsStart != -1 && indexRoundBracketsEnd != -1))
            {
                if (indexSquareBracketsEnd + 1 == indexRoundBracketsStart)
                {
                    string before = text.Substring(0, indexSquareBracketsStart);

                    string insideSquareBrackets = text.Substring(indexSquareBracketsStart + 1,
                        indexSquareBracketsEnd - indexSquareBracketsStart - 1);

                    string insideRoundBrackets = text.Substring(indexRoundBracketsStart + 1,
                        indexRoundBracketsEnd - indexRoundBracketsStart - 1);

                    string end = text.Substring(indexRoundBracketsEnd + 1, text.Length - 1 - indexRoundBracketsEnd);

                    //
                    text = string.Format("{0}<a href=\"{1}\">{2}</a>{3}",
                        before, insideRoundBrackets, insideSquareBrackets, end);

                    //prev
                    //if (text.IndexOf("<p>") != -1
                    // || text.IndexOf("<h") != -1)
                    //    text = string.Format("{0}<a href=\"{1}\">{2}</a>{3}", 
                    //        before, insideRoundBrackets, insideSquareBrackets, end);
                    //else
                    //    text = string.Format("<p>{0}<a href=\"{1}\">{2}</a>{3}</p>",
                    //        before, insideRoundBrackets, insideSquareBrackets, end);
                    //wasModification = true; 
                }
            }
        }

        private void AutoLink(ref string text)
        {
            int indexStart = text.IndexOf("http://");

            if (indexStart != -1)
            {
                string before = text.Substring(0, indexStart);
                indexStart += 7;

                string after = text.Substring(indexStart, text.Length - indexStart);

                int indexFindwww = after.IndexOf("www.");

                int indexPoint;
                string afterPoint;
                string inside;

                bool wwwHave;
                if (indexFindwww != -1)
                {
                    wwwHave = true;

                    indexFindwww += 4;
                    string afterwww = after.Substring(indexFindwww, after.Length - indexFindwww);
                    indexPoint = afterwww.IndexOf('.');

                    afterPoint = afterwww.Substring(indexPoint + 1, afterwww.Length - 1 - indexPoint);

                    inside = afterwww.Substring(0, afterwww.IndexOf(afterPoint));
                }
                else //если нету www
                {
                    wwwHave = false;

                    indexPoint = after.IndexOf('.');

                    afterPoint = after.Substring(indexPoint + 1, after.Length - 1 - indexPoint);

                    inside = after.Substring(0, after.IndexOf(afterPoint));
                }
                //check no englishLetters letters
                //поиск не английского символа - означает конец адреса
                char[] array = afterPoint.ToArray();

                int index = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    bool was = false;
                    for (int j = 0; j < _englishLetters.Length; j++)
                        if (array[i] == _englishLetters[j])
                            was = true;

                    if (!was)
                    {
                        index = i;
                        break;
                    }
                }
                string arrayString = "";
                for (int i = 0; i < index; i++)
                    arrayString += array[i];
                //++++

                int indexEndAdress = after.IndexOf(arrayString) + index;

                string end = after.Substring(indexEndAdress, after.Length - indexEndAdress);

                string httpString;
                if (wwwHave)
                    httpString = "http://www.";
                else
                    httpString = "http://";

                //
                text = string.Format("{0}<a href=\"{1}{2}{3}\">{1}{2}{3}</a>{4}",
                       before, httpString, inside, arrayString, end);

                //prev
                //if (text.IndexOf("<p>") != -1
                // || text.IndexOf("<h") != -1)  
                //{
                //    text = string.Format("{0}<a href=\"{1}{2}{3}\">{1}{2}{3}</a>{4}",
                //          before, httpString, inside, arrayString, end);
                //}
                //else
                //{
                //    text = string.Format("<p>{0}<a href=\"{1}{2}{3}\">{1}{2}{3}</a>{4}</p>",
                //          before, httpString, inside, arrayString, end);
                //}
                //wasModification = true;
            }
        }

        private void Email(ref string text)
        {
            int indexStart = text.IndexOf('<');
            int indexEnd = text.IndexOf('>');

            if (indexStart != -1 && indexEnd != -1)
            {
                string before = text.Substring(0, indexStart);

                string inside = text.Substring(indexStart + 1,
                    indexEnd - indexStart - 1);

                string end = text.Substring(indexEnd + 1, text.Length - 1 - indexEnd);

                //
                text = string.Format("{0}<a href=\"mailto:{1}\">{1}</a>{2}",
                        before, inside, end);

                //prev
                //if (text.IndexOf("<p>") != -1
                // || text.IndexOf("<h") != -1)
                //    text = string.Format("{0}<a href=\"mailto:{1}\">{1}</a>{2}",
                //                            before, inside, end);
                //else
                //    text = string.Format("<p>{0}<a href=\"mailto:{1}\">{1}</a>{2}</p>",
                //                            before, inside, end);
            }
        }


        //multilines конвертирование распространяется на несколько строк
        void Blockquote()
        {
            bool blockquoteBegin = false;

            for (int i = 0; i < _list.Count; i++)
            {

                if (_list[i].IndexOf("mailto:") != -1) // пропускаю Email
                    continue;

                if (_list[i].IndexOf('>') != -1)//начался 
                {
                    if (!blockquoteBegin)
                    {
                        blockquoteBegin = true;
                        _list.Insert(i, "<blockquote>");
                    }
                    else//продолжился
                    {
                        _list[i] = _list[i].Substring(1, _list[i].Length - 1); // убираю >

                        if (i + 1 == _list.Count)//закончился
                        {
                            blockquoteBegin = false;
                            _list.Add("</blockquote>");
                            break;
                        }
                    }
                }
                else
                {
                    if (blockquoteBegin)//закончился
                    {
                        blockquoteBegin = false;
                        _list.Insert(i, "</blockquote>");
                    }
                }
            }
        }
        void UnorderedList()
        {
            bool listBegin = false;
            for (int i = 0; i < _list.Count; i++)
            {

                if (!String.IsNullOrEmpty(_list[i]) && i + 1 != _list.Count && _list[i].IndexOf("* ") != -1)
                {
                    if (!listBegin) //начало списка
                    {
                        listBegin = true;
                        _list.Insert(i, "<ul>");
                    }
                }

                if (listBegin && _list[i].IndexOf("* ") != -1)
                {
                    _list[i] = string.Format("<li>{0}</li>",
                         _list[i].Substring(2, _list[i].Length - 2));

                    //конец списка
                    if (i + 1 == _list.Count)
                    {
                        listBegin = false;
                        _list.Add("</ul>");
                        break;
                    }
                    //конец списка
                    else if (String.IsNullOrEmpty(_list[i + 1]) || _list[i + 1].IndexOf("* ") == -1)
                    {
                        ++i;
                        listBegin = false;
                        _list.Insert(i, "</ul>");
                    }
                }

            }
        }

        void OrderedList()
        {
            bool listBegin = false;
            bool listContinue = false;
            bool listBeginWas = false;

            int prevNumber = 0;
            for (int i = 0; i < _list.Count; i++)
            {
                listBeginWas = false;
                //listContinue = false;

                for (int number = 1; number < 80; number++)
                {
                    //if (!String.IsNullOrEmpty(list[i]) && i + 1 != list.Count && list[i].IndexOf(number + ". ") != -1)// список начался 
                    if (!String.IsNullOrEmpty(_list[i]) && _list[i].IndexOf(number + ". ") != -1)// список начался 
                    {
                        //список начался 
                        if (number == 1) 
                        {
                            prevNumber = number;
                            listBeginWas = true;
                            break;
                        }
                        else if (number - 1 == prevNumber)//список продолжается
                        {
                            prevNumber = number;
                            listContinue = true;
                            break;
                        }
                    }
                }


                if (listBeginWas && !listBegin) //список начался 
                {
                    listBegin = true;
                    _list.Insert(i, "<ol>");

                    // добавляю в строку где начался список нужные символы 
                    ++i;

                    listContinue = false;
                    int index = _list[i].IndexOf(". ") + ". ".Length;

                    _list[i] = string.Format("<li>{0}</li>",
                        _list[i].Substring(index, _list[i].Length - index));
                }
                else
                if (listContinue) //список продолжается
                {
                    listContinue = false;
                    int index = _list[i].IndexOf(". ") + ". ".Length;

                    _list[i] = string.Format("<li>{0}</li>",
                        _list[i].Substring(index, _list[i].Length - index));

                    if (i + 1 == _list.Count)//список закончился если послядняя строка в list оканчание списка
                    {
                        prevNumber = 0;
                        listBegin = false;
                        _list.Add("</ol>");                       
                        break;
                    }
                }
                else
                if (!listBeginWas && listBegin) //список закончился
                {
                    prevNumber = 0;
                    listBegin = false;
                    _list.Insert(i, "</ol>");
                }
            }
        }

    }
}
