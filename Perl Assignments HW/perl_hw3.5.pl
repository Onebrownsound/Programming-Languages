sub new_bank_account
{
   my $balance = $_[0]; #constructs ax to value when initialized 
   my $real_password = $_[1];
   my $incorrect_pw_attempts=0;
   my $alias_account_name=undef;
   my $alias_account_password=undef;
   
   my $display = sub {print "The balance for the account is $balance!. \n";};
   my $deposit = sub {print "This is where depoist logic goes \n";};
   my $withdraw = sub {print "This is where withdraw logic goes. \n";};
   my $call_the_cops = sub {print "The police have been called! \n"};
   my $link_account = sub 
      {
        
        return $_[0]; #first argument is a pointer to the original account alias, so now both point to the same piece of code

      };
 
   # return interface function:
     sub
   {
     my $method=$_[0];
     my $supplied_password=$_[1];
     my $value= $_[2];
     my $second_value= $_[3];
     my $original_memory_address = $_[4];


     if ($incorrect_pw_attempts > 7 ){return &$call_the_cops;}
     elsif ($supplied_password ne $real_password) {$incorrect_pw_attempts++; print "You gave the wrong password please try again \n";}
     
     else 
      {
        $incorrect_pw_attempts=0; #reset pw attempts
        if ($method eq deposit) { return $deposit->($value); }
        if ($method eq withdraw){return $withdraw->($value);}
        if ($method eq link_account){return $link_account->($value,$second_value,$original_memory_address);}
        else { die "error"; }
      }
   
     
   }
}

my $doms_account= new_bank_account(100000,'password'); #constructs new account with balance, real_password as arguments
my $your_account = $doms_account->(link_account,&$doms_account); #essentially creates another entry point to $doms_account by returning a pointer to doms_account

