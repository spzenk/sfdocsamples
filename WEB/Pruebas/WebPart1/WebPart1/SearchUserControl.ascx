<%@ control language="C#" classname="SearchUserControl" %>

<script runat="server">
  private int results;
  
  [Personalizable]
  public int ResultsPerPage
  {
    get
      {return results;}
    
    set
      {results = value;}
  }    
</script>

<asp:textbox runat="server" id="inputBox" BackColor="#FFFF99"     BorderColor="#003300" BorderStyle="Solid"></asp:textbox>
<asp:button runat="server" id="searchButton" text="Search" />


