using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace �p�P��̗��K
{
	/// <summary>
	/// Form2 �̊T�v�̐����ł��B
	/// </summary>
	public class Form2 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		public Form2()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form2));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(352, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "�P��̏�񂪖�������܂���B";
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(352, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "�@�P��̏�����͂��邩�t�@�C������";
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label3.Location = new System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(352, 24);
			this.label3.TabIndex = 2;
			this.label3.Text = "�ǂݍ��ނ����Ă��������B";
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label4.Location = new System.Drawing.Point(0, 119);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(370, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "��������������������������������������������������������";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(370, 135);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form2";
			this.Text = "�P��E�n��̗��K";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form2_KeyPress);
			this.Load += new System.EventHandler(this.Form2_Load);
			this.ResumeLayout(false);

		}
		#endregion
		//listview1�̒��̔ԍ�
		public int anum;
		/// <summary>���{��̈Ӗ�</summary>
		public string a;
		/// <summary>�����̉p�P��</summary>
		public string b;
		/// <summary>���������ڂ܂ŕ\�����Ă��邩</summary>
		public int bcou;
		/// <summary>�����𔭐�����I�u�W�F�N�g</summary>
		public System.Random rnd1=new System.Random();
		/// <summary>�o�������̐�</summary>
		public int q1;
		/// <summary>�����������̐�</summary>
		public int q2;
		
		//=====================================================
		// Form2 Constructer
		//=====================================================
		public class form1
		{
			/// <summary>�{�̂̃t�H�[���̒P�ꃊ�X�g�̃A�N�Z�T</summary>
			public static System.Windows.Forms.ListView listView1;
			public static System.Collections.ArrayList wordList;
		 
		}
		/// <summary><c>Form2</c>�ɒP�ꃊ�X�g�̎Q�Ƃ�n���܂�</summary>
		/// <param name="listview1">�P�ꃊ�X�g�̎Q�Ƃ��w��</param>
		public void set1(ref System.Windows.Forms.ListView listview1)
		{
			form1.listView1=listview1;
		}
		
		private void Form2_Load(object sender, System.EventArgs e){this.next();}

		/// <summary>�����ɂ���Ď��ɏo�肳���P���I�яo���A�o�肵�܂��B</summary>
		public void next()
		{
			if(form1.listView1.Items.Count==0){this.timer1.Enabled=false;return;}
			int r1=(int)rnd1.Next(form1.listView1.Items.Count);
			if(r1==form1.listView1.Items.Count)r1=0;
			this.anum=r1;
		 
			�p�P��̗��K.Word word0=(�p�P��̗��K.Word)form1.wordList[r1];
			this.a=word0.mean;
			this.b=word0.word;
			/*
			this.a=form1.listView1.Items[r1].SubItems[2].Text;
			this.b=form1.listView1.Items[r1].SubItems[0].Text;
			*/
			this.bcou=0;
			this.label1.Text=this.a;
			this.label2.Text="";
			this.label3.Text="";
			this.timer1.Interval=2000;
		}

		private void Form2_KeyPress(object sender, KeyPressEventArgs e)
		{
			string b=e.KeyChar.ToString();
			int c=(int)e.KeyChar;int len;
			if(65<=c&c<=90|97<=c&c<=123|c==32|c==44)
			{
				if(this.label3.Text.Length<this.b.Length&&this.agree(this.b.Substring(this.label3.Text.Length,1),b))
					this.label3.Text+=b;
			}
			else if(c==8&(len=this.label3.Text.Length)>0)
			{
				this.label3.Text=this.label3.Text.Substring(0,len-1);
			}
			if(this.label3.Text.Length==this.b.Length)
			{
				//�o�������̏���
				this.count(true);
				this.next();
			}
		}
		/// <summary>�����ƕ��������������ǂ����𔻒肵�܂��B</summary>
		/// <param name="a">��r���镶��</param>
		/// <param name="b">��r���镶��</param>
		/// <returns>�����ƕ���������������<c>true</c>��Ԃ��܂��B</returns>
		public bool agree(string a,string b)/*������v�m�F*/
		{
			string a0=a.ToLower();
			if(a0==b)return true;
			if((a0=='\u00E1'.ToString()|a0=='\u00E0'.ToString())&b=="a")return true;
			if((a0=='\u00ED'.ToString()|a0=='\u00EC'.ToString())&b=="i")return true;
			if((a0=='\u00FA'.ToString()|a0=='\u00F9'.ToString())&b=="u")return true;
			if((a0=='\u00E9'.ToString()|a0=='\u00E8'.ToString())&b=="e")return true;
			if((a0=='\u00F3'.ToString()|a0=='\u00F2'.ToString())&b=="o")return true;
			return false;
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
		 if(this.bcou>=this.b.Length){
		  //�o���Ȃ��������̏���
		  this.count(false);
		  this.next();
		 return;}
		 this.label2.Text+=this.b.Substring(this.bcou,1);
		 this.bcou++;
		 this.timer1.Interval=750;
		}
		
		/// <summary>�����E�s������P��̏��ɉ����܂�</summary>
		/// <param name="right">�����������ǂ������w��</param>
		public void count(bool right){
		 this.q1++;
		 �p�P��̗��K.Word word0=(�p�P��̗��K.Word)form1.wordList[anum];
		 word0.shutsudai++;
		 if(right)word0.seikai++;
		 /*
		 int n=System.Int32.Parse(form1.listView1.Items[anum].SubItems[4].Text)+1;
		 form1.listView1.Items[anum].SubItems[4].Text=n.ToString();
		 if(right){
		  this.q2++;
		  n=System.Int32.Parse(form1.listView1.Items[anum].SubItems[5].Text)+1;
		  form1.listView1.Items[anum].SubItems[5].Text=n.ToString();
		 }
		 */
		 int q3=(int)(q2*25/q1);
		 int i;string text="";
		 if(q3>0)for(i=1;i<=q3;i++){text+="��";}
		 while(text.Length<25){text+="��";}
		 this.label4.Text="������"+text;
		}
		
	}
}
