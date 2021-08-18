using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Exam.Models
{
    public class Student
    {
        public virtual int StudentId { get; set; }

        [DisplayName("Имя")]
        public virtual string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public virtual string LastName { get; set; }

        [DisplayName("Факультет")]
        public virtual string Faculty { get; set; }

        [DisplayName("Группа")]
        public virtual string Group { get; set; }

        [DisplayName("Теплофизика")]
        public virtual int Value_ThermalPhysics { get; set; }

        [DisplayName("Механика жидкости и  газов")]
        public virtual int Value_Fluid { get; set; }

        [DisplayName("Лопаточные машины")]
        public virtual int Value_Turbine { get; set; }

        [DisplayName("Криогенная техника")]
        public virtual int Value_Cryogenic { get; set; }

        [DisplayName("Сумма баллов")]
        public virtual int Total { get { return Value_ThermalPhysics + Value_Fluid + Value_Turbine + Value_Cryogenic ; } }
    }
}