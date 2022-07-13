using MySql.Data.MySqlClient;

namespace WaterSpiderExtractor
{
    public partial class MainForm : Form
    {
        const string DATABASE_FILE = "database.cfg";
        MySqlConnection waterspider;

        public MainForm()
        {
            InitializeComponent();
            
            toDatePicker.MaxDate = DateTime.Today;
            fromDatePicker.MaxDate = DateTime.Today;
            DateTime firsttime = DateTime.Parse("2022-05-10");
            toDatePicker.MinDate = firsttime;
            fromDatePicker.MinDate = firsttime;


            Init();
            if(waterspider.State == System.Data.ConnectionState.Open)
                connStatusPanel.BackColor = Color.Green;
            else
                connStatusPanel.BackColor = Color.Red;

        }
        void Init()
        {
            string host="", database="", user = "", passwd = "";
            foreach (string line in File.ReadAllLines(DATABASE_FILE))
            {
                try
                {
                    string[] parts = line.Split('=');
                    switch (parts[0])
                    {
                        case "host":
                            host = parts[1];
                            break;
                        case "database":
                            database = parts[1];
                            break;
                        case "user":
                            user = parts[1];
                            break;
                        case "passwd":
                            passwd = parts[1];
                            break;
                        default:
                            MessageBox.Show("Hibás sor: " + line);
                            break;
                    }
                }
                catch {}
            }
            string connectString = $"server={host};database={database};userid={user};password={passwd}";
            waterspider = new MySqlConnection(connectString);
            try { waterspider.Open(); }
            catch { }
        }
        List<WaterspiderRecord> GetData(string from, string to)
        {
            List<WaterspiderRecord> result = new List<WaterspiderRecord>();
            //SELECT * FROM `train_records` WHERE `tol` >= '2022-06-01' AND DATE(`ig`) <= '2022-06-30' ORDER BY `tol`
            string select = $"SELECT * FROM `train_records` WHERE `tol` >= '{from}' AND DATE(`ig`) <= '{to}' ORDER BY `tol`";
            MySqlCommand selectCMD = new MySqlCommand(select, waterspider);
            MySqlDataReader rdr = selectCMD.ExecuteReader();

            while (rdr.Read())
            {
                result.Add(new(rdr.GetString(0),rdr.GetString(1),rdr.GetString(2),rdr.GetString(3),rdr.GetString(4)));
            }
            rdr.Close();
            return result;
        }
        bool GetPath(string defaultName,out string filename)
        {
            SaveFileDialog sfd = new();
            sfd.Title = "Mentés helye";
            sfd.DefaultExt = "csv";
            sfd.Filter = "CSV Fájlok (*.csv)|*.csv|Minden fájl (*.*)|*.*";
            sfd.FileName = defaultName;
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            filename = "";
            if (DialogResult.OK == sfd.ShowDialog())
            {
                filename = Path.GetFullPath(sfd.FileName);
                return true;   
            }
            return false;
        }
        void GetDates(out string from, out string to)
        {
            from = fromDatePicker.Value.ToString("yyyy-MM-dd");
            to = toDatePicker.Value.ToString("yyyy-MM-dd");
        }
        private void downloadBtn_Click(object sender, EventArgs e)
        { 
            string path;
            if(GetPath("nyers_adat.csv", out path))
            {
                string from, to;
                GetDates(out from, out to);
                List<WaterspiderRecord> wsr = GetData(from, to);
                File.WriteAllText(path, "Vonat,Vezeto,Hiba,Tol,Ig\r\n");
                wsr.ForEach(x => File.AppendAllText(path, x.CSV));
                MessageBox.Show("Kész");
            }
        }

        private void timelimitBtn_Click(object sender, EventArgs e)
        {
            string path;
            if (GetPath("napi_adat.csv", out path))
            {
                try
                {
                    string from, to;
                    GetDates(out from, out to);
                    List<WaterspiderRecord> wsr = GetData(from, to);
                    List<Dailydata> ddl = new List<Dailydata>();
                    for (DateTime i = DateTime.Parse(from); i <= DateTime.Parse(to); i = i.AddDays(1))
                    {
                        Dailydata dd = new(i);
                        while (wsr.Count > 0 && wsr[0].Day(i))
                        {
                            if (wsr[0].InTime) dd.inTime++;
                            else dd.overTime++;
                            wsr.RemoveAt(0);
                        }
                        ddl.Add(dd);
                    }
                    File.WriteAllText(path, "Nap,Idoben,Tulment\r\n");
                    ddl.ForEach(x => { if (!(x.inTime == x.overTime && x.overTime == 0)) { File.AppendAllText(path, x.CSV); } });

                    MessageBox.Show("Kész");
                }
                catch(IOException ex) { MessageBox.Show("A fájl nyitva van. Kérlek zárd be."); }
            }
        }
    }
    struct Dailydata{
        public DateTime date;
        public int inTime = 0;
        public int overTime = 0;
        public Dailydata(DateTime date) => this.date = date;
        public string CSV => date + "," + inTime + "," + overTime + "\r\n";
    }
    class WaterspiderRecord
    {
        internal string vonat;
        internal string vezeto;
        internal string hiba;
        internal string start;
        internal string stop;
        public WaterspiderRecord(string vonat,string vezeto, string hiba,string start,string stop)
        {
            this.vonat = vonat;
            this.vezeto = vezeto;
            this.hiba = hiba;
            this.start = start;
            this.stop = stop;
        }
        public string CSV => vonat + "," + vezeto + "," + hiba + "," + start + "," + stop+"\r\n";
        public bool InTime => DateTime.Parse(stop).Subtract(DateTime.Parse(start)).TotalMinutes <= 120;
        public bool Day(DateTime day) => day.Date == DateTime.Parse(start).Date;
    }
}