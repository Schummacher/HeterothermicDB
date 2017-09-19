import os

def insert():
    os.system("sbcl --script insert.lisp")

def db_read():
    os.system("sbcl --script read.lisp")

def find():
    os.system("sbcl --script find.lisp")

def select_form():
    print()
    print("1: Insert")
    print("2: Read")
    print("3: Find")
    print("q: Quit")

def sel():
    i = input()
    if i == '1':
        insert()
    elif i == '2':
        db_read()
    elif i == '3':
        find()
    elif i == 'q':
        return
    print()
    start()

def start():
    select_form()
    sel()


start()
