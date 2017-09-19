;define struct of database
(defun make-cd (title artlist rating ripped)
  (list :title title :artlist artlist :rating rating :ripped ripped))

(defvar *db* nil)

(defun add-record (cd)
  (push cd *db*))

;put file data to a var
(defun load-db (filname)
  (with-open-file (in filname)
    (with-standard-io-syntax
      (setf *db* (read in)))))

(load-db "a.sdb")
(print *db*)
