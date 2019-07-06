using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows;

namespace �p�P��̗��K
{
	/// <summary>
	/// Form3 �̊T�v�̐����ł��B
	/// </summary>
	public class frmInput : System.Windows.Forms.Form
	{
		/// <summary>���̓��͗�</summary>
		public System.Windows.Forms.TextBox textBox1;
		/// <summary>[�ݒ�]�{�^��</summary>
		private System.Windows.Forms.Button button1;
		/// <summary>[�L�����Z��]�{�^��</summary>
		private System.Windows.Forms.Button button2;
		/// <summary>���b�Z�[�W��\�����郉�x��</summary>
		public System.Windows.Forms.Label label1;
		
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		/// <summary>�E�B���h�E�����̂܂܍쐬���܂��B�ׂ����ݒ�͕ʂɍs���K�v������܂��B</summary>
		/// <param name="List">�Q�Ƃ���P�ꃊ�X�g�̎Q�Ƃ����蓖�Ă܂�</param>
		public frmInput(ref System.Windows.Forms.ListView List)
		{
			InitializeComponent();
			this.list=List;
		}
		/// <summary>���͂�����ɂ���ăt�H�[���𐮂��܂�</summary>
		/// <param name="List">�Q�Ƃ���P�ꃊ�X�g�̎Q�Ƃ����蓖�Ă܂�</param>
		/// <param name="wordIndex">�ύX����P��̃C���f�b�N�X��ݒ肵�܂��B<c>listView1.SelectedItems[0].Index</c></param>
		/// <param name="mode">�P��̉���ύX���邩��ݒ肵�܂�</param>
		//public frmInput(ref System.Windows.Forms.ListView List,int wordIndex,string mode)
		public frmInput(�p�P��̗��K.Form1 form,int wordIndex,string mode){
			this.InitializeComponent();
			this.pForm=form;//
			//this.list=List;
			this.index1=wordIndex;
			switch(mode){
				case("�P��"):
					this.index2=0;
					this.label1.Text="�P�����͂��Ă��������B";
					this.textBox1.ImeMode=System.Windows.Forms.ImeMode.Off;
					break;
				case("�Ӗ�"):
					this.index2=2;
					this.label1.Text="�Ӗ�����͂��ĉ������B";
					this.textBox1.ImeMode=System.Windows.Forms.ImeMode.Hiragana;
					break;
				case("�Q��"):
					this.index2=3;
					this.label1.Text="�Q�Ƃ�������͂��ĉ������B";
					this.textBox1.ImeMode=System.Windows.Forms.ImeMode.Off;
					break;
				case("�ᕶ"):
					this.index2=7;
					this.label1.Text="�ᕶ����͂��ĉ������B";
					this.textBox1.ImeMode=System.Windows.Forms.ImeMode.Off;
					this.Height+=32;
					this.button1.Top+=32;
					this.button2.Top+=32;
					this.textBox1.Multiline=true;
					this.textBox1.Height=48;
					break;
			}
			this.textBox1.Text=this.pForm.listView1.Items[this.index1].SubItems[this.index2].Text;		
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmInput));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(288, 19);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(128, 48);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "�ݒ�(&S)";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(216, 48);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 24);
			this.button2.TabIndex = 2;
			this.button2.Text = "�L�����Z��(&C)";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(288, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "*";
			// 
			// frmInput
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(304, 79);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmInput";
			this.ShowInTaskbar = false;
			this.Text = "������";
			this.ResumeLayout(false);

		}
		#endregion
		
		
		public �p�P��̗��K.Form1 pForm;
		/// <summary>���C���E�B���h�E��<c>listView1</c>�ւ̎Q��</summary>
		public System.Windows.Forms.ListView list;
		/// <summary>�P�ꃊ�X�g�̒��ŉ��Ԗڂ̒P���ύX���邩</summary>
		public int index1;
		/// <summary>�P�ꒆ�ŉ��Ԗڂ̏���ύX���邩</summary>
		public int index2;
		
		/// <summary>[�L�����Z��]�����������̓�����K��</summary>
		/// <param name="sender">�C�x���g�����m�����I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		private void button2_Click(object sender, System.EventArgs e){this.Close();}
		
		/// <summary>[�ݒ�]�����������̓�����K��</summary>
		/// <param name="sender">�C�x���g�����m�����I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		private void button1_Click(object sender, System.EventArgs e)
		{
			Word vWord=(Word)this.pForm.wordList[index1];
			switch(index2){
				case 0:vWord.word=this.textBox1.Text;break;
				case 2:vWord.mean=this.textBox1.Text;break;
				case 7:vWord.example=this.textBox1.Text.Split(new char[]{'\n'});break;
			}
			this.pForm.wordList[index1]=vWord;
			this.pForm.listView1.Items[index1].SubItems[index2].Text=this.textBox1.Text;
			this.Close();
		}
	
		
	}
}
