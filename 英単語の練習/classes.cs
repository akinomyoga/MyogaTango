using System;
namespace �p�P��̗��K
{
	
	//*************************************
	//          class readXml
	//-------------------------------------
	/// <summary>Xml�𗘗p����̂Ɏg�p����N���X�B���I�N���X</summary>
	public class readXml
	{
		/// <summary>������Xml��ǂݍ��ނ̂Ɏg�p����System.Xml.XmlTextReader�B</summary>
		public System.Xml.XmlTextReader xtr;
		string fn;
		
		/// <summary>readXml�̃R���X�g���N�^</summary>
		/// <param name="filename">�t�@�C�������w�肵�܂��B</param>
		public readXml(string filename){
			this.fn=filename;
		}
		public void openFile(){
			xtr=new System.Xml.XmlTextReader(this.fn);
			xtr.MoveToContent();
		}
		public �p�P��̗��K.Word readWordData(){
			while(true){
				if(xtr.Read()){
					if(xtr.NodeType==System.Xml.XmlNodeType.Element&&xtr.Name=="word"){
						string name=this.unescape(xtr.GetAttribute("name"));//�P��(�p��)
						string mean=this.unescape(xtr.GetAttribute("mean"));//�Ӗ�(���{��)
						System.Collections.ArrayList refWordList=new System.Collections.ArrayList();
						string[] example=new string[]{};
						string part,conjugate;int shutsu,seikai;
						this.readSubData(out part,out conjugate,out refWordList,ref example,out shutsu,out seikai);
						return new �p�P��̗��K.Word(name,(wordPart)part,conjugate.Split(new char[]{';'}),mean,refWordList,example,shutsu,seikai);
					}
				}else{
					return �p�P��̗��K.Word.FileEnd;
				}
			}
		}
		public void closeFile(){
			if(xtr!=null)xtr.Close();
		}
		
		/// <summary>��̕⑫�����擾���܂��BXmlTextReader xtr �̈ʒu��Element����EndElement�܂ňړ������܂��B</summary>
		/// <param name="refWord">���̕ϐ��ɎQ�Ƃ��鑼�̌�̔z���n���܂�</param>
		/// <param name="example">���̕ϐ��ɗᕶ�̔z���n���܂�</param>
		private void readSubData(out string p,out string conj,out System.Collections.ArrayList refWordList,ref string[] example,out int shutsu,out int seikai)
		{//ref -> out �ɂ��Ă��l��
			refWordList=new System.Collections.ArrayList();
			System.Collections.ArrayList exampleList=new System.Collections.ArrayList();
			p=conj="";shutsu=seikai=0;
			while(xtr.Read()){
				if(xtr.NodeType==System.Xml.XmlNodeType.Element)switch(xtr.Name){//Element�Ȃ炻�̖��O�ŏꍇ����
					case "part":
						p=this.unescape(xtr.GetAttribute("value"));
						conj=this.unescape(xtr.GetAttribute("conjugate"));
						break;
					case "ref":
						string vName=this.unescape(xtr.GetAttribute("name"));
						string vType=xtr.GetAttribute("type");if(vType==null)vType="Reference";
						string vMean=this.unescape(xtr.GetAttribute("mean"));
						string vPart=xtr.GetAttribute("part");if(vPart==null)vPart="noun";
						refWordList.Add(new refWord(vName,vType,vPart,vMean));
						break;
					case "xmp"://�ᕶ
						exampleList.Add(this.unescape(xtr.ReadInnerXml()));
						break;
					case "exam":
						shutsu=System.Int32.Parse(xtr.GetAttribute("shutsudai"));
						seikai=System.Int32.Parse(xtr.GetAttribute("seikai"));
						break;
				}else if(xtr.NodeType==System.Xml.XmlNodeType.EndElement){
					example=(string[])exampleList.ToArray("s".GetType());
					return;
				}
						
			}
			example=(string[])exampleList.ToArray("s".GetType());
		}//public void readSubData() -->
		private string unescape(string str)
		{	
			if(str==null)return "";
			str=str.Replace("&lt;","<").Replace("&gt;",">").Replace("&amp;","&");
			str=str.Replace("&aacute;",'\u00E1'.ToString()).Replace("&agrave;",'\u00E0'.ToString());
			str=str.Replace("&iacute;",'\u00ED'.ToString()).Replace("&igrave;",'\u00EC'.ToString());
			str=str.Replace("&uacute;",'\u00FA'.ToString()).Replace("&ugrave;",'\u00F9'.ToString());
			str=str.Replace("&eacute;",'\u00E9'.ToString()).Replace("&egrave;",'\u00E8'.ToString());
			str=str.Replace("&oacute;",'\u00F3'.ToString()).Replace("&ograve;",'\u00F2'.ToString());
			//4e1,f0(&eth;),254,e6(aelig),28c,251,259,14b���G���e�B�e�B��
			return str;
		}
	}
	
