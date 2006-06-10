namespace mwg{
	public class stringList{
		public int start;
		public int len;
		public stringListNode[] nodes;
		public stringList(string[] array){
			for(int i=0;i<array.Length;i++){
				nodes[nodes.Length]=new stringListNode(i-1,i+1,array[i]);
			}
			len=array.Length;
			nodes[len-1].next=-1;
		}
		public struct stringListNode{
			public int next;
			public int prev;
			public string str;
			public stringListNode(int Next,int Prev,string Str){
				this.next=Next;
				this.prev=Prev;
				this.str=Str;
			}
		}
		public string Child(int index){
			int c=this.start;
			if(index!=0)for(int i=0;i<index;i++){
				c=nodes[c].next;
			}
			return nodes[c].str; 
		}
		public string[] ToArray(){
			string[] r=new string[]{};
			if(this.len==0)return r;
			int c=this.start;
			r[r.Length]=nodes[c].str;
			while(nodes[c].next!=-1){
				c=nodes[c].next;
				r[r.Length]=nodes[c].str;
			}
			return r;
		}	
		public System.Collections.ArrayList ToArrayList(){
			System.Collections.ArrayList r=new System.Collections.ArrayList();
			if(this.len==0)return r;
			int c=this.start;
			r.Add(nodes[c].str);
			while(nodes[c].next!=-1){
				c=nodes[c].next;
				r.Add(nodes[c].str);
			}
			return r;
		}
	}

}