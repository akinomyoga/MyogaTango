using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace 英単語の練習
{
	/// <summary>
	/// frmStart の概要の説明です。
	/// </summary>
	public class frmStart : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button bNew;
		private System.Windows.Forms.Button bOpen;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button bTest;
		private System.Windows.Forms.Button bExit;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		public frmStart()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();
			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
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

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
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
			this.bNew.Text = "新規ファイル(&N)";
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
			this.bOpen.Text = "   既存のファイル(&O)";
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
			this.bExit.Text = "終了(&E/Esc)";
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
			this.label1.Text = "Copyright, 村瀬, 2004-2005";
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
			this.Text = "英単語";
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
			/*入出力の実験
			string filename1="C:\\Documents and Settings\\功一\\My Documents\\英単語\\実験.xml";
			string filename2="C:\\Documents and Settings\\功一\\My Documents\\英単語\\実験.w.mwq";
			英単語の練習.readXml rx=new 英単語の練習.readXml(filename1);
			英単語の練習.writeXml wx=new 英単語の練習.writeXml(filename2);
			英単語の練習.Word data;
			rx.openFile();
			wx.openFile();
			while((data=rx.readWordData()).word!="FileEnd"||data.mean!="FileEnd"){
				wx.writeWordData(data);
			}
			rx.closeFile();
			wx.closeFile();
			MessageBox.Show("Test was completed now.The file '"+filename2+"' was saved.");//for debug
			//*/
			
			/*//PropertyGrid実験
			英単語の練習.Word testWord=new Word("hello","default","今日は","","","0","0");
			英単語の練習.frmWordEdit testForm=new frmWordEdit(ref testWord);
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
