using System;
using System.IO;
using System.Text;

namespace CsvTask
{
    class Csv
    {
        public static void PrintHelp()
        {
            Console.WriteLine("For the program to work correctly, you must enter arguments separated by a space, where:");
            Console.WriteLine("- the first argument is the address and name of the source csv file");
            Console.WriteLine("- the second argument is the address and name of the resulting html file");
        }

        public static void ReadCsv(string inputFileName, string outputFileName)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                using StreamReader reader = new StreamReader(inputFileName);

                bool quoteAdded = false;

                using StreamWriter writer = new StreamWriter(outputFileName);

                writer.Write("<!DOCTYPE html> <html> <head> <meta charset=\"UTF-8\"> <title>Table</title> </head> <body>");
                writer.Write("<table border=\"1\">");

                string textCsv;

                while ((textCsv = reader.ReadLine()) != null)
                {
                    if (textCsv.Length == 0)
                    {
                        continue;
                    }

                    if (quoteAdded)
                    {
                        writer.Write("<br/>");
                    }
                    else
                    {
                        writer.WriteLine("<tr>");
                        writer.Write("<td>");
                    }

                    for (int i = 0; i < textCsv.Length; i++)
                    {
                        char currentChar = textCsv[i];

                        if (currentChar == '<')
                        {
                            writer.Write("&lt;");
                        }
                        else if (currentChar == '>')
                        {
                            writer.Write("&gt;");
                        }
                        else if (currentChar == '&')
                        {
                            writer.Write("&amp;");
                        }
                        else if (currentChar == '"')
                        {
                            if (quoteAdded)
                            {
                                quoteAdded = false;
                            }
                            else
                            {
                                quoteAdded = true;

                                if (i != 0)
                                {
                                    if (textCsv[i - 1] == '"')
                                    {
                                        writer.Write('"');
                                    }
                                }
                            }
                        }
                        else if (currentChar == ',')
                        {
                            if (quoteAdded)
                            {
                                writer.Write(", ");
                            }
                            else
                            {
                                writer.Write("</td><td>");
                            }
                        }
                        else
                        {
                            writer.Write(currentChar);
                        }
                    }

                    if (!quoteAdded)
                    {
                        writer.WriteLine("</td>");
                        writer.WriteLine("</tr>");
                    }
                }

                writer.WriteLine("</table>");
                writer.WriteLine("</body>");
                writer.WriteLine("</html>");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File is not found!");
                Console.WriteLine();
                PrintHelp();

                Console.ReadKey();
            }
            catch (IOException)
            {
                Console.WriteLine("Error reading or writing the file");
                PrintHelp();

                Console.ReadKey();
            }
        }
    }
}
