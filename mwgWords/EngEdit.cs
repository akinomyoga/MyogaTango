using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mwgWords{
	/// <summary>
	/// Form1 �̊T�v�̐����ł��B
	/// </summary>
	public class EngEditWord : System.Windows.Forms.Form{
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ImageList imgTree;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ToolBarButton tOK;
		private System.Windows.Forms.ToolBarButton tNewMean;
		private System.Windows.Forms.ToolBarButton tNewRelative;
		private System.Windows.Forms.ToolBarButton tUp;
		private System.Windows.Forms.ToolBarButton tDown;
		private System.Windows.Forms.ToolBarButton tDelete;
		private System.Windows.Forms.ToolBarButton tSep1;
		private System.Windows.Forms.ToolBarButton tNewEx;
		private System.Windows.Forms.ImageList imgTool;
		private System.Windows.Forms.ToolBarButton tCancel;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel1;
		private System.ComponentModel.IContainer components;


		public EngEditWord():this(new EngWord()){}
		public EngEditWord(mwgWords.EngWord word){
			this.dtWord=word;
			InitializeComponent();
			this.initialize();
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing ){
			if( disposing ){
				if(components != null){
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
		private void InitializeComponent(){
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EngEditWord));
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imgTree = new System.Windows.Forms.ImageList(this.components);
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tOK = new System.Windows.Forms.ToolBarButton();
			this.tCancel = new System.Windows.Forms.ToolBarButton();
			this.tSep1 = new System.Windows.Forms.ToolBarButton();
			this.tNewMean = new System.Windows.Forms.ToolBarButton();
			this.tNewRelative = new System.Windows.Forms.ToolBarButton();
			this.tNewEx = new System.Windows.Forms.ToolBarButton();
			this.tUp = new System.Windows.Forms.ToolBarButton();
			this.tDown = new System.Windows.Forms.ToolBarButton();
			this.tDelete = new System.Windows.Forms.ToolBarButton();
			this.imgTool = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Left;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point(0, 28);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(160, 289);
			this.propertyGrid1.TabIndex = 0;
			this.propertyGrid1.Text = "propertyGrid1";
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.HideSelection = false;
			this.treeView1.ImageList = this.imgTree;
			this.treeView1.Location = new System.Drawing.Point(163, 28);
			this.treeView1.Name = "treeView1";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				  new System.Windows.Forms.TreeNode("�Ӗ�1", 1, 1, new System.Windows.Forms.TreeNode[] {
																																										 new System.Windows.Forms.TreeNode("���p��"),
																																										 new System.Windows.Forms.TreeNode("�֘A��", 16, 16),
																																										 new System.Windows.Forms.TreeNode("�ᕶ�E���")}),
																				  new System.Windows.Forms.TreeNode("�Ӗ�2", 2, 2, new System.Windows.Forms.TreeNode[] {
																																										 new System.Windows.Forms.TreeNode("���p")}),
																				  new System.Windows.Forms.TreeNode("�Ӗ�3", 3, 3),
																				  new System.Windows.Forms.TreeNode("�֘A��1", 13, 13),
																				  new System.Windows.Forms.TreeNode("�֘A��2", 19, 19),
																				  new System.Windows.Forms.TreeNode("�֘A��", 15, 15)});
			this.treeView1.Size = new System.Drawing.Size(160, 289);
			this.treeView1.TabIndex = 1;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// imgTree
			// 
			this.imgTree.ImageSize = new System.Drawing.Size(12, 12);
			this.imgTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTree.ImageStream")));
			this.imgTree.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tOK,
																						this.tCancel,
																						this.tSep1,
																						this.tNewMean,
																						this.tNewRelative,
																						this.tNewEx,
																						this.tUp,
																						this.tDown,
																						this.tDelete});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imgTool;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(656, 28);
			this.toolBar1.TabIndex = 2;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tOK
			// 
			this.tOK.Tag = "Save";
			this.tOK.ToolTipText = "�ύX��ۑ����Ă��̃E�B���h�E����܂��B";
			// 
			// tCancel
			// 
			this.tCancel.Tag = "Read";
			this.tCancel.ToolTipText = "�ύX��ۑ������ɂ��̃E�B���h�E����܂��B";
			// 
			// tSep1
			// 
			this.tSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tNewMean
			// 
			this.tNewMean.ImageIndex = 3;
			this.tNewMean.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tNewMean.ToolTipText = "�V�����Ӗ���ǉ����܂��B";
			// 
			// tNewRelative
			// 
			this.tNewRelative.ImageIndex = 3;
			this.tNewRelative.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tNewRelative.ToolTipText = "�V�����֘A���ǉ����܂��B";
			// 
			// tNewEx
			// 
			this.tNewEx.ImageIndex = 3;
			this.tNewEx.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tNewEx.ToolTipText = "�V�����ᕶ�E�����ǉ����܂��B";
			// 
			// tUp
			// 
			this.tUp.ImageIndex = 1;
			this.tUp.ToolTipText = "�I�����ꂽ���ڂ���Ɉړ����܂��B";
			// 
			// tDown
			// 
			this.tDown.ImageIndex = 0;
			this.tDown.ToolTipText = "�I�����ꂽ�P������Ɉړ����܂��B";
			// 
			// tDelete
			// 
			this.tDelete.ImageIndex = 2;
			this.tDelete.ToolTipText = "�I�����ꂽ�P����폜���܂��B";
			// 
			// imgTool
			// 
			this.imgTool.ImageSize = new System.Drawing.Size(16, 16);
			this.imgTool.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTool.ImageStream")));
			this.imgTool.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(160, 28);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 289);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// splitter2
			// 
			this.splitter2.Location = new System.Drawing.Point(323, 28);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(3, 289);
			this.splitter2.TabIndex = 4;
			this.splitter2.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(326, 28);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(330, 289);
			this.panel1.TabIndex = 5;
			// 
			// EngEditWord
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(656, 317);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.splitter2);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.toolBar1);
			this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.Name = "EngEditWord";
			this.Text = "�p�P��E�p�n��";
			this.Load += new System.EventHandler(this.EngEditWord_Load);
			this.ResumeLayout(false);

		}
		#endregion


		EngWord dtWord;
		/// <summary>
		/// �P��̓ǂݎ��ƕ\�����s���܂��B
		/// </summary>
		public void initialize(){
			//propertyGrid
			this.propertyGrid1.SelectedObject=this.dtWord;
			//TreeView
			this.treeView1.Nodes.Clear();
			System.Windows.Forms.TreeNode node;
			if(this.dtWord.meaning.Count>0)
				for(int i=0;i<this.dtWord.meaning.Count;i++){
					node=this.dtWord.meaning[i].ToTreeNode();
					node.Tag="Mean"+i.ToString();
					this.treeView1.Nodes.Add(node);
				}
			if(this.dtWord.relative.Count>0)
				for(int i=0;i<this.dtWord.relative.Count;i++){
					node=this.dtWord.relative[i].ToTreeNode();
					node.Tag="Rela"+i.ToString();
					this.treeView1.Nodes.Add(node);
				}
		}

		public EngWord DataWord{
			get{return this.dtWord;}
			set{this.dtWord=value;this.initialize();}
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e){
			string msg;
			int index;
			if(e.Node.Parent!=null){
				//�e�̖₢���킹
				msg=e.Node.Parent.Tag.ToString();
				if(!msg.StartsWith("Mean"))return;
				index=System.Int32.Parse(msg.Substring(4));
				if(index>=this.dtWord.meaning.Count)return;
				EngWord.mean parent=this.dtWord.meaning[index];
				//�q���R���g���[���ɓo�^�E�\��
				msg=e.Node.Tag.ToString();
				index=System.Int32.Parse(msg.Substring(4));
				if(index<0)return;
				switch(msg.Substring(0,4)){
					case "Sent":
						this.panel1.Controls.Clear();
						if(parent.sentence.Count>index){
							//TODO: �ᕶ��ҏW����R���g���[��(parent.sentence[index])
						}
						break;
					case "Rela":
						this.panel1.Controls.Clear();
						if(parent.relative.Count>index){
							//TODO: �֘A���ҏW����R���g���[��(parent.relative[index])
						}
						break;
				}
			}else{
				msg=e.Node.Tag.ToString();
				index=System.Int32.Parse(msg.Substring(4));
				if(index<0)return;
				switch(msg.Substring(0,4)){
					case "Mean":
						this.panel1.Controls.Clear();
						if(this.dtWord.meaning.Count>index){
							this.panel1.Controls.Add(new EngEditMean(this.dtWord.meaning[index]));
						}
						break;
					case "Rela":
						this.panel1.Controls.Clear();
						if(this.dtWord.relative.Count>index){
							//TODO: �֘A���ҏW����R���g���[��(this.dtWord.relative[index])
						}
						break;
				}
			}
		}
		//���������� Test Codes ����������
		private void EngEditWord_Load(object sender, System.EventArgs e){
			this.DataWord=EngDebug.TestInstanceOfEngWord();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e){
			if(e.Button.Tag==null)return;
			switch(e.Button.Tag.ToString()){
				case "Save":
					mwg.File.mwgBinary mbin=(mwg.File.mwgBinary)this.dtWord;
					mbin.filename="c:\\texDocuments\\EngWordTest\\mbwordtest.wrd";
					mbin.SaveToFile();
					break;
				case "Read":
					mbin=new mwg.File.mwgBinary("c:\\texDocuments\\EngWordTest\\mbwordtest.wrd");
					this.dtWord=new mwgWords.EngWord(mbin);
					this.initialize();
					break;
				case "OK":
					break;
			}
		
		}


	}

	public class EngDebug{
		internal static EngWord.mean TestInstanceOfMean(){
			EngWord.mean r=new mwgWords.EngWord.mean(mwgWords.EngWord.mean.Type.Construction,"�����͂���B");
			r.Attributive=true;
			r.Sensational=true;
			r.SVOO=true;
			r.conjugation.Add(new mwgWords.EngWord.conj(mwgWords.EngWord.conj.Type.PastParticle,"hihi","haihai"));
			r.relative.Add(new mwgWords.EngWord.rela(mwgWords.EngWord.rela.Type.Derivative,"helolo","�����ɂ�"));
			r.relative.Add(new mwgWords.EngWord.rela(mwgWords.EngWord.rela.Type.QuasiSynonym,"llo","����"));
			r.relative.Add(new mwgWords.EngWord.rela(mwgWords.EngWord.rela.Type.Misuse,"heo","����"));
			r.sentence.Add(new mwgWords.EngWord.sentence("hello �͈��A�̕���ł��B����Ŏg���܂��B����ɂ��͂̈Ӗ��ł��B",mwgWords.EngWord.sentence.Type.Description));
			return r;
		}
		internal static EngWord TestInstanceOfEngWord(){
			EngWord word=new EngWord("hello","h_lou");
			word.Add(EngDebug.TestInstanceOfMean());
			word.Add(EngDebug.TestInstanceOfMean());
			word.Add(new mwgWords.EngWord.rela(mwgWords.EngWord.rela.Type.None,"nihao","�����͂�"));
			return word;
		}
	}
}
