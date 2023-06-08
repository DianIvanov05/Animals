using Animal11d.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animal11d.Controllers
{
    public partial class AnimalShelter : Form
    {
        AnimalsLogic animalLogic = new AnimalsLogic();  
        public AnimalShelter()
        {
            InitializeComponent();
            textBox1.Visible = false;
            label2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if(string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Show Id");
                textBox1.Focus();
                return;
            }

            else
            {
                findId = int.Parse(textBox1.Text);
            }
            if(string.IsNullOrEmpty(textBox2.Text))
            {
                Animal findedAnimal = animalLogic.Get(findId);
                if(findedAnimal == null)
                {
                    MessageBox.Show("No such thing in database");
                    textBox1.Focus();
                    return;
                }
                LoadRecord(findedAnimal);
            }
            else
            {
                Animal updatedAnimal = new Animal();
                updatedAnimal.Name = textBox2.Text;
                updatedAnimal.Age = textBox4.Text;
            }


        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Animal newAnimal = new Animal
            {
                Name = textBox2.Text,
                Age = int.Parse(textBox3.Text),
                BreedsId = int.Parse(textBox4.Text)
            };
            animalLogic.Create(newAnimal);
        }

        private void AnimalShelter_Load(object sender, EventArgs e)
        {
            List<Animal> allAnimal = animalLogic.GetAll();
            foreach (var item in allAnimal)
            {
                listBox1.Items.Add($"{item.Id}. {item.Name} - {item.Age} ___ {item.BreedsId} ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Не си избрал Id за изтриване!");
                return;
            }

            int id = int.Parse(textBox1.Text);
            animalLogic.Delete(id);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible == false)
            {
                label1.Visible = true;
                textBox1.Visible = true;
            }

            //btnFind_Click(sender, e);
            if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text == "")
            {
                MessageBox.Show("Ne si izbral Id za iztrivane!");
                return;
            }
            label2.Enabled = false;
            textBox2.Enabled = false;
            label3.Enabled = false;
            textBox3.Enabled = false;
            label4.Enabled = false;
            textBox4.Enabled = false;
            Animal newProduct = animalLogic.Get(int.Parse(textBox1.Text));
            textBox1.Text = newProduct.Id.ToString();
            textBox2.Text = newProduct.Name;
            textBox4.Text = newProduct.Age.ToString();
        }
    }
}
