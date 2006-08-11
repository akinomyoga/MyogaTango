using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mwgWords{
	/// <summary>
	/// EngViewWord の概要の説明です。
	/// </summary>
	public class EngViewWord : System.Windows.Forms.Form{//interface IViewWord を実装
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader word;
		private System.Windows.Forms.ColumnHeader mean;
		private System.Windows.Forms.Panel panel1;
		private AxSHDocVw.AxWebBrowser axWebBrowser1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button bSearch;
		private System.Windows.Forms.Button bEdit;
		private System.Windows.Forms.Button bStudy;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EngViewWord(){
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
		protected override void Dispose( bool disposing ){
			if( disposing ){
				if(components != null){
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("word");
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("sample");
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EngViewWord));
			this.listView1 = new System.Windows.Forms.ListView();
			this.word = new System.Windows.Forms.ColumnHeader();
			this.mean = new System.Windows.Forms.ColumnHeader();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.axWebBrowser1 = new AxSHDocVw.AxWebBrowser();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.bSearch = new System.Windows.Forms.Button();
			this.bEdit = new System.Windows.Forms.Button();
			this.bStudy = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).BeginInit();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.word,
																						this.mean});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
			this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
																					  listViewItem1,
																					  listViewItem2});
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(480, 200);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// word
			// 
			this.word.Text = "単語/熟語";
			this.word.Width = 104;
			// 
			// mean
			// 
			this.mean.Text = "意味";
			this.mean.Width = 181;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.axWebBrowser1);
			this.panel1.Controls.Add(this.listView1);
			this.panel1.Location = new System.Drawing.Point(168, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(480, 464);
			this.panel1.TabIndex = 1;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 200);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(480, 3);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// axWebBrowser1
			// 
			this.axWebBrowser1.ContainingControl = this;
			this.axWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.axWebBrowser1.Enabled = true;
			this.axWebBrowser1.Location = new System.Drawing.Point(0, 200);
			this.axWebBrowser1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser1.OcxState")));
			this.axWebBrowser1.Size = new System.Drawing.Size(480, 264);
			this.axWebBrowser1.TabIndex = 1;
			this.axWebBrowser1.DocumentComplete += new AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler(this.axWebBrowser1_DocumentComplete);
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Items.AddRange(new object[] {
														  "第一章",
														  "第二章",
														  "第三章",
														  "検索結果: Hello (10件)",
														  "検索結果: cnj. (21件)"});
			this.listBox1.Location = new System.Drawing.Point(8, 8);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(152, 460);
			this.listBox1.TabIndex = 2;
			// 
			// bSearch
			// 
			this.bSearch.Location = new System.Drawing.Point(656, 8);
			this.bSearch.Name = "bSearch";
			this.bSearch.Size = new System.Drawing.Size(88, 24);
			this.bSearch.TabIndex = 3;
			this.bSearch.Text = "検索(&S)";
			// 
			// bEdit
			// 
			this.bEdit.Location = new System.Drawing.Point(656, 40);
			this.bEdit.Name = "bEdit";
			this.bEdit.Size = new System.Drawing.Size(88, 24);
			this.bEdit.TabIndex = 4;
			this.bEdit.Text = "編集(&E)";
			// 
			// bStudy
			// 
			this.bStudy.Location = new System.Drawing.Point(656, 72);
			this.bStudy.Name = "bStudy";
			this.bStudy.Size = new System.Drawing.Size(88, 24);
			this.bStudy.TabIndex = 5;
			this.bStudy.Text = "練習(&T)";
			// 
			// EngViewWord
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(752, 485);
			this.Controls.Add(this.bStudy);
			this.Controls.Add(this.bEdit);
			this.Controls.Add(this.bSearch);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.panel1);
			this.Name = "EngViewWord";
			this.Text = "English";
			this.Load += new System.EventHandler(this.EngViewWord_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void EngViewWord_Load(object sender, System.EventArgs e){
			this.axWebBrowser1.Navigate("_blank");
		}

		private void axWebBrowser1_DocumentComplete(object sender, AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent e){
			mshtml.HTMLDocument x=(mshtml.HTMLDocument)this.axWebBrowser1.Document;
			x.body.innerHTML="<body style='background-color:gray;'>これは実験</body>";
		}

		//予定:
		//ListView のそれぞれの Item は
	}
}
