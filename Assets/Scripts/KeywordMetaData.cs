using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeywordMetaData
{
    public string keywordName;
    public bool isAttribute;
    public bool isKeyword;
    public string TableName;
    public List<string> result;
    public List<string> DataTable = new List<string> { "Student", "Course", "Marks" };
    public List<string> StudentAttributes = new List<string> {
        "id",
        "firstname",
        "lastname",
        "email",
        "age" };
    public List<string> CourseAttributes = new List<string> {
        "courseId",
        "cname",
        "credits" };
    public List<string> MarksAttributes = new List<string> {
        "grade",
        "studentId",
        "courseId"
    };
    public List<string> SQLKeywords = new List<string> { "Select", "From", "Where" };
    public List<string> Operators = new List<string> { "between", "and", "or", ">","<","<=",">=","==" };




    public void FillKeyword()
    {
        if (TableName == "Student")
        {
            switch (keywordName)
            {
                case "firstname":
                    for (int i = 0; i < DataClass.students.Length; i++)
                    {
                        result.Add(DataClass.students[i].firstname);
                    }
                  
                    break;
                case "lastname":
                    for (int i = 0; i < DataClass.students.Length; i++)
                    {
                        result.Add(DataClass.students[i].lastname);
                    }
                    break;
                case "id":
                    for (int i = 0; i < DataClass.students.Length; i++)
                    {
                        result.Add(DataClass.students[i].id.ToString());
                    }
                    break;
                case "email":
                    for (int i = 0; i < DataClass.students.Length; i++)
                    {
                        result.Add(DataClass.students[i].email);
                    }
                    break;
                case "age":
                    for (int i = 0; i < DataClass.students.Length; i++)
                    {
                        result.Add(DataClass.students[i].age.ToString());
                    }
                    break;
                default:
                    Debug.Log("RESULT EMPTY Student");
                    break;

            }
        }
        else
            if (TableName == "Course")
        {
            switch (keywordName)
            {
                case "courseId":
                    for (int i = 0; i < DataClass.courses.Length; i++)
                    {
                        result.Add(DataClass.courses[i].courseId.ToString());
                    }

                    break;
                case "cname":
                    for (int i = 0; i < DataClass.courses.Length; i++)
                    {
                        result.Add(DataClass.courses[i].cname);
                    }
                    
                    break;
                case "credits":
                    for (int i = 0; i < DataClass.courses.Length; i++)
                    {
                        result.Add(DataClass.courses[i].credits.ToString());
                    }
                    break;
                default:
                    Debug.Log("RESULT EMPTY Course");
                    break;

            }
        }
        else
                if (TableName == "Marks")
        {
            switch (keywordName)
            {
                case "courseId":
                    for (int i = 0; i < DataClass.marks.Length; i++)
                    {
                        result.Add(DataClass.marks[i].courseId.ToString());
                    }

                    break;
                case "studentId":
                    for (int i = 0; i < DataClass.marks.Length; i++)
                    {
                        result.Add(DataClass.marks[i].studentId.ToString());
                    }
                    break;
                case "grade":
                    for (int i = 0; i < DataClass.marks.Length; i++)
                    {
                        result.Add(DataClass.marks[i].grade.ToString());
                    }
                    break;

            }
        }
    }

    public void IsAttributeTable() {
        isKeyword = false;
        isAttribute = true;
        FillKeyword();
    }

    public KeywordMetaData(string kname, string tag)
    {
       
        result = new List<string>();
        keywordName = kname.Trim();

        if (tag.Trim().Contains("Sel"))
        {
            if (StudentAttributes.Contains(keywordName))
            {
                TableName = "Student";
                IsAttributeTable();
               

            }
            else
                if (CourseAttributes.Contains(keywordName))
            {
                TableName = "Course";
                IsAttributeTable();
                

            }
            else
            if (MarksAttributes.Contains(keywordName))
            {
                TableName = "Marks";
                IsAttributeTable();
                

            }
        }
    }


}
