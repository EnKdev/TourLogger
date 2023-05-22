using System;
using System.IO;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using Newtonsoft.Json;
using TourLogger.Mvvm.Interfaces;
using TourLogger.Mvvm.Models;
using TourLogger.Mvvm.Util;

namespace TourLogger.Mvvm;

/// <summary>
/// Helper class to handle all the startup routines before the app can be seen as loaded.
/// </summary>
public class StartupHandler
{
    const string UpdatePath = $"./Update";

    /// <summary>
    /// Initializes the app by running through all startup routines.
    /// </summary>
    public static void InitApp()
    {
        CheckIfUpdatePathExists();
        MigrateCache();
        SetupAutoUpdater();
        HandleAccountParsing();
    }

    private static void CheckIfUpdatePathExists()
    {
        if (!Directory.Exists(UpdatePath))
        {
            Directory.CreateDirectory(UpdatePath);
        }
    }

    private static void MigrateCache()
    {
        if (File.Exists($"./Userdata/cache.dat"))
        {
            File.Copy($"./Userdata/cache.dat", $"./Userdata/tourCache.dat");
            File.Delete($"./Userdata/cache.dat");
        }
    }

    private static void SetupAutoUpdater()
    {
        AutoUpdater.DownloadPath = UpdatePath;
        
#if STABLE
        AutoUpdater.Start("https://enkdev.xyz/cdn/software/tourlogger/update/update.xml");
#elif EXPERIMENTAL
        AutoUpdater.Start("https://enkdev.xyz/cdn/software/tourlogger/update/update.experimental.xml");
#endif

        if (AutoUpdater.Mandatory)
        {
            AutoUpdater.ShowUpdateForm(new UpdateInfoEventArgs());
        }
    }

    private static void HandleAccountParsing()
    {
        if (File.Exists($"./Userdata/account.dat"))
        {
            try
            {
                // Read existing profile
                var account =
                    JsonConvert.DeserializeObject<AccountModel>(File.ReadAllText($"./Userdata/account.dat"));

                if (account == null)
                {
                    return;
                }

                ValueHolder.AccountName = account.Name;
                ValueHolder.TruckUsed = account.Truck;
                ValueHolder.AccountIncome = long.Parse(account.TotalIncome!);
                ValueHolder.ToursDriven = int.Parse(account.TotalTours!);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}