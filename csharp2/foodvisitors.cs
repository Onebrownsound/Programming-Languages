using System;
namespace foodstuff { // sample food visitors
///////////


// an "eater" will eat until a certain number of calories is reached
// returns total cals consumed.
// eater won't eat any vegetables.
public class eater : foodvisitor
{
   private int max;
   private int cals = 0;
   public eater(int m) {max = m;}
  
   public object visit(fruit f)
     {  Console.WriteLine("I'm eating the fruit "+f);
	cals += f.Calories;
	if (cals<max) return f.nextitem.accept(this); 
	else return cals;
     }

   public object visit(meat m)
     {  Console.WriteLine("I'm eating "+m+" now");
	cals += m.Calories;
	if (cals<max) return m.nextitem.accept(this); 
	else return cals;
     }

   public object visit(vegetable v)
     {  
	Console.Write("I hate vegetables! ");
	if (v.name=="spinach") 
          { Console.WriteLine("Except spinach!");
	    cals+=v.Calories;
	  }
	else Console.WriteLine("I won't eat "+v.name);
	if (cals<max) return v.nextitem.accept(this); 
	else return cals;
     }

   public object visit(nofood n)
     {
        if (cals<max) Console.WriteLine("No more food but I'm still hungry!");
          else Console.WriteLine("That was just right!");
	return cals;
     }
} // eating visitor


// healthnut visitor returns the fooditem with least calories
public class healthinspector : foodvisitor
{
   private fooditem min;
 
   // constructor must take first food cell
   public healthinspector(fooditem first)
   { min = first; }   

   public object visit(vegetable v)
   {
      if (v.Calories < min.Calories) min = v;
      return v.nextitem.accept(this);
   } 

   public object visit(fruit f)
   {
      if (f.Calories < min.Calories) min = f;
      return f.nextitem.accept(this);
   }

   public object visit(meat m) // can't be red meat!
   {
     if ((m.kind==Meattype.white) && m.Calories<min.Calories)
	min = m;
     return m.nextitem.accept(this);
   }

   public object visit(nofood n)
   {
     return min;
   } 

} // healthinspector visitor

///////////
}

/* question: how do I make code more efficient?  I can make a 
   superclass for all visitors, which will let'em share some code.
   But the code is already pretty neat!


   This code must be compiled together with foods.cs, otherwise it
   won't see the "internal" variables in "foods.cs":

   csc /t:library foods.cs foodvisitors.cs
*/
