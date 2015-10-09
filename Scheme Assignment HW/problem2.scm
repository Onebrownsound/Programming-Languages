;Dominick Modica PL HW problem 2
(define (makeasciis S) (map (lambda (x) (char->ascii x)) (string->list S)))

(define printasciis (lambda (l)
      (begin (map (lambda (x) (display (ascii->char x))) l)
	 (display "\n"))))


(define encrypt_helper(lambda(m)
	(remainder (expt m 17) 2773)))

(define decrypt_helper(lambda(m)
	(remainder (expt m 157) 2773)))

(define encrypt_list(lambda(message)
		 (display(map encrypt_helper message))))

(define decrypt_list(lambda(message)
		 (display(map decrypt_helper message))))


		


;Tests values should print in reverse aka 193, then 104 should appear
(encrypt_helper 104)
(decrypt_helper 193)
;functioning properly

(encrypt_list '(104 101 108 108 111))
(decrypt_list '(193 758 169 169 131))
(decrypt_list '(2063 193 758 2227 1860 131 131 169 758 660 1528 1751 2227 660 1684 758 2227 660 169 1020 1239 758 207))
;functioning properly
