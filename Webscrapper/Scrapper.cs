using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Webscrapper
{
    class Program
    {
        //Enter the folder name where you want
        //to store the attachments with filename being whatever you 
        //want the name of the file.
        public static void WebScrapping(String a, String file, String URL, String SaveFolder)
        {
            //All the attachements are stored in an HashSet to avoid duplication
            //HashSet<String> s = new HashSet<string>();
            //String SaveFolder = @"C:\Users\user\Desktop\Documnet\";
            //String FileName = "Test";
            ScrapingBrowser Browser = new ScrapingBrowser();
            Browser.AllowAutoRedirect = true; // Browser has settings you can access in setup
            Browser.AllowMetaRedirect = true;
            WebPage PDFResponse = Browser.NavigateToPage(new Uri(URL+ a));
            File.WriteAllBytes(SaveFolder + file, PDFResponse.RawResponse.Body);            
        }
        public static void Extract(String url, String extension)
        {
            HashSet<String> hash = new HashSet<string>();
            var doc = new HtmlWeb().Load(url);
            var linkTags = doc.DocumentNode.Descendants("link");
            var linkedPages = doc.DocumentNode.Descendants("a")
                                              .Select(a => a.GetAttributeValue("href", null))
                                              .Where(u => !String.IsNullOrEmpty(u));
            foreach (var a in hash)
            {
                if (a.EndsWith(extension))
                {
                    WebScrapping(a, "File name you want to ",url, "extension");
                }   
            }
            //Console.WriteLine(hash.Count());
        }
       }
        
