using System;
using System.IO;
using System.Text;

namespace CsvTask
{
    class Csv
    {
        public static void ReadCsv()
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                using (StreamReader reader = new StreamReader("Csv.txt"))
                {
                    bool cellOpen = false;
                    bool quoteAdded = false;

                    using (StreamWriter writer = new StreamWriter("HTML.html"))
                    {
                        writer.Write("<table>");

                        string textCSV;

                        while ((textCSV = reader.ReadLine()) != null)
                        {
                            writer.Write("<tr>");
                            writer.Write("<td>");

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
                                    writer.Write(ch);
                                }
                                else if ((ch == '\n') && cellOpen)
                                {
                                    writer.Write("<br/>");
                                }
                                else if ((ch == ',') && !cellOpen)
                                {
                                    writer.Write("</td><td>");
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
                                        writer.Write('"');
                                        quoteAdded = true;
                                    }
                                    else if (chNext != ch)
                                    {
                                        cellOpen = false;
                                    }
                                }
                                else if ((ch == '\n') && !cellOpen)
                                {
                                    writer.Write("</td>");
                                    writer.Write("</tr>");

                                    if (i == textCSV.Length - 1)
                                    {
                                        break;
                                    }

                                    writer.Write("<tr>");
                                    writer.Write("<td>");
                                }
                                else if (ch == '<')
                                {
                                    writer.Write("&lt;");
                                }
                                else if (ch == '>')
                                {
                                    writer.Write("&gt;");
                                }
                                else if (ch == '&')
                                {
                                    writer.Write("&amp;");
                                }
                                else
                                {
                                    writer.Write(ch);
                                }
                            }
                        }

                        writer.Write("</table>");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File is not found!");
                Console.ReadKey();
                return;
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                return;
            }
        }
    }
}
