;define stuct of database
(defun make-cd (title artlist rating ripped)
  (list :title title :artlist artlist :rating rating :ripped ripped))

(defvar *db* nil)

(defun add-record (cd)
  (push cd *db*))

;load file
(defun load-db (filname)
  (with-open-file (in filname)
    (with-standard-io-syntax
      (setf *db* (read in)))))

;list find
(defun db-ref (items n)
  (if (= n 0)
    (car items)
    (db-ref (cdr items) (- n 1))))

;(defun select-read ()
;  (format *query-io* "~&1:find with times")
;  (format *query-io* "~&")
;  (force-output *query-io*)
;  (read-line *query-io*))

;function, print before read
(defun my-read (input)
  (format *query-io* input)
  (force-output *query-io*)
  (read-line *query-io*))

;(defun times-read ()
;  (format *query-io* "~&Please input times you need: ")
;  (force-output *query-io*)
;  (read-line *query-io*))

(defun my-print (tmp)
  (if (null tmp)
    nil
    (or (format t "~&~A: ~A" (car tmp) (car (cdr tmp)))
	(my-print (cdr (cdr tmp))))))

;(defun my-search-title (item i)
;  (if (eq item ())
;    (format t "~&None of ~A" i)
;    (if (string= (car (cdr (car item))) i)
;      (my-print (car item))
;      (my-search-title (cdr item) i))))

;(defun my-search-artist-sub (item i)
;  (my-search-artist (cdr item) i)
;  (my-print (car item)))

;(defun my-search-artist (item i)
;  (if (eq item ())
;    (format t "~&None of ~A" i)
;    (if (string= (car (cdr (cdr (cdr (car item))))) i)
;      (my-search-artist-sub item i)
;      (my-search-artist (cdr item) i))))


;Variable Length cdr
(defun cdr-times (lllist times)
  (if (= times 0)
    lllist
    (cdr-times (cdr lllist) (- times 1))))

(defun my-search-sub (item i times)
  (my-search (cdr item) i times)
  (my-print (car item)))

(defun my-search (item i times)
  (if (eq item ())
    (format t "~&None of ~A" i)
    (if (string= (car (cdr-times (car item) times)) i)
      (my-search-sub item i times)
      (my-search (cdr item) i times))))

; f(x) = (x-1)*2-1 = x*2-3
(defun times-calculate (times)
  (- (* times 2) 3))


;(defun my-search (i)
;  (cond ((= 1 i) (my-search-artist (parse-integer (my-read "~&input artist name~&"))))
;	(t (sellect (parse-integer (my-read "~&Please input again~&"))))))

(defun sellect (i)
  (cond ((= 1 i) (my-print (db-ref *db* (parse-integer (my-read "~&Please input times you need: ")))))
	((= 2 i) (my-search *db* (my-read "~&Please input the title name: ") (times-calculate i)))
	((= 3 i) (my-search *db* (my-read "~&Please input the artist name: ") (times-calculate i)))
	(t (sellect (parse-integer (my-read "~&Please input again~&"))))))

(load-db "a.sdb")
;(print (sellect (select-read)))
(print (sellect (parse-integer (my-read "~&1:find with times~&2:Find for title name~&3:Find for artist name~&"))))
