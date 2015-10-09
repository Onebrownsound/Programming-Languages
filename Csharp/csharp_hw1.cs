// Static versus dynamic dispatch in C#

using System;
using System.Collections;

public delegate bool boolIntFun(int x);
public delegate bool boolStrFun(string x);
public delegate bool boolChrFun(char x); 


public class Csharp_HW1
{
    public static  bool is_greater_than_two(int x)
    {
        return x > 2;
    }

    public static int score_array(ArrayList A, boolIntFun f)
        {
        int score = 0;
        foreach ( int element in A)
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
