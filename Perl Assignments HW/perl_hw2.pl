sub doubles{
	@original_list = @_; # take in first list
	@merged = (@original_list,@original_list); # return the combination of both lists
	return sort(@merged);
}


@test=(1,2,3);
print "Test case :";
print join(", ",@test);
print ("\n");

@answer=doubles(@test);
print " Result: ";
print (join(", ",@answer));
# test works


