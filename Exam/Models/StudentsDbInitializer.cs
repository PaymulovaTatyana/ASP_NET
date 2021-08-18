using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Exam.Models
{
    public class StudentsDbInitializer: DropCreateDatabaseIfModelChanges<StudentContext>
    {
    }
}