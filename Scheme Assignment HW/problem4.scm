;Dominick Modica PL HW problem 4
; binary trees
(define (node x l r)   ; x is data, l is left, r is right
  (lambda (s)
    (cond  ((= s 0) x)
           ((= s 1) l)
           ((= s 2) r)
           (#t 'error))))

(define (data t) (t 0))
(define (left t) (t 1))
(define (right t) (t 2))

; sample tree
(define t1 (node 5 (node 3 '() '()) (node 8 (node 7 '() '()) '())))

;          5
;        /   \
;       3     8
;            /
;           7

; sample functions:

; return size (number of non-null nodes) in a tree:
(define (size t) (if (null? t) 0 (+ 1 (size (left t)) (size (right t)))))

(define (search x t)   ; assuming a binary search tree
  (and (not (null? t))
       (or (= x (data t))
           (and (< x (data t)) (search x (left t)))
     (and (> x (data t)) (search x (right t))))))

(define (howmany predicate t) ;take in a predicate and tree
	(cond 
		[(null? t) 0] ;if tree is null return 0
		[(predicate (data t)) (+ 1 (howmany predicate (left t)) (howmany predicate (right t))) ] ;test tree data vs predicate if true add 1 + call howmany with left and right subtrees
		[else  (+ 0 (howmany predicate (left t)) (howmany predicate (right t)))];test tree data vs predicate if false add 0 + call howmany with left and right subtrees
	))

(define test1 (lambda (x) (< x 2))) ;test predicate for x > 2 returns 4 with t1 PASS
(define test2 (lambda (x) (> x 2))) ;test predicate x < 2 returns 0 with t1 PASS