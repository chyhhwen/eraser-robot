using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace WindowsFormsApp15
{
	public partial class Form1 : Form
	{
		//初始值
		int a=0,x1,y1,d=1,f;
		string x, y;
		int [,] b = new int[2, 2];
		int[] c = new int[4];
		public Form1()
		{
			InitializeComponent();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			//回家時的運算
			if (f == 0)
			{
				for (int i = c[1]; i <= c[3]; i += 10)
				{
					pictureBox3.Location = new Point(c[0], i);
					Thread.Sleep(100);
					pictureBox3.Visible = true;
					pictureBox3.BackColor = Color.Yellow;
				}
			}
			else
			{
				for (int i = c[1]; i <= c[3]; i += 10)
				{
					pictureBox3.Location = new Point(c[2], i);
					Thread.Sleep(100);
					pictureBox3.Visible = true; 
					pictureBox3.BackColor = Color.Yellow;
				}
			}
			///////////////////////////////////////////////////////////////////////////
			if (f==0)
			{
				for(int i=c[0];i<=685;i+=10)
				{
					pictureBox3.Location = new Point(i,c[3]);
					Thread.Sleep(100);
					pictureBox3.Visible = true;
					pictureBox3.BackColor = Color.Yellow;
				}
			}
			else
			{
				for (int i = c[2]; i <= 685; i += 10)
				{
					pictureBox3.Location = new Point(i, c[3]);
					Thread.Sleep(100);
					pictureBox3.Visible = true;
					pictureBox3.BackColor = Color.Yellow;
				}
			}
			for (int i = c[3]; i <= 280; i += 10)
			{
				pictureBox3.Location = new Point(685,i);
				Thread.Sleep(100);
				pictureBox3.Visible = true;
				pictureBox3.BackColor = Color.Yellow;
			}
			///////////////////////////////////////////////////////////////////////////
			timer1.Enabled = false;//關閉timer
			button4.Enabled = false;//關閉button
			MessageBox.Show("執行完成", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);//顯示完成
			System.Windows.Forms.Application.Exit();//退出form
		}
		public static DialogResult InputBox(string title, string promptText, ref string value)
		{
			Form form = new Form();
			Label label = new Label();
			TextBox textBox = new TextBox();
			Button buttonOk = new Button();
			Button buttonCancel = new Button();
			///////////////////////////////////////////////////////////////////////////
			form.Text = title;
			label.Text = promptText;
			textBox.Text = value;
			///////////////////////////////////////////////////////////////////////////
			buttonOk.Text = "OK";
			buttonCancel.Text = "Cancel";
			buttonOk.DialogResult = DialogResult.OK;
			buttonCancel.DialogResult = DialogResult.Cancel;
			///////////////////////////////////////////////////////////////////////////
			label.SetBounds(9, 20, 372, 13);
			textBox.SetBounds(12, 36, 372, 20);
			buttonOk.SetBounds(228, 72, 75, 23);
			buttonCancel.SetBounds(309, 72, 75, 23);
			///////////////////////////////////////////////////////////////////////////
			label.AutoSize = true;
			textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
			buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			///////////////////////////////////////////////////////////////////////////
			form.ClientSize = new Size(396, 107);
			form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
			form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.StartPosition = FormStartPosition.CenterScreen;
			form.MinimizeBox = false;
			form.MaximizeBox = false;
			form.AcceptButton = buttonOk;
			form.CancelButton = buttonCancel;
			///////////////////////////////////////////////////////////////////////////
			DialogResult dialogResult = form.ShowDialog();
			value = textBox.Text;
			return dialogResult;
		}
		private void button5_Click(object sender, EventArgs e)
		{
			string value1="";
			if(InputBox("輸入X", "輸入黑板的寬:", ref value1) == DialogResult.OK);
			x1 = Convert.ToInt32(value1);
			///////////////////////////////////////////////////////////////////////////
			string value2 = "";
			if (InputBox("輸入Y", "輸入黑板的長:", ref value2) == DialogResult.OK);
			y1 = Convert.ToInt32(value2);
			///////////////////////////////////////////////////////////////////////////
			MessageBox.Show("輸入完成");
			button5.Enabled = false;//關閉button
		}
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			//畫方塊
			a = a + 1;
			
			if(a==1)
			{
				x = Convert.ToString(System.Windows.Forms.Cursor.Position.X);
				y = Convert.ToString(System.Windows.Forms.Cursor.Position.Y);
				b[0, 0] = Convert.ToInt32(x)-404;
				b[0, 1] = Convert.ToInt32(y)-224;
			}
			else
			{
				a = 0;
				x = Convert.ToString(System.Windows.Forms.Cursor.Position.X);
				y = Convert.ToString(System.Windows.Forms.Cursor.Position.Y);
				b[1, 0] = Convert.ToInt32(x)-404;
				b[1, 1] = Convert.ToInt32(y)-224;
				int d = 0;
				Graphics g = this.pictureBox1.CreateGraphics();
				for (int i = 0; i < 2; i++)
				{
					for (int j = 0; j < 2; j++)
					{
						c[d] = b[i, j];
						d += 1;
					}
				}
				Pen pen = new Pen(Brushes.Red);
				Point[] p = new Point[4];
				p[0] = new Point(c[0] , c[1]);
				p[1] = new Point(c[2] , c[1]);
				p[2] = new Point(c[2] , c[3]);
				p[3] = new Point(c[0] , c[3]);
				g.DrawLine(pen, p[0], p[1]);
				g.DrawLine(pen, p[1], p[2]);
				g.DrawLine(pen, p[2], p[3]);
				g.DrawLine(pen, p[3], p[0]);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			UP();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			LEFT();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			RIGHT();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			pictureBox1.Image = Image.FromFile("C:\\xampp\\htdocs\\aa\\image.jpg");//插入圖片
			/////////////////////////////////////////////////////////////////////////
			//serialPort1.PortName = "COM14";//設置端子
			//serialPort1.BaudRate = 9600;//設置鮑率
			//serialPort1.Open();//開啟端子
			//if (!serialPort1.IsOpen) return;//直到連上
			//button3.Enabled = false;//關閉button
			///////////////////////////////////////////////////////////////////////////
			//button3.Enabled = false;
			MessageBox.Show("連結完成", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);//顯示完成
		}
		private void UP()
		{
			serialPort1.Write("u");
		}
		private void LEFT ()
		{
			serialPort1.Write("r");
		}
		private void RIGHT ()
		{
			serialPort1.Write("l");
		}
		private void button4_Click(object sender, EventArgs e)
		{
			//運算部分
			///////////////////////////////////////////////////////////////////////////
			button4.Enabled = false;//關閉button
			x1 = 685;//設置x軸
			y1 = 280;//設置y軸
			pictureBox2.Location = new Point(685, 280);//設置長寬
			Thread.Sleep(100);//等待
			//開始計算
			///////////////////////////////////////////////////////////////////////////
			int z=0;
			for (int i = y1; i >= c[3] -10 ; i -= 5) //直走
			{
				
				z += 1;
				if(z%3==0)
				{
					UP();
				}
				Thread.Sleep(50);
				pictureBox2.Location = new Point(x1, i);
				pictureBox2.Visible = true;
				y1 = i;
			}
			pictureBox2.Height = 50;
			pictureBox2.Width = 50;
			Thread.Sleep(50);
			///////////////////////////////////////////////////////////////////////////
			RIGHT();
			z = 0;
			for (int i = x1; i >= c[2]-5;i -- ) //走到 c[2] c[3]
			{
				z += 1;
				if(z%3==0)
				{
					UP();
				}
				Thread.Sleep(10);
				pictureBox2.Location = new Point(i, y1);
				pictureBox2.Visible = true;
			}
			///////////////////////////////////////////////////////////////////////////
			z = 0;
			for (int j = c[3]; j >= c[1] - 10; j -= 10)
			{
				d += 1;
				if (d % 2 == 0)
				{
					for (int i = c[2] - 10; i >= c[0] - 10; i--)
					{
						z += 1;
						if (z % 3 == 0)
						{
							UP();
						}
						pictureBox2.Location = new Point(i, j);
						pictureBox2.Visible = true;
						x1 = i;
						Thread.Sleep(1);
					}
					//RIGHT();
					//180
					f = 0;
				}
				else
				{
					for (int i = c[0] - 10; i <= c[2] - 10; i++)
					{
						z += 1;
						if (z % 3 == 0)
						{
							UP();
						}
						pictureBox2.Location = new Point(i, j);
						pictureBox2.Visible = true;
						x1 = i;
						Thread.Sleep(1);
					}
					//LEFT();
					//180
					f = 1;
				}
			}
			///////////////////////////////////////////////////////////////////////////
			pictureBox2.Visible = false;//關閉picturebox
			pictureBox3.Visible = true;//開啟picturebox
			timer1.Enabled = true;//開啟timer
		}
	}
}
