//Alternative approach to download the files 

      public static String ContainsRegex(String a)
        {
				    //The keywords can be identified using the regex patterns
						//eg. pdf files in this
            Regex rgx = new Regex("(?!.*()).*pdf");
            Match match = rgx.Match(a);
            return match.ToString();
        }
        public static void Download(String strURLFileandPath, String strFileSaveFileandPath)

        {
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(strURLFileandPath);
            HttpWebResponse ws = (HttpWebResponse)wr.GetResponse();
            Stream str = ws.GetResponseStream();
            byte[] inBuf = new byte[100000];
            int bytesToRead = (int)inBuf.Length;
            int bytesRead = 0;
            while (bytesToRead > 0)
            {
                int n = str.Read(inBuf, bytesRead, bytesToRead);
                if (n == 0)
                    break;
                bytesRead += n;
                bytesToRead -= n;
            }
            FileStream fstr = new FileStream(strFileSaveFileandPath, FileMode.OpenOrCreate, FileAccess.Write);
            fstr.Write(inBuf, 0, bytesRead);
            str.Close();
            fstr.Close();
        }
