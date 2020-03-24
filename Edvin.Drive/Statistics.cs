using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Edvin.Drive
{
    public partial class Statistics : Form
    {
        public OleDbConnection myConnection;
        public Statistics()
        {
            InitializeComponent();
        }
    }
}
