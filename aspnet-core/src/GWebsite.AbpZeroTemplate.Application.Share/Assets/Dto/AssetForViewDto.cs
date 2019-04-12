using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
    /// <summary>
    /// <model cref="Asset"></model>
    /// </summary>
    public class AssetForViewDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
        public float Cost { get; set; }
    }
}
