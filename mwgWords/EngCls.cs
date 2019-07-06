namespace mwgWords{
	/// <summary>
	/// �p�P��A�p�n���\������N���X�ł��B
	/// </summary>
	public class EngWord:mwg.File.mb{

		#region fields & properties
		//=====================================
		//          Fields
		//-------------------------------------
		/// <summary>
		/// �P������ʂ���ׂ́AID�ԍ��ł��B���ۂ̎��ʂɂ́A�Ԃ�(core.word)�������Ďg�p���܂��B
		/// </summary>
		public int identifier;
		/// <summary>
		/// �\�L�A�����A�����Ǘ����܂��B�\�L�����̂ݎg���������邩��A�ė��p�����l�����ăJ�v�Z�����������ł��B
		/// </summary>
		public EngWord.wordCore core;
		/// <summary>
		/// �i���A�Ӗ��A�ᕶ�����Ǘ����܂��B
		/// </summary>
		public EngWord.mean.List meaning;
		/// <summary>
		/// �֘A�������Ǘ����܂��B
		/// </summary>
		public EngWord.rela.List relative;
		/// <summary>
		/// �Ӗ���^�����ē����鎖���o�������A�̔z��B
		/// �I�����Ő��� - a b c d ... (���Ԃ�������ƒi�X�������ς��) ; 
		/// �I�����ŕs���� - z ; 
		/// ���ڏ����Đ��� - A B C D ;  
		/// ���ڏ����ĕs���� - Z ;
		/// </summary>
		public string spellScore;
		/// <summary>
		/// �P���^�����ĈӖ��𓚂��鎖���o�������A�̔z��B
		/// �I�����Ő��� - a b c d ... (���Ԃ�������ƒi�X�������ς��) ; 
		/// �I�����ŕs���� - z ; 
		/// ���ڏ����Đ��� - A B C D ;  
		/// ���ڏ����ĕs���� - Z ;
		/// </summary>
		public string meanScore;
		//=====================================
		//          Properties
		//-------------------------------------
		/// <summary>
		/// �P������ʂ���ׂ� ID ���擾���܂��B
		/// </summary>
		public int ID{
			get{return this.identifier;}
		}
		/// <summary>
		/// �P��̒Ԃ�̕������擾���͐ݒ肵�܂��B
		/// </summary>
		public string Word{
			get{return this.core.word;}set{this.core.word=value;}
		}
		/// <summary>
		/// �P��̔������擾���͐ݒ肵�܂��B
		/// </summary>
		public string Pronunciation{
			get{return this.core.pronunciation;}set{this.core.pronunciation=value;}
		}
		/// <summary>
		/// �P��̒Ԃ�̐���s�����̋L���\��Ԃ��܂��B
		/// </summary>
		public string SpellScore{get{return this.spellScore;}}
		/// <summary>
		/// �P��̈Ӗ��𐳂���������ꂽ���ۂ��̋L���\��Ԃ��܂��B
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
		/// mwgWords.EngWord �R���X�g���N�^�B
		/// </summary>
		/// <param name="mbin">�Ǎ����� mwg.File.mwgBinary �C���X�^���X���w�肵�܂��B</param>
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
		/// mwgWords.EngWord �R���X�g���N�^�B
		/// </summary>
		/// <param name="data">�Ǎ����� byte[] ���w�肵�܂��B</param>
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
		/// �P��̕i���A�Ӗ��Ƃ���ɕt����������Ǘ����܂��B
		/// </summary>
		public class mean:mwg.File.mb{
			#region fields
			//---------------------------------
			//          Fields
			//---------------------------------
			/// <summary>
			/// �Ӗ��̖{��(���{��ɂ�����)��ێ����܂��B
			/// </summary>
			public string content;
			/// <summary>
			/// �i�������ł��邩��ێ����܂��B
			/// </summary>
			public EngWord.mean.Type type;
			/// <summary>
			/// ���̒P��ׂ̍������ނ��w�肵�܂��B
			/// </summary>
			public EngWord.mean.Attr attribute;
			/// <summary>
			/// ���̒P��́A�����ɉ�����������w�肵�܂��B
			/// </summary>
			public EngWord.mean.Usage usage;
			/// <summary>
			/// �ᕶ�A��󕶁A����Ȃǂ�ێ����܂��B
			/// </summary>
			public EngWord.sentence.List sentence;
			/// <summary>
			/// ���p�̃��X�g���Ǘ����܂��B
			/// </summary>
			public EngWord.conj.List conjugation;
			/// <summary>
			/// �֘A�������Ǘ����܂��B
			/// </summary>
			public EngWord.rela.List relative;
			/// <summary>
			/// �e�P��ւ̎Q�Ƃł��B�e�ƂȂ�P��ւ̐ڐG���s���ׂɕK�v�ł��B
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
			
			public mean():this(mwgWords.EngWord.mean.Type.None,"[�V�����Ӗ�]"){}
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
						//�P���`
						r0.Add(this.ConjJido("�P���`"));
						//�����`
						r1=this.ConjByType(EngWord.conj.Type.Plural);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.pluralS(this.Parent.Word));
							else r0.Add(this.ConjFumei("�����`"));
						}else r0.AddRange(r1);
						//���L�i
						r1=this.ConjByType(EngWord.conj.Type.Possesses);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.possesS(this.Parent.Word));
							else r0.Add(this.ConjFumei("���L�i"));
						}else r0.AddRange(r1);
						break;
					case EngWord.mean.Type.Verb:
						//���݌`
						r0.Add(this.ConjJido("���݌`"));
						//�O�P��
						r1=this.ConjByType(EngWord.conj.Type.ThirdSinglePresent);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.tspS(this.Parent.Word));
							else r0.Add(this.ConjFumei("�O�l�̒P�����݌`"));
						}else r0.AddRange(r1);
						//�ߋ�
						r1=this.ConjByType(EngWord.conj.Type.Past);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.pastS(this.Parent.Word));
							else r0.Add(this.ConjFumei("�ߋ��`"));
						}else r0.AddRange(r1);
						//�ߋ�����
						r1=this.ConjByType(EngWord.conj.Type.PastParticle);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.ppS(this.Parent.Word));
							else r0.Add(this.ConjFumei("pp(�ߋ�����)"));
						}else r0.AddRange(r1);
						//ing�`
						if(this.Parent!=null){
							r0.Add(EngWord.conj.ingS(this.Parent.Word));
						}else r0.Add(this.ConjFumei("ing(���ݕ����A������)"));
						break;
					case EngWord.mean.Type.Auxiliary:
						//���݌`
						r0.Add(this.ConjJido("���݌`"));
						//�ߋ�
						r1=this.ConjByType(EngWord.conj.Type.Past);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.pastS(this.Parent.Word));
							else r0.Add(this.ConjFumei("�ߋ��`"));
						}else r0.AddRange(r1);
						break;
					case EngWord.mean.Type.Adverb:
					case EngWord.mean.Type.Adjective:
						//����
						r0.Add(this.ConjJido("����"));
						//��r��
						r1=this.ConjByType(EngWord.conj.Type.Comparative);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.compS(this.Parent.Word));
							else r0.Add(this.ConjFumei("��r��"));
						}else r0.AddRange(r1);
						//�ŏ㋉
						r1=this.ConjByType(EngWord.conj.Type.Superlative);
						if(r1.Count==0){
							if(this.Parent!=null)r0.Add(EngWord.conj.superS(this.Parent.Word));
							else r0.Add(this.ConjFumei("�ŏ㋉"));
						}else r0.AddRange(r1);
						break;
					default:
						//���݌`
						r0.Add(this.ConjJido("���`"));
						//��
						for(int i=0;i<this.conjugation.Count;i++){
							if(this.conjugation[i].type!=EngWord.conj.Type.None){
								r0.Add(this.conjugation[i].ToListViewItem());
							}
						}
						break;
				}
				//���̑��̕���ǉ�
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
				return new System.Windows.Forms.ListViewItem(new string[]{"�s��","�s��",type},EngWord.conj.typeNum(type),conj.jidoColor,conj.jidoBack,conj.jidoFont);
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
				//TODO: TreeNode ���炱�� mean �C���X�^���X��H���l�ɂ���B
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
			/// �i�����Ǘ�����񋓑�
			/// </summary>
			public enum Type{
				None//���̑��A����
				,Noun//����
				,Verb//����
				,Adjective//�`�e��
				,Adverb//����
				,Preposition//�O�u��
				,Pronoun//�㖼��
				,Conjunction//�ڑ���
				,Auxiliary//������
				,Interjection//�ԓ���
				,Article//���� a an the �̂�
				,Idiom//�n��
				,Construction//�\��
			}
			public static string[] Types=new string[]{"�Ȃ�","����","����","�`�e��","����","�O�u��","�㖼��",
														 "�ڑ���","������","�ԓ���","����","�n��","�\��"};
			/// <summary>
			/// �l�X�ȑ����������܂��B
			/// </summary>
			[System.Flags()]
			public enum Attr{
				Proper=1//�ŗL
				,Collective=2//�W������
				,Abstract=4//�s�Z����(����)
				,Material=8//�s�Z����(����)
				,SV=16//������
				,SVC=32//�A������
				,SVO=64//������
				,SVOO=128//������
				,SVOC=256//������
				,Reflexive=512//�ċA����(oneself ��ړI��Ɏ��)�A�ċN����
				,Causative=1024//�g�𓮎�
				,Factive=2048//��ד���
				,Stative=4096//��ԓ���
				,Sensational=8192//�m�o���� sensational �Ƃ����̂��ǂ�����???
				,Interrogative=16384//�^�⎌
				,RelativePronoun=32768//�֌W�㖼��
				,RelativeAdverb=65536//�֌W����
				,Phrase=131072//�� �O�u����A�`�e����A������Ȃ�
				,Clause=262144//�� �֌W����
			}
			//�����Ƃ��Ēǉ���������
			//���������x�����A�p�x����
			//�ԓ��������A�A���Q
			//�������ŗL�l���A�ŗL�g�D�A�ŗL�n��
			//�n��͕i���ł͂Ȃ��āA�����Ƃ��Ĉ����������ǂ��B
			/// <summary>
			/// �ǂ�ȗp�@���K�p����邩�������܂��B
			/// </summary>
			[System.Flags()]
			public enum Usage{
				Nominal=1//�P�������I�p�@(to �s�莌�A������)
				,PluralNominal=2//���������I�p�@
				,Attributive=4//����`�e���I�p�@(�O�u����A�֌W��)
				,Predicative=8//���q�`�e���I�p�@(�O�u����A�֌W�㖼��)
				,Adjunct=16//�����I�p�@(�O�u����A�֌W����)
			}

			/// <summary>
			/// ����(�s�萔)���Ǘ�����̂ɗ��p�B
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
						string message="���� sentence.List �Ƃ��ēǂݍ������Ƃ��Ă���f�[�^�� mean.List�ł͂���܂���"
							+"\n���݂̃f�[�^�̈ʒu: "+mbin.current.ToString()+"/"+mbin.binaryData.Length.ToString()
							+"\nmn_L �ƂȂ�ׂ����� "+four;
						System.Console.WriteLine("\n===== mbReadingException =====\n"+message);
						throw(new mwg.File.mbReadingException(message,"mwgWords.EngWord.mean.List"));
					}
					int c=(int)(mwg.File.mbInt32)mbin;//mean �̐�
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
		/// �P��{�̂̏����Ǘ����܂��B
		/// </summary>
		public class wordCore:mwg.File.mb{
			//��mb ����
			//---------------------------------
			//          fields
			//---------------------------------
			/// <summary>
			/// �P��̕\�L�A�܂�Ԃ�(spell)��ێ����܂��B
			/// </summary>
			public string word;//�P��̕\�L
			/// <summary>
			/// �P��̔�����ێ����܂��B�����L���̌`�ŕێ����܂��B
			/// </summary>
			public string pronunciation;//����
			//---------------------------------
			//       Properties   
			//---------------------------------
			/// <summary>
			/// �P��̒Ԃ�(spelling)���擾���͐ݒ肵�܂��B
			/// </summary>
			public string Word{
				get{return this.word;}
				set{this.word=value;}
			}
			/// <summary>
			/// �P��̔����L���\�L���擾���͐ݒ肵�܂��B
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
			/// wordCore �̃R���X�g���N�^�B�w�肵�� EngWord ����K�v�ȏ��(�܂�A�Ԃ�Ɣ���)�𒊏o���đ�������ɂ��ăC���X�^���X���쐬���܂��B
			/// </summary>
			/// <param name="w1">���ƂȂ� EngWord �̃C���X�^���X���w�肵�ĉ������B</param>
			public wordCore(EngWord w1){
				this.word=w1.Word;
				this.pronunciation=w1.Pronunciation;
			}
			/// <summary>
			/// wordCore �̃R���X�g���N�^�B�w�肵�� wordCore �̕����Ƃ��č쐬���܂��B
			/// </summary>
			/// <param name="c1">���ƂȂ� EngWord.wordCore �̃C���X�^���X���w�肵�ĉ������B</param>
			public wordCore(EngWord.wordCore c1){
				this.word=c1.word;
				this.pronunciation=c1.pronunciation;
			}
			/// <summary>
			/// wordCore �̃R���X�g���N�^
			/// </summary>
			/// <param name="spell">�o�^����P��̒Ԃ���w�肵�܂��B</param>
			/// <param name="pron">�o�^����P��̔����L�����w�肵�܂��B</param>
			public wordCore(string spell,string pron){
				this.word=spell;
				this.pronunciation=pron;
			}
			/// <summary>
			/// wordCore �̃R���X�g���N�^
			/// </summary>
			/// <param name="mbin">�Ǎ����́Amwg.File.mwgBinary ��ݒ肵�܂��B</param>
			public wordCore(mwg.File.mwgBinary mbin){
				this.word=(string)(mwg.File.mbString)mbin;
				this.pronunciation=(string)(mwg.File.mbString)mbin;
			}
			/// <summary>
			/// wordCore �̃R���X�g���N�^
			/// </summary>
			/// <param name="data">�Ǎ����� byte[] ��ݒ肵�܂��B</param>
			public wordCore(byte[] data):this((mwg.File.mwgBinary)data){}
			//--some functions
			/// <summary>
			/// wordCore �� Stream �Ȃǂɏ������ގ����o����l�� byte[] �ɕϊ����܂��B
			/// </summary>
			/// <returns>�ϊ����ďo���� byte[] ��Ԃ��܂��B</returns>
			public override byte[] ToBinary(){return (byte[])this.ToMwgBinary();}
			/// <summary>
			/// wordCore �� mwg.File.mwgBinary �ɕϊ����܂��B
			/// </summary>
			/// <returns>�ϊ����ďo���� mwg.File.mwgBinary ��Ԃ��܂��B</returns>
			public override mwg.File.mwgBinary ToMwgBinary(){
				return ((mwg.File.mbString)this.word).ToMwgBinary()
					+((mwg.File.mbString)this.pronunciation).ToMwgBinary();
			}
			/// <summary>
			/// byte[] �ɕϊ��������́Abyte �� (byte[] �z��̒���) ���擾���܂��B
			/// </summary>
			public override int Length{
				get{return ((mwg.File.mbString)this.word).Length+((mwg.File.mbString)this.pronunciation).Length;}
			}
			//--operators
			/// <summary>
			/// mwg.File.mwgBinary�C���X�^���X (stream) �������ǂݍ���ŁAwordCore �C���X�^���X���쐬���܂��B
			/// </summary>
			/// <param name="mbin">�Ǎ����� mwgBinary</param>
			/// <returns>�ǂݍ���ŏo���� wordCore �C���X�^���X</returns>
			public static explicit operator wordCore(mwg.File.mwgBinary mbin){return new wordCore(mbin);}
			/// <summary>
			/// byte[] �������ǂݍ���ŁAwordCore �C���X�^���X���쐬���܂��B
			/// </summary>
			/// <param name="a">�Ǎ����� byte[]</param>
			/// <returns>�ǂݍ���ŏo���� wordCore �C���X�^���X</returns>
			public static explicit operator wordCore(byte[] a){return new wordCore(a);} 
		}
		#endregion

		#region [child class sentence]
		//=====================================
		//          child class : sentence
		//-------------------------------------
		/// <summary>
		/// �ᕶ�A����A���A���p��E���܂蕶��Ȃǂ������܂��B
		/// </summary>
		public class sentence:mwg.File.mb{
			//��mb��
			//field
			public string content;
			public EngWord.sentence.Type type;
			//constructor
			public sentence():this("[�V�����ᕶ�E���]",EngWord.sentence.Type.None){}
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
				//TODO: �G����p�ӂ���
				return new System.Windows.Forms.TreeNode(x,0,0);
				//TODO: TreeNode �̕����炱�� rela �C���X�^���X���t�ɂ��ǂ鎖���o����l�ɂ���B
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
				,Description//���
				,Proverb//���A�i��
				,FixedExpression//���܂蕶��
			}
			public class List:mwg.File.mb{
				//��mb����
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
						string message="���� sentence.List �Ƃ��ēǂݍ������Ƃ��Ă���f�[�^�� sentence.List�ł͂���܂���"
							+"\n���݂̃f�[�^�̈ʒu: "+mbin.current.ToString()
							+"\nsntL �ƂȂ�ׂ����� "+four;
						System.Console.WriteLine("\n===== mbReadingException =====\n"+message);
						throw(new mwg.File.mbReadingException(message,"mwgWords.EngWord.sentence.List"));
					}
					int c=(int)(mwg.File.mbInt32)mbin;//sentence �̐�
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
		/// ���p�`���Ǘ����܂��B
		/// </summary>
		public class conj:mwg.File.mb{
			public EngWord.conj.Type type;
			public EngWord.wordCore wc;
			public string comment;
			
			public conj():this(EngWord.conj.Type.None,"[�V�������p]",""){}
			public conj(EngWord.conj.Type type,string spell,string pronunciation){
				this.type=type;
				this.wc=new wordCore(spell,pronunciation);
				this.comment="";
			}
			public enum Type{
				None
				,Plural//�����`
				,Comparative//��r��
				,Superlative//�ŏ㋉
				,ThirdSinglePresent//�O�P��
				,Past//�ߋ��`
				,PastParticle//�ߋ�����
				,Possesses//���L�i
				//�s�K���`�����o�^����΋X�����B
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
							"���݁Aconj.List �Ƃ��ēǂݍ������Ƃ��Ă���f�[�^�� conj.List�ł͂���܂���\n���݂̃f�[�^�̈ʒu: "
							+mbin.current.ToString(),"mwgWords.EngWord.conj.List"));
					}
					int c=(int)(mwg.File.mbInt32)mbin;//sentence �̐�
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

			#region ���p�ω���������֐��Q
			/// <summary>
			/// �����`�𐄒肵�܂��B(�W�� Standard)
			/// </summary>
			/// <param name="a">�P���`���w�肵�܂�</param>
			/// <returns>ListViewItem �Ƃ��ďo�͂��܂��B</returns>
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
					//case "u":�t�����X��N���̌�� �`x
					//case "us":Latin���`i
					//case "um":Latin���`a
					//case "":Latin���`
					default:
						spell=a+"s";
						break;
				}
				return new System.Windows.Forms.ListViewItem(new string[]{spell,"[���薢��]","�����`"},EngWord.conj.typeNum("��"),conj.jidoColor,conj.jidoBack,conj.jidoFont);
			}
			/// <summary>
			/// ���L�i�𐄒肵�܂��B(�W��)
			/// </summary>
			/// <param name="a">�������w�肵�܂��B</param>
			/// <returns>ListViewItem �Ƃ��ďo�͂��܂��B</returns>
			public static System.Windows.Forms.ListViewItem possesS(string a){
				string spell;
				switch(a.Substring(a.Length-1,1)){
					case "s":spell=a+"'";break;
					default:spell=a+"'s";break;
				}
				return new System.Windows.Forms.ListViewItem(new string[]{spell,"[���薢��]","���L�i"},EngWord.conj.typeNum("��"),conj.jidoColor,conj.jidoBack,conj.jidoFont);
			}
			/// <summary>
			/// �O�l�̒P�������`�𐄒肵�܂��B
			/// </summary>
			/// <param name="a">���݌`(���^)���w�肵�܂��B</param>
			/// <returns>ListViewItem �Ƃ��ďo�͂��܂��B</returns>
			public static System.Windows.Forms.ListViewItem tspS(string a){
				System.Windows.Forms.ListViewItem x=pluralS(a);
				x.SubItems[2].Text="�O�l�̒P�����݌`";
				x.ImageIndex=EngWord.conj.typeNum("�O");
				return x;
			}
			/// <summary>
			/// ���ݕ����y�ѓ������𐄒肵�܂��B(�W��)
			/// </summary>
			/// <param name="a">���`(���݌`)���w�肵�܂��B</param>
			/// <returns>ListViewItem �Ƃ��ďo�͂��܂��B</returns>
			public static System.Windows.Forms.ListViewItem ingS(string a){
				string spell;
				if(a.Length<2)spell=a+"ing";
				else if(a.Substring(a.Length-2,2)=="ie")spell=a.Substring(0,a.Length-2)+"ying";
				else switch(a.Substring(a.Length-1,1)){
					case "i":
					case "e":spell=a.Substring(0,a.Length-1)+"ing";break;
					default:spell=a+"ing";break;
				}
				return new System.Windows.Forms.ListViewItem(new string[]{spell,"[���薢��]","���ݕ����y�ѓ�����"},EngWord.conj.typeNum("i"),conj.jidoColor,conj.jidoBack,conj.jidoFont);
				//TODO: �A�N�Z���g�̈ʒu�ɂ���Ďq�������d�˂�
			}
			//�ߋ��`�E�ߋ�����
			/// <summary>
			/// �ߋ��`�𐄒肵�܂��B(�W�� Standard)
			/// </summary>
			/// <param name="a">���݌`���w�肵�܂�</param>
			/// <returns>ListViewItem �Ƃ��ďo�͂��܂��B</returns>
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
				return new System.Windows.Forms.ListViewItem(new string[]{spell,"[���薢��]","�ߋ��`"},EngWord.conj.typeNum("��"),conj.jidoColor,conj.jidoBack,conj.jidoFont);
				//TODO: �A�N�Z���g�̈ʒu�ɂ���Ďq�������d�˂�B
			}
			//�ߋ��`�E�ߋ�����
			/// <summary>
			/// �ߋ������𐄒肵�܂��B(�W�� Standard)
			/// </summary>
			/// <param name="a">���݌`���w�肵�܂�</param>
			/// <returns>ListViewItem �Ƃ��ďo�͂��܂��B</returns>
			public static System.Windows.Forms.ListViewItem ppS(string a){
				System.Windows.Forms.ListViewItem x=EngWord.conj.pastS(a);
				x.SubItems[2].Text="�ߋ�����";
				x.ImageIndex=EngWord.conj.typeNum("p");
				return x;
			}
			//��r��
			/// <summary>
			/// ��r���𐄒肵�܂��B(�W�� Standard)
			/// </summary>
			/// <param name="a">�������w�肵�܂�</param>
			/// <returns>ListViewItem �Ƃ��ďo�͂��܂��B</returns>
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
				return new System.Windows.Forms.ListViewItem(new string[]{spell,"[���薢��]","��r��"},EngWord.conj.typeNum("��"),conj.jidoColor,conj.jidoBack,conj.jidoFont);
				//TODO: �A�N�Z���g�̈ʒu�ɂ���Ďq�������d�˂�B
			}
			//�ŏ㋉
			/// <summary>
			/// �ŏ㋉�𐄒肵�܂��B(�W�� Standard)
			/// </summary>
			/// <param name="a">�������w�肵�܂�</param>
			/// <returns>ListViewItem �Ƃ��ďo�͂��܂��B</returns>
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
				return new System.Windows.Forms.ListViewItem(new string[]{spell,"[���薢��]","�ŏ㋉"},EngWord.conj.typeNum("��"),conj.jidoColor,conj.jidoBack,conj.jidoFont);
				//TODO: �A�N�Z���g�̈ʒu�ɂ���Ďq�������d�˂�B
			}
			internal static System.Drawing.Color jidoColor=System.Drawing.Color.Gray;
			internal static System.Drawing.Color jidoBack=System.Drawing.Color.White;
			internal static System.Drawing.Font jidoFont=new System.Drawing.Font("MS UIGothic",8);
			public static int typeNum(string str)
			{
				if(str.Length==0)return 7;
				switch(str.Substring(0,1)){
					case "�P":return 0;
					case "��":return 1;
					case "��":return 2;
					case "�O":return 3;
					case "i":
					case "I":
						return 4;
					case "��":return 5;
					case "p":
					case "P":
						return 6;
					case "��":return 8;
					case "��":return 9;
					case "��":return 10;
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
		/// �֘A�̂����A�Q�Ƃ������Ǘ����܂��B
		/// </summary>
		public class rela:mwg.File.mb{
			//���Q�Ƃ̎d���Ɋւ���Field
			/** <summary>�Q�Ƃ̎d����ێ����܂��B</summary>*/
			public EngWord.rela.Type type;
			/** <summary>�Q�Ƃ̎d���ɂ��ăR�����g����������ꍇ�A������Ǘ����܂��B</summary>*/
			public string comment;
			//���Q�Ɛ�̒P��Ɋւ���Field
			/** <summary>�Q�Ƃ���ꂪ���ɒP�꒠�̒��ɓo�^����Ă��镨���ۂ����w�肵�܂��B</summary>*/
			public bool exist;
			/** <summary>�Q�Ɛ�P��� ID(identifier) ��ێ����܂��Bexist == true �̂Ƃ��̂ݗL���ł��B</summary>*/
			public int identifier;
			/** <summary>�Q�Ɛ�P��̊j�ƂȂ����ێ����܂��B</summary>*/
			public EngWord.wordCore core;
			/** <summary>�ȒP�ɈӖ���������܂��B</summary>*/
			public string mean;
			//---------------------------------
			//          Constructor
			//---------------------------------
			public rela():this(EngWord.rela.Type.None,"[�V�����֘A��]",""){}
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
			/// rela �̃R���X�g���N�^
			/// </summary>
			/// <param name="type">�Q�Ƃ̎d�����w�肵�܂��B</param>
			/// <param name="w1">���ƂȂ��(�Q�Ɛ��)���w�肵�܂��B</param>
			/// <param name="comment">�Q�Ƃ̎d���ɂ��ĉ�������w�肵�܂�</param>
			public rela(EngWord.rela.Type type,EngWord w1,string comment){
				this.type=type;
				this.comment="";
				this.exist=true;
				this.identifier=w1.identifier;
				this.core=new EngWord.wordCore(w1);
				/*part ���^����ꂽ��
				if(w1.meaning.Length>0){
					int i;
					for(i=w1.meaning.Length;i>0;i++)if(w1.meaning[i].type=part)break;
					this.mean=w1.meaning[i].content;
				}else this.mean="";*/
				this.mean=(w1.meaning.Length>0)?w1.meaning[0].content:"";
			}
			/// <summary>
			/// rela �̃R���X�g���N�^
			/// </summary>
			/// <param name="w1">���ƂȂ��(�Q�Ɛ��)���w�肵�܂��B</param>
			public rela(EngWord w1):this(EngWord.rela.Type.None,w1,""){}
			/// <summary>
			/// rela �̃R���X�g���N�^
			/// </summary>
			/// <param name="type">�Q�Ƃ̎d�����w�肵�܂��B</param>
			/// <param name="w1">���ƂȂ��(�Q�Ɛ��)���w�肵�܂��B</param>
			public rela(EngWord.rela.Type type,EngWord w1):this(type,w1,""){}
			public System.Windows.Forms.TreeNode ToTreeNode(){
				int imgN=(int)this.type+12;
				if(imgN==0)imgN=0;
				return new System.Windows.Forms.TreeNode(this.core.Word,imgN,imgN);
				//TODO: TreeNode �̕����炱�� rela �C���X�^���X���t�ɂ��ǂ鎖���o����l�ɂ���B
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
			/// ���̌ꂪ�A�e�̌�Ƃǂ̂悤�Ȋ֌W�ɂ��邩���w�肷��񋓑̂ł��B
			/// </summary>
			public enum Type{
				/// <summary>�ǂ̂悤�Ȋ֘A�̌ꂩ�w�肵�܂���B���w��܂��́A���̑��̎Q�Ƃ�\���܂�</summary>
				None,
				/// <summary>���`��</summary>
				Synonym,
				/// <summary>�ދ`��</summary>
				QuasiSynonym,
				/// <summary>���ӌ�</summary>
				Antonym,
				/// <summary>�ȗ��A�k��</summary>
				Abbr,
				/// <summary>�������̗�</summary>
				Acronym,
				/// <summary>�ꌹ</summary>
				Origin,
				/// <summary>�ꌹ�I�o����</summary>
				Sister,
				/// <summary>�h����</summary>
				Derivative,
				/// <summary>���̌���g�����n��</summary>
				Idiom,
				/// <summary>���̌���g�����\��</summary>
				Construction,
				/// <summary>�n��̍\���P��(���Ɏw��̗v��ꍇ�ȊO�͌����\)</summary>
				Component,
				/// <summary>����킵����A�Ԃ�ԈႢ</summary>
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
							"���݁Arela.List �Ƃ��ēǂݍ������Ƃ��Ă���f�[�^�� rela.List�ł͂���܂���\n���݂̃f�[�^�̈ʒu: "
							+mbin.current.ToString(),"mwgWords.EngWord.rela.List"));
					}
					int c=(int)(mwg.File.mbInt32)mbin;//rela �̐�
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
