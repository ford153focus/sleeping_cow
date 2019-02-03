using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace sleeping_cow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            bannedTasksKiller();
            timeCorrector();
        }

        private static void timeCorrector()
        {
            var ntpTime = Utils.DateTimeUtils.Ntp.GetNetworkTime();
            Utils.DateTimeUtils.SetSystemDateTime.SetByDtObj(ntpTime);
            Utils.DateTimeUtils.SetSystemTimeZone("Russian Standard Time");

            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 5) {
                Utils.PowerUtils.shutDown();
            }
        }

        private static void bannedTasksKiller()
        {
            var bannedTasks = new List<string> { 
                "left4dead", 
                "LeagueClient" 
            };

            foreach (Process theProcess in Process.GetProcesses())
            {
                if (bannedTasks.Contains(theProcess.ProcessName))
                {
                    // theProcess.Kill();
                    Utils.Bsod.Invoke();
                }
            }
        }
    }
}
