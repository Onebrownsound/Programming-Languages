/* this program implements the visitor pattern interface and visitee classes
   (visitor classes are in foodvisitors.cs).  The visitees are food items.
   There are currently 4 types of food items: fruit, vegetable, meat, and
   the identity 'nofood'.  The food items can form a linked list (note
   nextitem pointer in foodbase superclass).  
*/
using System;
namespace foodstuff {
/////////

public interface fooditem    // visitee class
{
   int Calories { get; }   // every fooditem has a number of calories
   object accept(foodvisitor v);  // accept visitor object
   // fooditem next{ get; set; }  // optional manipulation of next pointer here
}

public interface foodvisitor  // visitor class
{
   object visit(fruit f);
   object visit(vegetable v);
   object visit(meat m);
   object visit(nofood nf);
}

public class foodbase // contains items common to all food items.
{                     // note that a food base is not itself a fooditem.
   public readonly string name; // can only be set by constructor
   protected int calories;
   public foodbase(string n, int c)
     { name = n;  calories = c; }
   public virtual int Calories { get { return calories; } }
   public override string ToString() {return name;}
   public fooditem nextitem = new nofood();
    // should we put an accept here? not if it doesn't implement fooditem
}

public class fruit : foodbase, fooditem
{
   public fruit(string n, int c) : base(n,c) {}
   public object accept(foodvisitor v) { return v.visit(this); }
}

public class vegetable : foodbase, fooditem
{
   internal readonly string color;  // can only assign to in constructor
   public vegetable(string n,int cl, string co) : base(n,cl)
     {color = co;}
   public override string ToString() {return color+" "+name;}
   public object accept(foodvisitor v) { return v.visit(this); }
}

public enum Meattype { red, white }  // figure out what an enum is yourself.

public class meat : foodbase, fooditem
{
   internal Meattype kind;
   public meat(string n, Meattype c) : base(n,0)
    { kind=c;}
   public override int Calories { 
       get { if (kind==Meattype.white) return 300; else return 500; } }
   public object accept(foodvisitor v) { return v.visit(this); }
}

// nil food item (end of list)
public class nofood : fooditem
{
   public int Calories { get { return 0; } }
   public object accept(foodvisitor v) { return v.visit(this); }
}

//////////  end namespace
}

