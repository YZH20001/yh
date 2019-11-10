﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Dto
{
    public class UserInformationDto
    {

        public Guid ID { get; set; }
        public string Email { get; set; }
        public string SiteName { get; set; }
        public string ImagePath { get; set; }
        public int FansCount { get; set; }
        public int FocusCount { get; set; }
    }
}
