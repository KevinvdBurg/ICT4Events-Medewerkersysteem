﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;

namespace MedewerkerSysteem
{
    public partial class MederwerkerCreateAccount : Form
    {
        private RFID rfid; //Declare an RFID object
        private Administation administration = new Administation();
        List<Event> events = new List<Event>();

        
        public MederwerkerCreateAccount()
        {
            InitializeComponent();

            events = administration.FindEventAll();
            cbCAaddevent.DataSource = events;
            cbCAaddevent.DisplayMember = "Name";
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCAcancel_Click(object sender, EventArgs e)
        {
            new MederwerkerForm(administration).Show();
            Close();
        }


        
        private void btnCAcreate_Click(object sender, EventArgs e)
        {
            //tijdelijke int ipv RFID
            string test = "test";
            //Adres wordt aangemaakt
            Address address = new Address(tbCAcity.Text, tbCAcountry.Text, tbCAstreetname.Text, tbCAzipcode.Text);
            //Persoon wordt aangemaakt
            Person person = new Person(address, tbCAemail.Text, tbCAname.Text, tbCAlastname.Text);
            //Account wordt aangemaakt
            Account account = new Account(person, "bezoeker", test);

            //test int
            int i = 1;
            foreach (Event item in lbCAeventlist.Items)
            {
                AccountEvent accountEvent = new AccountEvent(false, account.RFID, item.EventID);
            }

            //Account wordt opgeslagen in de database door administration.Add()
            administration.Add(account);
            //address wordt opgeslagen in de database door person.AddAddress()
            person.AddAddress(address);
            new MederwerkerForm(administration).Show();

        }

        private void btnCAaddevent_Click(object sender, EventArgs e)
        {
            //Geselecteerde event wordt toegevoegd aan de listbox
            if (cbCAaddevent.SelectedText != null || cbCAaddevent.SelectedText !="")
            {
                lbCAeventlist.Items.Add(cbCAaddevent.SelectedItem);
            }
            else
            {
                MessageBox.Show("Geen Event aangeklikt");
            }
            lbCAeventlist.DisplayMember = "Name";
        }

        private void MederwerkerCreateAccount_Load(object sender, EventArgs e)
        {
            rfid = new RFID();

            rfid.Attach += new AttachEventHandler(rfid_Attach);
            rfid.Detach += new DetachEventHandler(rfid_Detach);
            rfid.Error += new ErrorEventHandler(rfid_Error);

            rfid.Tag += new TagEventHandler(rfid_Tag);
            rfid.TagLost += new TagEventHandler(rfid_TagLost);


            //Disabled controls until Phidget is attached
            openCmdLine(rfid);
        }

        //attach event handler...display the serial number of the attached RFID phidget
        void rfid_Attach(object sender, AttachEventArgs e)
        {
            RFID attached = (RFID)sender;

            switch (attached.ID)
            {
                case Phidget.PhidgetID.RFID_2OUTPUT_READ_WRITE:
                    break;
                case Phidget.PhidgetID.RFID:
                case Phidget.PhidgetID.RFID_2OUTPUT:
                default:
                    break;
            }

            if (rfid.outputs.Count > 0)
            {
                rfid.Antenna = true;
            }
        }

        //detach event handler...clear all the fields, display the attached status, and disable the checkboxes.
        void rfid_Detach(object sender, DetachEventArgs e)
        {
            RFID detached = (RFID)sender;

            //this.Bounds = new Rectangle(this.Location, new Size(298, 433));
        }

        void rfid_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("Error: " + e);

        }

        //Tag event handler...we'll display the tag code in the field on the GUI
        void rfid_Tag(object sender, TagEventArgs e)
        {
            tbCARFID.Text = e.Tag;
        }

        //Tag lost event handler...here we simply want to clear our tag field in the GUI
        void rfid_TagLost(object sender, TagEventArgs e)
        {
            //tbLetterRFID.Text = "";
            Console.WriteLine("Lost");
            Console.WriteLine(e.ToString());
        }

        #region Command line open functions
        private void openCmdLine(Phidget p)
        {
            openCmdLine(p, null);
        }

        private void openCmdLine(Phidget p, String pass)
        {
            int serial = -1;
            String logFile = null;
            int port = 5001;
            String host = null;
            bool remote = false, remoteIP = false;
            string[] args = Environment.GetCommandLineArgs();
            String appName = args[0];

            try
            { //Parse the flags
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i].StartsWith("-"))
                        switch (args[i].Remove(0, 1).ToLower())
                        {
                            case "l":
                                logFile = (args[++i]);
                                break;
                            case "n":
                                serial = int.Parse(args[++i]);
                                break;
                            case "r":
                                remote = true;
                                break;
                            case "s":
                                remote = true;
                                host = args[++i];
                                break;
                            case "p":
                                pass = args[++i];
                                break;
                            case "i":
                                remoteIP = true;
                                host = args[++i];
                                if (host.Contains(":"))
                                {
                                    port = int.Parse(host.Split(':')[1]);
                                    host = host.Split(':')[0];
                                }
                                break;
                            default:
                                goto usage;
                        }
                    else
                        goto usage;
                }
                if (logFile != null)
                    Phidget.enableLogging(Phidget.LogLevel.PHIDGET_LOG_INFO, logFile);
                if (remoteIP)
                    p.open(serial, host, port, pass);
                else if (remote)
                    p.open(serial, host, pass);
                else
                    p.open(serial);
                return; //success
            }
            catch { }
        usage:
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Invalid Command line arguments." + Environment.NewLine);
            sb.AppendLine("Usage: " + appName + " [Flags...]");
            sb.AppendLine("Flags:\t-n   serialNumber\tSerial Number, omit for any serial");
            sb.AppendLine("\t-l   logFile\tEnable phidget21 logging to logFile.");
            sb.AppendLine("\t-r\t\tOpen remotely");
            sb.AppendLine("\t-s   serverID\tServer ID, omit for any server");
            sb.AppendLine("\t-i   ipAddress:port\tIp Address and Port. Port is optional, defaults to 5001");
            sb.AppendLine("\t-p   password\tPassword, omit for no password" + Environment.NewLine);
            sb.AppendLine("Examples: ");
            sb.AppendLine(appName + " -n 50098");
            sb.AppendLine(appName + " -r");
            sb.AppendLine(appName + " -s myphidgetserver");
            sb.AppendLine(appName + " -n 45670 -i 127.0.0.1:5001 -p paswrd");
            MessageBox.Show(sb.ToString(), "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Exit();
        }
        #endregion
    }
}
