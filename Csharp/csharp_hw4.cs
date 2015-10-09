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



public class C2
{
	public void f(){
		A2 a2 = new A2();
		a2.f();
	}
	public void g(){
	
	}
	public void h1(){}
	public void h2(){}

}