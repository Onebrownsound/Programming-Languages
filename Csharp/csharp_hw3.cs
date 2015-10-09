// Static versus dynamic dispatch in C#

using System;
using System.Collections;

public delegate bool boolIntFun(int x);
public delegate bool boolStrFun(string x);
public delegate bool boolChrFun(char x); 
public interface Ia
{
   void f();
   void g();
   void h1();
}

public interface Ib
{
   void f();
   void g();
   void h2();
}


public class A : Ia
{
  public virtual void f() { Console.WriteLine("f from class A"); }
  public virtual void g() { Console.WriteLine("g from class A"); }
  public virtual void h1() { Console.WriteLine("h1 from class A"); }
}

public class B : Ib
{
  public virtual void f() { Console.WriteLine("f from class B"); }
  public virtual void g() { Console.WriteLine("g from class B"); }
  public virtual void h2() { Console.WriteLine("h2 from class B"); }
}

/// Show how to construct a class

public class C : Ia, Ib
{
  public virtual void f() { Console.WriteLine("f from class C"); } //So I figure just make brand new f and g for C.
  public virtual void g() { Console.WriteLine("g from class C"); }
  public void h1(){ //Since we cannot inherit from two classes, just call the class method the same name as it would be called if you hypothetically could and just instantiate a referfence to desired Class and call that method
    A a_template = new A();
    a_template.h1();
  }
  public void h2(){
    B b_template = new B(); // That way we can have our cake and eat it too!
    b_template.h2();
  }
}

// That implements both intferaces.  (class C can implement other
// interfaces, and extend a class as well).  This class should inherit
// both h1 from A and h2 from B.

public class Csharp_HW3
{
   
  public static  void Main()
  { 
    C n = new C();
    n.f(); n.g(); n.h1(); n.h2();
  }



}
