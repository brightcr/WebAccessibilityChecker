using System.ComponentModel;
using Microsoft.VisualStudio.Shell;

namespace WebAccessibilityChecker
{
    public class Options: DialogPage
    {
        [Category("General")]
        [DisplayName("Enabled")]
        [Description("Determines if the extension is enabled or not.")]
        [DefaultValue(true)]
        public bool Enabled { get; set; } = true;

        [Category("General")]
        [DisplayName("Run on page load")]
        [Description("Determines if the the accessiblity checker should run automatically on page load.")]
        [DefaultValue(true)]
        public bool RunOnPageLoad { get; set; } = true;

        [Category("Severity")]
        [DisplayName("Show warnings")]
        [Description("Shows accessibility errors classified as warnings.")]
        [DefaultValue(true)]
        public bool ShowWarnings { get; set; } = true;

        [Category("Severity")]
        [DisplayName("Show messages")]
        [Description("Shows accessibility errors classified as informational messages.")]
        [DefaultValue(false)]
        public bool ShowMessages { get; set; }
    }
}
