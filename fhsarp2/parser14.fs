// shift-reduce parser for online calculator

(*  Ambiguous context-free grammer:

    E := var of string  |  // not used at first
         val of float   |
         E + E          |
         E * E          |
         E - E          |
         E / E          |
         (E);;
         - E;           // unary minus - reduce-reduce precedence
                        //( will have highest precedence - reduce, don't shift

    negative values will be handled by the tokenizer

    input stream of tokens will be represented as an array, from C# program
    global index will point to the next token.

    parse stack will be a list of expressions, starting with empty stack.
    left-side is tos.


    IMPROVMENTS MADE 11/2013:

    float replaced by int - will do integer ops only (clearer)

    Changes mostly to the lexical scanner.  Operator symbols can now have
    more than one character.  White spaces are ignored.  Hash table used
    to make it easier to add new operators.  Binop and Unaryop replaces
    Plusexp, Uminusexp, etc, but you may need to add others (Ifexp need
    three parameters).  Look for commented out lines that show what changes
    are needed to add a new operator.

    IMPROVEMENTS MADE 11/2014: tokenize now tail-recursive
*)

open System;;
open Microsoft.FSharp.Math;;
open System.Text.RegularExpressions;;
open System.Collections.Generic;;

///////// Lexical Symbol Specification

// use regular expression to represent possible operator symbols:
let mutable operators = "([()\+\-\*/]|\s|and|or)";;  

// use hash table (Dictionary) to associate each operator with precedence
let prectable = Dictionary<string,int>();;
prectable.["+"] <- 200;
prectable.["-"] <- 300;
prectable.["*"] <- 400;
prectable.["/"] <- 500;
prectable.["("] <- 900;
prectable.[")"] <- 20;

let is_right_associative= Dictionary<string,bool>();;
is_right_associative.["+"] <- true;
is_right_associative.["-"] <- false;
is_right_associative.["*"] <- true;
is_right_associative.["/"] <- false;
is_right_associative.["("] <- true;
is_right_associative.[")"] <- true;

// function to add new operator (as regex string) with precedence (int)
let newoperator s prec =
  let n = operators.Length
  let prefix = operators.Substring(0,n-1)
  operators <- prefix + "|" + s + ")"
  if s.[0]='\\' then prectable.[s.Substring(1,s.Length-1)] <- prec
  else prectable.[s] <- prec;;

//sample usage of newoperator function:
//newoperator @"&&" 650;;  // use @ before string or use "\^" (explict escape)
//Console.WriteLine(string(prectable.["&&"]));;  // check if success
//newoperator @"^" 600;;

///////// ABSTRACT SYNTAX

// expr folds in both expressions and tokens from the lexer

type expr = Val of int | Binop of (string*expr*expr) | Unaryop of (string*expr) | Sym of String | EOF;;

// proper expression check (shallow)
let proper = function
  | Val(_) -> true
  | Binop(s,_,_) when prectable.ContainsKey(s) -> true
  | Unaryop(s,_) when prectable.ContainsKey(s) -> true
  | _ -> false;


let rec eval = function   // type is expr -> int
  | Val(v) -> v
  | Binop("+",a,b) -> eval a + eval b  // nolonger Plus(a,b)
  | Binop("*",a,b) -> eval a * eval b
  | Binop("-",a,b) -> eval a - eval b
  | Binop("/",a,b) -> eval(a) / eval(b)
  | Unaryop("-",a) -> -1 * eval(a)
//  | Binop("^",a,b) -> int(Math.Pow(float(eval a),float(eval b)))
  | _ -> (printf "error in eval\n"; 0);;
////////////////////////////////////////////////////


(*
         LEXICAL ANALYSER (LEXER)
*)

// Take input string, hard-coded examples
//let inp = "7+3*2";;  // testing operator precedence
//let TS = [|Val(7);Sym("+");Val(3);Sym("*");Val(2);EOF|];;

Console.Write("Enter expression to be evaluated: ");;
let inp = Console.ReadLine();;  // get user input

let s2 = Regex.Split(inp,operators);;
// now build list of tokens
let maketoken x =  try Val(int x)   // exception handling in F#
                   with
                   | exp -> Sym(x);;

let tokenize (s2:string[]) n = 
  let rec itokenize ax = function   // inner tail-recursive function
    | i when i<s2.Length -> 
       let t = s2.[i].Trim()
       if (t<>"") then 
         itokenize (maketoken(s2.[i])::ax) (i+1)
       else
         itokenize ax (i+1)
    | _ -> ax;
  itokenize [EOF] n;;

let TS = tokenize s2 0;;
printfn "token stream: %A" TS;;

let mutable TI = 0;; // global index for TS stream;;
///////////////////


///////////////////
////////////////////////// SHIFT-REDUCE PARSER ////////////////////////




let associate_right = function
 | Sym(s) when is_right_associative.ContainsKey(s) -> is_right_associative.[s]
 | _ -> false;;


let precedence = function
 | Val(_) -> 100
 | Sym(s) when prectable.ContainsKey(s) -> prectable.[s]
 | EOF    -> 10
 | _ -> 0;;

// check for precedence and proper expressions
let precheck(a,b,e1,e2) =
  let (pa,pb) = (precedence(a),precedence(b))
  match pa,pb with
  | pa,pb when (pa > pb) && proper(e1) && proper(e2) -> true
  | pa,pb when (pa = pb) && proper(e1) && proper(e2) && associate_right(a) ->true
  | _ -> false


// parse takes parse stack and lookahead; default is shift

// unify reduction of all binary operator expressions:
let binops = ["+";"-";"*";"/"];;  // list of all binary operators

let rec parse = function
  | ([e],EOF) when proper(e) -> e   // base case, returns an expression
  | (Sym(")")::e1::Sym("(")::t, la) when precheck(Sym("("),la,e1,e1) ->
            parse (e1::t,la)
  | (e1::Sym(op)::e2::cdr,la) 
     when (List.exists (fun x->x=op) binops) && precheck(Sym(op),la,e1,e2) ->
        let e = Binop(op,e1,e2)
        parse(e::cdr,la)
  | (Sym("-")::e1::t, la) when precheck(Sym("-"),la,e1,e1) ->  // interpret as a negative
            let e = Unaryop("-",e1) in parse (e::t,la)
  | (st,la) when (TI < TS.Length-1) ->
            (TI <- TI+1;         // shift!
             printf "shift: %A\n" st;   // trace
             let newla = TS.[TI] in parse (la::st,newla))
  | (st,la) -> printf "parsing error: %A\n" (la::st); 
               EOF;;


//////// RUN
let ee = parse([],TS.[0]);;
let v = eval ee;;
printf "value of %s = %d\n" inp v;;
