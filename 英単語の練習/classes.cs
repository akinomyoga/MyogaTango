using System;
namespace 英単語の練習
{
	
	//*************************************
	//          class readXml
	//-------------------------------------
	/// <summary>Xmlを利用するのに使用するクラス。動的クラス</summary>
	public class readXml
	{
		/// <summary>ここでXmlを読み込むのに使用するSystem.Xml.XmlTextReader。</summary>
		public System.Xml.XmlTextReader xtr;
		string fn;
		
		/// <summary>readXmlのコンストラクタ</summary>
		/// <param name="filename">ファイル名を指定します。</param>
		public readXml(string filename){
			this.fn=filename;
		}
		public void openFile(){
			xtr=new System.Xml.XmlTextReader(this.fn);
			xtr.MoveToContent();
		}
		public 英単語の練習.Word readWordData(){
			while(true){
				if(xtr.Read()){
					if(xtr.NodeType==System.Xml.XmlNodeType.Element&&xtr.Name=="word"){
						string name=this.unescape(xtr.GetAttribute("name"));//単語(英語)
						string mean=this.unescape(xtr.GetAttribute("mean"));//意味(日本語)
						System.Collections.ArrayList refWordList=new System.Collections.ArrayList();
						string[] example=new string[]{};
						string part,conjugate;int shutsu,seikai;
						this.readSubData(out part,out conjugate,out refWordList,ref example,out shutsu,out seikai);
						return new 英単語の練習.Word(name,(wordPart)part,conjugate.Split(new char[]{';'}),mean,refWordList,example,shutsu,seikai);
					}
				}else{
					return 英単語の練習.Word.FileEnd;
				}
			}
		}
		public void closeFile(){
			if(xtr!=null)xtr.Close();
		}
		
