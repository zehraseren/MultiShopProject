﻿namespace MS.UI.DtoLayer.DiscountDtos;

public class GetDiscountCodeDetailByCodeDto
{
    public int CouponId { get; set; }
    public string Code { get; set; }
    public int Rate { get; set; }
    public bool IsActive { get; set; }
    public DateTime ValidDate { get; set; }
}
