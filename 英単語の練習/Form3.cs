using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows;

namespace 英単語の練習
{
	/// <summary>
	/// Form3 の概要の説明です。
	/// </summary>
	public class frmInput : System.Windows.Forms.Form
	{
		/// <summary>情報の入力欄</summary>
		public System.Windows.Forms.TextBox textBox1;
		/// <summary>[設定]ボタン</summary>
		private System.Windows.Forms.Button button1;
		/// <summary>[キャンセル]ボタン</summary>
		private System.Windows.Forms.Button button2;
		/// <summary>メッセージを表示するラベル</summary>
		public System.Windows.Forms.Label label1;
		
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		/// <summary>ウィンドウをそのまま作成します。細かい設定は別に行う必要があります。</summary>
		/// <param name="List">参照する単語リストの参照を割り当てます</param>
		public frmInput(ref System.Windows.Forms.ListView List)
		{
			InitializeComponent();
			this.list=List;
		}
		/// <summary>入力する情報によってフォームを整えます</summary>
		/// <param name="List">参照する単語リストの参照を割り当てます</param>
		/// <param name="wordIndex">変更する単語のインデックスを設定します。<c>listView1.SelectedItems[0].Index</c></param>
		/// <param name="mode">単語の何を変更するかを設定します</param>
		//public frmInput(ref System.Windows.Forms.ListView List,int wordIndex,string mode)
		public frmInput(英単語の練習.Form1 form,int wordIndex,string mode){
			this.InitializeComponent();
			this.pForm=form;//
			//this.list=List;
			this.index1=wordIndex;
			switch(mode){
				case("単語"):
					this.index2=0;
					this.label1.Text="単語を入力してください。";
					this.textBox1.ImeMode=System.Windows.Forms.ImeMode.Off;
					break;
				case("意味"):
					this.index2=2;
					this.label1.Text="意味を入力して下さい。";
					this.textBox1.ImeMode=System.Windows.Forms.ImeMode.Hiragana;
					break;
				case("参照"):
					this.index2=3;
					this.label1.Text="参照する語を入力して下さい。";
					this.textBox1.ImeMode=System.Windows.Forms.ImeMode.Off;
					break;
				case("例文"):
					this.index2=7;
					this.label1.Text="例文を入力して下さい。";
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
			this.button1.Text = "設定(&S)";
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
			this.button2.Text = "キャンセル(&C)";
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
			this.Text = "情報入力";
			this.ResumeLayout(false);

		}
		#endregion
		
		
		public 英単語の練習.Form1 pForm;
		/// <summary>メインウィンドウの<c>listView1</c>への参照</summary>
		public System.Windows.Forms.ListView list;
		/// <summary>単語リストの中で何番目の単語を変更するか</summary>
		public int index1;
		/// <summary>単語中で何番目の情報を変更するか</summary>
		public int index2;
		
		/// <summary>[キャンセル]を押した時の動作を規定</summary>
		/// <param name="sender">イベントを検知したオブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		private void button2_Click(object sender, System.EventArgs e){this.Close();}
		
		/// <summary>[設定]を押した時の動作を規定</summary>
		/// <param name="sender">イベントを検知したオブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
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
