﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EKebun.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the EKebunUser class
    public class EKebunUser : IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }

        [PersonalData]
        public string Address { get; set; }

    }
}
// Add-Migration AddNewCustomData -context EKebunNewContext
// /*Update-Database -context EKebunNewContext*/

