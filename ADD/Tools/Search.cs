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
        public static void GetLatestArchives()
        {

            string scope = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\root";
            string monitorHTML = "<html><head><meta charset=\"UTF-8\" /><link rel=\"stylesheet\" type=\"text/css\" href=\"root\\includes\\monitor.css\"></head><body>";

            Regex regex = new Regex(@"([a-fA-F0-9]{64})");
            string connectionString = "Provider=Search.CollatorDSO;Extended Properties=\"Application=Windows\"";
            HashSet<string> imgExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    ".jpg", ".jpeg", ".jpe", ".gif", ".png", ".tiff", ".tif", ".svg", ".svgz", ".xbm", ".bmp", ".ico"
                };

            OleDbConnection connection = new OleDbConnection(connectionString);

            string query = @"SELECT TOP 50 System.ItemFolderPathDisplay FROM SystemIndex WHERE scope ='file:" + scope + "' AND System.FileName = 'index.htm' ORDER BY System.DateModified DESC";
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
                    result.Add(match.Value);
                }
            }
            connection.Close();
            if (result.Count > 0)
            {
                var uniqueResults = result.Distinct();
                foreach (string s in uniqueResults)
                {
                    var signature = "unsigned";
                    var img = "";
                  
                    var msg = "";
                    var date = "";
                    var blockchain = "";
                    var profiles = "";
                    string strNickName = "";
                    string profileImage = "";
                    string fullName = "";
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    try
                    {
                        doc.Load(scope + "\\" + s + "\\index.htm");
                    }
                    catch { break; }

                    monitorHTML = monitorHTML + "<div>";

                    try { profiles = doc.GetElementbyId("profiles").InnerHtml.Replace(@"../", @"root/"); }
                    catch { }

                    if (File.Exists("root//" + s + "//PRO"))
                    {



                        string readFile = System.IO.File.ReadAllText("root//" + s+ "//PRO");
                        int start = readFile.IndexOf("NIK=") + 4;
                        int length = readFile.IndexOf(Environment.NewLine, start);
                        strNickName = readFile.Substring(start, length - start);

                        start = readFile.IndexOf("IMG=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        profileImage = readFile.Substring(start, length - start).Replace(@"../", @"root/");

                        start = readFile.IndexOf("PRE=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = readFile.Substring(start, length - start);
                        start = readFile.IndexOf("FNM=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = fullName + " " + readFile.Substring(start, length - start);
                        start = readFile.IndexOf("MNM=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = fullName + " " + readFile.Substring(start, length - start);
                        start = readFile.IndexOf("LNM=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = fullName + " " + readFile.Substring(start, length - start);
                        start = readFile.IndexOf("SUF=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = fullName + " " + readFile.Substring(start, length - start);

                    }

                    try { signature = doc.GetElementbyId("signature").InnerText; }
                    catch { }
                    try { blockchain = doc.GetElementbyId("blockchain").InnerText; }
                    catch { }
                    try { date = doc.GetElementbyId("block-date").InnerText; }
                    catch { }

                    if (profileImage != "") { monitorHTML = monitorHTML + "<pro><img src=\"" + profileImage + "\"></pro>"; }
                    try { msg = doc.GetElementbyId("msg1").InnerText; }
                    catch { }
                    if (msg != "")
                    {
                        if (msg.Length > 500) { msg = msg.Substring(0, 499) + "..."; }

                        msg = "<b>" + fullName + "</b><a href=\"root/" + s + "/index.htm\">@" + strNickName + " - " + date + "</a><br>" + msg + "<br><a href=\"root/" + s + "/index.htm\">" + s + "/MSG1</a>";
                        monitorHTML = monitorHTML + "<section>" + msg + "</section>";
                    }

                    try { img = doc.GetElementbyId("img0").InnerText; }
                    catch { }

                    if (img != "") { monitorHTML = monitorHTML + "<section><a href =\"root/" + s + "/index.htm\"><img src=\"root/" +s + "/"+ img + "\"></a></section>"; }

                    
                        monitorHTML = monitorHTML + "<section><a href=\"root/" + s + "/index.htm\">" + blockchain + " - " + signature +"</a></section>";
                 

                    monitorHTML = monitorHTML + "</div>";



                }
                monitorHTML = monitorHTML + "</body></html>";

            }
            else
            { monitorHTML = monitorHTML + "<section>Nothing found</section></body></html>"; }
        
            
            File.WriteAllText("monitor.htm", monitorHTML);

        }

        public static void GetWindowsSearchResults(string searchEntry)
    {
           string scope = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/root";
           string searchHTML = "<html><head><meta charset=\"UTF-8\" /><link rel=\"stylesheet\" type=\"text/css\" href=\"root\\includes\\monitor.css\"></head><body>";
            Regex regex = new Regex(@"([a-fA-F0-9]{64})");
            string connectionString = "Provider=Search.CollatorDSO;Extended Properties=\"Application=Windows\"";
            HashSet<string> imgExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    ".jpg", ".jpeg", ".jpe", ".gif", ".png", ".tiff", ".tif", ".svg", ".svgz", ".xbm", ".bmp", ".ico"
                };

            OleDbConnection connection = new OleDbConnection(connectionString);
            string query = @"SELECT TOP 1000 System.ItemFolderPathDisplay FROM SystemIndex WHERE scope ='file:" + scope + "' and FREETEXT('" + searchEntry.Replace("'", "").Replace("\"", "").Replace("\\", "") + "')";
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
                    result.Add(match.Value);
                }
            }
            connection.Close();
            if (result.Count > 0)
            {
  
                foreach (string s in result)
                {
                   

                  
                    var signature = "unsigned";
                    var img = "";

                    var msg = "";
                    var date = "";
                    var blockchain = "";
                    var profiles = "";
                    string strNickName = "";
                    string profileImage = "";
                    string fullName = "";
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    try
                    {
                        doc.Load(scope + "\\" + s + "\\index.htm");
                    }
                    catch { break; }

                    searchHTML = searchHTML + "<div>";

                    try { profiles = doc.GetElementbyId("profiles").InnerHtml.Replace(@"../", @"root/"); }
                    catch { }

                    if (File.Exists("root//" + s + "//PRO"))
                    {



                        string readFile = System.IO.File.ReadAllText("root//" + s + "//PRO");
                        int start = readFile.IndexOf("NIK=") + 4;
                        int length = readFile.IndexOf(Environment.NewLine, start);
                        strNickName = readFile.Substring(start, length - start);

                        start = readFile.IndexOf("IMG=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        profileImage = readFile.Substring(start, length - start).Replace(@"../", @"root/");

                        start = readFile.IndexOf("PRE=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = readFile.Substring(start, length - start);
                        start = readFile.IndexOf("FNM=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = fullName + " " + readFile.Substring(start, length - start);
                        start = readFile.IndexOf("MNM=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = fullName + " " + readFile.Substring(start, length - start);
                        start = readFile.IndexOf("LNM=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = fullName + " " + readFile.Substring(start, length - start);
                        start = readFile.IndexOf("SUF=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = fullName + " " + readFile.Substring(start, length - start);

                    }

                    try { signature = doc.GetElementbyId("signature").InnerText; }
                    catch { }
                    try { blockchain = doc.GetElementbyId("blockchain").InnerText; }
                    catch { }
                    try { date = doc.GetElementbyId("block-date").InnerText; }
                    catch { }

                    if (profileImage != "") { searchHTML = searchHTML + "<pro><img src=\"" + profileImage + "\"></pro>"; }
                    try { msg = doc.GetElementbyId("msg1").InnerText; }
                    catch { }
                    if (msg != "")
                    {
                        if (msg.Length > 500) { msg = msg.Substring(0, 499) + "..."; }

                        msg = "<b>" + fullName + "</b><a href=\"root/" + s + "/index.htm\">@" + strNickName + " - " + date + "</a><br>" + msg + "<br><a href=\"root/" + s + "/index.htm\">" + s + "/MSG1</a>";
                        searchHTML = searchHTML + "<section>" + msg + "</section>";
                    }

                    try { img = doc.GetElementbyId("img0").InnerText; }
                    catch { }

                    if (img != "") { searchHTML = searchHTML + "<section><a href =\"root/" + s + "/index.htm\"><img src=\"root/" + s + "/" + img + "\"></a></section>"; }


                    searchHTML = searchHTML + "<section><a href=\"root/" + s + "/index.htm\">" + blockchain + " - " + signature + "</a></section>";


                    searchHTML = searchHTML + "</div>";



                }
                searchHTML = searchHTML + "</body></html>";

            }
            else
            { searchHTML = searchHTML + "<section>Nothing found</section></body></html>"; }


            File.WriteAllText("search.htm", searchHTML);
        }

        public static void DisplayResultsByTransactionID(List<string> transactionHash)
        {

            string searchHTML = "<html><head><meta charset=\"UTF-8\" /><link rel=\"stylesheet\" type=\"text/css\" href=\"root\\includes\\monitor.css\"></head><body>";
            string scope = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/root";

            foreach (string s in transactionHash)
                {

                    var signature = "unsigned";
                    var img = "";

                    var msg = "";
                    var date = "";
                    var blockchain = "";
                    var profiles = "";
                    string strNickName = "";
                    string profileImage = "";
                    string fullName = "";
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    try
                    {
                        doc.Load(scope + "\\" + s + "\\index.htm");
                    }
                    catch { break; }

                    searchHTML = searchHTML + "<div>";

                    try { profiles = doc.GetElementbyId("profiles").InnerHtml.Replace(@"../", @"root/"); }
                    catch { }

                    if (File.Exists("root//" + s + "//PRO"))
                    {



                        string readFile = System.IO.File.ReadAllText("root//" + s + "//PRO");
                        int start = readFile.IndexOf("NIK=") + 4;
                        int length = readFile.IndexOf(Environment.NewLine, start);
                        strNickName = readFile.Substring(start, length - start);

                        start = readFile.IndexOf("IMG=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        profileImage = readFile.Substring(start, length - start).Replace(@"../", @"root/");

                        start = readFile.IndexOf("PRE=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = readFile.Substring(start, length - start);
                        start = readFile.IndexOf("FNM=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = fullName + " " + readFile.Substring(start, length - start);
                        start = readFile.IndexOf("MNM=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = fullName + " " + readFile.Substring(start, length - start);
                        start = readFile.IndexOf("LNM=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = fullName + " " + readFile.Substring(start, length - start);
                        start = readFile.IndexOf("SUF=") + 4;
                        length = readFile.IndexOf(Environment.NewLine, start);
                        fullName = fullName + " " + readFile.Substring(start, length - start);

                    }

                    try { signature = doc.GetElementbyId("signature").InnerText; }
                    catch { }
                    try { blockchain = doc.GetElementbyId("blockchain").InnerText; }
                    catch { }
                    try { date = doc.GetElementbyId("block-date").InnerText; }
                    catch { }

                    if (profileImage != "") { searchHTML = searchHTML + "<pro><img src=\"" + profileImage + "\"></pro>"; }
                    try { msg = doc.GetElementbyId("msg1").InnerText; }
                    catch { }
                    if (msg != "")
                    {
                        if (msg.Length > 500) { msg = msg.Substring(0, 499) + "..."; }

                        msg = "<b>" + fullName + "</b><a href=\"root/" + s + "/index.htm\">@" + strNickName + " - " + date + "</a><br>" + msg + "<br><a href=\"root/" + s + "/index.htm\">" + s + "/MSG1</a>";
                        searchHTML = searchHTML + "<section>" + msg + "</section>";
                    }

                    try { img = doc.GetElementbyId("img0").InnerText; }
                    catch { }

                    if (img != "") { searchHTML = searchHTML + "<section><a href =\"root/" + s + "/index.htm\"><img src=\"root/" + s + "/" + img + "\"></a></section>"; }


                    searchHTML = searchHTML + "<section><a href=\"root/" + s + "/index.htm\">" + blockchain + " - " + signature + "</a></section>";


                    searchHTML = searchHTML + "</div>";



                }
                searchHTML = searchHTML + "</body></html>";

               File.WriteAllText("follow.htm", searchHTML);
        }
    }
}
