//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseMM
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeInfo
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public int IdGender { get; set; }
        public System.DateTime BirthDate { get; set; }
        public Nullable<int> Phone { get; set; }
        public Nullable<int> INN { get; set; }
        public Nullable<System.DateTime> DateOfStart { get; set; }
        public Nullable<System.DateTime> DateOfLeave { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
