using System.Collections;
using System.Collections.Generic;

public static class DataClass
{
    public class Student
    {
        public int id;
        public string firstname;
        public string lastname;
        public string email;
        public int age;
    }

    public class Course
    {
        public int courseId;
        public string cname;
        public int credits;
    }

    public class Marks
    {
        public int grade;
        public int studentId;
        public int courseId;
    }


    public static Student[] students = new Student[] {
        new Student(){
            id=1,
            firstname = "Ali",
            lastname= "Rahhal",
            email="aliR@gmail.com",
            age=21
        },
         new Student(){
            id=2,
            firstname = "Hamza",
            lastname= "Jadid",
            email="Hamza@gmail.com",
            age=23
        },
          new Student(){
            id=3,
            firstname = "Noura",
            lastname= "Joudieh",
            email="Noura@gmail.com",
            age=20
        },
           new Student(){
            id=4,
            firstname = "Bilal",
            lastname= "Said",
            email="Bilal@gmail.com",
            age=30
        },
            new Student(){
            id=5,
            firstname = "Shadi",
            lastname= "Mansour",
            email="Shadi@gmail.com",
            age=24
        },
             new Student(){
            id=6,
            firstname = "Layla",
            lastname= "Jaber",
            email="Layla@gmail.com",
            age=20
        },
              new Student(){
            id=7,
            firstname = "Marwan",
            lastname= "Sayed",
            email="Marwan@gmail.com",
            age=22
        },
           new Student(){
            id=8,
            firstname = "Marwa",
            lastname= "Khamis",
            email="MarwaK@gmail.com",
            age=23
        },
            new Student(){
            id=9,
            firstname = "Najwa",
            lastname= "Sobh",
            email="NajwaSobh@gmail.com",
            age=30
        },
             new Student(){
            id=10,
            firstname = "Zeina",
            lastname= "BouZour",
            email="zeinaBouZour@gmail.com",
            age=22
        },
};

    public static Course[] courses = new Course[] {
        new Course(){
            courseId=1,
            cname="Parallel Programming",
            credits=4
        },
         new Course(){
            courseId=2,
            cname="Android Development",
            credits=5
        },
          new Course(){
            courseId=3,
            cname="Database",
            credits=3
        },
           new Course(){
            courseId=4,
            cname="Image Processing",
            credits=3
        },
            new Course(){
            courseId=5,
            cname="ASP",
            credits=3
        },
             new Course(){
            courseId=6,
            cname="Theory of Computation",
            credits=4
        },
              new Course(){
            courseId=7,
            cname="Xamarin Mobile Development",
            credits=5
        },
               new Course(){
            courseId=8,
            cname="System Administrator",
            credits=5
        },
                new Course(){
            courseId=9,
            cname="Data Science",
            credits=3
        },
                 new Course(){
            courseId=10,
            cname="Prolog",
            credits=4
        },
                  new Course(){
            courseId=11,
            cname="Data Structure",
            credits=5
        },
                   new Course(){
            courseId=12,
            cname="Imperative Programming",
            credits=3
        },
                    new Course(){
            courseId=13,
            cname="Networking",
            credits=4
        },
                     new Course(){
            courseId=14,
            cname="Computer and Society",
            credits=3
        },
                      new Course(){
            courseId=15,
            cname="Artificial Intelligence",
            credits=4
        },
                       new Course(){
            courseId=16,
            cname="Soft Skills",
            credits=3
        },
                        new Course(){
            courseId=17,
            cname="Hibernate Database",
            credits=3
        },
                         new Course(){
            courseId=18,
            cname="Python",
            credits=3
        },
                          new Course(){
            courseId=19,
            cname="NoSQL",
            credits=4
        },
                           new Course(){
            courseId=20,
            cname="Operating Systems",
            credits=4
        },
    };

