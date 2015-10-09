;Dominick Modica PL HW problem 3
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
     
(define (multiply t) ;take in root pointer
    (if (null? t) 1 ; if root pointer is null return 1...not technically correct but just don't pass in empty BT, can be fixed by wrapping function logic or filtering for empty BT's
    (* (data t) (multiply (left t)) (multiply (right t))))) ;multiply root data times left and right subtree