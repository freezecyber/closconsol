using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonoFlat;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;
using System.IO;

using Syn.Bot;

using Syn.Bot.Siml.Events;
using Syn.Bot.Siml;

namespace OpenMessage
{
    public partial class newMessageFrm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();
       SimlBot lk = new SimlBot();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
        // To support flashing.
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        //Flash both the window caption and taskbar button.
        //This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags. 
        public const UInt32 FLASHW_ALL = 3;

        // Flash continuously until the window comes to the foreground. 
        public const UInt32 FLASHW_TIMERNOFG = 12;

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }
        public static bool FlashWindowEx(newMessageFrm form)
        {
            IntPtr hWnd = form.Handle;
            FLASHWINFO fInfo = new FLASHWINFO();

            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = hWnd;
            fInfo.dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG;
            fInfo.uCount = UInt32.MaxValue;
            fInfo.dwTimeout = 0;

            return FlashWindowEx(ref fInfo);
        }
        public string serverName;
       public String frmId {get; set; }
        String jidFrom;
        public string remoteUID = null;
       
        private string fdc;
        private roster rosFrm;

        public newMessageFrm(string jid, string domain)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            jidFrom = jid;
            newMessageWindow.Text = "Chat with: " + jid;
            serverName = domain;
            this.Text = "Chat with: " + jid; lk.Learning += new EventHandler<LearningEventArgs>(SynBot_Learning);
            Thread hdcx = new Thread(pxj);
            hdcx.Start();

            lk.Memorizing += new EventHandler<MemorizingEventArgs>(synBot_Memorizing);
            lk.Configuration.StoreVocabulary = true;
            lk.Configuration.StoreExamples = true;
            //Load brain files(siml) here...
            var simlPackage = File.ReadAllText("know.simlpk");
            lk.PackageManager.LoadFromString(simlPackage);
            try
            {
                var fileLearn = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "package\\Learned.siml"));
                lk.AddSiml(fileLearn);
                Console.WriteLine("Loaded learning file...");
            }
            catch { Console.WriteLine("NO learn..."); }
            try
            {
                int yh = 0;
                var fileLearn = Directory.GetFiles(Path.Combine("siml", "*.siml"));
                foreach (string fk in fileLearn)
                {
                    yh++;
                    lk.AddSiml(fk);
                    Console.WriteLine("Loaded learning file..." + yh.ToString());
                }
            } 
            catch { Console.WriteLine("NO learn..."); }
           


            

        }

        private void pxj()
        {
            if (File.Exists(datestver.Properties.Settings.Default.stk + ".txt"))
            {


                string[] pkn = File.ReadAllLines(datestver.Properties.Settings.Default.stk + ".txt");
                foreach (string ft in pkn)
                {
                    
                    var chatResulte = lk.Chat(ft);
                    
                        Console.WriteLine(chatResulte.BotMessage);
                   
                }
            }
            else
            {
                File.WriteAllText(datestver.Properties.Settings.Default.stk + ".txt", "my name is yan" + Environment.NewLine);
            }

        }

        public void sendBtn_Click(object sender, EventArgs e)
        {
            try
            {

                datestver.aitest.client.Connect();
          
            if (datestver.aitest.client.Connected == true)
            {
                try
                {
                        datestver.aitest.client.Authenticate("cyberfreeze", "disable1");
                }
                catch (System.Security.Authentication.AuthenticationException ex)
                {
                    Console.WriteLine("Error - Authentication", ex.Message);

                }

               
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - Connection", ex.Message);
                //client.Close();
            }
            fdc = textBox1.Text;
            File.AppendAllText(datestver.Properties.Settings.Default.stk + ".txt", fdc + Environment.NewLine);
            Thread hdc = new Thread(pj);
            hdc.Start();
            datestver.aitest.client.SendMessage(jidFrom + "@" + serverName, textBox1.Text);
            appendMsg("You: ", textBox1.Text);
          
            textBox1.Text = "";
            textBox1.Select();

        }

        private void pj()
        {
            
            var chatResult =lk.Chat(fdc);
            if (chatResult.Success)
            
                richTextBox1.AppendText(chatResult.BotMessage+Environment.NewLine);
            





            }

        static void msg(String title, String Error)
        {
            Form newFrm = new newMsgb(title, Error);
            newFrm.ShowDialog();
        }
      void SynBot_Learning(object sender, LearningEventArgs e)
        {
            Console.WriteLine("--------------------------------");
            try
            {
                Console.WriteLine("Writing to learn file...");
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "package\\Learned.siml");
                e.Document.Save(filePath);
                Console.WriteLine("Saved learn file!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Write Failed: " + ex.Message);
            }
            Console.WriteLine("--------------------------------");
        }
        void synBot_Memorizing(object sender, MemorizingEventArgs e)
        {
            Random random = new Random();
            string randNum = "";
            for (int i = 0; i < 10; i++)
            {
                int randomNumber = random.Next(0, 100);
                randNum += randomNumber.ToString();
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Writing to memory file for user: " + e.User.ID);
            try
            {
                if (Directory.Exists(Directory.GetCurrentDirectory() + "\\package\\" + e.User.ID))
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "\\package", e.User.ID, "Memorized-" + randNum + ".siml");
                    e.Document.Save(filePath);
                }
                else
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\package\\" + e.User.ID);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "\\package", e.User.ID, "Memorized" + randNum + ".siml");
                    e.Document.Save(filePath);
                }
                Console.WriteLine("Write success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Write failed: " + ex.Message);
            }

            Console.WriteLine("--------------------------------");
        }
        public void appendMsg(String jid, String Message)
        {

            if (Message.Contains("/*/*OTR_REQUEST*"))
            {
                //OTR does not work yet, working to get a random session ID first.
                String[] otrMsg = Message.Split('*');
                remoteUID = otrMsg[3];
                //Process the OTR request:
                otr newOtrSess = new otr();
                String SessionID = newOtrSess.generateSessionID();
                //newOtrSess.createSession(SessionID);
                msg("Status - Conversation - New OTR ID", SessionID);
                return; //Do NOT process the rest of this function!!!!
            }
            if(ApplicationIsActivated() == false)
            {
                

            }
            String timeNow = DateTime.Now.ToString("hh:mm:ss tt");
            if (jid == "You")
            {
                richTextBox1.SelectionColor = Color.Cyan;
                richTextBox1.AppendText("["+timeNow + "]" + jid + ": ");
                richTextBox1.SelectionColor = Color.White;
                richTextBox1.AppendText(Message + Environment.NewLine);
              
                var chatResult = lk.Chat(Message);
                
                    richTextBox1.AppendText(chatResult.BotMessage + Environment.NewLine);
                
            } else
            {
                richTextBox1.SelectionColor = Color.LightGreen;
                richTextBox1.AppendText("[" + timeNow + "]" + jid + ": ");
                richTextBox1.SelectionColor = Color.White;
                richTextBox1.AppendText(Message + Environment.NewLine);
                
                var chatResult =lk.Chat(Message);
               
                    richTextBox1.AppendText(chatResult.BotMessage + Environment.NewLine);
                

            }
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.ScrollToCaret();

        }
        public static bool ApplicationIsActivated()
        {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero)
            {
                return false;       // No window is currently activated
            }

            var procId = Process.GetCurrentProcess().Id;
            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);

            return activeProcId == procId;
        }

        public void _msgText(String jid, String Message)
        {
            appendMsg(jid, Message);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {

                    datestver.aitest.client.Connect();
           
                if (datestver.aitest.client.Connected == true)
                {
                    try
                    {
                            datestver.aitest.client.Authenticate("cyberfreeze", "disable1");
                    }
                    catch (System.Security.Authentication.AuthenticationException ex)
                    {
                        Console.WriteLine("Error - Authentication", ex.Message);

                    }

                   
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - Connection", ex.Message);
                    //client.Close();
                }
                if (textBox1.Text == "") { return; }
                fdc = textBox1.Text;
                Thread hdc = new Thread(pj);
                hdc.Start();
                datestver.aitest.client.SendMessage(jidFrom + "@" + serverName, textBox1.Text);
                appendMsg("You", textBox1.Text);
                textBox1.Text = "";
                textBox1.Select();
            }
        }

        private void newMessageWindow_Click(object sender, EventArgs e)
        {

        }
    }
}