	//********************************************
	//             class writeXml
	//--------------------------------------------
	/// <summary>�P�꒠�f�[�^��Xml�t�@�C���ɏ������ގ��ɗ��p���܂�</summary>
	public class writeXml{
		/// <summary>�������݂ɗ��p���� System.Xml.XmlTextWriter</summary>
		public System.Xml.XmlTextWriter xtw;
		/// <summary>�����ɂ����đ���̑ΏۂƂȂ�t�@�C���̃p�X�B</summary>
		public string fn;
		/// <summary>class writeXml �� constructer�BwriteXml �� construct ���������ł̓t�@�C���͏������܂�܂���Bmember �� openFile()�֐����Ăяo���ĉ������B</summary>
		/// <param name="filename">�ǂݍ��ރt�@�C�����������Ɏw�肵�܂��B</param>
		public writeXml(string filename){
			this.fn=filename;
		}
		/// <summary>�t�@�C�����J���A�w�b�_���ƃ��[�g�m�[�h�����������܂��B�����炠�������͍폜����܂��B</summary>
		public void openFile(){
			this.xtw=new System.Xml.XmlTextWriter(this.fn,System.Text.Encoding.UTF8);
			this.xtw.Formatting=System.Xml.Formatting.Indented;
			this.xtw.Indentation=1;
			this.xtw.WriteStartDocument();
			this.xtw.WriteStartElement("wordbook");
			xtw.WriteAttributeString("version","mwq-wordbookfile-1.0��");
		}
		/// <summary>�X�̒P��̏����t�@�C�����ɏ������݂܂��B</summary>
		/// <param name="w">�������ޒP��̏����i�[���Ă��� �p�P��̗��K.Word ���w��B</param>
		public void writeWordData(�p�P��̗��K.Word w){
			xtw.WriteStartElement("word");{
				xtw.WriteAttributeString("name",this.escape( w.word+((w.pron=="")?"":"|"+w.pron) ));
				xtw.WriteAttributeString("mean",this.escape(w.mean));
				xtw.WriteStartElement("part");{
					xtw.WriteAttributeString("value",this.escape(w.part.partString));
					xtw.WriteAttributeString("conjugate",this.escape(w.strConjugate));
				}xtw.WriteEndElement();
				string nm;//typ nm �Q�ƌ�̏����w�肷�镶������i�[
				int rwl,exl;//rwl �͎Q�Ƃ́A exl �͗ᕶ�́A����\���܂��B
				if((rwl=w.referWord.Count)!=0)for(int i=0;i<rwl;i++){//if( �`=0)�͂���Ȃ�����(Count=0�ɂȂ邱�Ƃ͂Ȃ�?)
					refWord rfword=(refWord)w.referWord[i];
					if((nm=rfword.word.Trim())!=""){
						if(rfword.pron!="")nm+="|"+rfword.pron;
						xtw.WriteStartElement("ref");
						xtw.WriteAttributeString("type",rfword.typeString);
						xtw.WriteAttributeString("name",this.escape(nm));
						if(rfword.mean!="")xtw.WriteAttributeString("mean",this.escape(rfword.mean));
						xtw.WriteAttributeString("part",rfword.part.partString);
						xtw.WriteEndElement();
					}
				}
				if((exl=w.example.Length)!=0)for(int i=0;i<exl;i++){//if( �`=0)�͂���Ȃ�����(length=0�ɂȂ邱�Ƃ͂Ȃ�?)
					if(w.example[i].Trim()!="")xtw.WriteElementString("xmp",this.escape(w.example[i]));
				}
				xtw.WriteStartElement("exam");{
					xtw.WriteAttributeString("shutsudai",w.shutsudai.ToString());
					xtw.WriteAttributeString("seikai",w.seikai.ToString());
				}xtw.WriteEndElement();
			}xtw.WriteEndElement();
		}
		/// <summary>�t�@�C���̃��[�g�m�[�h����A�t�@�C������܂��B�ēx�������݂��������ꍇ�́AopenFile()�֐�����Ăюn�߂ĉ������B</summary>
		public void closeFile(){
			if(xtw!=null){
				xtw.WriteEndElement();
				xtw.WriteEndDocument();
				xtw.Close();
			}
		}
		private string escape(string str){
			if(str==null)return "";
			str=str.Replace("<","&lt;").Replace(">","&gt;").Replace("&","&amp;");
			str=str.Replace('\u00E1'.ToString(),"&aacute;").Replace('\u00E0'.ToString(),"&agrave;");
			str=str.Replace('\u00ED'.ToString(),"&iacute;").Replace('\u00EC'.ToString(),"&igrave;");
			str=str.Replace('\u00FA'.ToString(),"&uacute;").Replace('\u00F9'.ToString(),"&ugrave;");
			str=str.Replace('\u00E9'.ToString(),"&eacute;").Replace('\u00E8'.ToString(),"&egrave;");
			str=str.Replace('\u00F3'.ToString(),"&oacute;").Replace('\u00F2'.ToString(),"&ograve;");
			return str;
		}
	}
	//******************************************
	//               class Word
	//------------------------------------------
	public class Word
	{
        //=====================================
        //          variables
        //-------------------------------------
		public string word;
		public wordPart part;
		public string[] conjugate;
		public string mean;
		public string pron;
		public System.Collections.ArrayList referWord;
		public string[] example;
		public int shutsudai,seikai;
        //=====================================
        //         Word constructor
		//-------------------------------------
		/// <summary>�P��̏����i�[����N���X public class Word �̃R���X�g���N�^�B</summary>
		/// <param name="word">�P����w�肵�܂��B�����L�����t�����ɂ�"�P��|�����L��"�Ƃ��ēn���ĉ������B</param>
		/// <param name="part">�i�����w�肵�܂��B����="verb"�A����="noun"�A����="adverb"�A�`�e��="adjective"</param>
		/// <param name="conj">���p�`���w�肵�܂��B"���p�`�̎��:[���ۂ̊��p�����P��|�����L��]"��P�ʂƂ��āA��������ꍇ�ɂ̓Z�~�R����";" �ŋ�؂�܂��B�� �܂��� null �Ŏw�肳�ꂽ�ꍇ�ɂ́A���p�`�̎w��͓��ɂȂ����ƌ��Ȃ���܂��B
		/// ���p�`�̎�ނ� �����`="plural"�A��r��(comparative degree)="comp"�A�ŏ㋉(superlative degree)=""�A�O�P��(third person singular present tense)="tsp"�A�ߋ��`(past tense)="past"�A���ݕ���(present participle)="presentp"�A�ߋ�����(past participle)="pp"</param>
		/// <param name="mean">���{��̈Ӗ����w�肵�ĉ������B(�ܘ_�A���{��łȂ��Ƃ��ǂ�ŗ����ł���΂悢)</param>
		/// <param name="refWord">�Q�Ƃ���P��̔z��B���`��E�ދ`���"[��]"�A���ӌ��"[��]"�A�o����(�ꌹ�Ȃ�)��"[�o]"�A���̑���"[�Q]"��P��̓��ɕt���ēn���ĉ������B</param>
		/// <param name="example">�ᕶ�̔z��</param>
		public Word(string word,wordPart part,string[] conj,string mean,System.Collections.ArrayList refWords,string[] example,int shutudai,int seikai){
			string[] word2=word.Split(new char[]{'|'},2);
			initialize(word2[0],(word2.Length==2)?word2[1]:"",part,conj,mean,refWords,example,shutudai,seikai);
		}
		public Word(string word,wordPart part,string[] conj,string mean,string[] refWords,string[] example,int shutudai,int seikai){
			string[] word2=word.Split(new char[]{'|'},2);
			System.Collections.ArrayList refWords2=new System.Collections.ArrayList();
			for(int ir=0;ir<refWords.Length;ir++){
				refWords2.Add(new �p�P��̗��K.refWord(refWords[ir]));
			}
			initialize(word2[0],(word2.Length==2)?word2[1]:"",part,conj,mean,refWords2,example,shutudai,seikai);
		}
		private void initialize(string word,string pronounce,wordPart part,string[] conj,string mean,System.Collections.ArrayList refWords,string[] example,int shutudai,int seikai)
		{
			this.word=word;
			this.pron=pronounce;
			this.part=part;
			this.conjugate=conj;
			this.mean=mean;
			this.referWord=(System.Collections.ArrayList)refWords;
			this.example=example;
			this.shutsudai=shutsudai;
			this.seikai=this.seikai;
		}
		
