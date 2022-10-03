//The purpose of this application is to calculate if students are high, moderate or low risk depending on 
//different variables such as GPA and meeeting with an advisor. 

using System.Windows.Forms.VisualStyles;

namespace Student_Success_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static int techId = 15273244;
        static int generateId()
        {
            return techId++;
        }

        private void btn_add_student_Click(object sender, EventArgs e)
        {
            // When this button is clicked, the student name, major, school year, GPA, advisor
            // assignment information, appointment date will be displayed on the listview.
            string assgined_ad = "No";
            if (checkBox_advisor.Checked) assgined_ad = "Yes";

            string[] row = { (techId ++).ToString(), textBox_name.Text, comboBox_major.Text, comboBox_year.Text,
                textBox_GPA.Text, assgined_ad, dateTimePicker_appt.Value.ToShortDateString()};
            ListViewItem listViewItem = new ListViewItem(row);
            listView_students.Items.Add(listViewItem);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            // When this button is clicked, the information will be erased.
            textBox_name.Text = "";
            comboBox_major.Text = "";
            comboBox_year.Text = "";
            textBox_GPA.Text = "";
            dateTimePicker_appt.Value = DateTime.Today;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //When this button is clicked, it will find on the listview the data entered by the user.
            string search_term = textBox_search.Text;
            ListViewItem matched_item = listView_students.FindItemWithText(search_term);

            if (matched_item != null && search_term != "")
                MessageBox.Show("Student ID: " + matched_item.SubItems[0].Text + "\nName: " +
                    matched_item.SubItems[1].Text + "\nMajor: " +
                    matched_item.SubItems[2].Text + "\nYear: " + matched_item.SubItems[3].Text
                    + "\nGPA: " + matched_item.SubItems[4].Text + "\nAdvisor? " +
                    matched_item.SubItems[5].Text + "\nAppointment: " + matched_item.SubItems[6].Text);
            else
                MessageBox.Show("Search not found!");
        }

        private void btn_high_GPA_Click(object sender, EventArgs e)
        {
            // When this button is clicked, it will find and show the record with the highest GPA.
            if (listView_students.Items.Count != 0)
            {
                decimal highest_GPA = 0;
                ListViewItem highest_GPA_item = new ListViewItem();
                foreach (ListViewItem item in listView_students.Items)
                {
                    decimal GPA = Convert.ToDecimal(item.SubItems[4].Text);
                    if (GPA > highest_GPA)
                    {
                        highest_GPA = GPA;
                        highest_GPA_item = item;
                    }
                }

                MessageBox.Show("Student ID " + highest_GPA_item.SubItems[0].Text + "\nName: " +
                        highest_GPA_item.SubItems[1].Text + "\nMajor: " +
                        highest_GPA_item.SubItems[2].Text + "\nYear: " +
                        highest_GPA_item.SubItems[3].Text + "\nGPA: " +
                        highest_GPA_item.SubItems[4].Text + "\nAdvisor: " +
                        highest_GPA_item.SubItems[5].Text + "\nAppointment: " +
                        highest_GPA_item.SubItems[6].Text);
            }
        }

        private void btn_low_GPA_Click(object sender, EventArgs e)
        {
            // When this button is clicked, it will find and show the record with the lowest GPA.
            if (listView_students.Items.Count != 0)
            {
                decimal lowest_GPA = 4;
                ListViewItem lowest_GPA_item = new ListViewItem();
                foreach (ListViewItem item in listView_students.Items)
                {
                    decimal GPA = Convert.ToDecimal(item.SubItems[4].Text);
                    if (GPA < lowest_GPA)
                    {
                        lowest_GPA = GPA;
                        lowest_GPA_item = item;
                    }
                }

                MessageBox.Show("Student ID " + lowest_GPA_item.SubItems[0].Text + "\nName: " +
                        lowest_GPA_item.SubItems[1].Text + "\nMajor: " +
                        lowest_GPA_item.SubItems[2].Text + "\nYear: " +
                        lowest_GPA_item.SubItems[3].Text + "\nGPA: " +
                        lowest_GPA_item.SubItems[4].Text + "\nAdvisor: " +
                        lowest_GPA_item.SubItems[5].Text + "\nAppointment: " +
                        lowest_GPA_item.SubItems[6].Text); ;
            }
        }

        private void btn_remove_record_Click(object sender, EventArgs e)
        {
            // When this button is clicked, it will remove all the selected information.
            if (listView_students.SelectedItems.Count > 0)
            {
                listView_students.Items.Remove(listView_students.SelectedItems[0]);
            }
        }

        private void btn_remove_all_Click(object sender, EventArgs e)
        {
            // When this button is clicked, it will remove all the information without any selection.
            listView_students.Items.Clear();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            // When this button is clicked, it will edit the selected information.
            if (listView_students.SelectedItems.Count > 0)
            {
                ListViewItem selected_item = listView_students.SelectedItems[0];
                textBox_name.Text = selected_item.SubItems[1].Text;
                comboBox_major.Text = selected_item.SubItems[2].Text;
                comboBox_year.Text = selected_item.SubItems[3].Text;
                textBox_GPA.Text = selected_item.SubItems[4].Text;
                listView_students.Items.Remove(selected_item);
            }
        }
    }
}