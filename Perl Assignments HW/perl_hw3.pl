sub howmany{
	my $function=$_[0];
	my @data=@{$_[1]};
	
	my $count=0;
	foreach $x (@data){
		if ($function->($x)){
			$count +=1;
		}
	}
	return $count;

}

sub testfunction{
	$_[0] >5;
}

@test_array=(10,6,2,8,1); #test data
$test_reference=\&testfunction; #create reference to the test function
print (howmany($test_reference,\@test_array)); # prints 3 test PASSED