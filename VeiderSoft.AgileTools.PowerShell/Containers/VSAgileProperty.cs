using VeiderSoft.AgileTools.PowerShell.Infrastructure;

namespace VeiderSoft.AgileTools.PowerShell.Containers
{
    public class VSAgileProperty : BlockCodeBase, IBlockCodeGenerator
    {
        public VSAgileProperty() :base(new BlockCode())
        {
            
        }

        public void SetTemplate()
        {
            this.template =
@" 
private {Type} {name};
public {Type} {Name}
{
    get { return this.{name};}
    set {
        if(value == {name}) return;
        {name} = value;
        NotifyChanged(nameof({Name}));
    }
}";
        }
        public void Replace(string pattern, string value)
        {
            this.template = this.template.Replace(pattern, value);
        }
    }
}
