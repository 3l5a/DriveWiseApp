﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.BrandDTOs;
public class BrandAddDto
{
    [Required]
    [DefaultValue(null)]
    public string Name { get; set; }
}
