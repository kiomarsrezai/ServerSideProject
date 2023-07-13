using WareHousingApi.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WareHousingApi.Entities.Models.Departments
{
    public class DepartmentViewModel
    {
        //[JsonPropertyName("Id")]
        public int Id { get; set; }

        [Display(Name ="عنوان دپارتمان")]
        [Required(ErrorMessage ="وارد نمودن {0} الزامی است.")]
        public string DepartmentName { get; set; }
        
        [Display(Name = "کد دپارتمان")]
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        public string DepartmentCode { get; set; }

        //[JsonPropertyName("ردیف")]
        //public int Row { get; set; }

        [Display(Name = "دسته پدر")]
        public string MotherName { get; set; }

        [JsonIgnore]
        public int? MotherId { get; set; }


        //[Display(Name = "آدرس"), JsonPropertyName("آدرس")]
        //[Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        ////[UrlValidate("/",@"\"," ")]
        //public string Url { get; set; }
    }
}
