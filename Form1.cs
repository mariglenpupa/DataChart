using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map.Charts.Matrix.Iguess
{
    public partial class Form1 : Form
    {
        // We used a panel to dock the button to the bottom right corner.
        public Form1()
        {
            InitializeComponent();
            AddCountries();
            Work();
        }
        string[] all =  // We are creating an array because it's easier to add a country this way, instead of doing countries.Add("country", 0);
        {
            "ALB",
            "GR",
            "USA",
            "UK",
            "Ger",
            "FR"
        };
        private void button1_Click(object sender, EventArgs e)
        {
            Work();
        }

        Random random = new Random();
        List<Client> clients = new List<Client>();
        List<Country> countries = new List<Country>();
        void AddCountries()
        {
            // Get all countries from the array and add them to the list.
            foreach (string i in all)
                countries.Add(new Country() { name = i, count = 0 });
        }
        void Work()
        {
            // Create Random Clients
            for (int i = 0; i < 10; i++)
            {
                Client cl = new Client();
                int a = random.Next(0, all.Length);
                countries[a].count++;
                cl.country = all[a];
                clients.Add(cl);
            }
            // Add data to the chart
            foreach (Country c in countries)
            {
                // Check if the country has users, if not do not add it to the chart.
                if(c.count > 0) chart1.Series["FG"].Points.AddXY(c.name, c.count);
            }
        }

        // Click the chart to hide/show the legend
        bool enabled = true;
        private void chart1_Click(object sender, EventArgs e)
        {
            chart1.Legends[0].Enabled = enabled;
            enabled = !enabled;
        }
    }
    class Client
    {
        public string country { get; set; }
    }
    class Country
    {
        public string name { get; set; }
        public int count { get; set; }
    }
}
