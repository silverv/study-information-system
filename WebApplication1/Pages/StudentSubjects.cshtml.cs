using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1
{
    public class StudentSubjectsModel : PageModel
    {
        public string PersonalCode { get; set; }
        public List<Subject> Subjects { get; set; }
        public Subject ChosenSubject { get; set; }

        public Subject QuerySubject { get; set; } // This is the subject that is here just for it's property keys, no values are needed from it

        public List<Subject> AllSubjects { get; set; }

        public void OnPost(string PersonalCode)
        {
            setPersonalAndAllSubjects(PersonalCode);
        }
        private int getIdFromPersonalCode(string PersonalCode)
        {
            using (OisContext ois = new OisContext())
            {
                return (from student in ois.Student
                             where student.Personalcode == PersonalCode
                             select student.StudentId).First();
            }
        }
        private List<Subject> getStudentSubjects(string PersonalCode)
        {
            using (OisContext ois = new OisContext())
            {
                return (from subject in ois.Subject
                            join studentinsubject in ois.Studentinsubject on subject.SubjectId equals studentinsubject.SubjectId
                            join student in ois.Student on studentinsubject.StudentId equals student.StudentId
                            where student.Personalcode == this.PersonalCode
                            select subject).ToList();
            }
        }
        private void setPersonalAndAllSubjects(string PersonalCode)
        { 
            this.PersonalCode = PersonalCode;
            using (OisContext ois = new OisContext())
            {
                this.Subjects = getStudentSubjects(PersonalCode);
                this.AllSubjects = getAllSubjects().Except(Subjects).ToList();
            }
        }
        private List<Subject> getAllSubjects()
        {
            using (OisContext ois = new OisContext())
            {
                return (from subject in ois.Subject
                        select subject).Distinct().ToList();
            }
        }
        public void OnPostAdd(int SubjectId, string PersonalCode)
        {
            using (OisContext ois = new OisContext())
            {
                var id = getIdFromPersonalCode(PersonalCode);
                ois.Studentinsubject.Add(new Studentinsubject
                {
                    StudentId = id,
                    SubjectId = SubjectId
                });
                ois.SaveChanges();
            }
            setPersonalAndAllSubjects(PersonalCode);
        }
        public void OnPostRemove(int SubjectId, string PersonalCode)
        {
            using (OisContext ois = new OisContext())
            {
                int id = (from student in ois.Student
                          where student.Personalcode == PersonalCode
                          select student.StudentId).First();
                ois.Studentinsubject.Remove((from sis in ois.Studentinsubject
                                             where sis.StudentId == id
                                             select sis).First());
                ois.SaveChanges();
            }
            setPersonalAndAllSubjects(PersonalCode);
        }
        public void OnPostFilter(string Query, string PersonalCode)
        {
            using (OisContext ois = new OisContext())
            {
                int id = (from student in ois.Student
                          where student.Personalcode == PersonalCode
                          select student.StudentId).First();
                ois.Studentinsubject.Remove((from sis in ois.Studentinsubject
                                             where sis.StudentId == id
                                             select sis).First());
                ois.SaveChanges();
            }
            this.Subjects = getStudentSubjects(PersonalCode);
            this.AllSubjects = getAllSubjects().Except(this.Subjects).ToList(); // These are now filtered subjects
        }
    }
}