		//================================
        //      Word properties
        //--------------------------------
		public wordPart Part
		{
			set{this.part=value;}
			get{return this.part;}
		}
		public string strConjugate{
			get{
				if(this.conjugate.Length==0)return "";
				string r=this.conjugate[0];
				if(this.conjugate.Length>1)for(int i=1;i<this.conjugate.Length;i++)r+=";"+this.conjugate[i];
				return r;
			}
		}
        //================================
        //        Word functions
        //--------------------------------
		public System.Windows.Forms.ListViewItem ToListViewItem(){
			System.Windows.Forms.ListViewItem return1=new System.Windows.Forms.ListViewItem();
			System.Drawing.Color cBlack=System.Drawing.Color.Black;
			System.Drawing.Font cFont0=new System.Drawing.Font("MS UI Gothic",9);
			//System.Drawing.Font cFont1=new System.Drawing.Font("HG�ۺ޼��M-PRO",9);
			//System.Drawing.Font cFont2=new System.Drawing.Font("HG��������-PRO",9);
			//---���̒���
			//-------�P��
			if(return1.SubItems.Count!=0)return1.SubItems[0].Text=(this.word=="")?" ":this.word;
			//-------�i��
			return1.SubItems.Add(this.part.IDLetter,this.part.ForeColor,this.part.BackColor,cFont0);
			switch(this.part.partNumber)
			{	
				case 0:return1.ImageIndex=0;break;//n
				case 1:return1.ImageIndex=2;break;//a
				case 2:return1.ImageIndex=1;break;//v
				case 3:return1.ImageIndex=3;break;//ad
				default:
					return1.ImageIndex=0;
					break;
			}
			//-------�Ӗ��E�Q��
			return1.SubItems.Add(this.mean);
			string refer;int len;//string refer;int len;
			if((len=this.referWord.Count)==0){
				refer="";
			}else{
				refWord rfword=(refWord)this.referWord[0];
				refer=rfword.word;
				if(len>1)for(int ir=1;ir<len;ir++){
					rfword=(refWord)this.referWord[ir];
					refer+=","+rfword.word;
				}
			}
			return1.SubItems.Add(refer);
			//-------�o��E�����E����
			return1.SubItems.Add(this.shutsudai.ToString());
			return1.SubItems.Add(this.seikai.ToString());
			double num=System.Int32.Parse(return1.SubItems[5].Text);
			double den=System.Int32.Parse(return1.SubItems[4].Text);
			if(den==0)return1.SubItems.Add("�s��",cBlack,System.Drawing.Color.Silver,cFont0);else{
				double vNum=System.Math.Round(num/den*100);
				int vColGB=(int)(127.5*(1+vNum/100));
				System.Drawing.Color vCol=System.Drawing.Color.Yellow;
				if(vColGB>255){
					System.Windows.Forms.MessageBox.Show("���̒P��Ɉُ킪�����܂� - "+return1.SubItems[0].Text);
					//vColGB=255;
				}else vCol=System.Drawing.Color.FromArgb(255,vColGB,vColGB);
				return1.SubItems.Add(vNum.ToString()+"%",cBlack,vCol,cFont0);
			}
			//-�ᕶ
			string exampletext;
			if((len=this.example.Length)==0){
				exampletext="";
			}else{
				exampletext=this.example[0];
				if(len>1)for(int ir=0;ir<len;ir++){
					exampletext+="\n"+this.example[ir];
				}
				if(exampletext!="")return1.ImageIndex+=5;
			}
			return1.SubItems.Add(exampletext);
			return1.UseItemStyleForSubItems=false;
			return return1;
			
		}
		//==============================
        //    Word static member
        //------------------------------
		/// <summary>�t�@�C������P��̏���ǂݎ���Ă���ۂɁA����ȏ�P��̏�񂪂Ȃ�����ʒm����ׂɗp���镨�ł���B�P��̏��ł͂Ȃ��B</summary>
		public static Word FileEnd{
			get{
				return new �p�P��̗��K.Word("FileEnd",(wordPart)"FileEnd",new string[]{},"FileEnd",new string[]{},new string[]{},0,0);
			}
		}
		internal static System.Collections.ArrayList StringArrayToArrayList(string[] a){
			System.Collections.ArrayList r=new System.Collections.ArrayList();
			for(int ir=0;ir<a.Length;ir++)
			{
				r.Add(a[ir]);
			}
			return r;
		}

	}
	

