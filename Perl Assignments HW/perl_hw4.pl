sub newaccount
{
   my $balance = 0;

   my $add_one= sub { $balance++; };
   my $display= sub {return $balance;};
  
   # return interface function:
   sub
   {
     my $method = $_[0]; # requested method
     if ($method eq add_one) { return &$add_one; }
     if ($method eq display){return &$display;}
     
       else { die "error"; }
   }
}

my $example = newaccount();
my $yourexample = newaccount();
$yourexample->(add_one);
$example->(add_one);
$example->(add_one);
$example->(add_one);
$example->(add_one);
print "here is example value ", $example->(display), "\n"; #displays 4 TEST PASSED
print "here is yourexample value ", $yourexample->(display), "\n"; #displays 1 TEST PASSED
#I feel like having to manually always build an interface is annoying
#Probably would have not figured this out without seeing the newaccount example;
#It was very helpful