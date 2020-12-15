using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiteGrabber.Core;
using SiteGrabber.Leboncoin;
using SiteGrabber.PapFr;
using SiteGrabber.Seloger;
using SiteGrabber.SuperImmo;

namespace SiteGrabber
{
    public class Program
    {
        private static SqlConnection connection;
        public static readonly object Sync = new object();
        public static void SaveAnnouncement(GenericAnnouncementModel model)
        {
            try
            {
                var query = model.GenerateQuery();
                lock (Sync)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                Logger.WriteLine("{1}  {0} models processed \t\t\t", count++, model.HostSite);
                //Console.CursorLeft = 0;
            }
            catch (Exception e)
            {
                Logger.WriteLine(e.Message);
            }
        }

        private static int count = 1;
        public static void Main(string[] args)
        {
            string connectionString =
                "Data Source=10.123.132.64;Initial Catalog=PapaStreet;User Id=sa;Password=Qwerty1;";
            Logger.WriteLine("connecting to sql server...");
            connection=new SqlConnection(connectionString);
            connection.Open();

            Logger.WriteLine("connected");

            Logger.WriteLine("binding listeners...");
            //listen for events
            LeboncoinParser.Instance.AnnouncementParsed += SaveAnnouncement;
            SuperImmoParser.Instance.AnnouncementParsed += SaveAnnouncement;
            SelogerParser.Instance.AnnouncementParsed += SaveAnnouncement;
            PapFrParser.Instance.AnnouncementParsed += SaveAnnouncement;
            Logger.WriteLine("listeners bound");

            Logger.WriteLine("starting threads");
            //start all 
            StartInNewThread(async () =>await LeboncoinParser.Instance.Start());
            StartInNewThread(async () =>await SuperImmoParser.Instance.Start());
            StartInNewThread(async () =>await SelogerParser.Instance.Start());
            StartInNewThread(async () =>await PapFrParser.Instance.Start());


            Application.Run();
        }

        private static void StartInNewThread(Action action)
        {
            Thread thread = new Thread(() => action());
            Logger.WriteLine("starting thread : "+thread.ManagedThreadId);
            thread.SetApartmentState(ApartmentState.Unknown);
            Logger.WriteLine("started thread : " + thread.ManagedThreadId);
            thread.Start();
        }
    }
}
