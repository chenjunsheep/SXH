namespace Sxh.Client.Business.Model
{
    public class UserAccount : User
    {
        public double Cash { get; set; }
        public override bool HasValue => base.HasValue && !string.IsNullOrEmpty(PasswordTran);
    }
}
