using System;
using System.Collections;



public class A2 
{
  protected virtual void f() {Console.WriteLine("A2.f");}
  protected virtual void g() {Console.WriteLine("A2.g");}
  protected virtual void h1() {Console.WriteLine("A2.h1");}
}
public class B2 
{
  protected virtual void f() {Console.WriteLine("B2.f");}
  protected virtual void g() {Console.WriteLine("B2.g");}
  protected virtual void h2() {Console.WriteLine("B2.h2");}
}






public class C3:B2 
{
	public void call_g(){ this.g();} // this is where the trick lies, had to do some googling to finally get a hint
	public void call_h2(){this.h2();} // so B2's methods are restricted to descendants of that class
	//that doesn't mean we cannot define a new public method that refers to these protected methods....that is where the loop whole lies
}

public class C2 : A2
{
	public void call_f(){ this.f();} // have c2 inherit directly from A2
	public void call_h1(){this.h1();}
	public void call_h2(){ C3 c3 = new C3(); // create new references to a C3 object (which inherits from B2) and has public methods that return the protected functions
		c3.call_h2();} // call the "hidden functions"
	public void call_g(){C3 c3= new C3();
		c3.call_g();}

}

public class hello{
	public static void Main()
	{
		Console.WriteLine("Starting");
		C2 c2 = new C2();
		c2.call_f();
		c2.call_g();
		c2.call_h1();
		c2.call_h2();

	}
}