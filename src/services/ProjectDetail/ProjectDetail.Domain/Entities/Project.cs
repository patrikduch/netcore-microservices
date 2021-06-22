using NetMicroservices.SqlWrapper.Nuget;

namespace ProjectDetail.Domain
{
    /// <summary>
    /// Project domain entity object.
    /// </summary>
    public class Project : EntityBase
    {
        /// <summary>
        /// Gets or sets project name.
        /// </summary>
        public string Name { get; set; }
    }
}
