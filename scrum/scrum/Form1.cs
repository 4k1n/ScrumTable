using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scrum
{
    public partial class frmScrum : Form
    {

        public frmScrum()
        {
            InitializeComponent();
            
        }


        List<Story> story = new List<Story>();
        Story story_ = new Story();
        Story story2_ = new Story();
        Story story3_ = new Story();
        private void btnStoryEkle_Click(object sender, EventArgs e)
        {
            if (txtboxstory1.Visible != true)
            {
                story_.storyAdi = txtStoryName.Text;
                story_.storyYazari = txtStoryYazari.Text;
                story_.storyAciklama = txtTaskAciklama.Text;
                story.Add(story_);

                txtboxstory1.Text = Convert.ToString("Story İsmi:" + Environment.NewLine + txtStoryName.Text + Environment.NewLine) + Convert.ToString("Story Yazarı:" + Environment.NewLine + txtStoryYazari.Text + Environment.NewLine) + Convert.ToString("Story Açıklaması:" + Environment.NewLine + txtStoryAciklama.Text + Environment.NewLine);
                txtboxstory1.Visible = true;
                btnstoryclose1.Visible = true;
                cmbStoryAdi.Items.Add(txtStoryName.Text);
            }
            else if (txtboxstory2.Visible != true)
            {
                story2_.storyAdi = txtStoryName.Text;
                story2_.storyYazari = txtStoryYazari.Text;
                story2_.storyAciklama = txtTaskAciklama.Text;
                story.Add(story2_);

                txtboxstory2.Text = Convert.ToString("Story İsmi:" + Environment.NewLine + txtStoryName.Text + Environment.NewLine) + Convert.ToString("Story Yazarı:" + Environment.NewLine + txtStoryYazari.Text + Environment.NewLine) + Convert.ToString("Story Açıklaması:" + Environment.NewLine + txtStoryAciklama.Text + Environment.NewLine);
                
                btnstoryclose2.Visible = true;
                txtboxstory2.Visible = true;
                cmbStoryAdi.Items.Add(txtStoryName.Text);
            }
            else if (txtboxstory3.Visible != true)
            {
                story3_.storyAdi = txtStoryName.Text;
                story3_.storyYazari = txtStoryYazari.Text;
                story3_.storyAciklama = txtTaskAciklama.Text;
                story.Add(story3_);

                txtboxstory3.Text = Convert.ToString("Story İsmi:" + Environment.NewLine + txtStoryName.Text + Environment.NewLine) + Convert.ToString("Story Yazarı:" + Environment.NewLine + txtStoryYazari.Text + Environment.NewLine) + Convert.ToString("Story Açıklaması:" + Environment.NewLine + txtStoryAciklama.Text + Environment.NewLine);
                
                btnstoryclose3.Visible = true;
                txtboxstory3.Visible = true;
                cmbStoryAdi.Items.Add(txtStoryName.Text);
            }
            else if(txtboxstory1.Visible == true && txtboxstory2.Visible == true && txtboxstory3.Visible == true)
            {
                MessageBox.Show("Daha fazla proje eklenemez.");
            }
        }

        List<Task> task = new List<Task>();
        int offsetX = 0;
        int offsetY = 0;

        private void btnTaskEkle_Click(object sender, EventArgs e)
        {
            Task task_ = new Task();
            task_.taskAdi = txtTaskAdi.Text;
            task_.taskYazari = txtTaskYazari.Text;
            task_.taskAciklamasi = txtTaskAciklama.Text;
            task_.storyAdi = cmbStoryAdi.Text;
            task_.bitirmeTarihi = dtpBitirmeTarihi.Value;
            task.Add(task_);

            Button yeniButon = new Button
            {
                Top = 4 + offsetY, //y
                Left = 4 + offsetX, //x
                Width = 52,
                Height = 35,
                BackColor = Color.White,
                Text = txtTaskAdi.Text
            };

            offsetX += 55;

            if (task.Count%3==0)
            {
                offsetX -= 165;
                offsetY += 40;               
            }

            pnlToDo.DragEnter += panel_DragEnter ;
            pnlInProgress.DragEnter += panel_DragEnter;
            pnlDone.DragEnter += panel_DragEnter;

            pnlToDo.DragDrop += panel_DragDrop;
            pnlInProgress.DragDrop += panel_DragDrop;
            pnlDone.DragDrop += panel_DragDrop;

            yeniButon.MouseDown += Dinamicbutton_MouseDown;

            pnlToDo.Controls.Add(yeniButon);
            
        }

        private void panel_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)e.Data.GetData(typeof(Button))).Parent = (Panel)sender;
        }

        private void panel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Dinamicbutton_MouseDown(object sender, MouseEventArgs e)
        {
            Button buton = (sender as Button);
            buton.DoDragDrop(buton, DragDropEffects.Move);
            Button dinamicbutton = (sender as Button);
            int taskKontrol = 0, indis = 0;
            foreach (Task taskAdi in task)
            {
                if (dinamicbutton.Text == taskAdi.taskAdi.ToString())
                {
                    indis = taskKontrol;
                }
                taskKontrol++;
            }
            MessageBox.Show("Story Adı:" + Environment.NewLine + task[indis].storyAdi + Environment.NewLine + "Task Adı:" + Environment.NewLine + task[indis].taskAdi + Environment.NewLine + "Task Yazarı:" + Environment.NewLine + task[indis].taskYazari + Environment.NewLine + "Task Açıklaması:" + Environment.NewLine + task[indis].taskAciklamasi + Environment.NewLine + "Tahmini Bitirme Tarihi" + Environment.NewLine + task[indis].bitirmeTarihi.ToString());

        }


        private void frmScrum_Load(object sender, EventArgs e)
        {
            pnlToDo.AllowDrop = true;
            pnlInProgress.AllowDrop = true;
            pnlDone.AllowDrop = true;
        }



        private void btnstoryclose1_Click(object sender, EventArgs e)
        {
            txtboxstory1.Clear();
            txtboxstory1.Visible = false;
            btnstoryclose1.Visible = false;
            cmbStoryAdi.Items.RemoveAt(0);
        }

        private void btnstoryclose2_Click(object sender, EventArgs e)
        {
            txtboxstory2.Clear();
            txtboxstory2.Visible = false;
            btnstoryclose2.Visible = false;
            cmbStoryAdi.Items.RemoveAt(1);
        }

        private void btnstoryclose3_Click(object sender, EventArgs e)
        {
            txtboxstory3.Clear();
            txtboxstory3.Visible = false;
            btnstoryclose3.Visible = false;
            cmbStoryAdi.Items.RemoveAt(2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnTask1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
