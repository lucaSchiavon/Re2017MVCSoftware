using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ls.Prj.DTO
{
    public class UsaHouseDTO
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required(ErrorMessage = "address is required.")]
        [StringLength(255)]
        public string address { get; set; }
        [Column(TypeName = "money")]
        public decimal? agencyCosts { get; set; }
        public int? bathrooms { get; set; }
        [Column(TypeName = "money")]
        public decimal? closingCosts { get; set; }
        public int? constructionYear { get; set; }
        [Required(ErrorMessage = "country is required.")]
        [StringLength(255)]
        public string country { get; set; }
        public bool? enabled { get; set; }

        [Column(TypeName = "money")]
        public decimal? extimateAccountingExpense { get; set; }
        public decimal? annualExtimateAccountingExpense
        {
            get
            {
                return this.extimateAccountingExpense * 12;
            }
        }

        [Column(TypeName = "money")]
        public decimal? extimateCondoExpense { get; set; }
        public decimal? annualExtimateCondoExpense
        {
            get
            {
                return this.extimateCondoExpense * 12;
            }
        }


        [Column(TypeName = "money")]
        public decimal? extimateInsuranceExpense { get; set; }
        public decimal? annualExtimateInsuranceExpense
        {
            get
            {
                return this.extimateInsuranceExpense * 12;
            }
        }


        [Column(TypeName = "money")]
        public decimal? extimateMaintenanceExpense { get; set; }
        public decimal? annualExtimateMaintenanceExpense
        {
            get
            {
                return this.extimateMaintenanceExpense * 12;
            }
        }
        [Column(TypeName = "money")]
        public decimal? extimatePestControlExpense { get; set; }
        public decimal? annualExtimatePestControlExpense
        {
            get
            {
                return this.extimatePestControlExpense * 12;
            }
        }

        [Column(TypeName = "money")]
        public decimal? extimatePropertyManagerExpense { get; set; }
        public decimal? annualExtimateProperyManagerExpense
        {
            get
            {
                return this.extimatePropertyManagerExpense * 12;
            }
        }

        [Column(TypeName = "money")]
        public decimal? extimatePropertyTax { get; set; }
        public decimal? annualExtimatePropertyTax
        {
            get
            {
                return this.extimatePropertyTax * 12;
            }
        }
        [Column(TypeName = "money")]
        public decimal? extimateUtilitiesExpense { get; set; }
        public decimal? annualExtimateUtilitiesExpense
        {
            get
            {
                return this.extimateUtilitiesExpense * 12;
            }
        }
        [Column(TypeName = "money")]
        public decimal? grossRent { get; set; }
        public decimal? annualGrossRent {
            get
            {
                return this.grossRent * 12;
            }
        }
        public string housePhoto { get; set; }
        [Required(ErrorMessage = "nickname is required.")]
        [StringLength(255)]
        public string nickname { get; set; }
        public string notes { get; set; }
        [Column(TypeName = "money")]
        public decimal? otherClosingCosts { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? percVacancy { get; set; }

        public DateTime? purchaseDate { get; set; }
        [Required(ErrorMessage = "purchase price is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [Column(TypeName = "money")]
        public decimal? purchasePrice { get; set; }
        public int? rooms { get; set; }
        public DateTime sellingDate { get; set; }
        public int? sqFeet { get; set; }
        [DefaultValue(0)]
        [Column(TypeName = "money")]
        public decimal? sqFeetPrice { get; set; }
        [Required(ErrorMessage = "state is required.")]
        [StringLength(50)]
        public string state { get; set; }
        [Column(TypeName = "money")]
        public decimal? titleCompanyCosts { get; set; }
        public string zillowLink { get; set; }


        public decimal? monthVacancy
        {
            get
            {
                return (((this.grossRent) * this.percVacancy) / 100);
            }
        }
        public decimal? annualVacancy
        {
            get
            {
                return (((this.grossRent * 12) * this.percVacancy) / 100);
            }
        }
        public decimal? monthOperatingIncome
        {
            get
            {
                return (this.grossRent - ((this.grossRent * this.percVacancy) / 100));
            }
        }
        public decimal? annualOperatingIncome
        {
            get
            {
                return ((this.grossRent * 12) - (((this.grossRent * 12) * this.percVacancy) / 100));
            }
        }
        public double grossYeld
        {
            get
            {
                return Math.Round((double)((((this.grossRent * 12) - (((this.grossRent * 12) * this.percVacancy) / 100)) / this.purchasePrice)) * 100, 2);
            }
        }
        public decimal? totalOperatingExpense
        {
            get
            {
                return (this.extimatePropertyTax + this.extimatePestControlExpense + this.extimateUtilitiesExpense + this.extimatePropertyManagerExpense + this.extimateMaintenanceExpense + this.extimateInsuranceExpense + this.extimateCondoExpense + this.extimateAccountingExpense);
            }
        }
        public decimal? totalAnnualOperatingExpense
        {
            get
            {
                return ((this.extimatePropertyTax + this.extimatePestControlExpense + this.extimateUtilitiesExpense + this.extimatePropertyManagerExpense + this.extimateMaintenanceExpense + this.extimateInsuranceExpense + this.extimateCondoExpense + this.extimateAccountingExpense) * 12);
            }
        }
        public double opExpOnOpIncome
        {
            get
            {
                if (totalOperatingExpense != 0)
                {
                    return (Math.Round((double)(this.monthOperatingIncome / totalOperatingExpense), 2));
                }
                else { return 0; }

                
            }
        }
        public double annualOpExpOnOpIncome
        {
            get
            {
                if (totalAnnualOperatingExpense != 0)
                {
                    return (Math.Round((double)(this.annualOperatingIncome / totalAnnualOperatingExpense), 2));
                }
                else
                { return 0; }
                   
            }
        }
        public decimal? netOperatingIncome
        {
            get
            {
                return (this.monthOperatingIncome - this.totalOperatingExpense);
            }
        }
        public decimal? annualNetOperatingIncome
        {
            get
            {
                return (this.annualOperatingIncome - this.totalAnnualOperatingExpense);
            }
        }
        public double NetOperatingIncomePerc
        {
            get
            {
                return (Math.Round((double)(this.annualOperatingIncome / this.purchasePrice), 2));
            }
        }
        public decimal? totalPurchasePrice
        {
            get
            {
                return (this.purchasePrice + this.closingCosts + this.titleCompanyCosts + this.agencyCosts + this.otherClosingCosts);
            }
        }
        public double finalNetIncome
        {
            get
            {
                return (Math.Round((double)(this.annualNetOperatingIncome / this.totalPurchasePrice), 2));
            }
        }

        //[Required(ErrorMessage = "city is required.")]
        //[StringLength(50)]
        //public string city { get; set; }






        //[Column(TypeName = "money")]
        //public decimal? extimateVacancyRate { get; set; }




    }
}