	//************************************************
	//              struct wordPart
	//------------------------------------------------
	public struct wordPart{
		public int partNumber;
		public wordPart(string partName){
			switch(partName.ToLower())
			{
				case "����":case "��":case "noun":
					this.partNumber=0;
					break;
				case "�`�e��":case "�`":case "adjective":
					this.partNumber=1;
					break;
				case "����":case "��":case "verb":
					this.partNumber=2;
					break;
				case "����":case "��":case "adverb":
					this.partNumber=3;
					break;
				case "�㖼��":case "��":case "pronoun":
					this.partNumber=4;
					break;
				case "�O�u��":case "�O":case "preposition":
					this.partNumber=5;
					break;
				case "�ڑ���":case "��":case "conjunction":
					this.partNumber=6;
					break;
				case "������":case "��":case "auxiliaryverb":
					this.partNumber=7;
					break;
				case "�\��":case "�\":case "construction":
					this.partNumber=8;
					break;
				case "�ԓ���":case "��":case "interjection":
					this.partNumber=9;
					break;
				default:
					this.partNumber=0;
					break;
			}//�Ȍ㑼�̕i���ɂ��Ă��ǉ�
		}
		public wordPart(int partNum){
			this.partNumber=partNum;
		}
		
		//=====================================
		//          properties
		//-------------------------------------
		public System.Drawing.Color BackColor{
			get{
				switch(this.partNumber){
					case 0:return System.Drawing.Color.FromArgb(255,255,220);//n
					case 1:return System.Drawing.Color.FromArgb(220,255,220);//a
					case 2:return System.Drawing.Color.FromArgb(255,220,220);//v
					case 3:return System.Drawing.Color.FromArgb(220,220,255);//ad
					case 4:return System.Drawing.Color.FromArgb(255,255,220);//prn
					case 5:return System.Drawing.Color.Green;//prp
					case 6:return System.Drawing.Color.Red;//cnj
					case 7:return System.Drawing.Color.FromArgb(255,224,192);//aux
					case 8:return System.Drawing.Color.Gray;//construction
					case 9:return System.Drawing.Color.Yellow;//interj
					default:return System.Drawing.Color.White;
				}
			}
		}
		public System.Drawing.Color ForeColor{
			get{
				switch(this.partNumber){
					case 4:return System.Drawing.Color.Green;//prn
					case 5:return System.Drawing.Color.White;//prp
					case 6:return System.Drawing.Color.White;//cnj
					case 8:return System.Drawing.Color.White;//construct
					case 9:return System.Drawing.Color.Red;//interj
					default:return System.Drawing.Color.Black;//���̑�
				}
			}
		}
		public string IDLetter{
			get{
				if(this.partNumber<0||this.partNumber>9)return "Err";
				return wordPart.IDLetterBase[this.partNumber];
			}
		}
		public string partName{
			get{
				if(this.partNumber<0||this.partNumber>9)return "Err";
				return wordPart.partNameBase[this.partNumber];
			}
		}
		public string partString{
			get{
				if(this.partNumber<0||this.partNumber>9)return "Err";
				return wordPart.partStringBase[this.partNumber];
			}
		}
		//=====================================
		//          static properties
		//-------------------------------------
		public static wordPart Noun{get{return new wordPart(0);}}
		public static wordPart Adjective{get{return new wordPart(1);}}
		public static wordPart Verb{get{return new wordPart(2);}}
		public static wordPart Adverb{get{return new wordPart(3);}}
		public static wordPart Pronoun{get{return new wordPart(4);}}
		public static wordPart Preposition{get{return new wordPart(5);}}
		public static wordPart Conjunction{get{return new wordPart(6);}}
		public static wordPart AuxiliaryVerb{get{return new wordPart(7);}}
		public static wordPart Construction{get{return new wordPart(8);}}
		public static wordPart Interjection{get{return new wordPart(9);}}
		//=====================================
		//          static variants
		//-------------------------------------
		public static string[] partStringBase=new string[]{"noun","adjective","verb","adverb","pronoun","preposition","conjunction","auxiliaryverb","construction","interjection"};
		public static string[] partNameBase=new string[]{"����","�`�e��","����","����","�㖼��","�O�u��","�ڑ���","������","�\��","�ԓ���"};
		public static string[] IDLetterBase=new string[]{"��","�`","��","��","��","�O","��","��","�\","��"};
		//=====================================
		//          operators
		//-------------------------------------
		public static explicit operator wordPart(string x){return new wordPart(x);}
		public static explicit operator wordPart(int v){return new wordPart(v);}
		public static explicit operator string(wordPart prt){return prt.partString;}
	}//<--endof class wordPart	
	
	
	//*****************************************
	//          struct refWord
	//-----------------------------------------
	public struct refWord{
		public int reftype;
		public string word;
		public string mean;
		public wordPart part;
		public string pron;
		//=====================================
		//          constructor
		//-------------------------------------
		public refWord(string word){
			this=new refWord(word,"reference","noun","","");
		}
		public refWord(string word,string type,string part,string mean){
			string[] word2=word.Split(new char[]{'|'},2);
			this=new refWord(word2[0],type,part,mean,(word2.Length==2)?word2[1]:"");
		}
		public refWord(string word,string type,string part,string mean,string pron){
			this.word=word;
			switch(type.ToLower()){
				case "�h����":case "�h":case "derivative":
					this.reftype=1;break;
				case "���`��":case "��":case "synonym":
					this.reftype=2;break;
				case "�ދ`��":case "��":case "quasisynonym":
					this.reftype=3;break;
				case "���ӌ�":case "��":case "antonym":
					this.reftype=4;break;
				case "�o����":case "�o":case "sister":
					this.reftype=5;break;
				case "�n��":case "�n":case "idiom":
					this.reftype=6;break;
				case "����":case "��":case "abreviation":
					this.reftype=7;break;
				case "������":case "��":case "acronym":
					this.reftype=8;break;
				case "����킵����":case "��":case "confusing":
					this.reftype=-1;break;
				default:
					this.reftype=0;break;
			}
			this.mean=mean;
			this.part=(wordPart)part;
			this.pron=pron;
		}
	//-- properties
		public string typeIDLetter{
			get{
				switch(this.reftype){
					case 0:return "�Q";
					case 1:return "�h";
					case 2:return "��";
					case 3:return "��";
					case 4:return "��";
					case 5:return "�o";
					case 6:return "�n";
					case 7:return "��";
					case 8:return "��";
					case -1:return "��";
					default:return "�Q";
				}
			}
		}
		public string typeString{
			get{
				switch(this.reftype){
					case 0:return "Reference";
					case 1:return "Derivative";
					case 2:return "Synonym";
					case 3:return "QuasiSynonym";
					case 4:return "Antonym";
					case 5:return "Sister";
					case 6:return "Idiom";
					case 7:return "Abreviation";
					case 8:return "Acronym";
					case -1:return "Confusing";
					default:return "Reference";
				}
			}
		}
		public string typeName{
			get{
				switch(this.reftype){
					case 0:return "�Q�ƌ�";
					case 1:return "�h����";
					case 2:return "���`��";
					case 3:return "�ދ`��";
					case 4:return "���ӌ�";
					case 5:return "�o����";
					case 6:return "�n��";
					case 7:return "����";
					case 8:return "������";
					case -1:return "����킵����";
					default:return "�Q�ƌ�";
				}
			}
		}
	}//<--endof struct refWord
}
