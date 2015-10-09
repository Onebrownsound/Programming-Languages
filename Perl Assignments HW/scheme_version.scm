;Exercise 3.1

(define (makeaccume start)
(define (accum current)
(set! start (+ start current))start) accum)

;Exercise 3.2

(define (make-monitored f)
(define count 0)
(define (mf arg)
(cond ((eq? arg 'reset-count) (set! count 0))
((eq? arg 'how-many-calls?) count)
(#t (begin (set! count (+ 1 count)) (f arg))))) mf)

;Exercise 3.3

(define (make-account bal password)
(define (withdraw amount)
(if (>= bal amount) (begin (set! bal (- bal amount)) bal) "Insufficient funds"))
(define (deposit amount)
(set! bal (+ bal amount)) bal)
(define (display p m)
(if (eq? p password)
(cond ((eq? m 'withdraw) withdraw)
((eq? m 'deposit) deposit)
(#t (error "error" m)))
(lambda (m) "Incorrect Password"))) display)

;Exercise 3.4

(define (make-account balance password)
(define (withdraw amount)
(if (>= bal amount) (begin (set! bal (- balance amount)) balance) "Insufficient funds"))
(define (deposit amount)
(set! balance (+ balance amount)) balance)
(define (display p m)
(if (eq? p password)
(cond ((eq? m 'withdraw) withdraw)
((eq? m 'deposit) deposit)
(#t (error "error" m))) suspicious))
(define count 0)
(define (suspicious m)
(if (< count 7) (begin (set! count (+ 1 count)) 
"Incorrect password") (alert)))
(define (alert)
"Call the Police!!") display)

;Exercise 3.5