		/// <summary>語の補足情報を取得します。XmlTextReader xtr の位置をElementからEndElementまで移動させます。</summary>
		/// <param name="refWord">この変数に参照する他の語の配列を渡します</param>
		/// <param name="example">この変数に例文の配列を渡します</param>
		private void readSubData(out string p,out string conj,out System.Collections.ArrayList refWordList,ref string[] example,out int shutsu,out int seikai)
		{//ref -> out についても考慮
			refWordList=new System.Collections.ArrayList();
			System.Collections.ArrayList exampleList=new System.Collections.ArrayList();
			p=conj="";shutsu=seikai=0;
			while(xtr.Read()){
				if(xtr.NodeType==System.Xml.XmlNodeType.Element)switch(xtr.Name){//Elementならその名前で場合分け
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
					case "xmp"://例文
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
			//4e1,f0(&eth;),254,e6(aelig),28c,251,259,14bもエンティティに
			return str;
		}
	}
	
	//********************************************
	//             class writeXml
	//--------------------------------------------
	/// <summary>単語帳データをXmlファイルに書き込む時に利用します</summary>
	public class writeXml{
		/// <summary>書き込みに利用する System.Xml.XmlTextWriter</summary>
		public System.Xml.XmlTextWriter xtw;
		/// <summary>ここにおいて操作の対象となるファイルのパス。</summary>
		public string fn;
		/// <summary>class writeXml の constructer。writeXml を construct しただけではファイルは書き込まれません。member の openFile()関数を呼び出して下さい。</summary>
		/// <param name="filename">読み込むファイル名をここに指定します。</param>
		public writeXml(string filename){
			this.fn=filename;
		}
		/// <summary>ファイルを開き、ヘッダ情報とルートノードを初期化します。元からあった情報は削除されます。</summary>
		public void openFile(){
			this.xtw=new System.Xml.XmlTextWriter(this.fn,System.Text.Encoding.UTF8);
			this.xtw.Formatting=System.Xml.Formatting.Indented;
			this.xtw.Indentation=1;
			this.xtw.WriteStartDocument();
			this.xtw.WriteStartElement("wordbook");
			xtw.WriteAttributeString("version","mwq-wordbookfile-1.0β");
		}
		/// <summary>個々の単語の情報をファイル内に書き込みます。</summary>
		/// <param name="w">書き込む単語の情報を格納している 英単語の練習.Word を指定。</param>
		public void writeWordData(英単語の練習.Word w){
			xtw.WriteStartElement("word");{
				xtw.WriteAttributeString("name",this.escape( w.word+((w.pron=="")?"":"|"+w.pron) ));
				xtw.WriteAttributeString("mean",this.escape(w.mean));
				xtw.WriteStartElement("part");{
					xtw.WriteAttributeString("value",this.escape(w.part.partString));
					xtw.WriteAttributeString("conjugate",this.escape(w.strConjugate));
				}xtw.WriteEndElement();
				string nm;//typ nm 参照語の情報を指定する文字列を格納
				int rwl,exl;//rwl は参照の、 exl は例文の、数を表します。
				if((rwl=w.referWord.Count)!=0)for(int i=0;i<rwl;i++){//if( ～=0)はいらないかも(Count=0になることはない?)
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
				if((exl=w.example.Length)!=0)for(int i=0;i<exl;i++){//if( ～=0)はいらないかも(length=0になることはない?)
					if(w.example[i].Trim()!="")xtw.WriteElementString("xmp",this.escape(w.example[i]));
				}
				xtw.WriteStartElement("exam");{
					xtw.WriteAttributeString("shutsudai",w.shutsudai.ToString());
					xtw.WriteAttributeString("seikai",w.seikai.ToString());
				}xtw.WriteEndElement();
			}xtw.WriteEndElement();
		}
		/// <summary>ファイルのルートノードを閉じ、ファイルを閉じます。再度書き込みをしたい場合は、openFile()関数から再び始めて下さい。</summary>
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
		/// <summary>単語の情報を格納するクラス public class Word のコンストラクタ。</summary>
		/// <param name="word">単語を指定します。発音記号も付す時には"単語|発音記号"として渡して下さい。</param>
		/// <param name="part">品詞を指定します。動詞="verb"、名詞="noun"、副詞="adverb"、形容詞="adjective"</param>
		/// <param name="conj">活用形を指定します。"活用形の種類:[実際の活用した単語|発音記号]"を単位として、複数或る場合にはセミコロン";" で区切ります。空白 または null で指定された場合には、活用形の指定は特にない物と見なされます。
		/// 活用形の種類は 複数形="plural"、比較級(comparative degree)="comp"、最上級(superlative degree)=""、三単現(third person singular present tense)="tsp"、過去形(past tense)="past"、現在分詞(present participle)="presentp"、過去分詞(past participle)="pp"</param>
		/// <param name="mean">日本語の意味を指定して下さい。(勿論、日本語でなくとも読んで理解できればよい)</param>
		/// <param name="refWord">参照する単語の配列。同義語・類義語は"[同]"、反意語は"[反]"、姉妹語(語源など)は"[姉]"、その他は"[参]"を単語の頭に付して渡して下さい。</param>
		/// <param name="example">例文の配列</param>
		public Word(string word,wordPart part,string[] conj,string mean,System.Collections.ArrayList refWords,string[] example,int shutudai,int seikai){
			string[] word2=word.Split(new char[]{'|'},2);
			initialize(word2[0],(word2.Length==2)?word2[1]:"",part,conj,mean,refWords,example,shutudai,seikai);
		}
		public Word(string word,wordPart part,string[] conj,string mean,string[] refWords,string[] example,int shutudai,int seikai){
			string[] word2=word.Split(new char[]{'|'},2);
			System.Collections.ArrayList refWords2=new System.Collections.ArrayList();
			for(int ir=0;ir<refWords.Length;ir++){
				refWords2.Add(new 英単語の練習.refWord(refWords[ir]));
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
			//System.Drawing.Font cFont1=new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO",9);
			//System.Drawing.Font cFont2=new System.Drawing.Font("HG正楷書体-PRO",9);
			//---情報の調整
			//-------単語
			if(return1.SubItems.Count!=0)return1.SubItems[0].Text=(this.word=="")?" ":this.word;
			//-------品詞
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
			//-------意味・参照
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
			//-------出題・正解・正解率
			return1.SubItems.Add(this.shutsudai.ToString());
			return1.SubItems.Add(this.seikai.ToString());
			double num=System.Int32.Parse(return1.SubItems[5].Text);
			double den=System.Int32.Parse(return1.SubItems[4].Text);
			if(den==0)return1.SubItems.Add("不定",cBlack,System.Drawing.Color.Silver,cFont0);else{
				double vNum=System.Math.Round(num/den*100);
				int vColGB=(int)(127.5*(1+vNum/100));
				System.Drawing.Color vCol=System.Drawing.Color.Yellow;
				if(vColGB>255){
					System.Windows.Forms.MessageBox.Show("次の単語に異常が見られます - "+return1.SubItems[0].Text);
					//vColGB=255;
				}else vCol=System.Drawing.Color.FromArgb(255,vColGB,vColGB);
				return1.SubItems.Add(vNum.ToString()+"%",cBlack,vCol,cFont0);
			}
			//-例文
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
		/// <summary>ファイルから単語の情報を読み取っている際に、これ以上単語の情報がない事を通知する為に用いる物である。単語の情報ではない。</summary>
		public static Word FileEnd{
			get{
				return new 英単語の練習.Word("FileEnd",(wordPart)"FileEnd",new string[]{},"FileEnd",new string[]{},new string[]{},0,0);
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
				case "名詞":case "名":case "noun":
					this.partNumber=0;
					break;
				case "形容詞":case "形":case "adjective":
					this.partNumber=1;
					break;
				case "動詞":case "動":case "verb":
					this.partNumber=2;
					break;
				case "副詞":case "副":case "adverb":
					this.partNumber=3;
					break;
				case "代名詞":case "代":case "pronoun":
					this.partNumber=4;
					break;
				case "前置詞":case "前":case "preposition":
					this.partNumber=5;
					break;
				case "接続詞":case "接":case "conjunction":
					this.partNumber=6;
					break;
				case "助動詞":case "助":case "auxiliaryverb":
					this.partNumber=7;
					break;
				case "構文":case "構":case "construction":
					this.partNumber=8;
					break;
				case "間投詞":case "間":case "interjection":
					this.partNumber=9;
					break;
				default:
					this.partNumber=0;
					break;
			}//以後他の品詞についても追加
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
					default:return System.Drawing.Color.Black;//その他
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
		public static string[] partNameBase=new string[]{"名詞","形容詞","動詞","副詞","代名詞","前置詞","接続詞","助動詞","構文","間投詞"};
		public static string[] IDLetterBase=new string[]{"名","形","動","副","代","前","接","助","構","間"};
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
				case "派生語":case "派":case "derivative":
					this.reftype=1;break;
				case "同義語":case "同":case "synonym":
					this.reftype=2;break;
				case "類義語":case "類":case "quasisynonym":
					this.reftype=3;break;
				case "反意語":case "反":case "antonym":
					this.reftype=4;break;
				case "姉妹語":case "姉":case "sister":
					this.reftype=5;break;
				case "熟語":case "熟":case "idiom":
					this.reftype=6;break;
				case "略語":case "略":case "abreviation":
					this.reftype=7;break;
				case "頭文字":case "頭":case "acronym":
					this.reftype=8;break;
				case "紛らわしい語":case "紛":case "confusing":
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
					case 0:return "参";
					case 1:return "派";
					case 2:return "同";
					case 3:return "類";
					case 4:return "反";
					case 5:return "姉";
					case 6:return "熟";
					case 7:return "略";
					case 8:return "頭";
					case -1:return "紛";
					default:return "参";
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
					case 0:return "参照語";
					case 1:return "派生語";
					case 2:return "同義語";
					case 3:return "類義語";
					case 4:return "反意語";
					case 5:return "姉妹後";
					case 6:return "熟語";
					case 7:return "略語";
					case 8:return "頭文字";
					case -1:return "紛らわしい語";
					default:return "参照語";
				}
			}
		}
	}//<--endof struct refWord
}
