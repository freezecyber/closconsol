
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace closconsol
{
    static class Program
    {
        private static string ftg;
        private static int ik;
        private static Thread jdgf;
        private static Thread jdgfs;

        public static bool IsProcessOpen(string name)
        {


            //here we're going to get a list of all running processes on
            //the computer
            Application.DoEvents(); foreach (Process clsProcess in Process.GetProcesses())
            {

                //now we're going to see if any of the running processes
                //match the currently running processes. Be sure to not
                //add the .exe to the name you provide, i.e: NOTEPAD,
                //not NOTEPAD.EXE or false is always returned even if
                //notepad is running.
                //Remember, if you have the process running more than once, 
                //say IE open 4 times the loop thr way it is now will close all 4,
                //if you want it to just close the first one it finds
                //then add a return; after the Kill
                if (clsProcess.ProcessName.Contains(name))
                {
                    ik++;
                    if (!clsProcess.Responding)
                    {

                        Thread.Sleep(69500);
                        if (!clsProcess.Responding)
                        {
                            clsProcess.Kill();
                            return false;

                        }
                        else
                        {



                            //if the process is found to be running then we
                            //return a true
                            return true;

                        }
                    }
                
                    else
                    {



                        //if the process is found to be running then we
                        //return a true
                        return true;

                    }

                }
            }
            //otherwise we return a false
            return false;
        }
        public static void phsm()
        {

            do
            {
                Console.WriteLine("RESTART----RESTART---RESTART");

                Console.WriteLine("lecture prossx.txt");
                    string[] dyu = File.ReadAllLines("prossx.txt");
                    Application.DoEvents();
                foreach (string fj in dyu)

                {
                    Process[] processlist = Process.GetProcesses();
                    Application.DoEvents();

                    foreach (Process theprocess in processlist)

                    {


                        if (theprocess.ProcessName.Contains(fj))

                        {


                            Console.WriteLine("kill");


                            ik--;
                            try
                            {
                                theprocess.Kill();
                                theprocess.Kill();
                                theprocess.Kill();
                                theprocess.Kill();
                                theprocess.Kill();
                                theprocess.Kill();
                            }
                            catch { }


                        }








                    }





                    Application.DoEvents();


                    string fbi = Path.GetFileNameWithoutExtension(fj);
                    if (IsProcessOpen(fbi))
                    {
                        Console.WriteLine("is open");


                        Console.WriteLine(" ++ " + fj);

                    }
                    else
                    {
                        Console.WriteLine("is close");

                        Console.WriteLine(fj);

                    }
                }

              
                Thread.Sleep(3000000);
               

            } while (true);
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        public static void jk()
        {


            do
            {
                
                try
                {
                    Console.WriteLine("lecture progsx.txt");
                    string[] hfdc = File.ReadAllLines("progsx.txt");
               
                Application.DoEvents();
                foreach (string fth in hfdc)
                {


                    string fbi = Path.GetFileNameWithoutExtension(fth);

                    if (IsProcessOpen(fbi))
                    {

                        ik++;
                        Console.WriteLine("is open");

                        Console.WriteLine(" ++ " + fth);


                    }
                    else
                    {
                        bool createdNew = true;
                        using (Mutex mutex = new Mutex(true, fbi, out createdNew))
                        {
                            if (createdNew)
                            {
                                try
                                {
                                    Console.WriteLine("create new");
   
                                       Thread.Sleep(0);
                                        Application.DoEvents();
                                        Process.Start(fth);
                                   
                                }
                                catch { MessageBox.Show(fth + "not found"); }
                            }
                            else
                            {
                                Process current = Process.GetCurrentProcess();
                                Application.DoEvents(); foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                                {
                                    if (process.Id != current.Id)
                                    {
                                        Console.WriteLine("foreground");
   
                                           SetForegroundWindow(process.MainWindowHandle);
                                       
                                    }
                                }
                            }


                        }



                        ik++;
                        Console.WriteLine(" ++ " + fth);



                    }


                }

                }
                catch { Console.WriteLine("error proggx");  break; }

                Thread.Sleep(60000);
                
            } while (true);
        }


        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.Write("Bienvenue sur le programe Pour la Compagnie" + Environment.NewLine + "nous sommes fier de vous presenter" + Environment.NewLine + " linterface avec intelligence artificiel" + Environment.NewLine + "elle peut apprendre evoluer et changer");
            Console.WriteLine("");
            Console.WriteLine("--------");
            Console.WriteLine("Creer par : YAN BERGERON");
            Console.WriteLine("--------");

            string fth = File.ReadAllText("directory.tx");
            ftg = fth;
            System.IO.Directory.SetCurrentDirectory(fth);
            try
            {
                //Set the current directory.
                Directory.SetCurrentDirectory(ftg);
                Environment.CurrentDirectory = ftg;

                Properties.Settings.Default.Save();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("The specified directory does not exist. {0}", e);
            }
            // Print to console the results.
            Console.WriteLine("Root directory: {0}", Directory.GetDirectoryRoot(ftg));
            Console.WriteLine("Current directory: {0}", Directory.GetCurrentDirectory());



            try
            {
                string myHost = System.Net.Dns.GetHostName();
                string myIP = null;

                for (int i = 0; i <= System.Net.Dns.GetHostEntry(myHost).AddressList.Length - 1; i++)
                {
                    if (System.Net.Dns.GetHostEntry(myHost).AddressList[i].IsIPv6LinkLocal == false)
                    {
                        myIP = System.Net.Dns.GetHostEntry(myHost).AddressList[i].ToString();
                    }
                }
                Console.WriteLine("--------");
                Console.WriteLine("local ip : " + myIP);
                var xg = Environment.SystemPageSize;
                Console.WriteLine("--------");
                Console.WriteLine("memory paging loaded : " + xg);
                string[] sss = Environment.GetLogicalDrives();
                Console.WriteLine("logical drives : ");
                foreach (string bf in sss)
                {
                    Console.Write(bf);
                }
                var stt = Environment.MachineName;
                Console.WriteLine("");
                Console.WriteLine("--------");
                Console.WriteLine("machinne name : " + stt);
                int tre = Environment.ProcessorCount;
                Console.WriteLine("--------");
                Console.WriteLine("processor count : " + tre);
               
                var sut = Environment.UserDomainName;
                Console.WriteLine("--------");
                Console.WriteLine("network name : " + myHost);
                var scx = Environment.UserName;
                Console.WriteLine("--------");
                Console.WriteLine("user name : " + scx);
                var syr = Environment.Version;
                Console.WriteLine("--------");
                var syre = Environment.OSVersion;
                Console.WriteLine("os ver : " + syre);
                Console.WriteLine("--------");
                Console.WriteLine("ver : " + syr);
                string externalip = new WebClient().DownloadString("http://icanhazip.com");
                Console.WriteLine("--------");
                Console.WriteLine("ip adress : " + externalip);

                Console.WriteLine("--------");

                var sfg = Environment.UserInteractive;
                Console.WriteLine("interactif : " + sfg);
            }
            catch { Console.WriteLine("error environement"); }
            jdgf = new Thread(jk);
            jdgf.Start();
            Console.WriteLine("===================progsx started=====================");
            Console.WriteLine(" TYPE : ::open::  ::progs. .start.stop:: : kill::pross. .start.stop:: : TYPE");
            do
            {
               
                var stf= Console.ReadLine();

                if (stf == "progs.start")
                {
                    Console.WriteLine("progs start");

                    jdgf = new Thread(jk);
                    jdgf.Start();
                    Console.WriteLine(" TYPE : ::open::  ::progs. .start.stop:: kill: ::pross. .start.stop:: : TYPE");
                }
                else if (stf == "open")
                {
                    Process.Start(ftg + "/prossx.txt");
                    Process.Start(ftg + "/progsx.txt");
                }
                else if (stf == "kill")
                {
                    string[] hfdc = File.ReadAllLines("progsx.txt");

                    Application.DoEvents();
                    foreach (string fthf in hfdc)
                    {


                        string fbi = Path.GetFileNameWithoutExtension(fthf);

                        if (IsProcessOpen(fbi))
                        {

                        

                            foreach (Process shdm in Process.GetProcesses())
                            {
                                if (shdm.ProcessName == (fbi))
                                {
                                    shdm.Kill();
                                }
                            }


                        }

                    }
                }
                else if (stf == "progs.stop")
                {
                    Console.WriteLine("stoped");

                    jdgf.Abort();
                    Console.WriteLine(" TYPE : ::open::  ::progs. .start.stop:: :kill ::pross. .start.stop:: : TYPE");
                }
                else if (stf == "pross.start")
                {
                    Console.WriteLine("pross start");

                    jdgfs = new Thread(phsm);
                    jdgfs.Start();
                    Console.WriteLine(" TYPE : ::open::  ::progs. .start.stop:: : kill::pross. .start.stop:: : TYPE");

                }
                else if (stf == "pross.stop")
                {
                    Console.WriteLine("stoped");

                    jdgfs.Abort();
                    Console.WriteLine(" TYPE : ::open::  ::progs. .start.stop:: :kill ::pross. .start.stop:: : TYPE");
                }
                else
                {
                    Console.WriteLine(" TYPE : ::open::  ::progs. .start.stop:: : kill::pross. .start.stop:: : TYPE");
                    try
                    {
                        Console.WriteLine("lecture progsx.txt");
                        string[] hfdcs = File.ReadAllLines("progsx.txt");

                        Application.DoEvents();
                        foreach (string fthf in hfdcs)
                        {


                            string fbi = Path.GetFileNameWithoutExtension(fthf);

                            if (IsProcessOpen(fbi))
                            {

                                ik++;
                                Console.WriteLine("is open");

                                Console.WriteLine(" ++ " + fthf);


                            }
                            else
                            {
                                bool createdNew = true;
                                using (Mutex mutex = new Mutex(true, fbi, out createdNew))
                                {
                                    if (createdNew)
                                    {
                                        try
                                        {
                                            Console.WriteLine("create new");

                                            Thread.Sleep(0);
                                            Application.DoEvents();
                                            Process.Start(fthf);

                                        }
                                        catch { MessageBox.Show(fthf + "not found"); }
                                    }
                                    else
                                    {
                                        Process current = Process.GetCurrentProcess();
                                        Application.DoEvents(); foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                                        {
                                            if (process.Id != current.Id)
                                            {
                                                Console.WriteLine("foreground");

                                                SetForegroundWindow(process.MainWindowHandle);

                                            }
                                        }
                                    }


                                }



                                ik++;
                                Console.WriteLine(" ++ " + fthf);



                            }


                        }

                    }
                    catch { Console.WriteLine("error proggx"); break; }

                }
            } while (true);

        }
    }
}
