namespace Re2017MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("House")]
    public partial class House
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string nickname { get; set; }

        [StringLength(50)]
        public string state { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(10)]
        public string street { get; set; }

        public string housePhoto { get; set; }

        public string zillowLink { get; set; }

        [Column(TypeName = "money")]
        public decimal? purchasePrice { get; set; }

        public int? sqFeet { get; set; }

        [Column(TypeName = "money")]
        public decimal? sqFeetPrice { get; set; }

        public int? constructionYear { get; set; }

        [Column(TypeName = "money")]
        public decimal? grossRent { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? percVacancy { get; set; }

        [Column(TypeName = "money")]
        public decimal? extimateAccountingExpense { get; set; }

        [Column(TypeName = "money")]
        public decimal? extimateCondoExpense { get; set; }

        [Column(TypeName = "money")]
        public decimal? extimateInsuranceExpense { get; set; }

        [Column(TypeName = "money")]
        public decimal? extimateMaintenanceExpense { get; set; }

        [Column(TypeName = "money")]
        public decimal? extimateProperyManagerExpense { get; set; }

        [Column(TypeName = "money")]
        public decimal? extimateUtilitiesExpense { get; set; }

        [Column(TypeName = "money")]
        public decimal? extimatePestControlExpense { get; set; }

        [Column(TypeName = "money")]
        public decimal? extimatePropertyTax { get; set; }

        [Column(TypeName = "money")]
        public decimal? closingCosts { get; set; }

        [Column(TypeName = "money")]
        public decimal? titleCompanyCosts { get; set; }

        [Column(TypeName = "money")]
        public decimal? agencyCosts { get; set; }

        [Column(TypeName = "money")]
        public decimal? otherClosingCosts { get; set; }
    }
}
