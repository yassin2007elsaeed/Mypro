using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Rawan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        COMPANYEntities db=new COMPANYEntities();
        public MainWindow()
        {
            InitializeComponent();
            Datagrid.ItemsSource=db.EMPLOYEEEs.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            EMPLOYEEE rec = new EMPLOYEEE();

            rec.ENAME = Name1.Text;
            rec.EPOSITION = State1.Text;
            db.EMPLOYEEEs.Add(rec);
            db.SaveChanges();
            MessageBox.Show("Id Saved succesfuly");
        }

        private void Udate_Click(object sender, RoutedEventArgs e)
        {
            EMPLOYEEE rec = new EMPLOYEEE();

            int record=int.Parse(Id1.Text);
            rec= db.EMPLOYEEEs.First(x => x.EID == record);
            rec.ENAME = Name1.Text;
            rec.EPOSITION = State1.Text;
            db.EMPLOYEEEs.AddOrUpdate(rec);
            db.SaveChanges();
            MessageBox.Show("Updated");
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            int idFromText = int.Parse(Id1.Text);
            EMPLOYEEE rec = db.EMPLOYEEEs.Remove(db.EMPLOYEEEs.First(x => x.EID == idFromText));
            MessageBox.Show("Record deleted");
            db.SaveChanges();
        }

        private void Ref_Click(object sender, RoutedEventArgs e)
        {
            Datagrid.ItemsSource = db.EMPLOYEEEs.ToList();

        }

        private void ser_Click(object sender, RoutedEventArgs e)
        {
            EMPLOYEEE rec= new EMPLOYEEE();
            int record = int.Parse(Id1.Text);
            rec=db.EMPLOYEEEs.First( x => x.EID == record);
            Datagrid.ItemsSource=new List<EMPLOYEEE> { rec };
            db.SaveChanges();

        }
    }
}
