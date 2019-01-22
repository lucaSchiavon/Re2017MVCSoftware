namespace Ls.Prj.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ls.Base.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;

    public partial class House: LsEntity
    {
        public int id { get; set; }
        [Required(ErrorMessage = "address is required.")]
        [StringLength(255)]
        public string address { get; set; }
        [Column(TypeName = "money")]
        public decimal? agencyCosts { get; set; }
        public int? bathrooms { get; set; }
        [Column(TypeName = "money")]
        public decimal? closingCosts { get; set; }
        //public int? constructionYear { get; set; }
        public string constructionYear { get; set; }
        [Required(ErrorMessage = "country is required.")]
        [StringLength(255)]
        public string country { get; set; }
        public string city { get; set; }
        public bool? enabled { get; set; }
        [Column(TypeName = "money")]
        public decimal? extimateAccountingExpense { get; set; }
        [Column(TypeName = "money")]
        public decimal? extimateCondoExpense { get; set; }
        [Column(TypeName = "money")]
        public decimal? extimateInsuranceExpense { get; set; }
        [Column(TypeName = "money")]
        public decimal? extimateMaintenanceExpense { get; set; }
        [Column(TypeName = "money")]
        public decimal? extimatePestControlExpense { get; set; }
        [Column(TypeName = "money")]
        public decimal? extimatePropertyManagerExpense { get; set; }
        [Column(TypeName = "money")]
        public decimal? extimatePropertyTax { get; set; }
        [Column(TypeName = "money")]
        public decimal? extimateUtilitiesExpense { get; set; }
        [Column(TypeName = "money")]
        public decimal? grossRent { get; set; }
        public string housePhoto { get; set; }
        [Required(ErrorMessage = "nickname is required.")]
        [StringLength(255)]
        public string nickname { get; set; }
        public string notes { get; set; }
        [Column(TypeName = "money")]
        public decimal? otherClosingCosts { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? percVacancy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? purchaseDate { get; set; }
        [Required(ErrorMessage = "purchase price is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [Column(TypeName = "money")]
        public decimal? purchasePrice { get; set; }
        public int? rooms { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? sellingDate { get; set; }
        public int? sqFeet { get; set; }
        [DefaultValue(0)]
        [Column(TypeName = "money")]
        //public decimal? sqFeetPrice { get; set; }
        [Required(ErrorMessage = "state is required.")]
        [StringLength(50)]
        public string state { get; set; }
        [Column(TypeName = "money")]
        public decimal? titleCompanyCosts { get; set; }
        public string zillowLink { get; set; }
        //public string city { get; set; }
      //public string purchaseDateStr
      //  {
      //      get
      //      {
      //          string DateStr="1000-01-01";
      //          if (this.purchaseDate != null)
      //          {
      //              DateStr = new DateTime(((DateTime)this.purchaseDate).Year, ((DateTime)this.purchaseDate).Month, ((DateTime)this.purchaseDate).Day).ToString("yyyy-MM-dd");
      //          }
                
              
      //          return DateStr;
      //      }
      //  }
        //private string _sellingDateStr;
        //public string sellingDateStr
        //{
        //    get
        //    {
        //        //string DateStr = "1000-01-01";
        //        //if (this.sellingDate != null)
        //        //{
        //        //  DateStr = new DateTime(((DateTime)this.sellingDate).Year, ((DateTime)this.sellingDate).Month, ((DateTime)this.sellingDate).Day).ToString("yyyy-MM-dd");
        //        //}

        //        //return DateStr;
        //        return _sellingDateStr;
        //    }
        //    set
        //    {
        //        string DateStr = "1000-01-01";
        //        if (this.sellingDate != null)
        //        {
        //            _sellingDateStr = new DateTime(((DateTime)this.sellingDate).Year, ((DateTime)this.sellingDate).Month, ((DateTime)this.sellingDate).Day).ToString("yyyy-MM-dd");
        //        }
        //        else
        //        {
        //            _sellingDateStr = DateStr;
        //        }
        //    }
        //    }

       
        //public decimal? extimateVacancyRate { get; set; }



    }
}
