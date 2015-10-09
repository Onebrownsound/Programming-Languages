sub new_fx_counter
{
   my $ax = 0; #constructs ax to value when initialized 
   my $fx = $_[0]; #first parsed argument should be a pointer to a function
   
   my $display = sub {print "The call count is $ax!.";};
   

 
   # return interface function:
    sub
   {
     my $method=$_[0];
     my $value=$_[1];
   
     if ($method eq execute) {$ax++; return &$fx; }
     if ($method eq how_many_calls){return &$display;}
     else { die "error"; }
   }
}


sub test_printer{
  print "Hello World";
}

my $example = new_fx_counter(\&test_printer); #take in a reference to the address of a test_function 
my $second_example=new_fx_counter(\&test_printer);
$second_example->(execute);
$example->(execute);
$example->(execute);
$example->(execute);
$example->(how_many_calls);
$second_example->(how_many_calls);
#examples executed 3 times prints 3 calls second_example executed 1 time prints 1 PASS
