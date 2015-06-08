using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;




namespace ADD.Tools
{
    class Search
    {
        public static void GetWindowsSearchResults(string searchEntry)
    {
           string scope = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/root";
           string searchHTML = "<html><head><meta charset=\"UTF-8\" /><link rel=\"stylesheet\" type=\"text/css\" href=\"root\\includes\\css.css\"></head><body><div class=\"main\">";
            Regex regex = new Regex(@"([a-fA-F0-9]{64})");
            string connectionString = "Provider=Search.CollatorDSO;Extended Properties=\"Application=Windows\"";
            HashSet<string> imgExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    ".jpg", ".jpeg", ".jpe", ".gif", ".png", ".tiff", ".tif", ".svg", ".svgz", ".xbm", ".bmp", ".ico"
                };

            OleDbConnection connection = new OleDbConnection(connectionString);
            string query = @"SELECT TOP 50 System.ItemFolderPathDisplay FROM SystemIndex WHERE scope ='file:" + scope + "' and FREETEXT('" + searchEntry.Replace("'", "").Replace("\"", "").Replace("\\", "") + "')";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();
            HashSet<string> result = new HashSet<string>();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string searchString = reader.GetString(0);
                Match match = regex.Match(searchString);
                if (match.Success)
                {
                    result.Add(searchString);
                }
            }
            connection.Close();
            if (result.Count > 0)
            {
  
                foreach (string folderPath in result)
                {
                    var signature = "ANONYMOUS";
                    var img = "";
                    //var file = "";
                    var msg = "";
                    var date = "";
                    var blockchain = "";
   

                    Match match = regex.Match(folderPath);
                    string s = match.Value;
                    //if (s == null) { break; }
                    try
                    {
                        var doc = new HtmlAgilityPack.HtmlDocument();
                        doc.Load(folderPath + "\\index.htm");

                        try
                        {
                            img = doc.GetElementbyId("img0").InnerText;
                            searchHTML = searchHTML + "<div class=\"item\"><div class=\"content\"><table><tr><th rowspan='5'><a href='root/" + s + "/index.htm'><img src='root/" + s + "/" + img + "' Width = '80px'/></a></th><th></th></tr>";
                        }
                        catch { searchHTML = searchHTML + "<div class=\"item\"><div class=\"content\"><table><tr><th rowspan='5'></th><th></th></tr>"; }
                        try { signature = doc.GetElementbyId("signature").InnerText; }
                        catch { }
                        try { blockchain = doc.GetElementbyId("blockchain").InnerText; }
                        catch { }
                        searchHTML = searchHTML + "<tr><td>" + blockchain + " - " + signature + "</td></tr>";
                        try { date = doc.GetElementbyId("block-date").InnerText; }
                        catch { }
                        try { msg = doc.GetElementbyId("msg1").InnerText; }
                        catch { }
                        searchHTML = searchHTML + "<tr><td><a href='root/" + s + "/index.htm'>" + date + " - " + msg.PadRight(50).Substring(0, 49) + "...</a></td></tr>";

                        if (msg.Length > 250)
                        { searchHTML = searchHTML + "<tr><td>" + msg.Substring(0, 249) + "</td></tr>"; }
                        else { searchHTML = searchHTML + "<tr><td>" + msg + "</td></tr>"; }


                        searchHTML = searchHTML + "<tr><td><a href='root/" + s + "/index.htm'>" + s + "</a></td></tr></table></div></div>";
                    }
                    catch { }
                }
                
                searchHTML = searchHTML + "</div></body></html>";
                
            }
            File.WriteAllText("search.htm", searchHTML);
           
        }
    }
}
