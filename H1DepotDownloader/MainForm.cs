using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H1DepotDownloader
{
    public partial class MainForm : MaterialForm
    {

        TextWriter _writer = null;

        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey900, Primary.BlueGrey500, Accent.Red100, TextShade.WHITE);
            materialSkinManager.AddFormToManage(this);

            _writer = new TextBoxStreamWriter(consoleLogs);
            Console.SetOut(_writer);
        }

        private void startDownloadBtn_Click_1(object sender, EventArgs e)
        {
            if (usernameText.Text == "" || passwordText.Text == "") { MessageBox.Show("Please fill in Username AND Password fields", "H1Emu - DepotDownloader", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            directory.Text = ContentDownloader.DEFAULT_DOWNLOAD_DIR;
            startDownloadBtn_ClickAsync();
        }

        private async Task startDownloadBtn_ClickAsync()
        {
            string [] args = argsText.Text.Split(' ');

            try { 
            AccountSettingsStore.LoadFromFile("account.config");
            } catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }

            string username = usernameText.Text;
            string password = passwordText.Text;

            ContentDownloader.Config.RememberPassword = HasParameter(args, "-remember-password");

            ContentDownloader.Config.DownloadManifestOnly = HasParameter(args, "-manifest-only");

            int cellId = GetParameter<int>(args, "-cellid", -1);
            if (cellId == -1)
            {
                cellId = 0;
            }

            ContentDownloader.Config.CellID = cellId;

            string fileList = GetParameter<string>(args, "-filelist");
            string[] files = null;

            if (fileList != null)
            {
                try
                {
                    string fileListData = File.ReadAllText(fileList);
                    files = fileListData.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    ContentDownloader.Config.UsingFileList = true;
                    ContentDownloader.Config.FilesToDownload = new List<string>();
                    ContentDownloader.Config.FilesToDownloadRegex = new List<Regex>();

                    var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
                    foreach (var fileEntry in files)
                    {
                        try
                        {
                            string fileEntryProcessed;
                            if (isWindows)
                            {
                                // On Windows, ensure that forward slashes can match either forward or backslashes in depot paths
                                fileEntryProcessed = fileEntry.Replace("/", "[\\\\|/]");
                            }
                            else
                            {
                                // On other systems, treat / normally
                                fileEntryProcessed = fileEntry;
                            }
                            Regex rgx = new Regex(fileEntryProcessed, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                            ContentDownloader.Config.FilesToDownloadRegex.Add(rgx);
                        }
                        catch
                        {
                            // For anything that can't be processed as a Regex, allow both forward and backward slashes to match
                            // on Windows
                            if (isWindows)
                            {
                                ContentDownloader.Config.FilesToDownload.Add(fileEntry.Replace("/", "\\"));
                            }
                            ContentDownloader.Config.FilesToDownload.Add(fileEntry);
                            continue;
                        }
                    }

                    Console.WriteLine("Using filelist: '{0}'.", fileList);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Warning: Unable to load filelist: {0}", ex.ToString());
                }
            }

            ContentDownloader.Config.InstallDirectory = GetParameter<string> (args, "-dir");

            ContentDownloader.Config.VerifyAll = HasParameter(args, "-verify-all") || HasParameter(args, "-verify_all") || HasParameter(args, "-validate");
            ContentDownloader.Config.MaxServers = GetParameter<int>(args, "-max-servers", 20);
            ContentDownloader.Config.MaxDownloads = GetParameter<int>(args, "-max-downloads", 8);
            ContentDownloader.Config.MaxServers = Math.Max(ContentDownloader.Config.MaxServers, ContentDownloader.Config.MaxDownloads);
            ContentDownloader.Config.LoginID = HasParameter(args, "-loginid") ? (uint?)GetParameter<uint>(args, "-loginid") : null;


            uint appId = GetParameter<uint>(args, "-app", ContentDownloader.INVALID_APP_ID);
            if (appId == ContentDownloader.INVALID_APP_ID)
            {
                Console.WriteLine("Error: -app not specified!");
            }

            ulong pubFile = GetParameter<ulong>(args, "-pubfile", ContentDownloader.INVALID_MANIFEST_ID);
            ulong ugcId = GetParameter<ulong>(args, "-ugc", ContentDownloader.INVALID_MANIFEST_ID);
            if (pubFile != ContentDownloader.INVALID_MANIFEST_ID)
            {
                #region Pubfile Downloading

                if (InitializeSteam(username, password))
                {
                    try
                    {
                        await ContentDownloader.DownloadPubfileAsync(appId, pubFile).ConfigureAwait(false);
                    }
                    catch (Exception ex) when (
                        ex is ContentDownloaderException
                        || ex is OperationCanceledException)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception er)
                    {
                        Console.WriteLine("Download failed to due to an unhandled exception: {0}", er.Message);
                        throw;
                    }
                    finally
                    {
                        ContentDownloader.ShutdownSteam3();
                    }
                }
                else
                {
                    Console.WriteLine("Error: InitializeSteam failed");
                }

                #endregion
            }
            else if (ugcId != ContentDownloader.INVALID_MANIFEST_ID)
            {
                #region UGC Downloading

                if (InitializeSteam(username, password))
                {
                    try
                    {
                        await ContentDownloader.DownloadUGCAsync(appId, ugcId).ConfigureAwait(false);
                    }
                    catch (Exception ex) when (
                        ex is ContentDownloaderException
                        || ex is OperationCanceledException)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception er)
                    {
                        Console.WriteLine("Download failed to due to an unhandled exception: {0}", er.Message);
                        throw;
                    }
                    finally
                    {
                        ContentDownloader.ShutdownSteam3();
                    }
                }
                else
                {
                    Console.WriteLine("Error: InitializeSteam failed");
                }

                #endregion
            }
            else
            {
                #region App downloading

                string branch = GetParameter<string>(args, "-branch") ?? GetParameter<string>(args, "-beta") ?? ContentDownloader.DEFAULT_BRANCH;
                ContentDownloader.Config.BetaPassword = GetParameter<string>(args, "-betapassword");

                ContentDownloader.Config.DownloadAllPlatforms = HasParameter(args, "-all-platforms");
                string os = GetParameter<string>(args, "-os", null);

                if (ContentDownloader.Config.DownloadAllPlatforms && !String.IsNullOrEmpty(os))
                {
                    Console.WriteLine("Error: Cannot specify -os when -all-platforms is specified.");
                }

                string arch = GetParameter<string>(args, "-osarch", null);

                ContentDownloader.Config.DownloadAllLanguages = HasParameter(args, "-all-languages");
                string language = GetParameter<string>(args, "-language", null);

                if (ContentDownloader.Config.DownloadAllLanguages && !String.IsNullOrEmpty(language))
                {
                    Console.WriteLine("Error: Cannot specify -language when -all-languages is specified.");
                }

                bool lv = HasParameter(args, "-lowviolence");

                List<(uint, ulong)> depotManifestIds = new List<(uint, ulong)>();
                bool isUGC = false;

                List<uint> depotIdList = GetParameterList<uint>(args, "-depot");
                List<ulong> manifestIdList = GetParameterList<ulong>(args, "-manifest");
                if (manifestIdList.Count > 0)
                {
                    if (depotIdList.Count != manifestIdList.Count)
                    {
                        Console.WriteLine("Error: -manifest requires one id for every -depot specified");
                    }

                    var zippedDepotManifest = depotIdList.Zip(manifestIdList, (depotId, manifestId) => (depotId, manifestId));
                    depotManifestIds.AddRange(zippedDepotManifest);
                }
                else
                {
                    depotManifestIds.AddRange(depotIdList.Select(depotId => (depotId, ContentDownloader.INVALID_MANIFEST_ID)));
                }

                if (InitializeSteam(username, password))
                {
                    try
                    {
                        await ContentDownloader.DownloadAppAsync(appId, depotManifestIds, branch, os, arch, language, lv, isUGC).ConfigureAwait(false);
                    }
                    catch (Exception ex) when (
                        ex is ContentDownloaderException
                        || ex is OperationCanceledException)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception er)
                    {
                        Console.WriteLine("Download failed to due to an unhandled exception: {0}", er.Message);
                        throw;
                    }
                    finally
                    {
                        ContentDownloader.ShutdownSteam3();
                    }
                }
                else
                {
                    Console.WriteLine("Error: InitializeSteam failed");
                }

            }

        }


        static bool InitializeSteam(string username, string password)
        {
            if (username != null && password == null && (!ContentDownloader.Config.RememberPassword || !AccountSettingsStore.Instance.LoginKeys.ContainsKey(username)))
            {
                do
                {
                    Console.Write("Enter account password for \"{0}\": ", username);
                    if (Console.IsInputRedirected)
                    {
                        password = Console.ReadLine();
                    }
                    else
                    {
                        // Avoid console echoing of password
                        password = Util.ReadPassword();
                    }
                    Console.WriteLine();
                } while (String.Empty == password);
            }
            else if (username == null)
            {
                Console.WriteLine("No username given. Using anonymous account with dedicated server subscription.");
            }

            // capture the supplied password in case we need to re-use it after checking the login key
            ContentDownloader.Config.SuppliedPassword = password;

            return ContentDownloader.InitializeSteam3(username, password);
        }

        static int IndexOfParam(string[] args, string param)
        {
            for (int x = 0; x < args.Length; ++x)
            {
                if (args[x].Equals(param, StringComparison.OrdinalIgnoreCase))
                    return x;
            }
            return -1;
        }
        static bool HasParameter(string[] args, string param)
        {
            return IndexOfParam(args, param) > -1;
        }

        static T GetParameter<T>(string[] args, string param, T defaultValue = default(T))
        {
            int index = IndexOfParam(args, param);

            if (index == -1 || index == (args.Length - 1))
                return defaultValue;

            string strParam = args[index + 1];

            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                return (T)converter.ConvertFromString(strParam);
            }

            return default(T);
        }

        static List<T> GetParameterList<T>(string[] args, string param)
        {
            List<T> list = new List<T>();
            int index = IndexOfParam(args, param);

            if (index == -1 || index == (args.Length - 1))
                return list;

            index++;

            while (index < args.Length)
            {
                string strParam = args[index];

                if (strParam[0] == '-') break;

                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    list.Add((T)converter.ConvertFromString(strParam));
                }

                index++;
            }

            return list;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string localVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString().TrimEnd('0').TrimEnd('.');
            this.Text = $"H1Emu - DepotDownloader - {localVersion}";

            outputLabel.Font = new Font("Roboto", 14);
        }
    }
}
#endregion