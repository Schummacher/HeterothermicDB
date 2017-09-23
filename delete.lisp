;define stuct of database
(defun make-cd (title artlist rating ripped)
  (list :title title :artlist artlist :rating rating :ripped ripped))

(defvar *db* nil)
(defvar *db-tmp* nil)

(defun add-record (cd)
  (push cd *db*))

(defun save-db (filname)
  (with-open-file (out filname
		       :direction :output
		       :if-exists :supersede)
    (with-standard-io-syntax
      (print *db-tmp* out))))

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

;function, print before read
(defun my-read (input)
  (format *query-io* input)
  (force-output *query-io*)
  (read-line *query-io*))

(defun my-print (tmp)
  (if (null tmp)
    nil
    (or (format t "~&~A: ~A" (car tmp) (car (cdr tmp)))
	(my-print (cdr (cdr tmp))))))

(defun delete-print (tmp)
  (format t "~&DELETE:")
  (my-print tmp))

;Variable Length cdr
(defun cdr-times (lllist times)
  (if (= times 0)
    lllist
    (cdr-times (cdr lllist) (- times 1))))

(defun my-delete-right (item i times)
  (delete-print (car item))
  (my-delete (cdr item) i times))

(defun my-delete-left (item i times)
  (push (car item) *db-tmp*)
  (my-delete (cdr item) i times))

(defun my-delete (item i times)
  (if (eq item ())
    (format t "~&None of ~A" i)
    (if (string= (car (cdr-times (car item) times)) i)
      (my-delete-right item i times)
      (my-delete-left item i times)))
  (save-db "a.sdb"))

; f(x) = (x-1)*2-1 = x*2-3
(defun times-calculate (times)
  (- (* times 2) 3))

(defun sellect (i)
  (cond ((= 1 i) (my-print (db-ref *db* (parse-integer (my-read "~&Please input times you need: ")))))
	((= 2 i) (my-delete *db* (my-read "~&Please input the title name: ") (times-calculate i)))
	((= 3 i) (my-delete *db* (my-read "~&Please input the artist name: ") (times-calculate i)))
	(t (sellect (parse-integer (my-read "~&Please input again~&"))))))

(load-db "a.sdb")
;(print (sellect (select-read)))
(print (sellect (parse-integer (my-read "~&2: Delete for title name~&3: Delete for artist name~&"))))

