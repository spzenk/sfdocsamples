using CSSFriendly;
public partial class Walkthrough : DynamicAdaptersPage
{
    public override string StyleSheetTheme
    {
        get
        {
            return "Enhanced";
        }
        set
        {
            base.StyleSheetTheme = value;
        }
    }
}
