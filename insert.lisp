;define struct of database
(defun make-cd (title artlist rating ripped)
  (list :title title :artlist artlist :rating rating :ripped ripped))

(defvar *db* nil)

(defun add-record (cd)
  (push cd *db*))

(defun prompt-read (prompt)
  (format *query-io* "~a: " prompt)
  (force-output *query-io*)
  (read-line *query-io*))

;write and insert
(defun prompt-for-cd ()
  (make-cd
    (prompt-read "Title")
    (prompt-read "Artlist")
    (or (parse-integer (prompt-read "Rating") :junk-allowed t) 0)
    (y-or-n-p "Ripped [y/n]: ")))

(defun add-cds ()
  (loop (add-record (prompt-for-cd))
	(if (not (y-or-n-p "Another? [y/n]: ")) (return))))

;save data to file
(defun save-db (filname)
  (with-open-file (out filname
		       :direction :output
		       :if-exists :supersede)
    (with-standard-io-syntax
      (print *db* out))))

;load file
(defun load-db (filname)
  (with-open-file (in filname)
    (with-standard-io-syntax
      (setf *db* (read in)))))

(load-db "a.sdb")
(add-cds)
(print *db*)
(save-db "a.sdb")
