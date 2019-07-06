using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace �p�P��̗��K
{
	/// <summary>
	/// editWordCtl �̊T�v�̐����ł��B
	/// </summary>
	public class editWordCtl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListBox listPart;
		private System.Windows.Forms.Label labPrt;
		private System.Windows.Forms.Button bPronA;
		private System.Windows.Forms.Button bPron9;
		private System.Windows.Forms.Button bPron8;
		private System.Windows.Forms.Button bPron7;
		private System.Windows.Forms.Button bPron6;
		private System.Windows.Forms.Button bPron5;
		private System.Windows.Forms.Button bPron4;
		private System.Windows.Forms.Button bPron3;
		private System.Windows.Forms.Button bPron2;
		private System.Windows.Forms.Button bPron1;
		private System.Windows.Forms.Label labPron;
		private System.Windows.Forms.TextBox txtPron;
		private System.Windows.Forms.Label labMean;
		private System.Windows.Forms.TextBox txtMean;
		private System.Windows.Forms.Label labWord;
		private System.Windows.Forms.TextBox txtWord;
		private System.Windows.Forms.Label labPart;
		private System.Windows.Forms.Button bPronB;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;


		//=====================================
		//          constructors
		//-------------------------------------
		public editWordCtl()
		{
			// ���̌Ăяo���́AWindows.Forms �t�H�[�� �f�U�C�i�ŕK�v�ł��B
			InitializeComponent();

			// TODO: InitializeComponent �Ăяo���̌�ɏ�����������ǉ����܂��B
			this.Word="";
			this.Pronounce="";
			this.Mean="";
			//this.Part=�p�P��̗��K.Word.WordPart.Noun;
		}
		
		public editWordCtl(�p�P��̗��K.Word word){
			InitializeComponent();
			this.Word=word.word;
			this.Pronounce=word.pron;
			this.Mean=word.mean;
			this.Part=word.Part;

		}
		public editWordCtl(string word,string prn,string mean,string prt){
			InitializeComponent();
			this.Word=word;
			this.Pronounce=prn;
			this.Mean=mean;
			this.Part=(�p�P��̗��K.wordPart)prt;
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

		#region �R���|�[�l���g �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			this.listPart = new System.Windows.Forms.ListBox();
			this.labPrt = new System.Windows.Forms.Label();
			this.bPronA = new System.Windows.Forms.Button();
			this.bPron9 = new System.Windows.Forms.Button();
			this.bPron8 = new System.Windows.Forms.Button();
			this.bPron7 = new System.Windows.Forms.Button();
			this.bPron6 = new System.Windows.Forms.Button();
			this.bPron5 = new System.Windows.Forms.Button();
			this.bPron4 = new System.Windows.Forms.Button();
			this.bPron3 = new System.Windows.Forms.Button();
			this.bPron2 = new System.Windows.Forms.Button();
			this.bPron1 = new System.Windows.Forms.Button();
			this.labPron = new System.Windows.Forms.Label();
			this.txtPron = new System.Windows.Forms.TextBox();
			this.labMean = new System.Windows.Forms.Label();
			this.txtMean = new System.Windows.Forms.TextBox();
			this.labWord = new System.Windows.Forms.Label();
			this.txtWord = new System.Windows.Forms.TextBox();
			this.labPart = new System.Windows.Forms.Label();
			this.bPronB = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listPart
			// 
			this.listPart.ItemHeight = 12;
			this.listPart.Items.AddRange(new object[] {
														  "����",
														  "�`�e��",
														  "����",
														  "����",
														  "�㖼��",
														  "�O�u��",
														  "�ڑ���",
														  "������",
														  "�ԓ���",
														  "�\��"});
			this.listPart.Location = new System.Drawing.Point(144, 136);
			this.listPart.Name = "listPart";
			this.listPart.Size = new System.Drawing.Size(112, 64);
			this.listPart.TabIndex = 35;
			this.listPart.SelectedIndexChanged += new System.EventHandler(this.listPart_SelectedIndexChanged);
			// 
			// labPrt
			// 
			this.labPrt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labPrt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.labPrt.Location = new System.Drawing.Point(8, 136);
			this.labPrt.Name = "labPrt";
			this.labPrt.Size = new System.Drawing.Size(40, 16);
			this.labPrt.TabIndex = 34;
			this.labPrt.Text = "4.�i��";
			// 
			// bPronA
			// 
			this.bPronA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bPronA.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.bPronA.Location = new System.Drawing.Point(224, 64);
			this.bPronA.Name = "bPronA";
			this.bPronA.Size = new System.Drawing.Size(24, 24);
			this.bPronA.TabIndex = 33;
			this.bPronA.TabStop = false;
			this.bPronA.Text = "ua";
			this.bPronA.Click += new System.EventHandler(this.bPron);
			// 
			// bPron9
			// 
			this.bPron9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bPron9.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.bPron9.Location = new System.Drawing.Point(200, 64);
			this.bPron9.Name = "bPron9";
			this.bPron9.Size = new System.Drawing.Size(24, 24);
			this.bPron9.TabIndex = 32;
			this.bPron9.TabStop = false;
			this.bPron9.Text = "th";
			this.bPron9.Click += new System.EventHandler(this.bPron);
			// 
			// bPron8
			// 
			this.bPron8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bPron8.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.bPron8.Location = new System.Drawing.Point(176, 64);
			this.bPron8.Name = "bPron8";
			this.bPron8.Size = new System.Drawing.Size(24, 24);
			this.bPron8.TabIndex = 31;
			this.bPron8.TabStop = false;
			this.bPron8.Text = "e";
			this.bPron8.Click += new System.EventHandler(this.bPron);
			// 
			// bPron7
			// 
			this.bPron7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bPron7.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.bPron7.Location = new System.Drawing.Point(152, 64);
			this.bPron7.Name = "bPron7";
			this.bPron7.Size = new System.Drawing.Size(24, 24);
			this.bPron7.TabIndex = 30;
			this.bPron7.TabStop = false;
			this.bPron7.Text = "ua";
			this.bPron7.Click += new System.EventHandler(this.bPron);
			// 
			// bPron6
			// 
			this.bPron6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bPron6.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.bPron6.Location = new System.Drawing.Point(128, 64);
			this.bPron6.Name = "bPron6";
			this.bPron6.Size = new System.Drawing.Size(24, 24);
			this.bPron6.TabIndex = 29;
			this.bPron6.TabStop = false;
			this.bPron6.Text = "th";
			this.bPron6.Click += new System.EventHandler(this.bPron);
			// 
			// bPron5
			// 
			this.bPron5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bPron5.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.bPron5.Location = new System.Drawing.Point(104, 64);
			this.bPron5.Name = "bPron5";
			this.bPron5.Size = new System.Drawing.Size(24, 24);
			this.bPron5.TabIndex = 28;
			this.bPron5.TabStop = false;
			this.bPron5.Text = "si";
			this.bPron5.Click += new System.EventHandler(this.bPron);
			// 
			// bPron4
			// 
			this.bPron4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bPron4.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.bPron4.Location = new System.Drawing.Point(80, 64);
			this.bPron4.Name = "bPron4";
			this.bPron4.Size = new System.Drawing.Size(24, 24);
			this.bPron4.TabIndex = 27;
			this.bPron4.TabStop = false;
			this.bPron4.Text = "ae";
			this.bPron4.Click += new System.EventHandler(this.bPron);
			// 
			// bPron3
			// 
			this.bPron3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bPron3.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.bPron3.Location = new System.Drawing.Point(56, 64);
			this.bPron3.Name = "bPron3";
			this.bPron3.Size = new System.Drawing.Size(24, 24);
			this.bPron3.TabIndex = 26;
			this.bPron3.TabStop = false;
			this.bPron3.Text = "o";
			this.bPron3.Click += new System.EventHandler(this.bPron);
			// 
			// bPron2
			// 
			this.bPron2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bPron2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.bPron2.Location = new System.Drawing.Point(32, 64);
			this.bPron2.Name = "bPron2";
			this.bPron2.Size = new System.Drawing.Size(24, 24);
			this.bPron2.TabIndex = 25;
			this.bPron2.TabStop = false;
			this.bPron2.Text = "sh";
			this.bPron2.Click += new System.EventHandler(this.bPron);
			// 
			// bPron1
			// 
			this.bPron1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bPron1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.bPron1.Location = new System.Drawing.Point(8, 64);
			this.bPron1.Name = "bPron1";
			this.bPron1.Size = new System.Drawing.Size(24, 24);
			this.bPron1.TabIndex = 24;
			this.bPron1.TabStop = false;
			this.bPron1.Text = "th";
			this.bPron1.Click += new System.EventHandler(this.bPron);
			// 
			// labPron
			// 
			this.labPron.BackColor = System.Drawing.Color.Gray;
			this.labPron.ForeColor = System.Drawing.Color.White;
			this.labPron.Location = new System.Drawing.Point(8, 40);
			this.labPron.Name = "labPron";
			this.labPron.Size = new System.Drawing.Size(40, 16);
			this.labPron.TabIndex = 23;
			this.labPron.Text = "2.����";
			// 
			// txtPron
			// 
			this.txtPron.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPron.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.txtPron.Location = new System.Drawing.Point(56, 40);
			this.txtPron.Name = "txtPron";
			this.txtPron.Size = new System.Drawing.Size(216, 19);
			this.txtPron.TabIndex = 19;
			this.txtPron.Text = "";
			this.txtPron.ImeModeChanged += new System.EventHandler(this.txtPron_ImeModeChanged);
			this.txtPron.TextChanged += new System.EventHandler(this.txtPron_TextChanged);
			// 
			// labMean
			// 
			this.labMean.BackColor = System.Drawing.Color.LimeGreen;
			this.labMean.ForeColor = System.Drawing.Color.White;
			this.labMean.Location = new System.Drawing.Point(8, 104);
			this.labMean.Name = "labMean";
			this.labMean.Size = new System.Drawing.Size(40, 16);
			this.labMean.TabIndex = 22;
			this.labMean.Text = "3.�Ӗ�";
			// 
			// txtMean
			// 
			this.txtMean.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMean.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.txtMean.Location = new System.Drawing.Point(56, 104);
			this.txtMean.Name = "txtMean";
			this.txtMean.Size = new System.Drawing.Size(216, 19);
			this.txtMean.TabIndex = 21;
			this.txtMean.Text = "";
			this.txtMean.ImeModeChanged += new System.EventHandler(this.txtMean_ImeModeChanged);
			this.txtMean.TextChanged += new System.EventHandler(this.txtMean_TextChanged);
			// 
			// labWord
			// 
			this.labWord.BackColor = System.Drawing.Color.Gray;
			this.labWord.ForeColor = System.Drawing.Color.White;
			this.labWord.Location = new System.Drawing.Point(8, 8);
			this.labWord.Name = "labWord";
			this.labWord.Size = new System.Drawing.Size(40, 16);
			this.labWord.TabIndex = 20;
			this.labWord.Text = "1.�P��";
			// 
			// txtWord
			// 
			this.txtWord.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtWord.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.txtWord.Location = new System.Drawing.Point(56, 8);
			this.txtWord.Name = "txtWord";
			this.txtWord.Size = new System.Drawing.Size(216, 19);
			this.txtWord.TabIndex = 18;
			this.txtWord.Text = "";
			this.txtWord.ImeModeChanged += new System.EventHandler(this.txtWord_ImeModeChanged);
			this.txtWord.TextChanged += new System.EventHandler(this.txtWord_TextChanged);
			// 
			// labPart
			// 
			this.labPart.BackColor = System.Drawing.Color.White;
			this.labPart.Location = new System.Drawing.Point(56, 136);
			this.labPart.Name = "labPart";
			this.labPart.Size = new System.Drawing.Size(72, 16);
			this.labPart.TabIndex = 36;
			// 
			// bPronB
			// 
			this.bPronB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bPronB.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.bPronB.Location = new System.Drawing.Point(248, 64);
			this.bPronB.Name = "bPronB";
			this.bPronB.Size = new System.Drawing.Size(24, 24);
			this.bPronB.TabIndex = 37;
			this.bPronB.TabStop = false;
			this.bPronB.Text = "e";
			this.bPronB.Click += new System.EventHandler(this.bPron);
			// 
			// editWordCtl
			// 
			this.Controls.Add(this.bPronB);
			this.Controls.Add(this.labPart);
			this.Controls.Add(this.listPart);
			this.Controls.Add(this.labPrt);
			this.Controls.Add(this.bPronA);
			this.Controls.Add(this.bPron9);
			this.Controls.Add(this.bPron8);
			this.Controls.Add(this.bPron7);
			this.Controls.Add(this.bPron6);
			this.Controls.Add(this.bPron5);
			this.Controls.Add(this.bPron4);
			this.Controls.Add(this.bPron3);
			this.Controls.Add(this.bPron2);
			this.Controls.Add(this.bPron1);
			this.Controls.Add(this.labPron);
			this.Controls.Add(this.txtPron);
			this.Controls.Add(this.labMean);
			this.Controls.Add(this.txtMean);
			this.Controls.Add(this.labWord);
			this.Controls.Add(this.txtWord);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Name = "editWordCtl";
			this.Size = new System.Drawing.Size(280, 208);
			this.Load += new System.EventHandler(this.editWordCtl_Load);
			this.Enter += new System.EventHandler(this.editWordCtl_Enter);
			this.ResumeLayout(false);

		}
		#endregion


		//=====================================
		//          properties
		//-------------------------------------
		private string pWord;
		private string pMean;
		private string pPron;
		private �p�P��̗��K.wordPart pPrt;
		[Category("�p�P��̏��"),Description("���̃R���g���[���̕ێ�����p�P��̖{�̂�ݒ�A�擾���܂��B")]
		public string Word{
			get{return this.pWord;}
			set{
				this.pWord=value;
				if(this.txtWord.Text!=this.pWord){
					this.txtWord.Text=this.pWord;
				}
			}
		}
		[Category("�p�P��̏��"),Description("���̃R���g���[�����ێ�����p�P��̈Ӗ���ݒ�A�擾���܂��B")]
		public string Mean{
			get{return this.pMean;}
			set{
				this.pMean=value;
				if(this.txtMean.Text!=this.pMean){
					this.txtMean.Text=this.pMean;
				}
			}
		}
		[Category("�p�P��̏��"),Description("���̃R���g���[�����ێ�����p�P��̔������A�����L���Őݒ�A�擾���܂��B")]
		public string Pronounce{
			get{return this.pPron;}
			set{
				this.pPron=value;
				if(this.txtPron.Text!=this.pPron){
					this.txtPron.Text=this.pPron;
				}
			}
		}
		[Category("�p�P��̏��"),Description("���̃R���g���[�����ێ�����p�P��̕i����ݒ�A�擾���܂��B")]
		public �p�P��̗��K.wordPart Part{
			get{return this.pPrt;}
			set{
				this.pPrt=value;
				string partName=this.pPrt.partName;
				if(this.labPart.Text!=partName){
					this.labPart.Text=partName;
				}
				if(this.listPart.SelectedItem.ToString()!=partName){
					for(int i=0;i<this.listPart.Items.Count;i++){
						if(this.listPart.Items[i].ToString()==partName){
							this.listPart.SelectedIndex=i;
						}
					}
				}
			}//set�����܂�
		}
		//=====================================
		//          public funciton(){}
		//-------------------------------------
		public void Clear(){
			this.Word="";
			this.Mean="";
			this.Pronounce="";
			//this.Part�͂��̂܂�
			this.txtWord.Focus();
		}
		public void setWord(�p�P��̗��K.Word word){
			this.Word=word.word;
			this.Mean=word.mean;
			this.Pronounce=word.pron;
			this.Part=this.Part;
			this.txtWord.Focus();
		}
		public void FocusOn(int i){
			switch(i){
				case 1:
					this.txtWord.Focus();
					break;
				case 2:
					this.txtMean.Focus();
					break;
				case 3:
					this.txtPron.Focus();
					break;
			}
		}
		
		//=====================================
		//          event handlers
		//-------------------------------------
		private System.Windows.Forms.ImeMode imeHira=System.Windows.Forms.ImeMode.Hiragana;
		private System.Drawing.Color colImeOn=System.Drawing.Color.LimeGreen;
		private System.Drawing.Color colImeOff=System.Drawing.Color.Gray;

		private void txtWord_ImeModeChanged(object sender, System.EventArgs e)
		{
			this.labWord.BackColor=(this.txtWord.ImeMode==this.imeHira)?this.colImeOn:this.colImeOff;
		}
		private void txtMean_ImeModeChanged(object sender, System.EventArgs e)
		{
			this.labMean.BackColor=(this.txtMean.ImeMode==this.imeHira)?this.colImeOn:this.colImeOff;
		}
		private void txtPron_ImeModeChanged(object sender, System.EventArgs e)
		{
			this.labPron.BackColor=(this.txtPron.ImeMode==this.imeHira)?this.colImeOn:this.colImeOff;
		}

		private void editWordCtl_Load(object sender, System.EventArgs e)
		{
			load();
		}
		private void load()
		{
			this.bPron1.Text='\u00f0'.ToString();//eth
			this.bPron2.Text="��";
			this.bPron3.Text='\u0254'.ToString();
			this.bPron4.Text='\u00e6'.ToString();
			this.bPron5.Text='\u04e1'.ToString();//'\u0292'
			this.bPron6.Text="��";
			this.bPron7.Text='\u028c'.ToString();
			this.bPron8.Text='\u0251'.ToString();//�te
			this.bPron9.Text='\u0259'.ToString();//�M�La
			this.bPronA.Text='\u014b'.ToString();//ng
			this.bPronB.Text='\u025b'.ToString();//��
			this.listPart.SelectedIndex=0;
		}


		private void txtPronInsertLetter(string letter)
		{
			int n1=txtPron.SelectionStart;
			this.txtPron.SelectedText="";
			if(0<=n1&n1<this.txtPron.TextLength)
			{
				this.txtPron.Text=this.txtPron.Text.Substring(0,n1)+letter+this.txtPron.Text.Substring(n1);
				this.txtPron.SelectionStart=n1+1;
			}
			else
			{
				this.txtPron.AppendText(letter);
				this.txtPron.SelectionStart=this.txtPron.TextLength;
			}

		}
		private void bPron(object sender, System.EventArgs e)
		{	
			System.Windows.Forms.Button senderButton=(System.Windows.Forms.Button)sender;
			this.txtPronInsertLetter(senderButton.Text);
			this.txtPron.Focus();
		}

		private void txtWord_TextChanged(object sender, System.EventArgs e)
		{
			this.Word=this.txtWord.Text;
		}

		private void txtPron_TextChanged(object sender, System.EventArgs e)
		{	
			string str=txtPron.Text;
			str=str.Replace("a'",'\u00E1'.ToString()).Replace("a`",'\u00E0'.ToString());
			str=str.Replace("i'",'\u00ED'.ToString()).Replace("i`",'\u00EC'.ToString());
			str=str.Replace("u'",'\u00FA'.ToString()).Replace("u`",'\u00F9'.ToString());
			str=str.Replace("e'",'\u00E9'.ToString()).Replace("e`",'\u00E8'.ToString());
			str=str.Replace("o'",'\u00F3'.ToString()).Replace("o`",'\u00F2'.ToString());
			int n1=this.txtPron.SelectionStart+((this.txtPron.Text.Length!=str.Length)?-1:0);
			this.Pronounce=str;
			this.txtPron.SelectionStart=n1;
		}

		private void txtMean_TextChanged(object sender, System.EventArgs e)
		{
			this.Mean=this.txtMean.Text;
		}

		private void listPart_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch(this.listPart.SelectedIndex){
				case 0:this.Part=�p�P��̗��K.wordPart.Noun;break;
				case 1:this.Part=�p�P��̗��K.wordPart.Adjective;break;
				case 2:this.Part=�p�P��̗��K.wordPart.Verb;break;
				case 3:this.Part=�p�P��̗��K.wordPart.Adverb;break;
				case 4:this.Part=�p�P��̗��K.wordPart.Pronoun;break;
				case 5:this.Part=�p�P��̗��K.wordPart.Preposition;break;
				case 6:this.Part=�p�P��̗��K.wordPart.Conjunction;break;
				case 7:this.Part=�p�P��̗��K.wordPart.AuxiliaryVerb;break;
				case 8:this.Part=�p�P��̗��K.wordPart.Interjection;break;
				case 9:this.Part=�p�P��̗��K.wordPart.Construction;break;
				default:this.Part=�p�P��̗��K.wordPart.Noun;break;
			}//wordPart �� partNumber �ƃ��X�g�̏��Ԃ��K��������v���Ȃ��̂ŁA�����ŕϊ�����
		}

		private void editWordCtl_Enter(object sender, System.EventArgs e)
		{
			//this.txtWord.Focus();
		}
		//=====================================
		//          events
		//-------------------------------------
		public delegate void TextChangedEventHandler(object sender,TextChangedEventArgs e);
		public delegate void PartChangedEventHandler(object sender,PartChangedEventArgs e);
		public event TextChangedEventHandler WordChanged;
		public event TextChangedEventHandler MeanChanged;
		public event TextChangedEventHandler PronChanged;
		public event PartChangedEventHandler PartChanged;
		protected virtual void OnWordChanged(){
			if(WordChanged!=null)
			{
				TextChangedEventArgs e=new TextChangedEventArgs(this.Word);
				WordChanged(this,e);
			}
		}
		protected virtual void OnPronChanged(){
			if(PronChanged!=null)
			{
				TextChangedEventArgs e=new TextChangedEventArgs(this.Pronounce);
				PronChanged(this,e);
			}
		}
		protected virtual void OnMeanChanged(){
			if(MeanChanged!=null)
			{
				TextChangedEventArgs e=new TextChangedEventArgs(this.Mean);
				MeanChanged(this,e);
			}
		}
		protected virtual void OnPartChanged(){
			if(PartChanged!=null)
			{
				PartChangedEventArgs e=new PartChangedEventArgs(this.Part);
				PartChanged(this,e);
			}
		}
	}
	
	//������������������������������������������������
	//         EventArgs for editWordCtl
	//������������������������������������������������
	public class TextChangedEventArgs:System.EventArgs{
		public string text;
		public TextChangedEventArgs(string text){
			this.text=text;
		}
	}
	
	public class PartChangedEventArgs:System.EventArgs{
		public �p�P��̗��K.wordPart part;
		public PartChangedEventArgs(string text){
			this.part=new �p�P��̗��K.wordPart(text);
		}
		public PartChangedEventArgs(wordPart prt){
			this.part=prt;
		}
	}
	
	
}
