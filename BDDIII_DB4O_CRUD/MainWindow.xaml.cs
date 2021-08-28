using System;
using System.Collections.Generic;
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
using Model;
using Implementation;

namespace BDDIII_DB4O_CRUD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person p;
        Transact t;
        PersonImpl implPerson;
        TransactImpl implTransact;
        List<Person> members;
        public MainWindow()
        {
            InitializeComponent();
        }
        #region Methods
        /// <summary>
        /// Opcion 0 mostramos Persona
        /// Opcion 1 mostramos Transact
        /// </summary>
        /// <param name="option"></param>
        void LoadListBox(byte option)
        {
            try
            {
                lbxData.Items.Clear();
                switch (option)
                {
                    case 0:
                        List<Person> pers = new List<Person>();
                        implPerson = new PersonImpl();
                        pers = implPerson.Select();

                        foreach (Person item in pers)
                        {
                            lbxData.Items.Add(item.GetInfo());
                        }                    
                        break;
                    case 1:
                        List<Transact> transact = new List<Transact>();
                        implTransact = new TransactImpl();
                        transact = implTransact.Select();
                        foreach (Transact item in transact)
                        {
                            lbxData.Items.Add(item.GetData());
                        }
                        break;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        #endregion

        private void btnInsertPerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                implPerson = new PersonImpl();
                p = implPerson.SelectByCi(txtCi.Text);
                if (p!=null)
                {
                    MessageBox.Show("La persona ya existe");
                }
                else
                {
                    p = new Person(txtCi.Text, txtName.Text, txtLastName.Text, txtSecondLastName.Text, char.Parse(cbxGender.Text), dpBirthDate.SelectedDate.Value);
                    implPerson = new PersonImpl();
                    implPerson.Insert(p);
                    LoadListBox(0);
                    MessageBox.Show("Objeto insertado con exito");
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadListBox(1);
        }

        private void btnFindPersonCi_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                implPerson = new PersonImpl();
                p = implPerson.SelectByCi(txtCi.Text);
                if (p!=null)
                {
                    MessageBox.Show("La persona existe en la base de datos");
                }
                else
                {
                    MessageBox.Show("La persona no existe en la base de datos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                implPerson = new PersonImpl();
                p = implPerson.SelectByCi(txtCi.Text);
                if (p != null)
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar a la persona?","Eliminar",MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        implPerson.Delete(p);
                        MessageBox.Show("Persona eliminada");
                    }
                    LoadListBox(0);
                }
                else
                {
                    MessageBox.Show("La persona no existe en la base de datos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdatePerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                implPerson = new PersonImpl();
                p = implPerson.SelectByCi(txtCi.Text);
                if (p != null)
                {
                    Person r = new Person(txtCi.Text, txtName.Text, txtLastName.Text, txtSecondLastName.Text, char.Parse(cbxGender.Text), dpBirthDate.SelectedDate.Value);
                    implPerson.Update(p, r);
                    MessageBox.Show("Persona modificada exitosamente");
                    LoadListBox(0);
                }
                else
                {
                    MessageBox.Show("La persona no existe en la base de datos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegisterTransact_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                
                p = new Person(txtCi.Text, txtName.Text, txtLastName.Text, txtSecondLastName.Text, char.Parse(cbxGender.Text), dpBirthDate.SelectedDate.Value);
                t = new Transact(txtCode.Text, p, DateTime.Now, txtDescription.Text);

                implTransact = new TransactImpl();
                implTransact.Insert(t);
                LoadListBox(1);
                MessageBox.Show("Objeto insertado con exito");

                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegisterBranch_Click(object sender, RoutedEventArgs e)
        {
            members = new List<Person>();
            members.Add(new Person(txtCi.Text, txtName.Text, txtLastName.Text, txtSecondLastName.Text, char.Parse(cbxGender.Text), dpBirthDate.SelectedDate.Value));
            foreach (var item in members)
            {
                lbxBranch.Items.Add(item);
            }
            //AEA

            //p = new Person(txtCi.Text, txtName.Text, txtLastName.Text, txtSecondLastName.Text, char.Parse(cbxGender.Text), dpBirthDate.SelectedDate.Value);
        }

        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
