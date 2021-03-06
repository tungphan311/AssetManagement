﻿using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto
{
    /// <summary>
    /// <model cref="Project"></model>
    /// </summary>
    public class ProjectFilter : PagedAndSortedInputDto
    {

        public string Code { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }    

    }
}
