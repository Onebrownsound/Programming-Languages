// Static versus dynamic dispatch in C#

using System;
using System.Collections;

public delegate bool boolIntFun(int x); //Three different options for sending functions as variables
public delegate bool boolStrFun(string x);
public delegate bool boolChrFun(char x); 


public class Csharp_HW1
{
    public static  bool is_greater_than_two(int x) //Acts as a condition
    {
        return x > 2;
    }

    public static int score_array(ArrayList A, boolIntFun f) //Takes in an ArrayList
        {
        int score = 0;
        foreach ( int element in A) //I guess this line acts of a sort of type-casting , since it will iterate over A. However if there is a non-int in the array it crashes.
        {
            if (f(element)) score++;

        }
        return score;
    }

    public static void Main()
    {
        ArrayList A = new ArrayList();
        A.Add(10);
        A.Add(1);
        A.Add(2);
        A.Add(2);
        int how_many = score_array(A, is_greater_than_two);
        Console.WriteLine("There are "+how_many+" element(s) that qualify.");
        Console.Read();

    }



}
