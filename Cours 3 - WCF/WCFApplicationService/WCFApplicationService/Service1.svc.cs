using System;
using System.Collections.Generic;
using System.Linq;

namespace WCFApplicationService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {

        public List<Student> Students = new List<Student>
        {
            new Student{IdBooster = 1, Firstname = "toto", Lastname = "toto", Age = 12},
            new Student{IdBooster = 2, Firstname = "tata", Lastname = "toto", Age = 12},
            new Student{IdBooster = 3, Firstname = "tutu", Lastname = "toto", Age = 12},
            new Student{IdBooster = 4, Firstname = "titi", Lastname = "toto", Age = 12}
        };

        public List<Student> GetStudents()
        {
            return Students;
        }

        public void CreateStudent(Student student)
        {
            Students.Add(student);
        }

        public Student GetPerson(int idBooster)
        {
            return Students.Where(x => x.IdBooster == idBooster).SingleOrDefault();
        }
    }
}
