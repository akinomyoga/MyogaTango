namespace mwgWords{
	/// <summary>
	/// 英単語、英熟語を表現するクラスです。
	/// </summary>
	public class EngWord:mwg.File.mb{

		#region fields & properties
		//=====================================
		//          Fields
		//-------------------------------------
		/// <summary>
		/// 単語を識別する為の、ID番号です。実際の識別には、綴り(core.word)も併せて使用します。
		/// </summary>
		public int identifier;
		/// <summary>
		/// 表記、発音、等を管理します。表記発音のみ使う時もあるから、再利用性を考慮してカプセル化した物です。
		/// </summary>
		public EngWord.wordCore core;
		/// <summary>
		/// 品詞、意味、例文等を管理します。
		/// </summary>
		public EngWord.mean.List meaning;
		/// <summary>
		/// 関連する語を管理します。
		/// </summary>
		public EngWord.rela.List relative;
		/// <summary>
		/// 意味を与えられて答える事が出来たか、の配列。
		/// 選択肢で正解 - a b c d ... (時間がかかると段々文字が変わる) ; 
		/// 選択肢で不正解 - z ; 
		/// 直接書いて正解 - A B C D ;  
		/// 直接書いて不正解 - Z ;
		/// </summary>
		public string spellScore;
		/// <summary>
		/// 単語を与えられて意味を答える事が出来たか、の配列。
		/// 選択肢で正解 - a b c d ... (時間がかかると段々文字が変わる) ; 
		/// 選択肢で不正解 - z ; 
		/// 直接書いて正解 - A B C D ;  
		/// 直接書いて不正解 - Z ;
		/// </summary>
		public string meanScore;
		//=====================================
		//          Properties
		//-------------------------------------
		/// <summary>
		/// 単語を識別する為の ID を取得します。
		/// </summary>
		public int ID{
			get{return this.identifier;}
		}
		/// <summary>
		/// 単語の綴りの部分を取得亦は設定します。
		/// </summary>
		public string Word{
			get{return this.core.word;}set{this.core.word=value;}
		}
		/// <summary>
		/// 単語の発音を取得亦は設定します。
		/// </summary>
		public string Pronunciation{
			get{return this.core.pronunciation;}set{this.core.pronunciation=value;}
		}
		/// <summary>
		/// 単語の綴りの正解不正解の記号表を返します。
		/// </summary>
		public string SpellScore{get{return this.spellScore;}}
		/// <summary>
		/// 単語の意味を正しく答えられたか否かの記号表を返します。
		/// </summary>
		public string MeanScore{get{return this.meanScore;}}
		#endregion
		
		public EngWord():this(new mwgWords.EngWord.wordCore()){}
		public EngWord(mwgWords.EngWord.wordCore wc){
			this.identifier=(int)(long)(new mwg.File.mbDateTime(System.DateTime.Now));
			this.core=wc;
			this.meaning=new mwgWords.EngWord.mean.List();
			this.relative=new mwgWords.EngWord.rela.List();
			this.meanScore="";
			this.spellScore="";
		}
		public EngWord(string spell,string pronunciation){
			this.identifier=(int)(long)(new mwg.File.mbDateTime(System.DateTime.Now));
			this.core=new mwgWords.EngWord.wordCore(spell,pronunciation);
			this.meaning=new mwgWords.EngWord.mean.List();
			this.relative=new mwgWords.EngWord.rela.List();
			this.meanScore="";
			this.spellScore="";
		}
		public void Add(mwgWords.EngWord.mean meaning){
			meaning.Parent=this;
			this.meaning.Add(meaning);
		}
		public void Add(mwgWords.EngWord.rela relative){
			this.relative.Add(relative);
		}

		#region mb functions
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
		//          mb functions
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
		/// <summary>
		/// mwgWords.EngWord コンストラクタ。
		/// </summary>
		/// <param name="mbin">読込元の mwg.File.mwgBinary インスタンスを指定します。</param>
		public EngWord(mwg.File.mwgBinary mbin){
			this.identifier=(int)(mwg.File.mbInt32)mbin;
			this.core=(EngWord.wordCore)mbin;
			this.meaning=(EngWord.mean.List)mbin;
			for(int i=0;i<this.meaning.Count;i++){
				this.meaning[i].Parent=this;
			}
			this.relative=(EngWord.rela.List)mbin;
			this.meanScore=(string)(mwg.File.mbString)mbin;
			this.spellScore=(string)(mwg.File.mbString)mbin;
		}
		/// <summary>
		/// mwgWords.EngWord コンストラクタ。
		/// </summary>
		/// <param name="data">読込元の byte[] を指定します。</param>
		public EngWord(byte[] data):this((mwg.File.mwgBinary)data){}
		public override int Length{
			get{return 4+this.core.Length
					+this.meaning.Length
					+this.relative.Length
					+((mwg.File.mbString)this.meanScore).Length
					+((mwg.File.mbString)this.spellScore).Length;
			}
		}
		public override byte[] ToBinary(){
			return (byte[])this.ToMwgBinary();
		}
		public override mwg.File.mwgBinary ToMwgBinary(){
			return ((mwg.File.mbInt32)(int)this.identifier).ToMwgBinary()
				+this.core.ToMwgBinary()
				+this.meaning.ToMwgBinary()
				+this.relative.ToMwgBinary()
				+((mwg.File.mbString)this.meanScore).ToMwgBinary()
				+((mwg.File.mbString)this.spellScore).ToMwgBinary();
		}
		public static explicit operator EngWord(mwg.File.mwgBinary a){return new EngWord(a);}
		public static explicit operator EngWord(byte[] a){return new EngWord(a);}
		#endregion

		#region [child class mean]
		//=====================================
		//          child class : mean
		//-------------------------------------
		/// <summary>
		/// 単語の品詞、意味とそれに付随する情報を管理します。
		/// </summary>
		public class mean:mwg.File.mb{
			#region fields
			//---------------------------------
			//          Fields
			//---------------------------------
			/// <summary>
			/// 意味の本体(日本語による説明)を保持します。
			/// </summary>
			public string content;
			/// <summary>
			/// 品詞が何であるかを保持します。
			/// </summary>
			public EngWord.mean.Type type;
			/// <summary>
			/// その単語の細かい分類を指定します。
			/// </summary>
			public EngWord.mean.Attr attribute;
			/// <summary>
			/// その単語の、文中に於ける役割を指定します。
			/// </summary>
			public EngWord.mean.Usage usage;
			/// <summary>
			/// 例文、や訳文、解説などを保持します。
			/// </summary>
			public EngWord.sentence.List sentence;
			/// <summary>
			/// 活用のリストを管理します。
			/// </summary>
			public EngWord.conj.List conjugation;
			/// <summary>
			/// 関連する語を管理します。
			/// </summary>
			public EngWord.rela.List relative;
			/// <summary>
			/// 親単語への参照です。親となる単語への接触を行う為に必要です。
			/// </summary>
			public EngWord Parent;
			#endregion

			#region Properties
			//---------------------------------
			//          Properties
			//---------------------------------

			public EngWord.mean.Type PartType{
				get{return this.type;}
				set{this.type=value;}
			}
			public bool Proper{
				get{return 0!=(this.attribute&EngWord.mean.Attr.Proper);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.Proper;
					else this.attribute&= ~EngWord.mean.Attr.Proper;
				}
			}
			public bool Collective{
				get{return 0!=(this.attribute&EngWord.mean.Attr.Collective);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.Collective;
					else this.attribute&= ~EngWord.mean.Attr.Collective;
				}
			}
			public bool Abstract{
				get{return 0!=(this.attribute&EngWord.mean.Attr.Abstract);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.Abstract;
					else this.attribute&= ~EngWord.mean.Attr.Abstract;
				}
			}
			public bool Material{
				get{return 0!=(this.attribute&EngWord.mean.Attr.Material);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.Material;
					else this.attribute&= ~EngWord.mean.Attr.Material;
				}
			}
			public bool SV{
				get{return 0!=(this.attribute&EngWord.mean.Attr.SV);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.SV;
					else this.attribute&= ~EngWord.mean.Attr.SV;
				}
			}
			public bool SVC{
				get{return 0!=(this.attribute&EngWord.mean.Attr.SVC);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.SVC;
					else this.attribute&= ~EngWord.mean.Attr.SVC;
				}
			}
			public bool SVO{
				get{return 0!=(this.attribute&EngWord.mean.Attr.SVO);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.SVO;
					else this.attribute&= ~EngWord.mean.Attr.SVO;
				}
			}
			public bool SVOO{
				get{return 0!=(this.attribute&EngWord.mean.Attr.SVOO);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.SVOO;
					else this.attribute&= ~EngWord.mean.Attr.SVOO;
				}
			}
			public bool SVOC{
				get{return 0!=(this.attribute&EngWord.mean.Attr.SVOC);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.SVOC;
					else this.attribute&= ~EngWord.mean.Attr.SVOC;
				}
			}
			public bool Causative{
				get{return 0!=(this.attribute&EngWord.mean.Attr.Causative);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.Causative;
					else this.attribute&= ~EngWord.mean.Attr.Causative;
				}
			}
			public bool Reflexive{
				get{return 0!=(this.attribute&EngWord.mean.Attr.Reflexive);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.Reflexive;
					else this.attribute&= ~EngWord.mean.Attr.Reflexive;
				}
			}
			public bool Factive{
				get{return 0!=(this.attribute&EngWord.mean.Attr.Factive);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.Factive;
					else this.attribute&= ~EngWord.mean.Attr.Factive;
				}
			}
			public bool Stative{
				get{return 0!=(this.attribute&EngWord.mean.Attr.Stative);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.Stative;
					else this.attribute&= ~EngWord.mean.Attr.Stative;
				}
			}
			public bool Sensational{
				get{return 0!=(this.attribute&EngWord.mean.Attr.Sensational);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.Sensational;
					else this.attribute&= ~EngWord.mean.Attr.Sensational;
				}
			}
			public bool Interrogative{
				get{return 0!=(this.attribute&EngWord.mean.Attr.Interrogative);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.Interrogative;
					else this.attribute&= ~EngWord.mean.Attr.Interrogative;
				}
			}
			public bool RelativePronoun{
				get{return 0!=(this.attribute&EngWord.mean.Attr.RelativePronoun);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.RelativePronoun;
					else this.attribute&= ~EngWord.mean.Attr.RelativePronoun;
				}
			}
			public bool RelativeAdverb{
				get{return 0!=(this.attribute&EngWord.mean.Attr.RelativeAdverb);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.RelativeAdverb;
					else this.attribute&= ~EngWord.mean.Attr.RelativeAdverb;
				}
			}
			public bool Phrase{
				get{return 0!=(this.attribute&EngWord.mean.Attr.Phrase);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.Phrase;
					else this.attribute&= ~EngWord.mean.Attr.Phrase;
				}
			}
			public bool Clause{
				get{return 0!=(this.attribute&EngWord.mean.Attr.Clause);}
				set{
					if(value)this.attribute|=EngWord.mean.Attr.Clause;
					else this.attribute&= ~EngWord.mean.Attr.Clause;
				}
			}
			public bool Nominal{
				get{return 0!=(this.usage&EngWord.mean.Usage.Nominal);}
				set{
					if(value)this.usage|=EngWord.mean.Usage.Nominal;
					else this.usage&= ~EngWord.mean.Usage.Nominal;
				}
			}
			public bool PluralNominal{
				get{return 0!=(this.usage&EngWord.mean.Usage.PluralNominal);}
				set{
					if(value)this.usage|=EngWord.mean.Usage.PluralNominal;
					else this.usage&= ~EngWord.mean.Usage.PluralNominal;
				}
			}
			public bool Attributive{
				get{return 0!=(this.usage&EngWord.mean.Usage.Attributive);}
				set{
					if(value)this.usage|=EngWord.mean.Usage.Attributive;
					else this.usage&= ~EngWord.mean.Usage.Attributive;
				}
			}
			public bool Predicative{
				get{return 0!=(this.usage&EngWord.mean.Usage.Predicative);}
				set{
					if(value)this.usage|=EngWord.mean.Usage.Predicative;
					else this.usage&= ~EngWord.mean.Usage.Predicative;
				}
			}
			public bool Adjunct{
				get{return 0!=(this.usage&EngWord.mean.Usage.Adjunct);}
				set{
					if(value)this.usage|=EngWord.mean.Usage.Adjunct;
					else this.usage&= ~EngWord.mean.Usage.Adjunct;
				}
			}
			#endregion
			
			public mean():this(mwgWords.EngWord.mean.Type.None,"[新しい意味]"){}
			public mean(mwgWords.EngWord.mean.Type part,string mean){
				this.content=mean;
				this.type=part;
				this.attribute=0;
				this.usage=0;
				this.conjugation=new mwgWords.EngWord.conj.List();
				this.sentence=new mwgWords.EngWord.sentence.List();
				this.relative=new mwgWords.EngWord.rela.List();
			}
			public void Add(mwgWords.EngWord.conj conjugation1){
				this.conjugation.Add(conjugation1);
			}
			public void Add(mwgWords.EngWord.rela relative1){
				this.relative.Add(relative1);
			}
			public void Add(mwgWords.EngWord.sentence sentence1){
				this.sentence.Add(sentence1);
			}

			#region UserInterface
			//-------------------------------------
			//          User Interface
			//-------------------------------------
			public System.Windows.Forms.ListViewItem[] GetConjListForView(){
				System.Collections.ArrayList r0=new System.Collections.ArrayList();
				System.Collections.ArrayList r1;
				switch(this.type){
					case EngWord.mean.Type.Noun:
					case EngWord.mean.Type.Pronoun:
						//単数形
						r0.Add(this.ConjJido("単数形"));
						//複数形
						r1=this.ConjByType(EngWord.conj.Type.Plural);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.pluralS(this.Parent.Word));
							else r0.Add(this.ConjFumei("複数形"));
						}else r0.AddRange(r1);
						//所有格
						r1=this.ConjByType(EngWord.conj.Type.Possesses);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.possesS(this.Parent.Word));
							else r0.Add(this.ConjFumei("所有格"));
						}else r0.AddRange(r1);
						break;
					case EngWord.mean.Type.Verb:
						//現在形
						r0.Add(this.ConjJido("現在形"));
						//三単現
						r1=this.ConjByType(EngWord.conj.Type.ThirdSinglePresent);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.tspS(this.Parent.Word));
							else r0.Add(this.ConjFumei("三人称単数現在形"));
						}else r0.AddRange(r1);
						//過去
						r1=this.ConjByType(EngWord.conj.Type.Past);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.pastS(this.Parent.Word));
							else r0.Add(this.ConjFumei("過去形"));
						}else r0.AddRange(r1);
						//過去分詞
						r1=this.ConjByType(EngWord.conj.Type.PastParticle);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.ppS(this.Parent.Word));
							else r0.Add(this.ConjFumei("pp(過去分詞)"));
						}else r0.AddRange(r1);
						//ing形
						if(this.Parent!=null){
							r0.Add(EngWord.conj.ingS(this.Parent.Word));
						}else r0.Add(this.ConjFumei("ing(現在分詞、動名詞)"));
						break;
					case EngWord.mean.Type.Auxiliary:
						//現在形
						r0.Add(this.ConjJido("現在形"));
						//過去
						r1=this.ConjByType(EngWord.conj.Type.Past);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.pastS(this.Parent.Word));
							else r0.Add(this.ConjFumei("過去形"));
						}else r0.AddRange(r1);
						break;
					case EngWord.mean.Type.Adverb:
					case EngWord.mean.Type.Adjective:
						//原級
						r0.Add(this.ConjJido("原級"));
						//比較級
						r1=this.ConjByType(EngWord.conj.Type.Comparative);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.compS(this.Parent.Word));
							else r0.Add(this.ConjFumei("比較級"));
						}else r0.AddRange(r1);
						//最上級
						r1=this.ConjByType(EngWord.conj.Type.Superlative);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.superS(this.Parent.Word));
							else r0.Add(this.ConjFumei("最上級"));
						}else r0.AddRange(r1);
						break;
					default:
						//現在形
						r0.Add(this.ConjJido("原形"));
						//他
						for(int i=0;i<this.conjugation.Count;i++){
							if(this.conjugation[i].type!=EngWord.conj.Type.None){
								r0.Add(this.conjugation[i].ToListViewItem());
							}
						}
						break;
				}
				//その他の物を追加
				r0.AddRange(this.ConjByType(EngWord.conj.Type.None));
				//return
				if(r0.Count>0){
					System.Windows.Forms.ListViewItem[] r=new System.Windows.Forms.ListViewItem[r0.Count];
					for(int i=0;i<r0.Count;i++){
						r[i]=(System.Windows.Forms.ListViewItem)r0[i];
					}
					return r;
				}else return new System.Windows.Forms.ListViewItem[]{};
			}
			private System.Collections.ArrayList ConjByType(EngWord.conj.Type type){
				System.Collections.ArrayList r0=new System.Collections.ArrayList();
				for(int i=0;i<this.conjugation.Count;i++){
					if(this.conjugation[i].type==type){
						r0.Add(this.conjugation[i].ToListViewItem());
					}
				}
				return r0;
			}
			private System.Windows.Forms.ListViewItem ConjFumei(string type){
				return new System.Windows.Forms.ListViewItem(new string[]{"不明","不明",type},EngWord.conj.typeNum(type),conj.jidoColor,conj.jidoBack,conj.jidoFont);
			}
			private System.Windows.Forms.ListViewItem ConjJido(string type){
				if(this.Parent!=null){
					string[] sub=new string[]{this.Parent.Word,this.Parent.Pronunciation,type};
					return new System.Windows.Forms.ListViewItem(sub,EngWord.conj.typeNum(type),conj.jidoColor,conj.jidoBack,conj.jidoFont);
				}else{
					return this.ConjFumei(type);
				}
			}

			public System.Windows.Forms.TreeNode ToTreeNode(){
				System.Windows.Forms.TreeNode[] r=new System.Windows.Forms.TreeNode[this.relative.Count+this.sentence.Count];
				int i=0;int j;
				for(j=0;j<this.relative.Count;j++,i++){
					r[i]=this.relative[j].ToTreeNode();
					r[i].Tag="Rela"+i.ToString();
				}for(j=0;j<this.sentence.Count;j++,i++){
					r[i]=this.sentence[j].ToTreeNode();
					r[i].Tag="Sent"+i.ToString();
				}
				int imgN=(int)this.type;
				return new System.Windows.Forms.TreeNode(this.content,imgN,imgN,r);
				//TODO: TreeNode からこの mean インスタンスを辿れる様にする。
			}
			#endregion

			#region mb functions
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			//          mb functions
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			public mean(mwg.File.mwgBinary mbin){
				this.content=(string)(mwg.File.mbString)mbin;
				this.type=(EngWord.mean.Type)(int)(mwg.File.mbInt32)mbin;
				this.attribute=(EngWord.mean.Attr)(int)(mwg.File.mbInt32)mbin;
				this.usage=(EngWord.mean.Usage)(int)(mwg.File.mbInt32)mbin;
				this.sentence=(EngWord.sentence.List)mbin;
				this.conjugation=(EngWord.conj.List)mbin;
				this.relative=(EngWord.rela.List)mbin;
			}
			public mean(byte[] data):this((mwg.File.mwgBinary)data){}
			public override int Length{
				get{
					return 12+((mwg.File.mbString)this.content).Length
						+this.sentence.Length
						+this.conjugation.Length
						+this.relative.Length;
				}
			}
			public override byte[] ToBinary(){
				return (byte[])this.ToMwgBinary();
			}
			public override mwg.File.mwgBinary ToMwgBinary(){
				return ((mwg.File.mbString)this.content).ToMwgBinary()
					+((mwg.File.mbInt32)(int)this.type).ToMwgBinary()
					+((mwg.File.mbInt32)(int)this.attribute).ToMwgBinary()
					+((mwg.File.mbInt32)(int)this.usage).ToMwgBinary()
					+this.sentence.ToMwgBinary()
					+this.conjugation.ToMwgBinary()
					+this.relative.ToMwgBinary();
			}
			public static explicit operator EngWord.mean(mwg.File.mwgBinary a){return new EngWord.mean(a);}
			public static explicit operator EngWord.mean(byte[] a){return new EngWord.mean(a);}
			#endregion

			#region child classes: List & Type & Attr & Usage
			//---------------------------------
			//          child classes
			//---------------------------------
			/// <summary>
			/// 品詞を管理する列挙体
			/// </summary>
			public enum Type{
				None//その他、未定
				,Noun//名詞
				,Verb//動詞
				,Adjective//形容詞
				,Adverb//副詞
				,Preposition//前置詞
				,Pronoun//代名詞
				,Conjunction//接続詞
				,Auxiliary//助動詞
				,Interjection//間投詞
				,Article//冠詞 a an the のみ
				,Idiom//熟語
				,Construction//構文
			}
			public static string[] Types=new string[]{"なし","名詞","動詞","形容詞","副詞","前置詞","代名詞",
														 "接続詞","助動詞","間投詞","冠詞","熟語","構文"};
			/// <summary>
			/// 様々な属性を扱います。
			/// </summary>
			[System.Flags()]
			public enum Attr{
				Proper=1//固有
				,Collective=2//集合名詞
				,Abstract=4//不可算名詞(抽象)
				,Material=8//不可算名詞(物質)
				,SV=16//自動詞
				,SVC=32//連結動詞
				,SVO=64//他動詞
				,SVOO=128//他動詞
				,SVOC=256//他動詞
				,Reflexive=512//再帰動詞(oneself を目的語に取る)、再起名詞
				,Causative=1024//使役動詞
				,Factive=2048//作為動詞
				,Stative=4096//状態動詞
				,Sensational=8192//知覚動詞 sensational というのかどうかは???
				,Interrogative=16384//疑問詞
				,RelativePronoun=32768//関係代名詞
				,RelativeAdverb=65536//関係副詞
				,Phrase=131072//句 前置詞句、形容詞句、副詞句など
				,Clause=262144//節 関係詞節
			}
			//属性として追加したい物
			//副詞→程度副詞、頻度副詞
			//間投詞→挨拶、感嘆
			//名詞→固有人名、固有組織、固有地名
			//熟語は品詞ではなくて、属性として扱った方が良い。
			/// <summary>
			/// どんな用法が適用されるかを扱います。
			/// </summary>
			[System.Flags()]
			public enum Usage{
				Nominal=1//単数名詞的用法(to 不定詞、動名詞)
				,PluralNominal=2//複数名詞的用法
				,Attributive=4//限定形容詞的用法(前置詞句、関係詞)
				,Predicative=8//叙述形容詞的用法(前置詞句、関係代名詞)
				,Adjunct=16//副詞的用法(前置詞句、関係副詞)
			}

			/// <summary>
			/// 複数(不定数)を管理するのに利用。
			/// </summary>
			public class List:mwg.File.mb{
				private System.Collections.ArrayList dat=new System.Collections.ArrayList();
				public List(){}
				public void Add(EngWord.mean meaning){
					this.dat.Add(meaning);
				}
				public EngWord.mean this[int index]{
					get{return (EngWord.mean)this.dat[index];}
					set{this.dat[index]=value;}
				}
				public int Count{get{return this.dat.Count;}}
				public void RemoveAt(int index){this.dat.RemoveAt(index);}
				public static explicit operator EngWord.mean[](EngWord.mean.List a){
					EngWord.mean[] r=new EngWord.mean[a.dat.Count];
					for(int i=0;i<a.dat.Count;i++){
						r[i]=(EngWord.mean)a.dat[i];
					}
					return r;
				}
				//-----------------------------
				//        mb fucnitons
				//-----------------------------
				public List(mwg.File.mwgBinary mbin){
					string four=((mwg.File.mbFourcc)mbin).ToString();
					if(four!="mn_L"){
						string message="現在 sentence.List として読み込もうとしているデータは mean.Listではありません"
							+"\n現在のデータの位置: "+mbin.current.ToString()+"/"+mbin.binaryData.Length.ToString()
							+"\nmn_L となるべき所→ "+four;
						System.Console.WriteLine("\n===== mbReadingException =====\n"+message);
						throw(new mwg.File.mbReadingException(message,"mwgWords.EngWord.mean.List"));
					}
					int c=(int)(mwg.File.mbInt32)mbin;//mean の数
					for(int i=0;i<c;i++)this.dat.Add((EngWord.mean)mbin);
				}
				public List(byte[] data):this((mwg.File.mwgBinary)data){}
				public override int Length{
					get{
						int r=8;
						int c=this.Count;
						for(int i=0;i<c;i++)r+=this[i].Length;
						return r;
					}
				}
				public override byte[] ToBinary(){
					return (byte[])this.ToMwgBinary();
				}
				public override mwg.File.mwgBinary ToMwgBinary(){
					mwg.File.mwgBinary r=((mwg.File.mbFourcc)"mn_L").ToMwgBinary();
					r+=((mwg.File.mbInt32)this.Count).ToMwgBinary();
					int c=this.Count;
					for(int i=0;i<c;i++)r+=this[i].ToMwgBinary();
					return r;
				}
				public static explicit operator EngWord.mean.List(mwg.File.mwgBinary a){return new EngWord.mean.List(a);}
				public static explicit operator EngWord.mean.List(byte[] a){return new EngWord.mean.List(a);}
			}
			#endregion
		}
		#endregion

		#region [child class wordCore]
		//=====================================
		//          child class : wordCore
		//-------------------------------------
		/// <summary>
		/// 単語本体の情報を管理します。
		/// </summary>
		public class wordCore:mwg.File.mb{
			//■mb 了■
			//---------------------------------
			//          fields
			//---------------------------------
			/// <summary>
			/// 単語の表記、つまり綴り(spell)を保持します。
			/// </summary>
			public string word;//単語の表記
			/// <summary>
			/// 単語の発音を保持します。発音記号の形で保持します。
			/// </summary>
			public string pronunciation;//発音
			//---------------------------------
			//       Properties   
			//---------------------------------
			/// <summary>
			/// 単語の綴り(spelling)を取得亦は設定します。
			/// </summary>
			public string Word{
				get{return this.word;}
				set{this.word=value;}
			}
			/// <summary>
			/// 単語の発音記号表記を取得亦は設定します。
			/// </summary>
			public string Pronunciation{
				get{return this.pronunciation;}
				set{this.pronunciation=value;}
			}
			//---------------------------------
			//          constructors
			//---------------------------------
			public wordCore():this("[new word]",""){}
			/// <summary>
			/// wordCore のコンストラクタ。指定した EngWord から必要な情報(つまり、綴りと発音)を抽出して其れを元にしてインスタンスを作成します。
			/// </summary>
			/// <param name="w1">元となる EngWord のインスタンスを指定して下さい。</param>
			public wordCore(EngWord w1){
				this.word=w1.Word;
				this.pronunciation=w1.Pronunciation;
			}
			/// <summary>
			/// wordCore のコンストラクタ。指定した wordCore の複製として作成します。
			/// </summary>
			/// <param name="c1">元となる EngWord.wordCore のインスタンスを指定して下さい。</param>
			public wordCore(EngWord.wordCore c1){
				this.word=c1.word;
				this.pronunciation=c1.pronunciation;
			}
			/// <summary>
			/// wordCore のコンストラクタ
			/// </summary>
			/// <param name="spell">登録する単語の綴りを指定します。</param>
			/// <param name="pron">登録する単語の発音記号を指定します。</param>
			public wordCore(string spell,string pron){
				this.word=spell;
				this.pronunciation=pron;
			}
			/// <summary>
			/// wordCore のコンストラクタ
			/// </summary>
			/// <param name="mbin">読込元の、mwg.File.mwgBinary を設定します。</param>
			public wordCore(mwg.File.mwgBinary mbin){
				this.word=(string)(mwg.File.mbString)mbin;
				this.pronunciation=(string)(mwg.File.mbString)mbin;
			}
			/// <summary>
			/// wordCore のコンストラクタ
			/// </summary>
			/// <param name="data">読込元の byte[] を設定します。</param>
			public wordCore(byte[] data):this((mwg.File.mwgBinary)data){}
			//--some functions
			/// <summary>
			/// wordCore を Stream などに書き込む事が出来る様に byte[] に変換します。
			/// </summary>
			/// <returns>変換して出来た byte[] を返します。</returns>
			public override byte[] ToBinary(){return (byte[])this.ToMwgBinary();}
			/// <summary>
			/// wordCore を mwg.File.mwgBinary に変換します。
			/// </summary>
			/// <returns>変換して出来た mwg.File.mwgBinary を返します。</returns>
			public override mwg.File.mwgBinary ToMwgBinary(){
				return ((mwg.File.mbString)this.word).ToMwgBinary()
					+((mwg.File.mbString)this.pronunciation).ToMwgBinary();
			}
			/// <summary>
			/// byte[] に変換した時の、byte 数 (byte[] 配列の長さ) を取得します。
			/// </summary>
			public override int Length{
				get{return ((mwg.File.mbString)this.word).Length+((mwg.File.mbString)this.pronunciation).Length;}
			}
			//--operators
			/// <summary>
			/// mwg.File.mwgBinaryインスタンス (stream) から情報を読み込んで、wordCore インスタンスを作成します。
			/// </summary>
			/// <param name="mbin">読込元の mwgBinary</param>
			/// <returns>読み込んで出来た wordCore インスタンス</returns>
			public static explicit operator wordCore(mwg.File.mwgBinary mbin){return new wordCore(mbin);}
			/// <summary>
			/// byte[] から情報を読み込んで、wordCore インスタンスを作成します。
			/// </summary>
			/// <param name="a">読込元の byte[]</param>
			/// <returns>読み込んで出来た wordCore インスタンス</returns>
			public static explicit operator wordCore(byte[] a){return new wordCore(a);} 
		}
		#endregion

		#region [child class sentence]
		//=====================================
		//          child class : sentence
		//-------------------------------------
		/// <summary>
		/// 例文、解説、諺、慣用句・決まり文句などを扱います。
		/// </summary>
		public class sentence:mwg.File.mb{
			//■mb■
			//field
			public string content;
			public EngWord.sentence.Type type;
			//constructor
			public sentence():this("[新しい例文・解説]",EngWord.sentence.Type.None){}
			public sentence(string snt):this(snt,EngWord.sentence.Type.None){}
			public sentence(string snt,EngWord.sentence.Type type){
				this.content=snt;
				this.type=type;
			}
			//properties
			/*
			public string Content{
				get{return this.content.ToString();}
				set{this.content=value;}
			}*/
			public System.Windows.Forms.TreeNode ToTreeNode(){
				string x=this.content;
				if(x.Length>20)x=x.Substring(0,17)+"...";
				//int imgN=this.type+12;
				//TODO: 絵柄を用意する
				return new System.Windows.Forms.TreeNode(x,0,0);
				//TODO: TreeNode の方からこの rela インスタンスを逆にたどる事が出来る様にする。
			}
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			//          mb functions
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			public sentence(mwg.File.mwgBinary mbin){
				this.content=(string)(mwg.File.mbString)mbin;
				this.type=(EngWord.sentence.Type)(int)(mwg.File.mbInt32)mbin;
			}
			public sentence(byte[] data):this((mwg.File.mwgBinary)data){}
			public override int Length{
				get{return ((mwg.File.mbString)this.content).Length+4;}
			}
			public override byte[] ToBinary(){
				return (byte[])this.ToMwgBinary();
			}
			public override mwg.File.mwgBinary ToMwgBinary(){
				return ((mwg.File.mbString)this.content).ToMwgBinary()+((mwg.File.mbInt32)(int)this.type).ToMwgBinary();
			}
			public static explicit operator EngWord.sentence(mwg.File.mwgBinary a){return new EngWord.sentence(a);}
			public static explicit operator EngWord.sentence(byte[] a){return new EngWord.sentence(a);}
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			//          child classes
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			public enum Type{
				None
				,Example
				,Description//解説
				,Proverb//諺、格言
				,FixedExpression//決まり文句
			}
			public class List:mwg.File.mb{
				//■mb了■
				private System.Collections.ArrayList dat=new System.Collections.ArrayList();
				public List(){}
				public void Add(EngWord.sentence snt){
					this.dat.Add(snt);
				}
				public EngWord.sentence this[int index]{
					get{
						return (EngWord.sentence)this.dat[index];
					}
					set{
						this.dat[index]=value;
					}
				}
				public int Count{get{return this.dat.Count;}}
				public void RemoveAt(int index){
					this.dat.RemoveAt(index);
				}
				public static explicit operator EngWord.sentence[](EngWord.sentence.List a){
					EngWord.sentence[] r=new EngWord.sentence[a.dat.Count];
					for(int i=0;i<a.dat.Count;i++){
						r[i]=(EngWord.sentence)a.dat[i];
					}
					return r;
				}
				//-----------------------------
				//        mb fucnitons
				//-----------------------------
				public List(mwg.File.mwgBinary mbin){
					string four=((mwg.File.mbFourcc)mbin).ToString();
					if(four!="sntL"){
						string message="現在 sentence.List として読み込もうとしているデータは sentence.Listではありません"
							+"\n現在のデータの位置: "+mbin.current.ToString()
							+"\nsntL となるべき所→ "+four;
						System.Console.WriteLine("\n===== mbReadingException =====\n"+message);
						throw(new mwg.File.mbReadingException(message,"mwgWords.EngWord.sentence.List"));
					}
					int c=(int)(mwg.File.mbInt32)mbin;//sentence の数
					for(int i=0;i<c;i++)this.dat.Add((EngWord.sentence)mbin);
				}
				public List(byte[] data):this((mwg.File.mwgBinary)data){}
				public override int Length{
					get{
						int r=8;
						int c=this.Count;
						for(int i=0;i<c;i++)r+=this[i].Length;
						return r;
					}
				}
				public override byte[] ToBinary(){
					return (byte[])this.ToMwgBinary();
				}
				public override mwg.File.mwgBinary ToMwgBinary(){
					mwg.File.mwgBinary r=((mwg.File.mbFourcc)"sntL").ToMwgBinary();
					r+=((mwg.File.mbInt32)this.Count).ToMwgBinary();
					int c=this.Count;
					for(int i=0;i<c;i++)r+=this[i].ToMwgBinary();
					return r;
				}
				public static explicit operator EngWord.sentence.List(mwg.File.mwgBinary a){return new EngWord.sentence.List(a);}
				public static explicit operator EngWord.sentence.List(byte[] a){return new EngWord.sentence.List(a);}
			}
		}
		#endregion

		#region [child class conj]
		//=====================================
		//          child class : conj
		//-------------------------------------
		/// <summary>
		/// 活用形を管理します。
		/// </summary>
		public class conj:mwg.File.mb{
			public EngWord.conj.Type type;
			public EngWord.wordCore wc;
			public string comment;
			
			public conj():this(EngWord.conj.Type.None,"[新しい活用]",""){}
			public conj(EngWord.conj.Type type,string spell,string pronunciation){
				this.type=type;
				this.wc=new wordCore(spell,pronunciation);
				this.comment="";
			}
			public enum Type{
				None
				,Plural//複数形
				,Comparative//比較級
				,Superlative//最上級
				,ThirdSinglePresent//三単現
				,Past//過去形
				,PastParticle//過去分詞
				,Possesses//所有格
				//不規則形だけ登録すれば宜しい。
			}
			public System.Windows.Forms.ListViewItem ToListViewItem(){
				string[] sub=new string[]{this.wc.Word,this.wc.Pronunciation,this.comment};
				return new System.Windows.Forms.ListViewItem(sub,EngWord.conj.typeNum(this.type));
			}
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			//          mb functions
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			public conj(mwg.File.mwgBinary mbin){
				this.type=(EngWord.conj.Type)(int)(mwg.File.mbInt32)mbin;
				this.wc=(EngWord.wordCore)mbin;
				this.comment=(string)(mwg.File.mbString)mbin;
			}
			public conj(byte[] data):this((mwg.File.mwgBinary)data){}
			public override int Length{
				get{
					return ((mwg.File.mbString)this.comment).Length+this.wc.Length+4;
				}
			}
			public override byte[] ToBinary(){
				return (byte[])this.ToMwgBinary();
			}
			public override mwg.File.mwgBinary ToMwgBinary(){
				return ((mwg.File.mbInt32)(int)this.type).ToMwgBinary()
					+this.wc.ToMwgBinary()
					+((mwg.File.mbString)this.comment).ToMwgBinary();
			}
			public static explicit operator EngWord.conj(mwg.File.mwgBinary a){return new EngWord.conj(a);}
			public static explicit operator EngWord.conj(byte[] a){return new EngWord.conj(a);}

			#region child class List
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			//          child classes
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			public class List:mwg.File.mb{
				private System.Collections.ArrayList dat=new System.Collections.ArrayList();
				public List(){}
				public void Add(EngWord.conj cnj){
					this.dat.Add(cnj);
				}
				public EngWord.conj this[int index]{
					get{
						return (EngWord.conj)this.dat[index];
					}
					set{
						this.dat[index]=value;
					}
				}
				public int Count{get{return this.dat.Count;}}
				public void RemoveAt(int index){
					this.dat.RemoveAt(index);
				}
				public static explicit operator EngWord.conj[](EngWord.conj.List a){
					EngWord.conj[] r=new EngWord.conj[a.dat.Count];
					for(int i=0;i<a.dat.Count;i++){
						r[i]=(EngWord.conj)a.dat[i];
					}
					return r;
				}
				//-----------------------------
				//        mb fucnitons
				//-----------------------------
				public List(mwg.File.mwgBinary mbin){
					if(((mwg.File.mbFourcc)mbin).ToString()!="cnjL"){
						throw(new mwg.File.mbReadingException(
							"現在、conj.List として読み込もうとしているデータは conj.Listではありません\n現在のデータの位置: "
							+mbin.current.ToString(),"mwgWords.EngWord.conj.List"));
					}
					int c=(int)(mwg.File.mbInt32)mbin;//sentence の数
					for(int i=0;i<c;i++)this.dat.Add((EngWord.conj)mbin);
				}
				public List(byte[] data):this((mwg.File.mwgBinary)data){}
				public override int Length{
					get{
						int r=8;
						int c=this.Count;
						for(int i=0;i<c;i++)r+=this[i].Length;
						return r;
					}
				}
				public override byte[] ToBinary(){
					return (byte[])this.ToMwgBinary();
				}
				public override mwg.File.mwgBinary ToMwgBinary(){
					mwg.File.mwgBinary r=((mwg.File.mbFourcc)"cnjL").ToMwgBinary();//
					r+=((mwg.File.mbInt32)this.Count).ToMwgBinary();
					int c=this.Count;
					for(int i=0;i<c;i++)r+=this[i].ToMwgBinary();
					return r;
				}
				public static explicit operator EngWord.conj.List(mwg.File.mwgBinary a){return new EngWord.conj.List(a);}
				public static explicit operator EngWord.conj.List(byte[] a){return new EngWord.conj.List(a);}
			}
			#endregion

			#region 活用変化自動推定関数群
			/// <summary>
			/// 複数形を推定します。(標準 Standard)
			/// </summary>
			/// <param name="a">単数形を指定します</param>
			/// <returns>ListViewItem として出力します。</returns>
			public static System.Windows.Forms.ListViewItem pluralS(string a){
				string spell;
				if(a.Length<2)spell=a+"s";
				else if(a.Substring(a.Length-2,2)=="fe"){
					spell=a.Substring(0,a.Length-2)+"ves";
				}else switch(a.Substring(a.Length-1,1)){
					case "o":
					case "x":
					case "s":
					case "v":
						spell=a+"es";
						break;
					case "y":
						spell=a.Substring(0,a.Length-1)+"ies";
						break;
					case "f":
						spell=a.Substring(0,a.Length-1)+"ves";
						break;
					//case "u":フランス語起源の語は ～x
					//case "us":Latin→～i
					//case "um":Latin→～a
					//case "":Latin→～
					default:
						spell=a+"s";
						break;
				}
				return new System.Windows.Forms.ListViewItem(new string[]{spell,"[推定未可]","複数形"},EngWord.conj.typeNum("複"),conj.jidoColor,conj.jidoBack,conj.jidoFont);
			}
			/// <summary>
			/// 所有格を推定します。(標準)
			/// </summary>
			/// <param name="a">名詞を指定します。</param>
			/// <returns>ListViewItem として出力します。</returns>
			public static System.Windows.Forms.ListViewItem possesS(string a){
				string spell;
				switch(a.Substring(a.Length-1,1)){
					case "s":spell=a+"'";break;
					default:spell=a+"'s";break;
				}
				return new System.Windows.Forms.ListViewItem(new string[]{spell,"[推定未可]","所有格"},EngWord.conj.typeNum("所"),conj.jidoColor,conj.jidoBack,conj.jidoFont);
			}
			/// <summary>
			/// 三人称単数複数形を推定します。
			/// </summary>
			/// <param name="a">現在形(原型)を指定します。</param>
			/// <returns>ListViewItem として出力します。</returns>
			public static System.Windows.Forms.ListViewItem tspS(string a){
				System.Windows.Forms.ListViewItem x=pluralS(a);
				x.SubItems[2].Text="三人称単数現在形";
				x.ImageIndex=EngWord.conj.typeNum("三");
				return x;
			}
			/// <summary>
			/// 現在分詞及び動名詞を推定します。(標準)
			/// </summary>
			/// <param name="a">原形(現在形)を指定します。</param>
			/// <returns>ListViewItem として出力します。</returns>
			public static System.Windows.Forms.ListViewItem ingS(string a){
				string spell;
				if(a.Length<2)spell=a+"ing";
				else if(a.Substring(a.Length-2,2)=="ie")spell=a.Substring(0,a.Length-2)+"ying";
				else switch(a.Substring(a.Length-1,1)){
					case "i":
					case "e":spell=a.Substring(0,a.Length-1)+"ing";break;
					default:spell=a+"ing";break;
				}
				return new System.Windows.Forms.ListViewItem(new string[]{spell,"[推定未可]","現在分詞及び動名詞"},EngWord.conj.typeNum("i"),conj.jidoColor,conj.jidoBack,conj.jidoFont);
				//TODO: アクセントの位置によって子音字を重ねる
			}
			//過去形・過去分詞
			/// <summary>
			/// 過去形を推定します。(標準 Standard)
			/// </summary>
			/// <param name="a">現在形を指定します</param>
			/// <returns>ListViewItem として出力します。</returns>
			public static System.Windows.Forms.ListViewItem pastS(string a){
				string spell;
				switch(a.Substring(a.Length-1,1)){
					case "e":
						spell=a+"d";
						break;
					case "y":
						spell=a.Substring(0,a.Length-1)+"ied";
						break;
					default:
						spell=a+"ed";
						break;
				}
				return new System.Windows.Forms.ListViewItem(new string[]{spell,"[推定未可]","過去形"},EngWord.conj.typeNum("過"),conj.jidoColor,conj.jidoBack,conj.jidoFont);
				//TODO: アクセントの位置によって子音字を重ねる。
			}
			//過去形・過去分詞
			/// <summary>
			/// 過去分詞を推定します。(標準 Standard)
			/// </summary>
			/// <param name="a">現在形を指定します</param>
			/// <returns>ListViewItem として出力します。</returns>
			public static System.Windows.Forms.ListViewItem ppS(string a){
				System.Windows.Forms.ListViewItem x=EngWord.conj.pastS(a);
				x.SubItems[2].Text="過去分詞";
				x.ImageIndex=EngWord.conj.typeNum("p");
				return x;
			}
			//比較級
			/// <summary>
			/// 比較級を推定します。(標準 Standard)
			/// </summary>
			/// <param name="a">原級を指定します</param>
			/// <returns>ListViewItem として出力します。</returns>
			public static System.Windows.Forms.ListViewItem compS(string a){
				string spell;
				switch(a.Substring(a.Length-1,1)){
					case "e":
						spell=a+"r";
						break;
					case "y":
						spell=a.Substring(0,a.Length-1)+"ier";
						break;
					default:
						spell=a+"er";
						break;
				}
				return new System.Windows.Forms.ListViewItem(new string[]{spell,"[推定未可]","比較級"},EngWord.conj.typeNum("比"),conj.jidoColor,conj.jidoBack,conj.jidoFont);
				//TODO: アクセントの位置によって子音字を重ねる。
			}
			//最上級
			/// <summary>
			/// 最上級を推定します。(標準 Standard)
			/// </summary>
			/// <param name="a">原級を指定します</param>
			/// <returns>ListViewItem として出力します。</returns>
			public static System.Windows.Forms.ListViewItem superS(string a){
				string spell;
				switch(a.Substring(a.Length-1,1)){
					case "e":
						spell=a+"st";
						break;
					case "y":
						spell=a.Substring(0,a.Length-1)+"iest";
						break;
					default:
						spell=a+"est";
						break;
				}
				return new System.Windows.Forms.ListViewItem(new string[]{spell,"[推定未可]","最上級"},EngWord.conj.typeNum("最"),conj.jidoColor,conj.jidoBack,conj.jidoFont);
				//TODO: アクセントの位置によって子音字を重ねる。
			}
			internal static System.Drawing.Color jidoColor=System.Drawing.Color.Gray;
			internal static System.Drawing.Color jidoBack=System.Drawing.Color.White;
			internal static System.Drawing.Font jidoFont=new System.Drawing.Font("MS UIGothic",8);
			public static int typeNum(string str)
			{
				if(str.Length==0)return 7;
				switch(str.Substring(0,1)){
					case "単":return 0;
					case "複":return 1;
					case "現":return 2;
					case "三":return 3;
					case "i":
					case "I":
						return 4;
					case "過":return 5;
					case "p":
					case "P":
						return 6;
					case "比":return 8;
					case "最":return 9;
					case "所":return 10;
					default:return 7;
				}
			}
			public static int typeNum(EngWord.conj.Type type){
				switch(type){
					case EngWord.conj.Type.Plural:return 0;
					case EngWord.conj.Type.ThirdSinglePresent:return 3;
					case EngWord.conj.Type.Past:return 5;
					case EngWord.conj.Type.PastParticle:return 6;
					case EngWord.conj.Type.Comparative:return 8;
					case EngWord.conj.Type.Superlative:return 9;
					case EngWord.conj.Type.Possesses:return 10;
					default:return 7;
				}
			}
			#endregion

		}
		#endregion

		#region [child class rela]
		//=====================================
		//          child class ; rela
		//-------------------------------------
		/// <summary>
		/// 関連のある語、参照する語を管理します。
		/// </summary>
		public class rela:mwg.File.mb{
			//▼参照の仕方に関するField
			/** <summary>参照の仕方を保持します。</summary>*/
			public EngWord.rela.Type type;
			/** <summary>参照の仕方についてコメントや解説がある場合、其れを管理します。</summary>*/
			public string comment;
			//▼参照先の単語に関するField
			/** <summary>参照する語が既に単語帳の中に登録されている物か否かを指定します。</summary>*/
			public bool exist;
			/** <summary>参照先単語の ID(identifier) を保持します。exist == true のときのみ有効です。</summary>*/
			public int identifier;
			/** <summary>参照先単語の核となる情報を保持します。</summary>*/
			public EngWord.wordCore core;
			/** <summary>簡単に意味を説明します。</summary>*/
			public string mean;
			//---------------------------------
			//          Constructor
			//---------------------------------
			public rela():this(EngWord.rela.Type.None,"[新しい関連語]",""){}
			public rela(string meaning):this(EngWord.rela.Type.None,meaning,""){}
			public rela(EngWord.rela.Type type,string spell,string meaning){
				this.type=type;
				this.comment="";
				this.exist=false;
				this.identifier=0;
				this.core=new EngWord.wordCore(spell,"");
				this.mean=meaning;
			}
			/// <summary>
			/// rela のコンストラクタ
			/// </summary>
			/// <param name="type">参照の仕方を指定します。</param>
			/// <param name="w1">元となる語(参照先の)を指定します。</param>
			/// <param name="comment">参照の仕方について解説等を指定します</param>
			public rela(EngWord.rela.Type type,EngWord w1,string comment){
				this.type=type;
				this.comment="";
				this.exist=true;
				this.identifier=w1.identifier;
				this.core=new EngWord.wordCore(w1);
				/*part が与えられた時
				if(w1.meaning.Length>0){
					int i;
					for(i=w1.meaning.Length;i>0;i++)if(w1.meaning[i].type=part)break;
					this.mean=w1.meaning[i].content;
				}else this.mean="";*/
				this.mean=(w1.meaning.Length>0)?w1.meaning[0].content:"";
			}
			/// <summary>
			/// rela のコンストラクタ
			/// </summary>
			/// <param name="w1">元となる語(参照先の)を指定します。</param>
			public rela(EngWord w1):this(EngWord.rela.Type.None,w1,""){}
			/// <summary>
			/// rela のコンストラクタ
			/// </summary>
			/// <param name="type">参照の仕方を指定します。</param>
			/// <param name="w1">元となる語(参照先の)を指定します。</param>
			public rela(EngWord.rela.Type type,EngWord w1):this(type,w1,""){}
			public System.Windows.Forms.TreeNode ToTreeNode(){
				int imgN=(int)this.type+12;
				if(imgN==0)imgN=0;
				return new System.Windows.Forms.TreeNode(this.core.Word,imgN,imgN);
				//TODO: TreeNode の方からこの rela インスタンスを逆にたどる事が出来る様にする。
			}
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			//          mb functions
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			public rela(mwg.File.mwgBinary mbin){
				this.type=(EngWord.rela.Type)(int)(mwg.File.mbInt32)mbin;
				this.comment=(string)(mwg.File.mbString)mbin;
				this.exist=(bool)(mwg.File.mbBool)mbin;
				this.identifier=(int)(mwg.File.mbInt32)mbin;
				this.core=(EngWord.wordCore)mbin;
				this.mean=(string)(mwg.File.mbString)mbin;
			}
			public rela(byte[] data):this((mwg.File.mwgBinary)data){}
			public override int Length{
				get{return 9+((mwg.File.mbString)this.comment).Length+this.core.Length+((mwg.File.mbString)this.mean).Length;}
			}
			public override byte[] ToBinary(){
				return (byte[])this.ToMwgBinary();
			}
			public override mwg.File.mwgBinary ToMwgBinary(){
				return ((mwg.File.mbInt32)(int)this.type).ToMwgBinary()
					+((mwg.File.mbString)this.comment).ToMwgBinary()
					+((mwg.File.mbBool)this.exist).ToMwgBinary()
					+((mwg.File.mbInt32)this.identifier).ToMwgBinary()
					+this.core.ToMwgBinary()
					+((mwg.File.mbString)this.mean).ToMwgBinary();
			}
			public static explicit operator EngWord.rela(mwg.File.mwgBinary a){return new EngWord.rela(a);}
			public static explicit operator EngWord.rela(byte[] a){return new EngWord.rela(a);}
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			//          child classes
			//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
			/// <summary>
			/// その語が、親の語とどのような関係にあるかを指定する列挙体です。
			/// </summary>
			public enum Type{
				/// <summary>どのような関連の語か指定しません。未指定または、その他の参照を表します</summary>
				None,
				/// <summary>同義語</summary>
				Synonym,
				/// <summary>類義語</summary>
				QuasiSynonym,
				/// <summary>反意語</summary>
				Antonym,
				/// <summary>省略、縮約</summary>
				Abbr,
				/// <summary>頭文字の略</summary>
				Acronym,
				/// <summary>語源</summary>
				Origin,
				/// <summary>語源的姉妹語</summary>
				Sister,
				/// <summary>派生語</summary>
				Derivative,
				/// <summary>その語を使った熟語</summary>
				Idiom,
				/// <summary>その語を使った構文</summary>
				Construction,
				/// <summary>熟語の構成単語(特に指定の要る場合以外は検索可能)</summary>
				Component,
				/// <summary>紛らわしい語、綴り間違い</summary>
				Misuse
			}
			public class List:mwg.File.mb{
				private System.Collections.ArrayList dat=new System.Collections.ArrayList();
				public List(){}
				public void Add(EngWord.rela rel){
					this.dat.Add(rel);
				}
				public EngWord.rela this[int index]{
					get{
						return (EngWord.rela)this.dat[index];
					}
					set{
						this.dat[index]=value;
					}
				}
				public int Count{get{return this.dat.Count;}}
				public void RemoveAt(int index){
					this.dat.RemoveAt(index);
				}
				public static explicit operator EngWord.rela[](EngWord.rela.List a){
					EngWord.rela[] r=new EngWord.rela[a.dat.Count];
					for(int i=0;i<a.dat.Count;i++){
						r[i]=(EngWord.rela)a.dat[i];
					}
					return r;
				}
				//-----------------------------
				//        mb fucnitons
				//-----------------------------
				public List(mwg.File.mwgBinary mbin){
					if(((mwg.File.mbFourcc)mbin).ToString()!="relL"){
						throw(new mwg.File.mbReadingException(
							"現在、rela.List として読み込もうとしているデータは rela.Listではありません\n現在のデータの位置: "
							+mbin.current.ToString(),"mwgWords.EngWord.rela.List"));
					}
					int c=(int)(mwg.File.mbInt32)mbin;//rela の数
					for(int i=0;i<c;i++)this.dat.Add((EngWord.rela)mbin);
				}
				public List(byte[] data):this((mwg.File.mwgBinary)data){}
				public override int Length{
					get{
						int r=8;
						int c=this.Count;
						for(int i=0;i<c;i++)r+=this[i].Length;
						return r;
					}
				}
				public override byte[] ToBinary(){
					return (byte[])this.ToMwgBinary();
				}
				public override mwg.File.mwgBinary ToMwgBinary(){
					mwg.File.mwgBinary r=((mwg.File.mbFourcc)"relL").ToMwgBinary();
					r+=((mwg.File.mbInt32)this.Count).ToMwgBinary();
					int c=this.Count;
					for(int i=0;i<c;i++)r+=this[i].ToMwgBinary();
					return r;
				}
				public static explicit operator EngWord.rela.List(mwg.File.mwgBinary a){return new EngWord.rela.List(a);}
				public static explicit operator EngWord.rela.List(byte[] a){return new EngWord.rela.List(a);}
			}
		}
		#endregion

	}
	public class EngWordGroup{
		public string title;
		public string description;
		public mwgWords.EngWord.rela.List relatives;
	}
}
