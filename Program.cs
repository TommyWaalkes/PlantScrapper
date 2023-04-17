
using System;
using System.IO;
using System.Net;

namespace API_Backup
{
    class Program
    {
        static void Main(string[] args)
        {
            string APIText = "";
            Console.WriteLine("Paste in the file path you wish to ouput all the files to:");
            string filePath = Console.ReadLine();
            Console.WriteLine("Next input a starting page for your api");
            int start =  int.Parse(Console.ReadLine());

            Console.WriteLine("Next put in the age you wish to end on");
            int end = int.Parse(Console.ReadLine());

                try
                {
                    for (int i = start; i <= end; i++)
                    {
                        string Url = "https://perenual.com/api/species-list?key=sk-zKUS64374955e6d69502&page="+i;
                        HttpWebRequest request = WebRequest.CreateHttp(Url);
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        StreamReader rd = new StreamReader(response.GetResponseStream());
                        APIText = rd.ReadToEnd();
                        //Console.WriteLine(APIText);
                        rd.Close();
                        string fileName = "plants" + i + ".json";

                       
                        
                        string fullPath = filePath + "\\" + fileName;

                        File.Create(fullPath).Dispose();

                        StreamWriter writer = new StreamWriter(fullPath);
                        writer.Write(APIText);
                        writer.Close();
                        Console.WriteLine("Json exported to " + fullPath + " named "+fileName+" successfully");
                                            }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Let's try that again");
                }
            }

        }
    }