    public static Marks[] marks = new Marks[] {
        new Marks(){
            studentId=1,
            courseId=1,
            grade=75
        },
         new Marks(){
            studentId=1,
            courseId=2,
            grade=70
        },
          new Marks(){
            studentId=1,
            courseId=4,
            grade=55
        },
           new Marks(){
            studentId=1,
            courseId=6,
            grade=85
        },
            new Marks(){
            studentId=1,
            courseId=8,
            grade=98
        },
             new Marks(){
            studentId=1,
            courseId=10,
            grade=75
        },
             new Marks(){
            studentId=2,
            courseId=1,
            grade=65
        },
         new Marks(){
            studentId=2,
            courseId=2,
            grade=80
        },
          new Marks(){
            studentId=2,
            courseId=4,
            grade=57
        },
           new Marks(){
            studentId=2,
            courseId=6,
            grade=90
        },
            new Marks(){
            studentId=2,
            courseId=8,
            grade=54
        },
             new Marks(){
            studentId=2,
            courseId=10,
            grade=40
        },
             new Marks(){
            studentId=3,
            courseId=1,
            grade=87
        },
         new Marks(){
            studentId=3,
            courseId=2,
            grade=23
        },
          new Marks(){
            studentId=3,
            courseId=4,
            grade=13
        },
           new Marks(){
            studentId=3,
            courseId=6,
            grade=58
        },
            new Marks(){
            studentId=3,
            courseId=8,
            grade=29
        },
             new Marks(){
            studentId=3,
            courseId=10,
            grade=39
        },
             ////
             new Marks(){
            studentId=1,
            courseId=3,
            grade=87
        },
         new Marks(){
            studentId=1,
            courseId=12,
            grade=43
        },
          new Marks(){
            studentId=1,
            courseId=5,
            grade=50
        },
           new Marks(){
            studentId=1,
            courseId=13,
            grade=41
        },
            new Marks(){
            studentId=1,
            courseId=7,
            grade=8
        },
             new Marks(){
            studentId=1,
            courseId=14,
            grade=99
        },
             ////
             
            new Marks(){
            studentId=9,
            courseId=9,
            grade=80
        },
         new Marks(){
            studentId=9,
            courseId=15,
            grade=87
        },
          new Marks(){
            studentId=9,
            courseId=11,
            grade=84
        },
           new Marks(){
            studentId=9,
            courseId=17,
            grade=89
        },
            new Marks(){
            studentId=9,
            courseId=20,
            grade=83
        },
             new Marks(){
            studentId=9,
            courseId=16,
            grade=88
        },
             new Marks(){
            studentId=10,
            courseId=9,
            grade=90
        },
         new Marks(){
            studentId=10,
            courseId=15,
            grade=45
        },
          new Marks(){
            studentId=10,
            courseId=11,
            grade=78
        },
           new Marks(){
            studentId=10,
            courseId=17,
            grade=23
        },
            new Marks(){
            studentId=10,
            courseId=20,
            grade=67
        },
             new Marks(){
            studentId=10,
            courseId=16,
            grade=81
        },
             ////////////////////////
                  new Marks(){
            studentId=8,
            courseId=9,
            grade=72
        },
         new Marks(){
            studentId=8,
            courseId=15,
            grade=81
        },
          new Marks(){
            studentId=8,
            courseId=11,
            grade=53
        },
           new Marks(){
            studentId=8,
            courseId=17,
            grade=61
        },
            new Marks(){
            studentId=8,
            courseId=20,
            grade=78
        },
             new Marks(){
            studentId=8,
            courseId=16,
            grade=36
        },
             new Marks(){
            studentId=7,
            courseId=9,
            grade=87
        },
         new Marks(){
            studentId=7,
            courseId=15,
            grade=86
        },
          new Marks(){
            studentId=7,
            courseId=11,
            grade=98
        },
           new Marks(){
            studentId=7,
            courseId=17,
            grade=76
        },
            new Marks(){
            studentId=7,
            courseId=20,
            grade=56
        },
             new Marks(){
            studentId=7,
            courseId=16,
            grade=51
        },
    };
}
