using System.IO;
using System.Text;

namespace CsvTask
{
    class ConvertCSV
    {
        public static void ReadCSV(string fileNameIn, string fileNameOut)
        {
            string textCSV = File.ReadAllText(fileNameIn);
            StringBuilder textHTML = new StringBuilder();

            textHTML.AppendLine(@"<!DOCTYPE html>
           <html>
           <head>
           <title>Таблица</title>
           </head>
           <body>
           <table>
           <tr>
           <td>");

            bool cellOpen = false;
            bool quoteAdded = false;

            for (int i = 0; i < textCSV.Length; i++)
            {
                char ch = textCSV[i];
                char chNext = ' ';

                if (i != textCSV.Length - 1)
                {
                    chNext = textCSV[i + 1];
                }

                if ((ch == ',') && cellOpen)
                {
                    textHTML.Append(ch);
                }
                else if (((ch == '\n')) && cellOpen)
                {
                    textHTML.Append("<br/>");
                }
                else if ((ch == ',') && !cellOpen)
                {
                    textHTML.Append("</td><td>");
                }
                else if (ch == '"')
                {
                    if (!cellOpen)
                    {
                        cellOpen = true;
                    }
                    else if (quoteAdded)
                    {
                        quoteAdded = false;
                    }
                    else if (chNext == ch)
                    {
                        textHTML.Append('"');
                        quoteAdded = true;
                    }
                    else if (chNext != ch)
                    {
                        cellOpen = false;
                    }
                }
                else if ((ch == '\n') && !cellOpen)
                {
                    textHTML.AppendLine("</td>");
                    textHTML.AppendLine("</tr>");

                    if (i == textCSV.Length - 1)
                    {
                        break;
                    }

                    textHTML.AppendLine("<tr>");
                    textHTML.Append("<td>");
                }
                else if (ch == '<')
                {
                    textHTML.Append("&lt;");
                }
                else if (ch == '>')
                {
                    textHTML.Append("&gt;");
                }
                else if (ch == '&')
                {
                    textHTML.Append("&amp;");
                }
                else
                {
                    textHTML.Append(ch);
                }
            }

            textHTML.AppendLine(@"</td>
            </tr>
            </table>
            </body>
            </html>");

            File.WriteAllText(fileNameOut, textHTML.ToString());
        }
    }
}

