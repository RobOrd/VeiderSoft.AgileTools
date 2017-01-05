using System.Management.Automation;
using System.Windows.Forms;
using VeiderSoft.AgileTools.PowerShell.Containers;
using VeiderSoft.AgileTools.PowerShell.Infrastructure;

namespace VeiderSoft.AgileTools.PowerShell
{
    [Cmdlet(VerbsCommon.Get, "Property")]
    [OutputType(typeof(VSAgileProperty))]
    public class GetPropertyCmdlet : Cmdlet
    {
        [Parameter(Position = 0)]
        [Alias("Nombre")]
        public string Name { get; set; }

        [Parameter(Position = 1)]
        [Alias("Tipo", "DataType", "dt")]
        public string Type { get; set; }

        IBlockCodeGenerator bcg;
        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            //Codegen object
            this.bcg = new VSAgileProperty();
        }
        protected override void ProcessRecord()
        {
            bcg.SetTemplate();

            bcg.Replace("{Type}", Type);
            bcg.Replace("{Name}", Name);

            var name = BCGHelper.ToLowerFirstLetter(Name);
            bcg.Replace("{name}", name);

            var bc = bcg.GetCodeGenerated();
            WriteObject(bc.Code);
            Clipboard.SetText(bc.Code);
        }
    }
}


