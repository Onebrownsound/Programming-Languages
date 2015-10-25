using System;
using System.Collections;

namespace foodstuff {
	public class islistordered : foodvisitor
	{
		public string state ="fruit";

		public object visit(fruit f){
			if (state !="fruit") return false;
			else return f.nextitem.accept(this);
		}

		public object visit(vegetable v){
			if (state =="fruit" || state =="vegetable"){
				state ="vegetable";
				return v.nextitem.accept(this);
			}
			else return false;
		}
		public object visit(meat m){
			state = "meat";
			return m.nextitem.accept(this);

		}
		public object visit(nofood n){
			return true;

		}

	}
}