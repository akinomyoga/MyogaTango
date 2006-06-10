using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace 英単語の練習{
	/// <summary>
	/// frmWordEdit の概要の説明です。
	/// </summary>
	public class frmWordEdit : System.Windows.Forms.Form{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabWordDat;
		private System.Windows.Forms.TabPage tabRefer;
		private System.Windows.Forms.TabPage tabExample;
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.Button bOKNext;
		private System.Windows.Forms.Button bOKPrev;
		private System.Windows.Forms.Button bOKNextNew;
		private System.Windows.Forms.Button bOKPrevNew;
		private System.Windows.Forms.Button bCancelPrevNew;
		private System.Windows.Forms.Button bCancelNextNew;
		private System.Windows.Forms.Button bCancelPrev;
		private System.Windows.Forms.Button bCancelNext;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.Button bApply;
		private System.Windows.Forms.Button bDel;
		private System.Windows.Forms.Button bUp;
		private System.Windows.Forms.Button bDown;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader clmType;
		private System.Windows.Forms.ColumnHeader clmWord;
		private System.Windows.Forms.ColumnHeader clmPron;
		private System.Windows.Forms.Button bRefAdd;
		private System.Windows.Forms.Button bRefDel;
		private System.Windows.Forms.Button bRefUp;
		private System.Windows.Forms.Button bRefDown;
		private 英単語の練習.editWordCtl editWordCtl;
		private 英単語の練習.editWordCtl editWordCtl1;
		private System.Windows.Forms.ColumnHeader clmMean;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		
		public frmWordEdit(){
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
		}
		public frmWordEdit(ref 英単語の練習.Word word){
			InitializeComponent();
			this.word1=word;
			this.word2=this.word1;
			//this.propertyGrid1.SelectedObject=this.word1;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmWordEdit));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabWordDat = new System.Windows.Forms.TabPage();
			this.editWordCtl = new 英単語の練習.editWordCtl();
			this.tabRefer = new System.Windows.Forms.TabPage();
			this.editWordCtl1 = new 英単語の練習.editWordCtl();
			this.bRefDown = new System.Windows.Forms.Button();
			this.bRefUp = new System.Windows.Forms.Button();
			this.bRefDel = new System.Windows.Forms.Button();
			this.bRefAdd = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.clmWord = new System.Windows.Forms.ColumnHeader();
			this.clmType = new System.Windows.Forms.ColumnHeader();
			this.clmPron = new System.Windows.Forms.ColumnHeader();
			this.clmMean = new System.Windows.Forms.ColumnHeader();
			this.tabExample = new System.Windows.Forms.TabPage();
			this.bOK = new System.Windows.Forms.Button();
			this.bOKNext = new System.Windows.Forms.Button();
			this.bOKPrev = new System.Windows.Forms.Button();
			this.bOKNextNew = new System.Windows.Forms.Button();
			this.bOKPrevNew = new System.Windows.Forms.Button();
			this.bCancelPrevNew = new System.Windows.Forms.Button();
			this.bCancelNextNew = new System.Windows.Forms.Button();
			this.bCancelPrev = new System.Windows.Forms.Button();
			this.bCancelNext = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.bApply = new System.Windows.Forms.Button();
			this.bDel = new System.Windows.Forms.Button();
			this.bUp = new System.Windows.Forms.Button();
			this.bDown = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabWordDat.SuspendLayout();
			this.tabRefer.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabWordDat);
			this.tabControl1.Controls.Add(this.tabRefer);
			this.tabControl1.Controls.Add(this.tabExample);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(568, 304);
			this.tabControl1.TabIndex = 0;
			// 
			// tabWordDat
			// 
			this.tabWordDat.Controls.Add(this.editWordCtl);
			this.tabWordDat.Location = new System.Drawing.Point(4, 21);
			this.tabWordDat.Name = "tabWordDat";
			this.tabWordDat.Size = new System.Drawing.Size(560, 279);
			this.tabWordDat.TabIndex = 0;
			this.tabWordDat.Text = "単語";
			this.tabWordDat.ToolTipText = "単語の基本的な情報を入力します";
			// 
			// editWordCtl
			// 
			this.editWordCtl.ForeColor = System.Drawing.SystemColors.ControlText;
			this.editWordCtl.Location = new System.Drawing.Point(8, 8);
			this.editWordCtl.Mean = "";
			this.editWordCtl.Name = "editWordCtl";
			this.editWordCtl.Pronounce = "";
			this.editWordCtl.Size = new System.Drawing.Size(272, 200);
			this.editWordCtl.TabIndex = 0;
			this.editWordCtl.Word = "";
			this.editWordCtl.MeanChanged += new 英単語の練習.editWordCtl.TextChangedEventHandler(this.editWordCtl_MeanChanged);
			this.editWordCtl.PronChanged += new 英単語の練習.editWordCtl.TextChangedEventHandler(this.editWordCtl_PronChanged);
			this.editWordCtl.WordChanged += new 英単語の練習.editWordCtl.TextChangedEventHandler(this.editWordCtl_WordChanged);
			this.editWordCtl.PartChanged += new 英単語の練習.editWordCtl.PartChangedEventHandler(this.editWordCtl_PartChanged);
			// 
			// tabRefer
			// 
			this.tabRefer.Controls.Add(this.editWordCtl1);
			this.tabRefer.Controls.Add(this.bRefDown);
			this.tabRefer.Controls.Add(this.bRefUp);
			this.tabRefer.Controls.Add(this.bRefDel);
			this.tabRefer.Controls.Add(this.bRefAdd);
			this.tabRefer.Controls.Add(this.listView1);
			this.tabRefer.Location = new System.Drawing.Point(4, 21);
			this.tabRefer.Name = "tabRefer";
			this.tabRefer.Size = new System.Drawing.Size(560, 279);
			this.tabRefer.TabIndex = 1;
			this.tabRefer.Text = "参照";
			this.tabRefer.ToolTipText = "参照する単語の設定を行います";
			// 
			// editWordCtl1
			// 
			this.editWordCtl1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.editWordCtl1.Location = new System.Drawing.Point(280, 72);
			this.editWordCtl1.Mean = "";
			this.editWordCtl1.Name = "editWordCtl1";
			this.editWordCtl1.Pronounce = "";
			this.editWordCtl1.Size = new System.Drawing.Size(272, 200);
			this.editWordCtl1.TabIndex = 9;
			this.editWordCtl1.Word = "";
			// 
			// bRefDown
			// 
			this.bRefDown.Image = ((System.Drawing.Image)(resources.GetObject("bRefDown.Image")));
			this.bRefDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bRefDown.Location = new System.Drawing.Point(368, 40);
			this.bRefDown.Name = "bRefDown";
			this.bRefDown.Size = new System.Drawing.Size(80, 24);
			this.bRefDown.TabIndex = 4;
			this.bRefDown.Text = "下へ(&D)";
			// 
			// bRefUp
			// 
			this.bRefUp.Image = ((System.Drawing.Image)(resources.GetObject("bRefUp.Image")));
			this.bRefUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bRefUp.Location = new System.Drawing.Point(368, 8);
			this.bRefUp.Name = "bRefUp";
			this.bRefUp.Size = new System.Drawing.Size(80, 24);
			this.bRefUp.TabIndex = 3;
			this.bRefUp.Text = "上へ(&U)";
			// 
			// bRefDel
			// 
			this.bRefDel.Image = ((System.Drawing.Image)(resources.GetObject("bRefDel.Image")));
			this.bRefDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bRefDel.Location = new System.Drawing.Point(280, 40);
			this.bRefDel.Name = "bRefDel";
			this.bRefDel.Size = new System.Drawing.Size(80, 24);
			this.bRefDel.TabIndex = 2;
			this.bRefDel.Text = " 削除(&R)";
			// 
			// bRefAdd
			// 
			this.bRefAdd.Location = new System.Drawing.Point(280, 8);
			this.bRefAdd.Name = "bRefAdd";
			this.bRefAdd.Size = new System.Drawing.Size(80, 24);
			this.bRefAdd.TabIndex = 1;
			this.bRefAdd.Text = "追加(&A)";
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.clmWord,
																						this.clmType,
																						this.clmPron,
																						this.clmMean});
			this.listView1.Location = new System.Drawing.Point(8, 8);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(264, 264);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// clmWord
			// 
			this.clmWord.Text = "参照単語";
			this.clmWord.Width = 100;
			// 
			// clmType
			// 
			this.clmType.Text = "種類";
			// 
			// clmPron
			// 
			this.clmPron.Text = "発音";
			this.clmPron.Width = 0;
			// 
			// clmMean
			// 
			this.clmMean.Text = "意味";
			this.clmMean.Width = 100;
			// 
			// tabExample
			// 
			this.tabExample.Location = new System.Drawing.Point(4, 21);
			this.tabExample.Name = "tabExample";
			this.tabExample.Size = new System.Drawing.Size(560, 279);
			this.tabExample.TabIndex = 2;
			this.tabExample.Text = "例文";
			// 
			// bOK
			// 
			this.bOK.Location = new System.Drawing.Point(56, 320);
			this.bOK.Name = "bOK";
			this.bOK.Size = new System.Drawing.Size(64, 24);
			this.bOK.TabIndex = 1;
			this.bOK.Text = "&OK";
			// 
			// bOKNext
			// 
			this.bOKNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bOKNext.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.bOKNext.Image = ((System.Drawing.Image)(resources.GetObject("bOKNext.Image")));
			this.bOKNext.Location = new System.Drawing.Point(120, 320);
			this.bOKNext.Name = "bOKNext";
			this.bOKNext.Size = new System.Drawing.Size(24, 24);
			this.bOKNext.TabIndex = 2;
			// 
			// bOKPrev
			// 
			this.bOKPrev.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bOKPrev.Image = ((System.Drawing.Image)(resources.GetObject("bOKPrev.Image")));
			this.bOKPrev.Location = new System.Drawing.Point(32, 320);
			this.bOKPrev.Name = "bOKPrev";
			this.bOKPrev.Size = new System.Drawing.Size(24, 24);
			this.bOKPrev.TabIndex = 3;
			// 
			// bOKNextNew
			// 
			this.bOKNextNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bOKNextNew.Image = ((System.Drawing.Image)(resources.GetObject("bOKNextNew.Image")));
			this.bOKNextNew.Location = new System.Drawing.Point(144, 320);
			this.bOKNextNew.Name = "bOKNextNew";
			this.bOKNextNew.Size = new System.Drawing.Size(24, 24);
			this.bOKNextNew.TabIndex = 4;
			// 
			// bOKPrevNew
			// 
			this.bOKPrevNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bOKPrevNew.Image = ((System.Drawing.Image)(resources.GetObject("bOKPrevNew.Image")));
			this.bOKPrevNew.Location = new System.Drawing.Point(8, 320);
			this.bOKPrevNew.Name = "bOKPrevNew";
			this.bOKPrevNew.Size = new System.Drawing.Size(24, 24);
			this.bOKPrevNew.TabIndex = 5;
			// 
			// bCancelPrevNew
			// 
			this.bCancelPrevNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bCancelPrevNew.Image = ((System.Drawing.Image)(resources.GetObject("bCancelPrevNew.Image")));
			this.bCancelPrevNew.Location = new System.Drawing.Point(176, 320);
			this.bCancelPrevNew.Name = "bCancelPrevNew";
			this.bCancelPrevNew.Size = new System.Drawing.Size(24, 24);
			this.bCancelPrevNew.TabIndex = 10;
			// 
			// bCancelNextNew
			// 
			this.bCancelNextNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bCancelNextNew.Image = ((System.Drawing.Image)(resources.GetObject("bCancelNextNew.Image")));
			this.bCancelNextNew.Location = new System.Drawing.Point(312, 320);
			this.bCancelNextNew.Name = "bCancelNextNew";
			this.bCancelNextNew.Size = new System.Drawing.Size(24, 24);
			this.bCancelNextNew.TabIndex = 9;
			// 
			// bCancelPrev
			// 
			this.bCancelPrev.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bCancelPrev.Image = ((System.Drawing.Image)(resources.GetObject("bCancelPrev.Image")));
			this.bCancelPrev.Location = new System.Drawing.Point(200, 320);
			this.bCancelPrev.Name = "bCancelPrev";
			this.bCancelPrev.Size = new System.Drawing.Size(24, 24);
			this.bCancelPrev.TabIndex = 8;
			// 
			// bCancelNext
			// 
			this.bCancelNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bCancelNext.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.bCancelNext.Image = ((System.Drawing.Image)(resources.GetObject("bCancelNext.Image")));
			this.bCancelNext.Location = new System.Drawing.Point(288, 320);
			this.bCancelNext.Name = "bCancelNext";
			this.bCancelNext.Size = new System.Drawing.Size(24, 24);
			this.bCancelNext.TabIndex = 7;
			// 
			// bCancel
			// 
			this.bCancel.Location = new System.Drawing.Point(224, 320);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(64, 24);
			this.bCancel.TabIndex = 6;
			this.bCancel.Text = "&Cancel";
			// 
			// bApply
			// 
			this.bApply.Location = new System.Drawing.Point(344, 320);
			this.bApply.Name = "bApply";
			this.bApply.Size = new System.Drawing.Size(72, 24);
			this.bApply.TabIndex = 11;
			this.bApply.Text = "&Apply";
			// 
			// bDel
			// 
			this.bDel.Image = ((System.Drawing.Image)(resources.GetObject("bDel.Image")));
			this.bDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bDel.Location = new System.Drawing.Point(584, 8);
			this.bDel.Name = "bDel";
			this.bDel.Size = new System.Drawing.Size(96, 24);
			this.bDel.TabIndex = 12;
			this.bDel.Text = "削除(Del)";
			// 
			// bUp
			// 
			this.bUp.Image = ((System.Drawing.Image)(resources.GetObject("bUp.Image")));
			this.bUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bUp.Location = new System.Drawing.Point(584, 40);
			this.bUp.Name = "bUp";
			this.bUp.Size = new System.Drawing.Size(96, 24);
			this.bUp.TabIndex = 13;
			this.bUp.Text = "前へ(&U)";
			// 
			// bDown
			// 
			this.bDown.Image = ((System.Drawing.Image)(resources.GetObject("bDown.Image")));
			this.bDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bDown.Location = new System.Drawing.Point(584, 72);
			this.bDown.Name = "bDown";
			this.bDown.Size = new System.Drawing.Size(96, 24);
			this.bDown.TabIndex = 14;
			this.bDown.Text = "後ろへ(&D)";
			// 
			// frmWordEdit
			// 
			this.AcceptButton = this.bOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(682, 351);
			this.Controls.Add(this.bDown);
			this.Controls.Add(this.bUp);
			this.Controls.Add(this.bDel);
			this.Controls.Add(this.bApply);
			this.Controls.Add(this.bOKPrevNew);
			this.Controls.Add(this.bOKNextNew);
			this.Controls.Add(this.bOKPrev);
			this.Controls.Add(this.bOKNext);
			this.Controls.Add(this.bOK);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.bCancelNextNew);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bCancelNext);
			this.Controls.Add(this.bCancelPrevNew);
			this.Controls.Add(this.bCancelPrev);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmWordEdit";
			this.ShowInTaskbar = false;
			this.Text = "単語の編集";
			this.tabControl1.ResumeLayout(false);
			this.tabWordDat.ResumeLayout(false);
			this.tabRefer.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		//=====================================
		//          fields
		//-------------------------------------
		private readonly System.Drawing.Color colImeOn=System.Drawing.Color.FromArgb(0,192,0);
		private readonly System.Drawing.Color colImeOff=System.Drawing.Color.Gray;
		//private readonly System.Windows.Forms.ImeMode imeHira=System.Windows.Forms.ImeMode.Hiragana;
		/// <summary>変更を加える前の英単語の情報</summary>
		public 英単語の練習.Word word1;//元の英単語
		/// <summary>変更を加えた後の英単語の情報</summary>
		public 英単語の練習.Word word2;

		private void editWordCtl_WordChanged(object sender, 英単語の練習.TextChangedEventArgs e){word2.word=e.text;}
		private void editWordCtl_PronChanged(object sender, 英単語の練習.TextChangedEventArgs e){word2.pron=e.text;}
		private void editWordCtl_PartChanged(object sender, 英単語の練習.PartChangedEventArgs e){word2.part=e.part;}
		private void editWordCtl_MeanChanged(object sender, 英単語の練習.TextChangedEventArgs e){word2.mean=e.text;}
		

	}
}
