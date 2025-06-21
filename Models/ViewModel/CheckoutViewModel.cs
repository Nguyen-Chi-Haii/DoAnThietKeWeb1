using System.ComponentModel.DataAnnotations;

namespace DoAnThietKeWeb1.Models.ViewModel
{
    public class CheckoutViewModel
    {


            [Required(ErrorMessage = "Họ và tên không được để trống")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Số điện thoại không được để trống")]
            [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "Địa chỉ nhận hàng không được để trống")]
            public string Address { get; set; }

            public string? Province { get; set; }
            public string? District { get; set; }
            public string? Ward { get; set; }

            public string? Note { get; set; }

    }
}
