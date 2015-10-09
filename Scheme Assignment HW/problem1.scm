;Dominick Modica PL HW problem 1
(define lastelement
	(lambda(l)
		(cond
			((= (length l) 0) ('error))
			((= (length l) 1) (car l))
			(else (lastelement (cdr l))))))
		
	


(lastelement '(1 2 3 4 5 6 ))
		