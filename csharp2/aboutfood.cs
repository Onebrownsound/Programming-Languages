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
    

    // below is functioning problem 1 code
    beverage problem1 = new beverage("coca cola",400);
    problem1.nextitem = c;
    Console.WriteLine("Problem 1 results below:");
    Console.WriteLine(problem1.accept(new beveragevisitor()));

    //below is functioning problem 3 code
    //c is not ordered so we expect the output to be false
    Console.WriteLine(c.accept(new islistordered()));
  

    //now lets construct and ordered list and test
    fruit testfruit = new fruit("apple",50);;
    vegetable testvegetable = new vegetable("cabbage soup",150,"white");;
    meat testmeat= new meat("chicken",Meattype.white);
    testfruit.nextitem=testvegetable;
    testvegetable.nextitem=testmeat;
    fooditem orderedTestList= testfruit;
    // Prints out true test case passes ...on a side note this is such a small % of test cases but w.e it works
    Console.WriteLine(orderedTestList.accept(new islistordered()));



    Console.Read();
    

  } // Main
}

/* compile with: csc foods.cs foodvisitors.cs aboutfood.cs  */
