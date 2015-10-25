using System;
using System.Collections;

namespace foodstuff {


	public class sumFoodList: foodvisitor
	{
		public int foodSum=0;
		public object visit(fruit f){  
	     	foodSum+= f.Calories;
	     	return f.nextitem.accept(this);
	     }
		
		public object visit(meat m){  
		  	foodSum+= m.Calories;
		  	return m.nextitem.accept(this);
		  }


     public object visit(vegetable v){
	     	foodSum+= v.Calories;
	     	return v.nextitem.accept(this);
	     }

	   public object visit(nofood n){
	     	return foodSum;
	   }


	}

}