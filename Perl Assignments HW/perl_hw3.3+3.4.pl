sub new_bank_account
{
   my $balance = $_[0]; #constructs ax to value when initialized 
   my $real_password = $_[1];
   my $incorrect_pw_attempts=0;
   
   my $display = sub {print "The balance for the account is $balance!. \n";};
   my $deposit = sub {print "This is where depoist logic goes \n";};
   my $withdraw = sub {print "This is where withdraw logic goes. \n";};
   my $call_the_cops = sub {print "The police have been called! \n"};

 
   # return interface function:
     sub
   {
     my $method=$_[0];
     my $supplied_password=$_[1];
     my $value= $_[2];


     if ($incorrect_pw_attempts > 7 ){return &$call_the_cops;}
     elsif ($supplied_password ne $real_password) {$incorrect_pw_attempts++; print "You gave the wrong password please try again \n";}
     
     else 
      {
        $incorrect_pw_attempts=0; #reset pw attempts
        if ($method eq deposit) { return $deposit->($value); }
        if ($method eq withdraw){return $withdraw->($value);}
        else { die "error"; }
      }
   
     
   }
}

my $doms_account= new_bank_account(100000,'password'); #constructs new account with balance, real_password as arguments
$doms_account->(withdraw,'password'); #TEST SUCCESS password matches and fowards user to appropriate code TEST PASS
$doms_account->(withdraw,'wrongpassword'); #Prints password rejection message 
$doms_account->(withdraw,'wrongpassword'); #Prints password rejection message 
$doms_account->(withdraw,'wrongpassword'); #Prints password rejection message 
$doms_account->(withdraw,'wrongpassword'); #Prints password rejection message 
$doms_account->(withdraw,'wrongpassword'); #Prints password rejection message 
$doms_account->(withdraw,'wrongpassword'); #Prints password rejection message 
$doms_account->(withdraw,'wrongpassword'); #Prints password rejection message 
$doms_account->(withdraw,'wrongpassword'); #Prints password rejection message 
$doms_account->(withdraw,'wrongpassword'); #Prints password rejection message 
#Finally after 7+ incorrect attempts police have been called
