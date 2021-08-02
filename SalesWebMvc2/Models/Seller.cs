using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace SalesWebMvc2.Models

{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} Requirido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} de ser entre {2} e {1}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Requirido")]
        [EmailAddress(ErrorMessage = "Entre com um e-mail valido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Data Aniversário")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} Requirido")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "{0} Requirido")]
        [Range(100.0, 5000.0, ErrorMessage = "O {0} deve ser entre {1} e {2}")]
        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]

        public double BaseSalary { get; set; }
        [Display(Name = "Departamento")]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        { }
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
