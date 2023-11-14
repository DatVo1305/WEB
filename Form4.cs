﻿using FontAwesome.Sharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using FontStyle = System.Drawing.FontStyle;

namespace WEB
{
    //public delegate void (object sender, EventArgs e);
    public partial class Form4 : Form
    {
        TabPage tabPage1;
        ChuyenTab chuyen;
        Webcom webcom = new Webcom();
        /*public static ArrayList buttons = new ArrayList();
        public static ArrayList buttons1 = new ArrayList();*/
        public ArrayList Weblist = new ArrayList();
        public Taotab Sender;
        public Form4(Taotab receiver, TabPage tabPage, ChuyenTab chuyen)
        {
            InitializeComponent();
            Sender = receiver;
            tabPage1 = tabPage;
            this.chuyen = chuyen;
        }
        /// <summary>
        /// Click chuot trai thi truy cap, chuot phai thi hien menustrip voi 2 option la truy cap va xoa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Label_Click(object sender, MouseEventArgs e)
        {
       
           if (sender is Label Clicked_Label)
            {
                int labelindex = (int)Clicked_Label.Tag;
                string labelname = Clicked_Label.Text;
                int index = ((Webcom)Weblist[labelindex]).Count;
                Webcom temp = ((Webcom)Weblist[labelindex]);
                if (e.Button == MouseButtons.Left)
                {
                    
                     //HisoryList.historyControl.Noibot(ref temp);
                     HisoryList.historyControl.TachHistory(ref temp);
                     temp.DateTime = DateTime.Now;
                     Sender(ref temp);      
                     chuyen(tabPage1);
                }
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenu contextMenu = new ContextMenu();
                    System.Drawing.Point point = new System.Drawing.Point(e.Location.X, e.Location.Y);
                    contextMenu.MenuItems.Add("Access");
                    contextMenu.MenuItems.Add("Delete");
                    contextMenu.Show(Clicked_Label, point);
                    

                  
                }
            }

        }
        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = "History list";
            int height = 70;
            int count = 0;
            //List<Label> list = new List<Label>();
            for (var i = HisoryList.historyControl.Head; i != null; i = i.NextforHistory1)
            {
                webcom = (Webcom)i;
                Label label = new Label
                {
                    Tag = count
                };
                Weblist.Add(i);
                label.Text = i.Title + " ---- Page: " + i.Count.ToString() + "\nAcess Time: " + i.DateTime.ToString() +"\n---------------------------------------";
                //label1.Text = i.Count.ToString();
                label.AutoSize = true;
                label.Location = new System.Drawing.Point(0, height);
                label.Visible = true;
           
                label.Font = new Font("Calibri", 12, FontStyle.Regular);
                this.Controls.Add(label);
                this.Controls.Add(label1);
                height += 70;
                label.MouseUp += Label_Click;
                count++;
            }

        }
    }
}
