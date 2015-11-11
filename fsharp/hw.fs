//problem warmup
type direction = North | South | East | West;;
let figure_out_direction (a_direction : direction)=
    match a_direction with
    | North -> 0
    | South -> 1
    | East -> 2
    | West -> 3
printfn "%f" ,figure_out_direction North;;//prints 0
printfn "%f" ,figure_out_direction South;; // prints 1
printfn "%f" ,figure_out_direction East;; // prints 2 
printfn "%f" , figure_out_direction West;; // prints 3

//problem 1 
let gcd (a :int) (b: int) =
	match a with
	| 0 -> b
	| _ -> gcd (b%a) a

//problem 2
// Won't compile but logic is 100%
// you should get the idea
let add_reals = function
	match x,y with
	| float , int -> x + float(y)
	| int , float -> float(x) + y
	| float , fraction -> x + float(y.numerator/y.denominator)
	| fraction , float -> float(x.numerator/x.denominator) + y
	| fraction, int -> x.add(real(y,1))
	| int, fraction -> y.add(real(x,1))
	| fraction, fraction -> x.add(y)
	| _ , _ -> x+y

//problem 3
rlist
|> List.filter (fun x -> x is Real)
|> List.sum




//problem 5
let find x m