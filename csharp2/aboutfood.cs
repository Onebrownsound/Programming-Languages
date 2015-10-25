/* tests food dlls */

using System;
using System.IO;
using foodstuff;

public class aboutfood
{
  public static void Main(string[] args)
  {
    fruit a = new fruit("apple",50);
    fruit b = new fruit("watermellon",200);
    vegetable c = new vegetable("cabbage soup",150,"white");
    vegetable d = new vegetable("spinach",1000,"green");
    meat e = new meat("chicken",Meattype.white);
    meat f = new meat("beef",Meattype.red);
    c.nextitem = e; e.nextitem=a; a.nextitem=f;
    f.nextitem = b; b.nextitem = d;
    fooditem thefood = c; // start of list;
    
    // eat visitor
    eater popeye = new eater(4000); // popeye needs 4000 calories
    int ate = (int) thefood.accept(popeye);  
    Console.WriteLine("popeye ate "+ate+" calories");

    //problem 0 visitor
    sumFoodList problem0 = new sumFoodList();
    Console.WriteLine("Problem 0 results below:");
    Console.WriteLine(c.accept(problem0));


    
    
    // healthinspector picks out healthiest food item
    healthinspector nutritionist = new healthinspector(c);
    fooditem best = (fooditem) thefood.accept(nutritionist);
    Console.WriteLine("nutritionist says the "+best+" is the healthiest."); 
    Console.Read();


     

/*

    // write list as xml to filename args[0]
    Console.WriteLine("\nout to file: "+args[0]);
    FileStream fs = new FileStream(@args[0],FileMode.OpenOrCreate,FileAccess.Write);
    xmlwriter xwriter = new xmlwriter(new StreamWriter(fs));
    thefood.accept(xwriter);
*/

  } // Main
}

/* compile with: csc foods.cs foodvisitors.cs aboutfood.cs  */
