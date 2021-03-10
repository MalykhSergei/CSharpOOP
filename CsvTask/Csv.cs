using System;
using System.IO;
using System.Text;

namespace CsvTask
{
    class Csv
    {
        public static void ReadCsv(string inputFileName, string outputFileName)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                using StreamReader reader = new StreamReader(inputFileName);

                bool cellOpen = false;
                bool quoteAdded = false;

                using StreamWriter writer = new StreamWriter(outputFileName);

                writer.Write("<!DOCTYPE html> <html> <head> <meta charset=\"UTF-8\"> <title>Table</title> </head> <body> <table>");

                string textCsv;

                while ((textCsv = reader.ReadLine()) != null)
                {
                    writer.Write("<tr>");
                    writer.Write("<td>");

                    for (int i = 0; i < textCsv.Length; i++)
                    {
                        char ch = textCsv[i];
                        char chNext = ' ';

                        if (i != textCsv.Length - 1)
                        {
                            chNext = textCsv[i + 1];
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

                            if (i == textCsv.Length - 1)
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

                writer.Write("</td> </tr> </table> </body> </html>");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File is not found!");
                Console.ReadKey();
            }
            catch (IOException)
            {
                Console.WriteLine("Error reading or writing the file");
                Console.ReadKey();
            }
        }
    }
}
