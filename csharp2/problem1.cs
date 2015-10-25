using System;
using System.Collections;

namespace foodstuff {


	public class beverage: foodbase, fooditem
	{
		public int temperature = 10; //stupid extra field 

		public beverage(string n, int c) : base(n,c) {}
		public object accept(foodvisitor v) // only accepts master visitor methods
		{	
			if (v is mastervisitor) return ((mastervisitor)v).visit(this);
    		else throw new Exception("this visitor will not work");

		} 
 	}

 	public interface mastervisitor : foodvisitor // so a mastervisitor can visit all visitee classes at this point in time
 	{
 		object visit(beverage b);
 	}// just make sure to include implementing this interfact when you make a new visitor class and you should be good to go


 	public class beveragevisitor: mastervisitor
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

	   public object visit(beverage b){
	   	foodSum+= b.Calories;
	   	return b.nextitem.accept(this);
	   }
	}
 	













}// end of foodstuf namespace