﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Anpherov_IKM_Course_project
{
    public partial class Form1 : Form
    {
        internal MajorWork MajorObject { get; private set; }

        private bool Mode;
        private MajorWork MojorObject;
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;
        public Form1()
        {
            InitializeComponent();
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Поточні дата і час:";
            dateLabel= new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 }; 
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text= DateTime.Now.ToLongTimeString();
        }

        private void tClock_Tick(object sender, EventArgs e)
        {
            tClock.Stop();
            MessageBox.Show("Минуло 25 секунд", "Увага");
            tClock.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MajorObject = new MajorWork();
            MajorObject.SetTime();
            MajorObject.Modify = false;
            About A = new About();
            A.tAbout.Start();
            A.ShowDialog();
            this.Mode = true;

            toolTip1.SetToolTip(bSearch, "Натисніть на кнопку для пошуку");
            toolTip1.IsBalloon = true;


        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (Mode)
            {
                tbInput.Enabled = true;
                tbInput.Focus();
                tClock.Start();
                bStart.Text = "Стоп";
                this.Mode = false;
                пускToolStripMenuItem.Text = "Стоп";
            }
            else
            {
                tbInput.Enabled = false;
                tClock.Stop();
                bStart.Text = "Пуск";
                this.Mode = true;
                MajorObject.Write(tbInput.Text);
                MajorObject.Task();
                label1.Text = MajorObject.Read();
                пускToolStripMenuItem.Text = "Старт";
            }
        }

        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            tClock.Stop();
            tClock.Start();
            if ((e.KeyChar >= '0') & (e.KeyChar <= '9') | (e.KeyChar == (char)8))
            {
                return;
            }
            else
            {
                tClock.Stop();
                MessageBox.Show("Неправильний символ", "Помилка");
                tClock.Start();
                e.KeyChar = (char)0;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string s;
            s = (System.DateTime.Now - MajorObject.GetTime()).ToString();
            MessageBox.Show(s, "Час роботи програми");
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About A = new About();
            A.progressBar1.Hide();
            A.ShowDialog();
        }

        private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdSave.ShowDialog() == DialogResult.OK)
            {
                MajorObject.WriteSaveFileName(sfdSave.FileName);
                MajorObject.Generator();
                MajorObject.SaveToFile();
            }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdOpen.ShowDialog() == DialogResult.OK)
            {
                MajorObject.WriteOpenFileName(ofdOpen.FileName);
                MajorObject.ReadFromFile(dgwOpen);
            }
        }

        private void проНакопичувачіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] Disks = System.IO.Directory.GetLogicalDrives();
            string disk = "";
            for (int i = 0; i < Disks.Length; i++)
            {
                try
                {
                    System.IO.DriveInfo D = new System.IO.DriveInfo(Disks[i]);
                    disk += D.Name + "-" + (D.TotalSize / (1024 * 1024 * 1024)).ToString() + "-" + (D.TotalFreeSpace / (1024 * 1024 * 1024)).ToString() + "GB" + (char)13;
                }
                catch
                {
                    disk += Disks[i] + "- не готовий" + (char)13;
                }
            }
            MessageBox.Show(disk, "Накопичувачі");
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MajorObject.SaveFileNameExists())
                MajorObject.SaveToFile();
            else
                зберегтиЯкToolStripMenuItem_Click(sender, e);
        }

        private void новийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MajorObject.NewRec();
            tbInput.Clear();
            label1.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MajorObject.Modify)
                if (MessageBox.Show("Дані не були збережені. Продовжити вихід?", "УВАГА", MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            MajorObject.Find(tbSearch.Text);
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}