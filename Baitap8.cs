// bài tập tuần 8

using Baitap8.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private SchoolContext context = new SchoolContext();
        private BindingSource bindingSource = new BindingSource();
        private int currentIndex = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = context.Students.ToList();
            dataGridView1.DataSource = bindingSource;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var student = new Student
            {
                FullName = string.IsNullOrWhiteSpace(textBox1.Text) ? null : textBox1.Text,
                Age = string.IsNullOrWhiteSpace(textBox2.Text) ? (int?)null : int.Parse(textBox2.Text),
                Major = string.IsNullOrWhiteSpace(comboBox1.Text) ? null : comboBox1.Text
            };
            context.Students.Add(student);
            context.SaveChanges();

            bindingSource.DataSource = context.Students.ToList();
            MessageBox.Show("thêm thành công");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Student student)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                bindingSource.DataSource = context.Students.ToList();
            }
            MessageBox.Show("Đã Xóa","Xóa");    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Student student)
            {
                student.FullName = textBox1.Text;
                student.Age = int.Parse(textBox2.Text);
                student.Major = comboBox1.Text;
                context.SaveChanges();

                bindingSource.DataSource = context.Students.ToList();
            }
            MessageBox.Show("Đã Sửa","Sửa");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current is Student student)
            {
                textBox1.Text = student.FullName;
                textBox2.Text = student.Age.ToString();
                comboBox1.Text = student.Major;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentIndex < bindingSource.Count - 1)
            {
                currentIndex++;
                bindingSource.Position = currentIndex;
            }
        }
        private void button5_Click(object sender, EventArgs e) 
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                bindingSource.Position = currentIndex;
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }
    }
}

