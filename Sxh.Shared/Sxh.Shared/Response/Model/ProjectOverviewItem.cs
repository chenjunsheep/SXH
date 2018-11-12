namespace Sxh.Shared.Response.Model
{
    public class ProjectOverviewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int PayTypeId { get; set; }
        public string PayTypeName { get; set; }
        public double Deadline { get; set; }
        public double TotalFunds { get; set; }
        public double Rate { get; set; }
        public string Note { get; set; }
        public int ProjectTypeId { get; set; }
    }
}
