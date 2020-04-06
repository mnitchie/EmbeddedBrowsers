using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Permissions;
using System.IO;

// Implementation modified from https://docs.microsoft.com/en-us/dotnet/framework/winforms/how-to-create-a-windows-forms-application-from-the-command-line 
// and https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-add-web-browser-capabilities-to-a-windows-forms-application
[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
public class TheWorstBrowser : Form {    
    public TheWorstBrowser() {
        InitializeForm();

        webBrowser.GoHome();
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new TheWorstBrowser());
    }

    private WebBrowser webBrowser;
    private ToolStrip urlContainer;
    private ToolStripTextBox urlInput;

    // Navigates to the URL in the address box when 
    // the ENTER key is pressed while the ToolStripTextBox has focus.
    private void toolStripTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Navigate(urlInput.Text);
        }
    }

    // Selects all the text in the text box when the user clicks it. 
    private void toolStripTextBox_Click(object sender, EventArgs e)
    {
        urlInput.SelectAll();
    }

    // Updates the URL in TextBoxAddress upon navigation.
    private void webBrowser_Navigated(object sender,
        WebBrowserNavigatedEventArgs e)
    {
        urlInput.Text = webBrowser.Url.ToString();
    }

    private void webBrowser_DocumentCompleted(object sender,
        WebBrowserDocumentCompletedEventArgs e) 
    {
        /*
        Attach an instance of TheWorstLogger to the html document. js executed in the page will be able
        to reference this via window.external. Inject javascript into the page that attaches an event handler
        to window.onerror that will call TheWorstLogger's handleError function, allowing us to log console errors.
        */

        // TODO: This doesn't do anything...

       /* var dir = Path.GetDirectoryName(Application.ExecutablePath);
        var logName = "TheWorstBrowser.log";
        var logPath = Path.Combine(dir, logName);
        webBrowser.ObjectForScripting = new TheWorstLogger{
            LogPath = logPath
        };

        var js = @"
        window.onerror = function(message, url, lineNumber) 
        { 
            window.external.errorHandler(message, url, lineNumber);
        }";
        webBrowser.Document.InvokeScript("eval", new object[] { js });
        */
    }

    // Navigates to the given URL if it is valid.
    private void Navigate(String address)
    {
        if (String.IsNullOrEmpty(address)) return;
        if (address.Equals("about:blank")) return;
        if (!address.StartsWith("http://") &&
            !address.StartsWith("https://"))
        {
            address = "http://" + address;
        }
        try
        {
            webBrowser.Navigate(new Uri(address));
        }
        catch (System.UriFormatException)
        {
            return;
        }
    }

    private void InitializeForm() {
        this.Size = new Size(1500, 900);
        this.Text = "The Worst Browser";
        this.StartPosition = FormStartPosition.CenterScreen;

        this.webBrowser = new WebBrowser();
        this.webBrowser.Dock = DockStyle.Fill;

        this.urlContainer = new ToolStrip();
        this.urlContainer.Size = new Size(900, 25);
        this.urlInput = new ToolStripTextBox{
            BorderStyle = BorderStyle.FixedSingle,
        };
        this.urlInput.Size = new System.Drawing.Size(890, 25);
        this.urlContainer.Items.Add(urlInput);

        this.urlInput.KeyDown +=
            new KeyEventHandler(toolStripTextBox_KeyDown);
        this.urlInput.Click +=
            new System.EventHandler(toolStripTextBox_Click);
        this.webBrowser.Navigated +=
            new WebBrowserNavigatedEventHandler(webBrowser_Navigated);
        this.webBrowser.DocumentCompleted += 
            new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);

        this.Controls.AddRange(new Control[] {
            webBrowser,
            urlContainer
        });
    }

    // http://notions.okuda.ca/2009/06/11/calling-javascript-in-a-webbrowser-control-from-c/
    // https://stackoverflow.com/questions/5529615/webbrowser-control-and-javascript-errors?noredirect=1&lq=1
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class TheWorstLogger
    {
        public string LogPath {get; set;}
        public void handleError(string message, string url, int lineNumber)
        {
            using (StreamWriter w = File.AppendText(this.LogPath)) {
                var msg = string.Format(
                    "Error: {1}\nline: {0}\nurl: {2}",
                    message, //#1
                    lineNumber, //#0
                    url
                );  
                w.WriteLine(msg);
            }
        }
    }
}