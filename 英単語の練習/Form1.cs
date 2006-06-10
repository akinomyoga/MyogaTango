using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace 英単語の練習
{
	/// <summary>
	/// メインウィンドウのクラスオブジェクト
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
	
	    #region オブジェクトの宣言
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		public System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button buttonB1;
		private System.Windows.Forms.Button buttonB2;
		private System.Windows.Forms.Button buttonB3;
		private System.Windows.Forms.Button buttonB4;
		private System.Windows.Forms.Button buttonB5;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labText3;
		private System.Windows.Forms.Label labText4;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ImageList imgList1;
		private System.Windows.Forms.Button buttonL1;
		private System.Windows.Forms.Button buttonL2;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mnC1I3;
		private System.Windows.Forms.MenuItem mnC1I4;
		private System.Windows.Forms.MenuItem mnC1I5;
		private System.Windows.Forms.MenuItem mnC1I6;
		private System.Windows.Forms.MenuItem mnC1I2;
		private System.Windows.Forms.MenuItem mnC1I1;
		private System.Windows.Forms.MenuItem mnC1I1I1;
		private System.Windows.Forms.MenuItem mnC1I1I3;
		private System.Windows.Forms.MenuItem mnC1I1I4;
		private System.Windows.Forms.MenuItem mnC1I1I2;
		private System.Windows.Forms.MenuItem menuItem28;
		private System.Windows.Forms.MenuItem menuItem29;
		private System.Windows.Forms.MenuItem menuItem30;
		private System.Windows.Forms.MenuItem menuItem31;
		private System.Windows.Forms.MenuItem menuItem32;
		private System.Windows.Forms.MenuItem menuItem33;
		private System.Windows.Forms.MenuItem mnC1I1I5;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem mnML1;
		private System.Windows.Forms.MenuItem mnML2;
		private System.Windows.Forms.MenuItem mnML4;
		private System.Windows.Forms.MenuItem mnML5;
		private System.Windows.Forms.MenuItem menuItem37;
		private System.Windows.Forms.MenuItem mnML6;
		private System.Windows.Forms.MenuItem mnML7;
		private System.Windows.Forms.MenuItem mnML8;
		private System.Windows.Forms.MenuItem mnML9;
		private System.Windows.Forms.MenuItem mnML10;
		private System.Windows.Forms.MenuItem mnML3;
		private System.Windows.Forms.MenuItem mnC1I7;
		private System.Windows.Forms.MenuItem mnC1I8;
		private System.Windows.Forms.Button buttonE1;
		private System.Windows.Forms.Button buttonE2;
		private System.Windows.Forms.Button buttonE3;
		private System.Windows.Forms.Button buttonE4;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.MenuItem menuItem34;
		private System.Windows.Forms.MenuItem menuItem35;
		private System.Windows.Forms.MenuItem menuItem36;
		private System.Windows.Forms.MenuItem menuItem38;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ImageList imgList2;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label labMsg;
		private 英単語の練習.editWordCtl editWordCtl1;
		private System.ComponentModel.IContainer components;
#endregion

		public Form1()
		{
			bool initialized=false;
			restart://また初めから実行する時
			frmSt=new frmStart();
			while(frmSt.result==null){
				frmSt.ShowDialog(this);
			}
			frmSt.Dispose();
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			switch(this.frmSt.result){
				case "bNew":
					if(!initialized)InitializeComponent();
					this.wordList=new System.Collections.ArrayList();
					if(!this.bNew())goto restart;
					break;
				case "bRead":
					if(!initialized)InitializeComponent();
					this.wordList=new System.Collections.ArrayList();
					if(!this.bRead())goto restart;
					break;
				case "Exit":
				default:
					this.Load += new System.EventHandler(this.Form1_Load_Exit);
					break;
			}
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing ){
		  if(disposing)if(components!=null)components.Dispose();
		  base.Dispose( disposing );
		}

		#region private void InitializeComponent()
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.button3 = new System.Windows.Forms.Button();
			this.imgList2 = new System.Windows.Forms.ImageList(this.components);
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mnC1I1 = new System.Windows.Forms.MenuItem();
			this.mnC1I1I1 = new System.Windows.Forms.MenuItem();
			this.mnC1I1I2 = new System.Windows.Forms.MenuItem();
			this.menuItem28 = new System.Windows.Forms.MenuItem();
			this.menuItem29 = new System.Windows.Forms.MenuItem();
			this.menuItem30 = new System.Windows.Forms.MenuItem();
			this.menuItem31 = new System.Windows.Forms.MenuItem();
			this.menuItem32 = new System.Windows.Forms.MenuItem();
			this.menuItem33 = new System.Windows.Forms.MenuItem();
			this.mnC1I1I3 = new System.Windows.Forms.MenuItem();
			this.mnC1I1I4 = new System.Windows.Forms.MenuItem();
			this.mnC1I1I5 = new System.Windows.Forms.MenuItem();
			this.mnC1I2 = new System.Windows.Forms.MenuItem();
			this.mnC1I3 = new System.Windows.Forms.MenuItem();
			this.mnC1I4 = new System.Windows.Forms.MenuItem();
			this.mnC1I5 = new System.Windows.Forms.MenuItem();
			this.mnC1I6 = new System.Windows.Forms.MenuItem();
			this.mnC1I7 = new System.Windows.Forms.MenuItem();
			this.mnC1I8 = new System.Windows.Forms.MenuItem();
			this.imgList1 = new System.Windows.Forms.ImageList(this.components);
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.labText3 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.buttonB1 = new System.Windows.Forms.Button();
			this.buttonB2 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.editWordCtl1 = new 英単語の練習.editWordCtl();
			this.labText4 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonE2 = new System.Windows.Forms.Button();
			this.buttonE3 = new System.Windows.Forms.Button();
			this.buttonE4 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.buttonE1 = new System.Windows.Forms.Button();
			this.buttonB3 = new System.Windows.Forms.Button();
			this.buttonB4 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buttonL2 = new System.Windows.Forms.Button();
			this.buttonL1 = new System.Windows.Forms.Button();
			this.buttonB5 = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem25 = new System.Windows.Forms.MenuItem();
			this.mnML1 = new System.Windows.Forms.MenuItem();
			this.mnML2 = new System.Windows.Forms.MenuItem();
			this.mnML3 = new System.Windows.Forms.MenuItem();
			this.mnML4 = new System.Windows.Forms.MenuItem();
			this.mnML5 = new System.Windows.Forms.MenuItem();
			this.menuItem37 = new System.Windows.Forms.MenuItem();
			this.mnML6 = new System.Windows.Forms.MenuItem();
			this.mnML7 = new System.Windows.Forms.MenuItem();
			this.mnML8 = new System.Windows.Forms.MenuItem();
			this.mnML9 = new System.Windows.Forms.MenuItem();
			this.mnML10 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem26 = new System.Windows.Forms.MenuItem();
			this.menuItem34 = new System.Windows.Forms.MenuItem();
			this.menuItem35 = new System.Windows.Forms.MenuItem();
			this.menuItem36 = new System.Windows.Forms.MenuItem();
			this.menuItem38 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.labMsg = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(352, 272);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 24);
			this.button1.TabIndex = 7;
			this.button1.TabStop = false;
			this.button1.Text = "登録";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "英単語帳(*.w.mwq)|*.w.mwq|めうか(*.mwq)|*.mwq|全てのファイル(*.*)|*.*";
			// 
			// button3
			// 
			this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button3.ImageIndex = 6;
			this.button3.ImageList = this.imgList2;
			this.button3.Location = new System.Drawing.Point(16, 368);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(64, 24);
			this.button3.TabIndex = 10;
			this.button3.TabStop = false;
			this.button3.Text = "　　保存";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// imgList2
			// 
			this.imgList2.ImageSize = new System.Drawing.Size(16, 16);
			this.imgList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList2.ImageStream")));
			this.imgList2.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4,
																						this.columnHeader5,
																						this.columnHeader6,
																						this.columnHeader7});
			this.listView1.ContextMenu = this.contextMenu1;
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(8, 32);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(632, 232);
			this.listView1.SmallImageList = this.imgList1;
			this.listView1.TabIndex = 5;
			this.listView1.TabStop = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "単語・熟語";
			this.columnHeader1.Width = 119;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "品詞";
			this.columnHeader2.Width = 41;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "意味";
			this.columnHeader3.Width = 149;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "参照";
			this.columnHeader4.Width = 175;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "出題";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader5.Width = 36;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "正解";
			this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader6.Width = 36;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "正解率";
			this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader7.Width = 48;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnC1I1,
																						 this.mnC1I2,
																						 this.mnC1I3,
																						 this.mnC1I4,
																						 this.mnC1I5,
																						 this.mnC1I6,
																						 this.mnC1I7,
																						 this.mnC1I8});
			// 
			// mnC1I1
			// 
			this.mnC1I1.Index = 0;
			this.mnC1I1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.mnC1I1I1,
																				   this.mnC1I1I2,
																				   this.mnC1I1I3,
																				   this.mnC1I1I4,
																				   this.mnC1I1I5});
			this.mnC1I1.Text = "変更";
			// 
			// mnC1I1I1
			// 
			this.mnC1I1I1.Index = 0;
			this.mnC1I1I1.Text = "英単語...";
			this.mnC1I1I1.Click += new System.EventHandler(this.mnC1I1I1_Click);
			// 
			// mnC1I1I2
			// 
			this.mnC1I1I2.Index = 1;
			this.mnC1I1I2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem28,
																					 this.menuItem29,
																					 this.menuItem30,
																					 this.menuItem31,
																					 this.menuItem32,
																					 this.menuItem33});
			this.mnC1I1I2.Text = "品詞";
			// 
			// menuItem28
			// 
			this.menuItem28.Index = 0;
			this.menuItem28.Text = "名詞";
			this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click);
			// 
			// menuItem29
			// 
			this.menuItem29.Index = 1;
			this.menuItem29.Text = "動詞";
			this.menuItem29.Click += new System.EventHandler(this.menuItem29_Click);
			// 
			// menuItem30
			// 
			this.menuItem30.Index = 2;
			this.menuItem30.Text = "形容詞";
			this.menuItem30.Click += new System.EventHandler(this.menuItem30_Click);
			// 
			// menuItem31
			// 
			this.menuItem31.Index = 3;
			this.menuItem31.Text = "副詞";
			this.menuItem31.Click += new System.EventHandler(this.menuItem31_Click);
			// 
			// menuItem32
			// 
			this.menuItem32.Index = 4;
			this.menuItem32.Text = "助動詞";
			// 
			// menuItem33
			// 
			this.menuItem33.Index = 5;
			this.menuItem33.Text = "構文";
			// 
			// mnC1I1I3
			// 
			this.mnC1I1I3.Index = 2;
			this.mnC1I1I3.Text = "意味...";
			this.mnC1I1I3.Click += new System.EventHandler(this.mnC1I1I3_Click);
			// 
			// mnC1I1I4
			// 
			this.mnC1I1I4.Index = 3;
			this.mnC1I1I4.Text = "参照...";
			this.mnC1I1I4.Click += new System.EventHandler(this.mnC1I1I4_Click);
			// 
			// mnC1I1I5
			// 
			this.mnC1I1I5.Index = 4;
			this.mnC1I1I5.Text = "例文...";
			this.mnC1I1I5.Click += new System.EventHandler(this.mnC1I1I5_Click);
			// 
			// mnC1I2
			// 
			this.mnC1I2.Index = 1;
			this.mnC1I2.Text = "-";
			// 
			// mnC1I3
			// 
			this.mnC1I3.Enabled = false;
			this.mnC1I3.Index = 2;
			this.mnC1I3.Text = "編集";
			this.mnC1I3.Click += new System.EventHandler(this.mnC1I3_Click);
			// 
			// mnC1I4
			// 
			this.mnC1I4.Enabled = false;
			this.mnC1I4.Index = 3;
			this.mnC1I4.Text = "削除";
			this.mnC1I4.Click += new System.EventHandler(this.mnC1I4_Click);
			// 
			// mnC1I5
			// 
			this.mnC1I5.Enabled = false;
			this.mnC1I5.Index = 4;
			this.mnC1I5.Text = "上へ";
			this.mnC1I5.Click += new System.EventHandler(this.mnC1I5_Click);
			// 
			// mnC1I6
			// 
			this.mnC1I6.Enabled = false;
			this.mnC1I6.Index = 5;
			this.mnC1I6.Text = "下へ";
			this.mnC1I6.Click += new System.EventHandler(this.mnC1I6_Click);
			// 
			// mnC1I7
			// 
			this.mnC1I7.Index = 6;
			this.mnC1I7.Text = "-";
			// 
			// mnC1I8
			// 
			this.mnC1I8.Enabled = false;
			this.mnC1I8.Index = 7;
			this.mnC1I8.Text = "挿入";
			this.mnC1I8.Click += new System.EventHandler(this.mnC1I8_Click);
			// 
			// imgList1
			// 
			this.imgList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imgList1.ImageSize = new System.Drawing.Size(12, 12);
			this.imgList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList1.ImageStream")));
			this.imgList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// textBox3
			// 
			this.textBox3.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.textBox3.Location = new System.Drawing.Point(288, 40);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(336, 19);
			this.textBox3.TabIndex = 2;
			this.textBox3.Text = "";
			this.textBox3.ImeModeChanged += new System.EventHandler(this.textBox3_ImeModeChanged);
			// 
			// labText3
			// 
			this.labText3.BackColor = System.Drawing.Color.Gray;
			this.labText3.ForeColor = System.Drawing.Color.White;
			this.labText3.Location = new System.Drawing.Point(288, 24);
			this.labText3.Name = "labText3";
			this.labText3.Size = new System.Drawing.Size(32, 16);
			this.labText3.TabIndex = 13;
			this.labText3.Text = "参照";
			// 
			// button4
			// 
			this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button4.ImageIndex = 5;
			this.button4.ImageList = this.imgList2;
			this.button4.Location = new System.Drawing.Point(16, 336);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(64, 24);
			this.button4.TabIndex = 9;
			this.button4.TabStop = false;
			this.button4.Text = "　　読込";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
			this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button5.Location = new System.Drawing.Point(8, 272);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(96, 24);
			this.button5.TabIndex = 14;
			this.button5.TabStop = false;
			this.button5.Text = "   単語の練習";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// buttonB1
			// 
			this.buttonB1.Enabled = false;
			this.buttonB1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonB1.Location = new System.Drawing.Point(16, 80);
			this.buttonB1.Name = "buttonB1";
			this.buttonB1.Size = new System.Drawing.Size(64, 24);
			this.buttonB1.TabIndex = 15;
			this.buttonB1.TabStop = false;
			this.buttonB1.Text = "編集";
			this.buttonB1.Click += new System.EventHandler(this.buttonB1_Click);
			// 
			// buttonB2
			// 
			this.buttonB2.Enabled = false;
			this.buttonB2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonB2.Location = new System.Drawing.Point(16, 112);
			this.buttonB2.Name = "buttonB2";
			this.buttonB2.Size = new System.Drawing.Size(64, 24);
			this.buttonB2.TabIndex = 16;
			this.buttonB2.TabStop = false;
			this.buttonB2.Text = "削除";
			this.buttonB2.Click += new System.EventHandler(this.buttonB2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.editWordCtl1);
			this.groupBox1.Controls.Add(this.labText4);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.labText3);
			this.groupBox1.Location = new System.Drawing.Point(8, 304);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(632, 232);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "簡易入力";
			// 
			// editWordCtl1
			// 
			this.editWordCtl1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.editWordCtl1.Location = new System.Drawing.Point(8, 16);
			this.editWordCtl1.Mean = "";
			this.editWordCtl1.Name = "editWordCtl1";
			this.editWordCtl1.Pronounce = "";
			this.editWordCtl1.Size = new System.Drawing.Size(272, 208);
			this.editWordCtl1.TabIndex = 21;
			this.editWordCtl1.Word = "";
			// 
			// labText4
			// 
			this.labText4.BackColor = System.Drawing.Color.Gray;
			this.labText4.ForeColor = System.Drawing.Color.White;
			this.labText4.Location = new System.Drawing.Point(288, 72);
			this.labText4.Name = "labText4";
			this.labText4.Size = new System.Drawing.Size(32, 16);
			this.labText4.TabIndex = 17;
			this.labText4.Text = "例文";
			// 
			// textBox4
			// 
			this.textBox4.AcceptsReturn = true;
			this.textBox4.Location = new System.Drawing.Point(288, 88);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(336, 96);
			this.textBox4.TabIndex = 3;
			this.textBox4.Text = "";
			// 
			// label5
			// 
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Location = new System.Drawing.Point(432, 200);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(144, 16);
			this.label5.TabIndex = 15;
			this.label5.Text = "正解数：0";
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Location = new System.Drawing.Point(288, 200);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 16);
			this.label4.TabIndex = 14;
			this.label4.Text = "出題数：0";
			// 
			// buttonE2
			// 
			this.buttonE2.BackColor = System.Drawing.Color.Pink;
			this.buttonE2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonE2.Location = new System.Drawing.Point(448, 272);
			this.buttonE2.Name = "buttonE2";
			this.buttonE2.Size = new System.Drawing.Size(32, 24);
			this.buttonE2.TabIndex = 24;
			this.buttonE2.Text = "動";
			this.buttonE2.Click += new System.EventHandler(this.buttonE2_Click);
			// 
			// buttonE3
			// 
			this.buttonE3.BackColor = System.Drawing.Color.LightSteelBlue;
			this.buttonE3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonE3.Location = new System.Drawing.Point(480, 272);
			this.buttonE3.Name = "buttonE3";
			this.buttonE3.Size = new System.Drawing.Size(32, 24);
			this.buttonE3.TabIndex = 25;
			this.buttonE3.Text = "副";
			this.buttonE3.Click += new System.EventHandler(this.buttonE3_Click);
			// 
			// buttonE4
			// 
			this.buttonE4.BackColor = System.Drawing.Color.LightGreen;
			this.buttonE4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonE4.Location = new System.Drawing.Point(512, 272);
			this.buttonE4.Name = "buttonE4";
			this.buttonE4.Size = new System.Drawing.Size(32, 24);
			this.buttonE4.TabIndex = 26;
			this.buttonE4.Text = "形";
			this.buttonE4.Click += new System.EventHandler(this.buttonE4_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(568, 272);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(64, 24);
			this.button6.TabIndex = 22;
			this.button6.Text = "挿入";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// buttonE1
			// 
			this.buttonE1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.buttonE1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonE1.Location = new System.Drawing.Point(416, 272);
			this.buttonE1.Name = "buttonE1";
			this.buttonE1.Size = new System.Drawing.Size(32, 24);
			this.buttonE1.TabIndex = 23;
			this.buttonE1.Text = "名";
			this.buttonE1.Click += new System.EventHandler(this.buttonE1_Click);
			// 
			// buttonB3
			// 
			this.buttonB3.Enabled = false;
			this.buttonB3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonB3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonB3.ImageIndex = 8;
			this.buttonB3.ImageList = this.imgList2;
			this.buttonB3.Location = new System.Drawing.Point(16, 144);
			this.buttonB3.Name = "buttonB3";
			this.buttonB3.Size = new System.Drawing.Size(64, 24);
			this.buttonB3.TabIndex = 18;
			this.buttonB3.TabStop = false;
			this.buttonB3.Text = "　　上へ";
			this.buttonB3.Click += new System.EventHandler(this.buttonB3_Click);
			// 
			// buttonB4
			// 
			this.buttonB4.Enabled = false;
			this.buttonB4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonB4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonB4.ImageIndex = 9;
			this.buttonB4.ImageList = this.imgList2;
			this.buttonB4.Location = new System.Drawing.Point(16, 176);
			this.buttonB4.Name = "buttonB4";
			this.buttonB4.Size = new System.Drawing.Size(64, 24);
			this.buttonB4.TabIndex = 19;
			this.buttonB4.TabStop = false;
			this.buttonB4.Text = "　　下へ";
			this.buttonB4.Click += new System.EventHandler(this.buttonB4_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.buttonL2);
			this.groupBox2.Controls.Add(this.buttonL1);
			this.groupBox2.Controls.Add(this.buttonB5);
			this.groupBox2.Controls.Add(this.buttonB1);
			this.groupBox2.Controls.Add(this.buttonB2);
			this.groupBox2.Controls.Add(this.buttonB3);
			this.groupBox2.Controls.Add(this.buttonB4);
			this.groupBox2.Controls.Add(this.button4);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Location = new System.Drawing.Point(648, 32);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(96, 400);
			this.groupBox2.TabIndex = 20;
			this.groupBox2.TabStop = false;
			// 
			// buttonL2
			// 
			this.buttonL2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonL2.Location = new System.Drawing.Point(48, 16);
			this.buttonL2.Name = "buttonL2";
			this.buttonL2.Size = new System.Drawing.Size(40, 24);
			this.buttonL2.TabIndex = 26;
			this.buttonL2.TabStop = false;
			this.buttonL2.Text = "詳細";
			this.buttonL2.Click += new System.EventHandler(this.buttonL2_Click);
			// 
			// buttonL1
			// 
			this.buttonL1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonL1.Location = new System.Drawing.Point(8, 16);
			this.buttonL1.Name = "buttonL1";
			this.buttonL1.Size = new System.Drawing.Size(40, 24);
			this.buttonL1.TabIndex = 24;
			this.buttonL1.TabStop = false;
			this.buttonL1.Text = "一覧";
			this.buttonL1.Click += new System.EventHandler(this.buttonL1_Click);
			// 
			// buttonB5
			// 
			this.buttonB5.Enabled = false;
			this.buttonB5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonB5.Location = new System.Drawing.Point(16, 208);
			this.buttonB5.Name = "buttonB5";
			this.buttonB5.Size = new System.Drawing.Size(64, 24);
			this.buttonB5.TabIndex = 20;
			this.buttonB5.Text = "交換";
			this.buttonB5.Click += new System.EventHandler(this.buttonB5_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 581);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(746, 22);
			this.statusBar1.TabIndex = 21;
			this.statusBar1.Text = "statusBar1";
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel1.Text = "例文";
			this.statusBarPanel1.Width = 730;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem15,
																					  this.menuItem5,
																					  this.menuItem20});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem3,
																					  this.menuItem4});
			this.menuItem1.Text = "ファイル(&F)";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
			this.menuItem3.Text = "読込(&R)";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuItem4.Text = "保存(&S)";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 1;
			this.menuItem15.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem21,
																					   this.menuItem16,
																					   this.menuItem17,
																					   this.menuItem18,
																					   this.menuItem19});
			this.menuItem15.Text = "リスト(&L)";
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 0;
			this.menuItem21.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem23,
																					   this.menuItem22});
			this.menuItem21.Text = "表示(&V)";
			// 
			// menuItem23
			// 
			this.menuItem23.Checked = true;
			this.menuItem23.Index = 0;
			this.menuItem23.Text = "詳細(&D)";
			this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 1;
			this.menuItem22.Text = "一覧(&L)";
			this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Enabled = false;
			this.menuItem16.Index = 1;
			this.menuItem16.Text = "編集(&E)";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Enabled = false;
			this.menuItem17.Index = 2;
			this.menuItem17.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
			this.menuItem17.Text = "削除(&D)";
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Enabled = false;
			this.menuItem18.Index = 3;
			this.menuItem18.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
			this.menuItem18.Text = "上へ(&T)";
			this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Enabled = false;
			this.menuItem19.Index = 4;
			this.menuItem19.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
			this.menuItem19.Text = "下へ(&B)";
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 2;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem25,
																					  this.menuItem24,
																					  this.menuItem6,
																					  this.menuItem7,
																					  this.menuItem8,
																					  this.menuItem9,
																					  this.menuItem10,
																					  this.menuItem26});
			this.menuItem5.Text = "入力(&I)";
			// 
			// menuItem25
			// 
			this.menuItem25.Index = 0;
			this.menuItem25.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mnML1,
																					   this.mnML2,
																					   this.mnML3,
																					   this.mnML4,
																					   this.mnML5,
																					   this.menuItem37,
																					   this.mnML6,
																					   this.mnML7,
																					   this.mnML8,
																					   this.mnML9,
																					   this.mnML10});
			this.menuItem25.Text = "特殊文字";
			// 
			// mnML1
			// 
			this.mnML1.Index = 0;
			this.mnML1.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.mnML1.Text = "a";
			this.mnML1.Click += new System.EventHandler(this.mnML1_Click);
			// 
			// mnML2
			// 
			this.mnML2.Index = 1;
			this.mnML2.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
			this.mnML2.Text = "i";
			this.mnML2.Click += new System.EventHandler(this.mnML2_Click);
			// 
			// mnML3
			// 
			this.mnML3.Index = 2;
			this.mnML3.Shortcut = System.Windows.Forms.Shortcut.CtrlU;
			this.mnML3.Text = "u";
			this.mnML3.Click += new System.EventHandler(this.mnML3_Click);
			// 
			// mnML4
			// 
			this.mnML4.Index = 3;
			this.mnML4.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
			this.mnML4.Text = "e";
			this.mnML4.Click += new System.EventHandler(this.mnML4_Click);
			// 
			// mnML5
			// 
			this.mnML5.Index = 4;
			this.mnML5.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.mnML5.Text = "o";
			this.mnML5.Click += new System.EventHandler(this.mnML5_Click);
			// 
			// menuItem37
			// 
			this.menuItem37.Index = 5;
			this.menuItem37.Text = "-";
			// 
			// mnML6
			// 
			this.mnML6.Index = 6;
			this.mnML6.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftA;
			this.mnML6.Text = "a";
			this.mnML6.Click += new System.EventHandler(this.mnML6_Click);
			// 
			// mnML7
			// 
			this.mnML7.Index = 7;
			this.mnML7.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftI;
			this.mnML7.Text = "i";
			this.mnML7.Click += new System.EventHandler(this.mnML7_Click);
			// 
			// mnML8
			// 
			this.mnML8.Index = 8;
			this.mnML8.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftU;
			this.mnML8.Text = "u";
			this.mnML8.Click += new System.EventHandler(this.mnML8_Click);
			// 
			// mnML9
			// 
			this.mnML9.Index = 9;
			this.mnML9.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftE;
			this.mnML9.Text = "e";
			this.mnML9.Click += new System.EventHandler(this.mnML9_Click);
			// 
			// mnML10
			// 
			this.mnML10.Index = 10;
			this.mnML10.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftO;
			this.mnML10.Text = "o";
			this.mnML10.Click += new System.EventHandler(this.mnML10_Click);
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 1;
			this.menuItem24.Text = "-";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 2;
			this.menuItem6.Text = "単語入力(&1)";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 3;
			this.menuItem7.Text = "意味入力(&2)";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 4;
			this.menuItem8.Text = "参照入力(&3)";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 5;
			this.menuItem9.Text = "例文入力(&4)";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 6;
			this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem11,
																					   this.menuItem12,
																					   this.menuItem13,
																					   this.menuItem14});
			this.menuItem10.Text = "品詞選択(&5)";
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 0;
			this.menuItem11.Shortcut = System.Windows.Forms.Shortcut.Ctrl1;
			this.menuItem11.Text = "名詞(&Z)";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 1;
			this.menuItem12.Shortcut = System.Windows.Forms.Shortcut.Ctrl2;
			this.menuItem12.Text = "動詞(&X)";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 2;
			this.menuItem13.Shortcut = System.Windows.Forms.Shortcut.Ctrl3;
			this.menuItem13.Text = "副詞(&C)";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 3;
			this.menuItem14.Shortcut = System.Windows.Forms.Shortcut.Ctrl4;
			this.menuItem14.Text = "形容詞(&V)";
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem26
			// 
			this.menuItem26.Index = 7;
			this.menuItem26.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem34,
																					   this.menuItem35,
																					   this.menuItem36,
																					   this.menuItem38});
			this.menuItem26.Text = "登録";
			this.menuItem26.Click += new System.EventHandler(this.menuItem26_Click);
			// 
			// menuItem34
			// 
			this.menuItem34.Index = 0;
			this.menuItem34.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.menuItem34.Text = "名詞として";
			this.menuItem34.Click += new System.EventHandler(this.menuItem34_Click);
			// 
			// menuItem35
			// 
			this.menuItem35.Index = 1;
			this.menuItem35.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.menuItem35.Text = "動詞として";
			this.menuItem35.Click += new System.EventHandler(this.menuItem35_Click);
			// 
			// menuItem36
			// 
			this.menuItem36.Index = 2;
			this.menuItem36.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.menuItem36.Text = "副詞として";
			this.menuItem36.Click += new System.EventHandler(this.menuItem36_Click);
			// 
			// menuItem38
			// 
			this.menuItem38.Index = 3;
			this.menuItem38.Shortcut = System.Windows.Forms.Shortcut.F4;
			this.menuItem38.Text = "形容詞として";
			this.menuItem38.Click += new System.EventHandler(this.menuItem38_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 3;
			this.menuItem20.Text = "ヘルプ(&H)";
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton5,
																						this.toolBarButton1,
																						this.toolBarButton2,
																						this.toolBarButton3});
			this.toolBar1.ButtonSize = new System.Drawing.Size(16, 16);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imgList2;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(746, 28);
			this.toolBar1.TabIndex = 27;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.ImageIndex = 4;
			this.toolBarButton5.ToolTipText = "新規ファイル";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 5;
			this.toolBarButton1.ToolTipText = "ファイルを開く";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.ImageIndex = 6;
			this.toolBarButton2.ToolTipText = "ファイルに保存する";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "英単語帳(*.w.mwq)|*.w.mwq|めうか(*.mwq)|*.mwq|テキストファイル(*.txt)|*.txt|全てのファイル(*.*)|*.*";
			this.saveFileDialog1.OverwritePrompt = false;
			// 
			// labMsg
			// 
			this.labMsg.Image = ((System.Drawing.Image)(resources.GetObject("labMsg.Image")));
			this.labMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labMsg.Location = new System.Drawing.Point(0, 544);
			this.labMsg.Name = "labMsg";
			this.labMsg.Size = new System.Drawing.Size(728, 16);
			this.labMsg.TabIndex = 28;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(746, 603);
			this.Controls.Add(this.labMsg);
			this.Controls.Add(this.toolBar1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonE2);
			this.Controls.Add(this.buttonE3);
			this.Controls.Add(this.buttonE4);
			this.Controls.Add(this.buttonE1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "英単語一覧";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		
		
		/// <summary>現在の単語帳ファイル</summary>
		public string fn="";
		/// <summary>このプログラムのパス(作業フォルダ)</summary>
		public string path;
		/// <summary>プログラムで利用する特殊文字の表</summary>
		public string[] ltr1;
		/// <summary>単語の情報を保持するリスト</summary>
		public System.Collections.ArrayList wordList;
		/// <summary>単語の情報を入力するdialogue</summary>
		private frmInput frmInput1;
		private frmStart frmSt;
		
		
		private void Form1_Load_Exit(object sender,System.EventArgs e){
			Application.Exit();
		}
		
		private void Form1_Load(object sender, System.EventArgs e){
			path=System.Reflection.Assembly.GetExecutingAssembly().Location;
			//特殊文字の設定
			ltr1=new string[]{'\u00E1'.ToString(),'\u00ED'.ToString(),'\u00FA'.ToString(),'\u00E9'.ToString(),'\u00F3'.ToString(),'\u00E0'.ToString(),'\u00EC'.ToString(),'\u00F9'.ToString(),'\u00E8'.ToString(),'\u00F2'.ToString()};
			this.mnML1.Text=ltr1[0];
			this.mnML2.Text=ltr1[1];
			this.mnML3.Text=ltr1[2];
			this.mnML4.Text=ltr1[3];
			this.mnML5.Text=ltr1[4];
			this.mnML6.Text=ltr1[5];
			this.mnML7.Text=ltr1[6];
			this.mnML8.Text=ltr1[7];
			this.mnML9.Text=ltr1[8];
			this.mnML10.Text=ltr1[9];
		}
		 
#region buttons EventHandler
		 
		public Form2 form2;
		private void button1_Click(object sender, System.EventArgs e){this.bEntry();}//登録
		private void button2_Click(object sender, System.EventArgs e){}//ファイル選択
		private void button3_Click(object sender, System.EventArgs e){this.bSave();}//保存
		private void button4_Click(object sender, System.EventArgs e){this.bRead();}//読込
		private void button5_Click(object sender, System.EventArgs e)
		{
			form2=new Form2();
			form2.set1(ref this.listView1);
			form2.Show();
		}

		private void buttonB1_Click(object sender, System.EventArgs e){this.bEdit();}//編集
		private void buttonB2_Click(object sender, System.EventArgs e){this.bDel();}//削除
		private void buttonB3_Click(object sender, System.EventArgs e){this.bUp();}//上へ
		private void buttonB4_Click(object sender, System.EventArgs e){this.bDown();}//下へ
		private void buttonB5_Click(object sender, System.EventArgs e)//交換
		{
			if(this.listView1.SelectedItems.Count==2)this.listView1ItemChange(this.listView1.SelectedItems[0].Index,this.listView1.SelectedItems[1].Index);
		}

		private void button6_Click(object sender, System.EventArgs e){this.bInsert();}//挿入
		private void buttonL1_Click(object sender, System.EventArgs e){this.bList();}
		private void buttonL2_Click(object sender, System.EventArgs e){this.bDetail();}

#endregion
		
		public void listView1ItemChange(int n,int m){//1.1//item同士の交換
		 Word vWord1=(Word)this.wordList[n];
		 this.wordList[n]=this.wordList[m];
		 this.wordList[m]=vWord1;
		 System.Windows.Forms.ListViewItem item1=(System.Windows.Forms.ListViewItem)this.listView1.Items[n].Clone();
		 this.listView1.Items[n]=(System.Windows.Forms.ListViewItem)this.listView1.Items[m].Clone();
		 this.listView1.Items[m]=item1;
		}

		/*
		public void listView1ItemAddAt(int n){//itemの挿入//1.0;
		 int a=this.listView1.Items.Add(this.makeItem()).Index;//追加
		 int i;for(i=a;i>n;i--)this.listView1ItemChange(i,i-1);//移動
		 while(this.listView1.SelectedItems.Count!=0)this.listView1.SelectedItems[0].Selected=false;//選択解除
		 this.listView1.Items[n].Selected=true;//選択
		}*/
		
		private void listView1_SelectedIndexChanged(object sender, EventArgs e){
			if(this.listView1.SelectedItems.Count!=0){
				string tex=this.listView1.SelectedItems[0].SubItems[7].Text;
				this.statusBar1.Panels[0].Text="例文:"+tex;
			    this.statusBar1.Panels[0].BorderStyle=(tex==" "|tex=="")?System.Windows.Forms.StatusBarPanelBorderStyle.None:System.Windows.Forms.StatusBarPanelBorderStyle.Sunken;
			}
			if(this.listView1.SelectedItems.Count==1){
			 this.buttonB1.Enabled=this.mnC1I3.Enabled=this.menuItem16.Enabled=true;
			 this.buttonB3.Enabled=this.mnC1I5.Enabled=this.menuItem18.Enabled=true;
			 this.buttonB4.Enabled=this.mnC1I6.Enabled=this.menuItem19.Enabled=true;
			 this.button6.Enabled=this.mnC1I8.Enabled=true;
			}else{
			 this.buttonB1.Enabled=this.mnC1I3.Enabled=this.menuItem16.Enabled=false;
			 this.buttonB3.Enabled=this.mnC1I5.Enabled=this.menuItem18.Enabled=false;
			 this.buttonB4.Enabled=this.mnC1I6.Enabled=this.menuItem19.Enabled=false;
			 this.button6.Enabled=this.mnC1I8.Enabled=false;
			}
			
			this.buttonB5.Enabled=(this.listView1.SelectedItems.Count==2);
			this.buttonB2.Enabled=this.mnC1I4.Enabled=this.menuItem17.Enabled=(this.listView1.SelectedItems.Count!=0);
		}
		
		

		//関数
		public Word makeWord(){//1.1
			return new Word(this.editWordCtl1.Word+'|'+this.editWordCtl1.Pronounce,this.editWordCtl1.Part,new string[]{},this.editWordCtl1.Mean,this.textBox3.Text.Split(new char[]{';',','}),this.textBox4.Text.Split(new char[]{'\n'}),0,0);
		}
		
#region 古い関数

		/*
		public System.Windows.Forms.ListViewItem makeItem(){//1.0;
			string sub0="";
			if(this.radioButton2.Checked)sub0="動";
			else if(this.radioButton3.Checked)sub0="副";
			else if(this.radioButton4.Checked)sub0="形";
			else if(this.radioButton5.Checked)sub0="構";
			else if(this.radioButton7.Checked)sub0="助";
			else sub0="名";
			string[] sub=new string[]{this.textBox1.Text,sub0,this.textBox2.Text,this.textBox3.Text,this.label4.Text.Substring(4),this.label5.Text.Substring(4),this.textBox4.Text};
		    return this.makeItem(sub);
		}
		
		public System.Windows.Forms.ListViewItem makeItem(string[] sbItems)//1.0;
		{
			System.Windows.Forms.ListViewItem return1=new System.Windows.Forms.ListViewItem();
			System.Drawing.Color cBlack=System.Drawing.Color.Black;
			System.Drawing.Color cWhite=System.Drawing.Color.White;
			System.Drawing.Font cFont0=new System.Drawing.Font("MS UI Gothic",9);
			System.Drawing.Font cFont1=new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO",9);
			System.Drawing.Font cFont2=new System.Drawing.Font("HG正楷書体-PRO",9);

			//---情報の調整
			//-------単語
			if(return1.SubItems.Count!=0)return1.SubItems[0].Text=(sbItems[0]=="")?" ":sbItems[0];
			//-------品詞
			if(sbItems[1]=="動"){
				return1.SubItems.Add("動",System.Drawing.Color.Black,System.Drawing.Color.FromArgb(255,220,220),cFont0);
				return1.ImageIndex=1;
			}else if(sbItems[1]=="副"){
				return1.SubItems.Add("副",cBlack,System.Drawing.Color.FromArgb(220,220,255),cFont0);
				return1.ImageIndex=3;
			}
			else if(sbItems[1]=="形")
			{
				return1.SubItems.Add("形",cBlack,System.Drawing.Color.FromArgb(220,255,220),cFont0);
				return1.ImageIndex=2;
			}
			else if(sbItems[1]=="構"){
				return1.SubItems.Add("構",cBlack,System.Drawing.Color.FromArgb(220,220,220),cFont0);
				return1.ImageIndex=4;
			}
			else if(sbItems[1]=="助"){
				return1.SubItems.Add("助",cBlack,System.Drawing.Color.FromArgb(255,220,220),cFont0);
				return1.ImageIndex=4;
			}else{
				return1.SubItems.Add("名",cBlack,System.Drawing.Color.FromArgb(255,255,220),cFont0);
				return1.ImageIndex=0;
			}
			//-------意味・参照
			return1.SubItems.Add(sbItems[2]);
			return1.SubItems.Add((sbItems[3]=="")?" ":sbItems[3]);
			//-------出題・正解・正解率
			return1.SubItems.Add(sbItems[4]);
			return1.SubItems.Add(sbItems[5]);
			double num=System.Int32.Parse(return1.SubItems[5].Text);
			double den=System.Int32.Parse(return1.SubItems[4].Text);
			if(den==0)return1.SubItems.Add("不定",cBlack,System.Drawing.Color.Silver,cFont0);else{
		        double vNum=System.Math.Round(num/den*100);
		        int vColGB=(int)(127.5*(1+vNum/100));
		        System.Drawing.Color vCol=System.Drawing.Color.Yellow;
		        if(vColGB>255){
					System.Windows.Forms.MessageBox.Show("次の単語に異常が見られます - "+return1.SubItems[0].Text);
					vColGB=255;
		        }else vCol=System.Drawing.Color.FromArgb(255,vColGB,vColGB);
		        return1.SubItems.Add(vNum.ToString()+"%",cBlack,vCol,cFont0);
			}
			return1.SubItems.Add(sbItems[6].Replace("／","\n"));
			if(sbItems[6]!=""&sbItems[6]!=" ")return1.ImageIndex+=5;
			return1.UseItemStyleForSubItems=false;
			//---登録
			return return1;
		}
		*/
#endregion
		
#region　b
		
		public void bEntry(){//1.1
			if(this.editWordCtl1.Word==""||this.editWordCtl1.Mean=="")return;
			//---登録及び選択
			while(this.listView1.SelectedItems.Count!=0)this.listView1.SelectedItems[0].Selected=false;
			Word vWord=this.makeWord();
			this.listView1.Items.Add(vWord.ToListViewItem()).Selected=true;
			this.wordList.Add(vWord);
			//---初期化
			this.editWordCtl1.Clear();
			this.textBox3.Text="";
			//this.label4.Text="出題数：0";
			//this.label5.Text="正解数：0";
			this.textBox4.Text="";
		}
		public void bEntryN(){this.editWordCtl1.Part=(wordPart)"noun";this.bEntry();}//1.1
		public void bEntryV(){this.editWordCtl1.Part=(wordPart)"verb";this.bEntry();}//1.1
		public void bEntryAd(){this.editWordCtl1.Part=(wordPart)"adverb";this.bEntry();}//1.1
		public void bEntryA(){this.editWordCtl1.Part=(wordPart)"adjective";this.bEntry();}//1.1
		public void bInsert(){//1.1
			if(this.editWordCtl1.Word==""||this.editWordCtl1.Mean=="")return;
			if(this.listView1.SelectedItems.Count==1)
			{	
				Word vWord=this.makeWord();
				int i=this.listView1.SelectedItems[0].Index;
				this.wordList.Insert(i,vWord);
				this.listView1.Items.Insert(i,vWord.ToListViewItem());
				//---登録及び選択
				while(this.listView1.SelectedItems.Count!=0)this.listView1.SelectedItems[0].Selected=false;
				//---初期化
				this.editWordCtl1.Clear();
				this.textBox3.Text="";
				//this.label4.Text="出題数：0";
				//this.label5.Text="正解数：0";
				this.textBox4.Text="";
			}
		}

		public bool bNew(){//1.1
			restart:
			if(this.saveFileDialog1.ShowDialog(this)!=System.Windows.Forms.DialogResult.OK)return false;
			string fname=this.saveFileDialog1.FileName;
			//------ファイル名取得
			string fname2="";
			string vL="";
			for(int i=fname.Length-1;i>=0;i--){
				vL=fname.Substring(i,1);
				if(vL=="\\")break;
				fname2=vL+fname2;
			}
			//----------拡張子調節
			if(this.saveFileDialog1.FilterIndex==1){
				if(fname2.Length<=6||fname.Substring(fname.Length-6,6)!=".w.mwq"){
					fname=fname.Insert(fname.Length-4,".w");
				}
			}
			//------上書き確認処理
			if(System.IO.File.Exists(fname)){
				if(System.Windows.Forms.MessageBox.Show(this,
									fname+" は既に存在します。\n置き換えますか?",
									"ファイル上書き確認",
									System.Windows.Forms.MessageBoxButtons.YesNo,
									System.Windows.Forms.MessageBoxIcon.Exclamation)
									==System.Windows.Forms.DialogResult.No)goto restart;
			}else{
				System.IO.FileStream fs = new System.IO.FileStream(fname, System.IO.FileMode.CreateNew);
				fs.Close();
			}
			//--------フォーム設定
			this.fn=fname;
			this.Text="英単語一覧 - \""+this.fn+"\"";
			this.listView1.Items.Clear();
			this.wordList.Clear();
			this.vMessage("新しいファイル - "+this.fn);
			return true;
		}
		
		public void bSave(){//1.1
			int j=this.listView1.Items.Count-1;
			writeXml wx=new writeXml(this.fn);
			wx.openFile();
			for(int i=0;i<wordList.Count;i++)wx.writeWordData((Word)this.wordList[i]);
			if(wx!=null)wx.closeFile();
			/*file.openW(this.fn);
			int i;System.Windows.Forms.ListViewItem item1;
			for(i=0;i<=j;i++)
			{
				item1=this.listView1.Items[i];
				file.writeNext(item1.SubItems[0].Text,item1.SubItems[1].Text,item1.SubItems[2].Text,item1.SubItems[3].Text,item1.SubItems[4].Text,item1.SubItems[5].Text,item1.SubItems[7].Text.Replace("\n","／"));
			}
			file.closeW();*/
			this.vMessage("単語を "+this.fn+" に保存しました。");
		}
		
		public bool bRead(){//1.1
			if(System.Windows.Forms.DialogResult.OK!=this.openFileDialog1.ShowDialog())return false;
			
			fn=this.openFileDialog1.FileName;
			this.Text="英単語一覧 - \""+this.fn+"\"";
			
			char[] sep=new char[]{'/'};
			this.listView1.Items.Clear();this.wordList.Clear();
			if(!file.openR(this.fn))return false;
			Word vWord;
			
			while(true)
			{
				string dat=file.nextWord();
				if(dat==null||dat==""){
					file.closeR();
					break;
				}else if(dat.StartsWith("<?xml")){
					this.vMessage("単語帳はXML形式で読み込まれます。");
					file.closeR();
					//--->>> to read xml file
					readXml rx=new readXml(this.fn);
					rx.openFile();
					while((vWord=rx.readWordData()).word!="FileEnd"||vWord.mean!="FileEnd"){
						this.wordList.Add(vWord);
					}
					if(rx!=null)rx.closeFile();
					//---<<< having read xml file
					break;
				}
				string[] sub=dat.Split(sep,7);
				this.wordList.Add(new Word(sub[0],(wordPart)sub[1],new string[]{}
											,sub[2],sub[3].Split(new char[]{';',','}),sub[6].Split(new char[]{';'})
											,System.Int32.Parse(sub[4]),System.Int32.Parse(sub[5])));
			}
			if(this.wordList.Count!=0)for(int iwl=0;iwl<this.wordList.Count;iwl++){
				vWord=(Word)this.wordList[iwl];
				this.listView1.Items.Add(vWord.ToListViewItem());
			}
			this.vMessage("単語の情報を "+this.fn+" から読み込みました");
			return true;
		}
		
		
		public void bEdit(){//1.0 → プロパティページで編集できるようにする。
			if(this.listView1.SelectedItems.Count!=1)return;
			System.Windows.Forms.ListViewItem item1=this.listView1.SelectedItems[0];
			//--編集する情報を読み取り
			英単語の練習.Word word0=(英単語の練習.Word)this.wordList[this.listView1.SelectedItems[0].Index];
			this.wordList.RemoveAt(this.listView1.SelectedItems[0].Index);
			this.listView1.SelectedItems[0].Remove();
			//--元々のデータを登録
			if(this.editWordCtl1.Word!=""&&this.editWordCtl1.Mean!="")this.button1_Click(new object(),new System.EventArgs());
			//--編集する情報を表示
			this.editWordCtl1.setWord(word0);//※情報(例文など)が失われます
		}
		/*
		public void bEdit(){//1.0
			if(this.listView1.SelectedItems.Count!=1)return;
			System.Windows.Forms.ListViewItem item1=this.listView1.SelectedItems[0];
			if(this.editWordCtl1.Word!=""&this.editWordCtl1.Mean!="")this.button1_Click(new object(),new System.EventArgs());//元々のデータを登録
			this.textBox1.Text=item1.SubItems[0].Text;
			this.textBox2.Text=item1.SubItems[2].Text;
			this.textBox3.Text=item1.SubItems[3].Text;
			switch(item1.SubItems[1].Text)
			{
				case "名":
					this.radioButton1.Checked=true;
					break;
				case "動":
					this.radioButton2.Checked=true;
					break;
				case "副":
					this.radioButton3.Checked=true;
					break;
				case "形":
					this.radioButton4.Checked=true;
					break;
			}
			this.label4.Text="出題数："+item1.SubItems[4].Text;
			this.label5.Text="正解数："+item1.SubItems[5].Text;
			this.textBox4.Text=item1.SubItems[7].Text;
			this.listView1.SelectedItems[0].Remove();
		}*/
		
		public void bEditWord(){//1.1
			if(this.listView1.SelectedItems.Count!=0){
				frmInput1=new frmInput(this,this.listView1.SelectedItems[0].Index,"単語");
				frmInput1.ShowDialog(this);
			}
		}
		public void bEditMean(){//1.1
			if(this.listView1.SelectedItems.Count!=0)
			{
				frmInput1=new frmInput(this,this.listView1.SelectedItems[0].Index,"意味");
				frmInput1.ShowDialog(this);
			}
		}
		/*public void bEditRef()//1.0
		{
			if(this.listView1.SelectedItems.Count!=0)
			{
				frmInput1=new frmInput(ref this.listView1,this.listView1.SelectedItems[0].Index,"参照");
				frmInput1.ShowDialog(this);
			}
		}*/
		public void bEditExmp(){//1.1
			if(this.listView1.SelectedItems.Count!=0)
			{
				frmInput1=new frmInput(this,this.listView1.SelectedItems[0].Index,"例文");
				frmInput1.ShowDialog(this);
			}
		}

		public void bDel(){//1.1
			while(this.listView1.SelectedItems.Count!=0){
				this.wordList.RemoveAt(this.listView1.SelectedItems[0].Index);
				this.listView1.SelectedItems[0].Remove();
			}
		}
		
		public void bUp(){//1.1
			int n;
			if(this.listView1.SelectedItems.Count==1&&(n=this.listView1.SelectedItems[0].Index)>0)
			{
				this.listView1ItemChange(n,n-1);
				this.listView1.Items[n].Selected=false;
				this.listView1.Items[n-1].Selected=true;
			}
		}
		
		public void bDown(){//1.1
			int n;
			if(this.listView1.SelectedItems.Count==1&&(n=this.listView1.SelectedItems[0].Index)<this.listView1.Items.Count-1)
			{
				this.listView1ItemChange(n,n+1);
				this.listView1.Items[n].Selected=false;
				this.listView1.Items[n+1].Selected=true;
			}
		}
		
		public void bDetail(){//1.1
			if(this.listView1.View!=System.Windows.Forms.View.Details){
				this.listView1.View=System.Windows.Forms.View.Details;
				this.menuItem22.Checked=false;//[22]一覧
				this.menuItem23.Checked=true;//[23]詳細
			}
		}
		public void bList(){//1.1
			if(this.listView1.View!=System.Windows.Forms.View.List){
				this.listView1.View=System.Windows.Forms.View.List;
				this.menuItem22.Checked=true;//[22]一覧
				this.menuItem23.Checked=false;//[23]詳細
			}
		}
		
		public void bLetter(string a){//1.1
			System.Windows.Forms.TextBox txtBox;//現在のテキストボックスを取得
			if(this.textBox3.Focused){
				txtBox=this.textBox3;
			}else if(this.textBox4.Focused){
				txtBox=this.textBox4;
			}else return;
			int n1=txtBox.SelectionStart;
			txtBox.SelectedText="";
			if(0<=n1&&n1<txtBox.TextLength){
				txtBox.Text=txtBox.Text.Substring(0,n1)+a+txtBox.Text.Substring(n1);
				txtBox.SelectionStart=n1+1;
			}else{
				txtBox.AppendText(a);
				txtBox.SelectionStart=txtBox.TextLength;
			}
		}
		
		public void vMessage(string a){this.labMsg.Text="　　("+System.DateTime.Now.ToShortTimeString()+")"+a;}
#endregion	
		
#region textBox　EventHandler

		public System.Drawing.Color col_g1=System.Drawing.Color.FromArgb(0,192,0);
		public System.Drawing.Color col_g2=System.Drawing.Color.Gray;
		public System.Windows.Forms.ImeMode ime_h=System.Windows.Forms.ImeMode.Hiragana;

		private void textBox3_ImeModeChanged(object sender, EventArgs e)		{
			this.labText3.BackColor=(this.textBox3.ImeMode==this.ime_h)?this.col_g1:this.col_g2;
		}
		
#endregion//---------------------endregion

		private void menuItem3_Click(object sender, System.EventArgs e){this.bRead();}
		private void menuItem4_Click(object sender, System.EventArgs e){this.bSave();}
		private void menuItem6_Click(object sender, System.EventArgs e){this.editWordCtl1.FocusOn(1);}
		private void menuItem7_Click(object sender, System.EventArgs e){this.editWordCtl1.FocusOn(2);}
		private void menuItem8_Click(object sender, System.EventArgs e){this.textBox3.Focus();}
		private void menuItem9_Click(object sender, System.EventArgs e){this.textBox4.Focus();}
		private void menuItem11_Click(object sender, System.EventArgs e){this.editWordCtl1.Part=(wordPart)"noun";}
		private void menuItem12_Click(object sender, System.EventArgs e){this.editWordCtl1.Part=(wordPart)"verb";}
		private void menuItem13_Click(object sender, System.EventArgs e){this.editWordCtl1.Part=(wordPart)"adverb";}
		private void menuItem14_Click(object sender, System.EventArgs e){this.editWordCtl1.Part=(wordPart)"adjective";}
		private void menuItem16_Click(object sender, System.EventArgs e){this.bEdit();}
		private void menuItem17_Click(object sender, System.EventArgs e){this.bDel();}
		private void menuItem18_Click(object sender, System.EventArgs e){this.bUp();}
		private void menuItem19_Click(object sender, System.EventArgs e){this.bDown();}
		private void menuItem22_Click(object sender, System.EventArgs e){this.bList();}
		private void menuItem23_Click(object sender, System.EventArgs e){this.bDetail();}
		private void menuItem26_Click(object sender, System.EventArgs e){this.bEntry();}
		private void menuItem34_Click(object sender, System.EventArgs e){this.bEntryN();}
		private void menuItem35_Click(object sender, System.EventArgs e){this.bEntryV();}
		private void menuItem36_Click(object sender, System.EventArgs e){this.bEntryAd();}
		private void menuItem38_Click(object sender, System.EventArgs e){this.bEntryA();}
		
		private void mnC1I1I1_Click(object sender, System.EventArgs e){this.bEditWord();}
		private void mnC1I1I3_Click(object sender, System.EventArgs e){this.bEditMean();}
		private void mnC1I1I4_Click(object sender, System.EventArgs e){/*this.bEditRef();*/}
		private void mnC1I1I5_Click(object sender, System.EventArgs e){this.bEditExmp();}
		private void mnC1I3_Click(object sender, System.EventArgs e){this.bEdit();}
		private void mnC1I4_Click(object sender, System.EventArgs e){this.bDel();}
		private void mnC1I5_Click(object sender, System.EventArgs e){this.bUp();}
		private void mnC1I6_Click(object sender, System.EventArgs e){this.bDown();}
		private void mnC1I8_Click(object sender, System.EventArgs e){this.bInsert();}

		private void buttonE1_Click(object sender, System.EventArgs e){this.bEntryN();}
		private void buttonE2_Click(object sender, System.EventArgs e){this.bEntryV();}
		private void buttonE3_Click(object sender, System.EventArgs e){this.bEntryAd();}
		private void buttonE4_Click(object sender, System.EventArgs e){this.bEntryA();}

		private void mnML1_Click(object sender, System.EventArgs e){this.bLetter(ltr1[0]);}
		private void mnML2_Click(object sender, System.EventArgs e){this.bLetter(ltr1[1]);}
		private void mnML3_Click(object sender, System.EventArgs e){this.bLetter(ltr1[2]);}
		private void mnML4_Click(object sender, System.EventArgs e){this.bLetter(ltr1[3]);}
		private void mnML5_Click(object sender, System.EventArgs e){this.bLetter(ltr1[4]);}
		private void mnML6_Click(object sender, System.EventArgs e){this.bLetter(ltr1[5]);}
		private void mnML7_Click(object sender, System.EventArgs e){this.bLetter(ltr1[6]);}
		private void mnML8_Click(object sender, System.EventArgs e){this.bLetter(ltr1[7]);}
		private void mnML9_Click(object sender, System.EventArgs e){this.bLetter(ltr1[8]);}
		private void mnML10_Click(object sender, System.EventArgs e){this.bLetter(ltr1[9]);}
		private void menuItem28_Click(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count!=0){
				this.listView1.SelectedItems[0].SubItems[1].Text="名";
				this.listView1.SelectedItems[0].ImageIndex=(this.listView1.SelectedItems[0].SubItems[7].Text=="")?0:5;
			}
		}

		private void menuItem29_Click(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count!=0)
			{
				this.listView1.SelectedItems[0].SubItems[1].Text="動";
				this.listView1.SelectedItems[0].ImageIndex=(this.listView1.SelectedItems[0].SubItems[7].Text=="")?1:6;
			}
		}

		private void menuItem30_Click(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count!=0)
			{
				this.listView1.SelectedItems[0].SubItems[1].Text="形";
				this.listView1.SelectedItems[0].ImageIndex=(this.listView1.SelectedItems[0].SubItems[7].Text=="")?2:7;
			}
		}

		private void menuItem31_Click(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count!=0)
			{
				this.listView1.SelectedItems[0].SubItems[1].Text="副";
				this.listView1.SelectedItems[0].ImageIndex=(this.listView1.SelectedItems[0].SubItems[7].Text=="")?3:8;
			}
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(e.Button.ImageIndex){
				case(4):
					this.bNew();
					break;
				case(5)://読込
					this.bRead();
					break;
				case(6)://保存
					this.bSave();
					break;
			}
		}
		public void jikkenn(){
			//this.components.
		}
		
	}
	
	//=========== class File ================
	
	public class file{
	 public static System.IO.StreamReader sr;
	 public static bool openR(string file){
	  try{
	   sr=new System.IO.StreamReader(file);
	   }
	  catch{
	   if(file==""){System.Windows.Forms.MessageBox.Show("ファイル名がまだ入力されていません。入力をしてからにしてください。");return false;}
	   System.Windows.Forms.MessageBox.Show("正しく読み込むことが出来ませんでした。\nファイル名が入力されているか確認してください。");
	   return false;
	   }
	  return true;
	  }
	 public static string nextWord(){
	  return sr.ReadLine();
	  }
	 public static void closeR(){sr.Close();}
	 
	 public static System.IO.StreamWriter sw;
	 public static void openW(string file){
	  sw=new System.IO.StreamWriter(file);
	 }
	 public static void writeNext(string a,string b,string c,string d,string e,string f,string g){
	  sw.WriteLine(a+"/"+b+"/"+c+"/"+d+"/"+e+"/"+f+"/"+g);
	 }
	 public static void closeW(){sw.Close();}
	}	
}
