// Developer Express Code Central Example:
// How to edit GridView data in a popup form
// 
// This example demonstrates how to switch a GridView to read-only mode and
// implement the Create, Update, Delete, and Insert operations in a popup form. In
// this example, you can also edit data after double-clicking a row.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4518

using System;

namespace GridSample {
    public class Person {
        string firstName;
        string secondName;
        string comments;
        public Person(string firstName, string secondName) {
            this.firstName = firstName;
            this.secondName = secondName;
            comments = String.Empty;
        }
        public Person(string firstName, string secondName, string comments)
            : this(firstName, secondName) {
            this.comments = comments;
        }
        public Person()
        {
            
        }
         
        public string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }
        public string SecondName {
            get { return secondName; }
            set { secondName = value; }
        }
        public string Info {
            get { return comments; }
            set { comments = value; }
        }
    }
}