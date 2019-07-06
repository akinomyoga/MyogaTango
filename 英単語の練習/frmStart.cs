using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace �p�P��̗��K
{
	/// <summary>
	/// frmStart �̊T�v�̐����ł��B
	/// </summary>
	public class frmStart : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button bNew;
		private System.Windows.Forms.Button bOpen;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button bTest;
		private System.Windows.Forms.Button bExit;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		public frmStart()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();
			//
			// TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
			//
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStart));
			this.bNew = new System.Windows.Forms.Button();
			this.bOpen = new System.Windows.Forms.Button();
			this.bTest = new System.Windows.Forms.Button();
			this.bExit = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// bNew
			// 
			this.bNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bNew.Image = ((System.Drawing.Image)(resources.GetObject("bNew.Image")));
			this.bNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bNew.Location = new System.Drawing.Point(200, 8);
			this.bNew.Name = "bNew";
			this.bNew.Size = new System.Drawing.Size(128, 24);
			this.bNew.TabIndex = 0;
			this.bNew.Text = "�V�K�t�@�C��(&N)";
			this.bNew.Click += new System.EventHandler(this.bNew_Click);
			// 
			// bOpen
			// 
			this.bOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bOpen.Image = ((System.Drawing.Image)(resources.GetObject("bOpen.Image")));
			this.bOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bOpen.Location = new System.Drawing.Point(200, 40);
			this.bOpen.Name = "bOpen";
			this.bOpen.Size = new System.Drawing.Size(128, 24);
			this.bOpen.TabIndex = 1;
			this.bOpen.Text = "   �����̃t�@�C��(&O)";
			this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
			// 
			// bTest
			// 
			this.bTest.Location = new System.Drawing.Point(336, 8);
			this.bTest.Name = "bTest";
			this.bTest.Size = new System.Drawing.Size(40, 24);
			this.bTest.TabIndex = 2;
			this.bTest.Text = "test!";
			this.bTest.Click += new System.EventHandler(this.bTest_Click);
			// 
			// bExit
			// 
			this.bExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bExit.Image = ((System.Drawing.Image)(resources.GetObject("bExit.Image")));
			this.bExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bExit.Location = new System.Drawing.Point(200, 72);
			this.bExit.Name = "bExit";
			this.bExit.Size = new System.Drawing.Size(128, 24);
			this.bExit.TabIndex = 3;
			this.bExit.Text = "�I��(&E/Esc)";
			this.bExit.Click += new System.EventHandler(this.bExit_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(184, 72);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.SpringGreen;
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(8, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(184, 8);
			this.label1.TabIndex = 5;
			this.label1.Text = "Copyright, ����, 2004-2005";
			// 
			// frmStart
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.CancelButton = this.bExit;
			this.ClientSize = new System.Drawing.Size(378, 103);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.bExit);
			this.Controls.Add(this.bTest);
			this.Controls.Add(this.bOpen);
			this.Controls.Add(this.bNew);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmStart";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "�p�P��";
			this.ResumeLayout(false);

		}
		#endregion


		public string result;
		private void bNew_Click(object sender, System.EventArgs e)
		{
			this.result="bNew";
			this.Close();
		}

		private void bOpen_Click(object sender, System.EventArgs e)
		{
			this.result="bRead";
			this.Close();
		}

		private void bTest_Click(object sender, System.EventArgs e)
		{	
			/*���o�͂̎���
			string filename1="C:\\Documents and Settings\\����\\My Documents\\�p�P��\\����.xml";
			string filename2="C:\\Documents and Settings\\����\\My Documents\\�p�P��\\����.w.mwq";
			�p�P��̗��K.readXml rx=new �p�P��̗��K.readXml(filename1);
			�p�P��̗��K.writeXml wx=new �p�P��̗��K.writeXml(filename2);
			�p�P��̗��K.Word data;
			rx.openFile();
			wx.openFile();
			while((data=rx.readWordData()).word!="FileEnd"||data.mean!="FileEnd"){
				wx.writeWordData(data);
			}
			rx.closeFile();
			wx.closeFile();
			MessageBox.Show("Test was completed now.The file '"+filename2+"' was saved.");//for debug
			//*/
			
			/*//PropertyGrid����
			�p�P��̗��K.Word testWord=new Word("hello","default","������","","","0","0");
			�p�P��̗��K.frmWordEdit testForm=new frmWordEdit(ref testWord);
			testForm.Show();
			*/
			//System.Windows.Forms.Design.IWindowsFormsEditorService edSvc;
			
		}

		private void bExit_Click(object sender, System.EventArgs e)
		{
			this.result="Exit";
			this.Close();
		}
	}
}
