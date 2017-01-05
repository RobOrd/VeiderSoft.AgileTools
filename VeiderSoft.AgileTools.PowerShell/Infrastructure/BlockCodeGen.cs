namespace VeiderSoft.AgileTools.PowerShell.Infrastructure
{
    public interface IBlockCode
    {
        string Code { get; set; }
    }
    public class BlockCode : IBlockCode
    {
        public string Code { get; set; }
    }

    public interface IBlockCodeGenerator
    {
        void Replace(string pattern, string value);
        void SetTemplate();
        IBlockCode GetCodeGenerated();
    }
    public class BlockCodeBase
    {
        protected string template { get; set; }
        IBlockCode blockCode { get; set; }

        public BlockCodeBase(IBlockCode bc)
        {
            this.blockCode = bc;
        }

        public IBlockCode GetCodeGenerated()
        {
            this.blockCode.Code = this.template;
            return this.blockCode;
        }
    }

    public class BCGHelper
    {
        public static string ToLowerFirstLetter(string token)
        {
            var name = token.ToCharArray()[0].ToString().ToLower();
            return name + token.Substring(1);
        }
    }
}
