﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeFarm
{
    public partial class ShopScreen : UserControl
    {
        public ShopScreen()
        {
            InitializeComponent();
        }

        private void swordPower1_Click(object sender, EventArgs e)
        {
            FarmScreen.counter = 0;
            Form f = this.FindForm();
            f.Controls.Remove(this);

            FarmScreen fs = new FarmScreen();
            f.Controls.Add(fs);

        }
    }
}
