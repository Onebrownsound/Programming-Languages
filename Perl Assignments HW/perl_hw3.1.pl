sub new_ax
{
   my $ax = $_[0]; #constructs ax to value when initialized 
   my $add = sub {$ax+=$_[0];};
   my $display = sub {print "The ax is $ax!.";};

 
   # return interface function:
    sub
   {
     my $method=$_[0];
     my $value=$_[1];
   
     if ($method eq add) { return $add->($value); }
     if ($method eq display){return &$display;}
     else { die "error"; }
   }
}
my $example = new_ax(10);
$example->(add,10);
$example->(add,10);
$example->(add,10);
$example->(display);
#prints 40 TEST PASSED
