sub therexists{
	my ($predicate,@A) = @_; # predicate is the condition to check,  
	my $answer = 0; #default answer is false
	foreach my $x (@A) # for each item in array test via predicate 
	{
		if ($predicate->($x))
		{
			$answer=1;
			return $answer;
		}
	}
	return answer; # if we iterate over array and do not find a true for the predicate return answer as false
}