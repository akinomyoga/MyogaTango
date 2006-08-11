using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace mwgWords{
	/// <summary>
	/// EngEditMean の概要の説明です。
	/// </summary>
	public class EngEditMean : System.Windows.Forms.UserControl{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox bxType;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckedListBox chkbxAttr;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckedListBox chkbxUsage;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabMean;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ImageList imgConj;
		private System.Windows.Forms.ImageList imgTab;
		private System.ComponentModel.IContainer components;

		public EngEditMean(){
			InitializeComponent();
		}
		public EngEditMean(EngWord.mean target){
			InitializeComponent();

			this.mean=target;
			this.bxType.Text=this.bxType.Items[(int)this.mean.type].ToString();
            this.textBox1.Text=target.content;

			for(int i=0;i<19;i++){
				this.chkbxAttr.SetItemChecked(i,this.getAttr(i));
			}
			/*
			this.chkbxAttr.SetItemChecked(0,target.Proper);
			this.chkbxAttr.SetItemChecked(1,target.Collective);
			this.chkbxAttr.SetItemChecked(2,target.Abstract);
			this.chkbxAttr.SetItemChecked(3,target.Material);
			this.chkbxAttr.SetItemChecked(4,target.SV);
			this.chkbxAttr.SetItemChecked(5,target.SVC);
			this.chkbxAttr.SetItemChecked(6,target.SVO);
			this.chkbxAttr.SetItemChecked(7,target.SVOO);
			this.chkbxAttr.SetItemChecked(8,target.SVOC);
			this.chkbxAttr.SetItemChecked(9,target.Reflexive);
			this.chkbxAttr.SetItemChecked(10,target.Causative);
			this.chkbxAttr.SetItemChecked(11,target.Factive);
			this.chkbxAttr.SetItemChecked(12,target.Stative);
			this.chkbxAttr.SetItemChecked(13,target.Sensational);
			this.chkbxAttr.SetItemChecked(14,target.Interrogative);
			this.chkbxAttr.SetItemChecked(15,target.RelativePronoun);
			this.chkbxAttr.SetItemChecked(16,target.RelativeAdverb);
			this.chkbxAttr.SetItemChecked(17,target.Phrase);
			this.chkbxAttr.SetItemChecked(18,target.Clause);
			*/
			this.chkbxUsage.SetItemChecked(0,target.Nominal);
			this.chkbxUsage.SetItemChecked(1,target.PluralNominal);
			this.chkbxUsage.SetItemChecked(2,target.Attributive);
			this.chkbxUsage.SetItemChecked(3,target.Predicative);
			this.chkbxUsage.SetItemChecked(4,target.Adjunct);
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

		#region コンポーネント デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EngEditMean));
			this.label1 = new System.Windows.Forms.Label();
			this.bxType = new System.Windows.Forms.ComboBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.chkbxAttr = new System.Windows.Forms.CheckedListBox();
			this.chkbxUsage = new System.Windows.Forms.CheckedListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabMean = new System.Windows.Forms.TabPage();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.imgConj = new System.Windows.Forms.ImageList(this.components);
			this.imgTab = new System.Windows.Forms.ImageList(this.components);
			this.tabControl1.SuspendLayout();
			this.tabMean.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "品詞";
			// 
			// bxType
			// 
			this.bxType.Items.AddRange(new object[] {
														"なし",
														"名詞",
														"動詞",
														"形容詞",
														"副詞",
														"前置詞",
														"代名詞",
														"接続詞",
														"助動詞",
														"間投詞",
														"冠詞",
														"熟語",
														"構文"});
			this.bxType.Location = new System.Drawing.Point(40, 8);
			this.bxType.Name = "bxType";
			this.bxType.Size = new System.Drawing.Size(120, 20);
			this.bxType.TabIndex = 2;
			this.bxType.Text = "なし";
			this.bxType.TextChanged += new System.EventHandler(this.bxType_TextChanged);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(40, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(264, 19);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "";
			this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "意味";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "属性";
			// 
			// chkbxAttr
			// 
			this.chkbxAttr.CheckOnClick = true;
			this.chkbxAttr.Items.AddRange(new object[] {
														   "固有",
														   "集合名詞",
														   "不可算名詞(抽象)",
														   "不可算名詞(物質)",
														   "自動詞(SV)",
														   "自動詞(連結) (SVC)",
														   "他動詞(SVO)",
														   "他動詞(SVOO)",
														   "他動詞(SVOC)",
														   "再帰動詞 reflexible",
														   "使役動詞",
														   "作為動詞 factive",
														   "状態動詞 stative",
														   "知覚動詞 sensational?",
														   "疑問詞",
														   "関係代名詞",
														   "関係副詞",
														   "句(前置詞句、形容詞句、副詞句)",
														   "節(不定詞節、関係使節)"});
			this.chkbxAttr.Location = new System.Drawing.Point(40, 56);
			this.chkbxAttr.Name = "chkbxAttr";
			this.chkbxAttr.Size = new System.Drawing.Size(264, 88);
			this.chkbxAttr.TabIndex = 6;
			this.chkbxAttr.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkbxAttr_ItemCheck);
			// 
			// chkbxUsage
			// 
			this.chkbxUsage.CheckOnClick = true;
			this.chkbxUsage.Items.AddRange(new object[] {
															"名詞的用法(単数)",
															"名詞的用法(複数)",
															"形容詞的用法(限定)",
															"形容詞的用法(叙述)",
															"副詞的用法"});
			this.chkbxUsage.Location = new System.Drawing.Point(40, 152);
			this.chkbxUsage.Name = "chkbxUsage";
			this.chkbxUsage.Size = new System.Drawing.Size(264, 88);
			this.chkbxUsage.TabIndex = 8;
			this.chkbxUsage.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkbxUsage_ItemCheck);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(0, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "用法";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabMean);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ImageList = this.imgTab;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(320, 272);
			this.tabControl1.TabIndex = 9;
			// 
			// tabMean
			// 
			this.tabMean.Controls.Add(this.label1);
			this.tabMean.Controls.Add(this.bxType);
			this.tabMean.Controls.Add(this.textBox1);
			this.tabMean.Controls.Add(this.label2);
			this.tabMean.Controls.Add(this.label3);
			this.tabMean.Controls.Add(this.chkbxAttr);
			this.tabMean.Controls.Add(this.chkbxUsage);
			this.tabMean.Controls.Add(this.label4);
			this.tabMean.ImageIndex = 0;
			this.tabMean.Location = new System.Drawing.Point(4, 23);
			this.tabMean.Name = "tabMean";
			this.tabMean.Size = new System.Drawing.Size(312, 245);
			this.tabMean.TabIndex = 0;
			this.tabMean.Text = "意味";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.listView1);
			this.tabPage1.ImageIndex = 1;
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(312, 245);
			this.tabPage1.TabIndex = 1;
			this.tabPage1.Text = "活用";
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader1});
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.Location = new System.Drawing.Point(8, 8);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(296, 144);
			this.listView1.SmallImageList = this.imgConj;
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "綴り";
			this.columnHeader2.Width = 77;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "発音";
			this.columnHeader3.Width = 71;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "説明";
			this.columnHeader1.Width = 135;
			// 
			// imgConj
			// 
			this.imgConj.ImageSize = new System.Drawing.Size(12, 12);
			this.imgConj.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgConj.ImageStream")));
			this.imgConj.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// imgTab
			// 
			this.imgTab.ImageSize = new System.Drawing.Size(16, 16);
			this.imgTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTab.ImageStream")));
			this.imgTab.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// EngEditMean
			// 
			this.AutoScroll = true;
			this.Controls.Add(this.tabControl1);
			this.Name = "EngEditMean";
			this.Size = new System.Drawing.Size(320, 272);
			this.tabControl1.ResumeLayout(false);
			this.tabMean.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public EngWord.mean mean;
		public void setAttr(int index,bool val){
			switch(index){
				case 0:this.mean.Proper=val;break;
				case 1:this.mean.Collective=val;break;
				case 2:this.mean.Abstract=val;break;
				case 3:this.mean.Material=val;break;
				case 4:this.mean.SV=val;break;
				case 5:this.mean.SVC=val;break;
				case 6:this.mean.SVO=val;break;
				case 7:this.mean.SVOO=val;break;
				case 8:this.mean.SVOC=val;break;
				case 9:this.mean.Reflexive=val;break;
				case 10:this.mean.Causative=val;break;
				case 11:this.mean.Factive=val;break;
				case 12:this.mean.Stative=val;break;
				case 13:this.mean.Sensational=val;break;
				case 14:this.mean.Interrogative=val;break;
				case 15:this.mean.RelativePronoun=val;break;
				case 16:this.mean.RelativeAdverb=val;break;
				case 17:this.mean.Phrase=val;break;
				case 18:this.mean.Clause=val;break;
			}
		}
		public void setAttr(string attrName,bool val){
			int index=System.Array.IndexOf(mwgWords.EngEditMean.AttrList,attrName);
			if(index>=0)this.setAttr(index,val);
		}
		public bool getAttr(int index){
			switch(index){
				case 0:return this.mean.Proper;
				case 1:return this.mean.Collective;
				case 2:return this.mean.Abstract;
				case 3:return this.mean.Material;
				case 4:return this.mean.SV;
				case 5:return this.mean.SVC;
				case 6:return this.mean.SVO;
				case 7:return this.mean.SVOO;
				case 8:return this.mean.SVOC;
				case 9:return this.mean.Reflexive;
				case 10:return this.mean.Causative;
				case 11:return this.mean.Factive;
				case 12:return this.mean.Stative;
				case 13:return this.mean.Sensational;
				case 14:return this.mean.Interrogative;
				case 15:return this.mean.RelativePronoun;
				case 16:return this.mean.RelativeAdverb;
				case 17:return this.mean.Phrase;
				case 18:return this.mean.Clause;
				default:return false;
			}
		}
		public bool getAttr(string attrName){
			int index=System.Array.IndexOf(mwgWords.EngEditMean.AttrList,attrName);
			if(index>=0)return this.getAttr(index);
			return false;
		}
		public void setUsage(int index,bool val){
			switch(index){
				case 0:this.mean.Nominal=val;break;
				case 1:this.mean.PluralNominal=val;break;
				case 2:this.mean.Attributive=val;break;
				case 3:this.mean.Predicative=val;break;
				case 4:this.mean.Adjunct=val;break;
			}
		}

		private void chkbxAttr_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e){
			if(e.NewValue==System.Windows.Forms.CheckState.Checked)this.setAttr(this.chkbxAttr.Items[e.Index].ToString(),true);
			if(e.NewValue==System.Windows.Forms.CheckState.Unchecked)this.setAttr(this.chkbxAttr.Items[e.Index].ToString(),false);
		}
		private void chkbxUsage_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e){
			if(e.NewValue==System.Windows.Forms.CheckState.Checked)this.setUsage(e.Index,true);
			if(e.NewValue==System.Windows.Forms.CheckState.Unchecked)this.setUsage(e.Index,false);
		}
		private void textBox1_Leave(object sender, System.EventArgs e){
			this.mean.content=this.textBox1.Text;
			//testCode
			if(this.textBox1.Text=="show"){
				this.textBox1.Text="";
				System.Console.WriteLine(((int)this.mean.attribute).ToString());
			}
		}
		private void bxType_TextChanged(object sender, System.EventArgs e){
			string[] types=mwgWords.EngWord.mean.Types;
			for(int i=0;i<this.bxType.Items.Count;i++)if(types[i]==this.bxType.Text){mean.type=(mwgWords.EngWord.mean.Type)i;break;}
			this.listView1.Items.Clear();
			this.listView1.Items.AddRange(this.mean.GetConjListForView());
		}

		public static string[] AttrList=new string[]{
			"固有","集合名詞","不可算名詞(抽象)","不可算名詞(物質)",
			"自動詞(SV)","自動詞(連結) (SVC)","他動詞(SVO)","他動詞(SVOO)","他動詞(SVOC)",
			"再帰動詞 reflexible","使役動詞","作為動詞 factive","状態動詞 stative","知覚動詞 sensational?",
			"疑問詞","関係代名詞","関係副詞","句(前置詞句、形容詞句、副詞句)","節(不定詞節、関係使節)"};
		public static string[] PartList=new string[]{
			"なし","名詞","動詞","形容詞",
			"副詞","前置詞","代名詞","接続詞",
			"助動詞","間投詞","冠詞","熟語","構文"};

		//public static int[] AttrMaskByPart=new int[]
			//{524287,15,147441,131073,
			//196609,131073,294927,327681
			//1,1,0,524287,491521};
	}
}
