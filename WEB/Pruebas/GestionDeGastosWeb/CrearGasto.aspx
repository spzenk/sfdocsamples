<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CrearGasto.aspx.cs" Inherits="CrearGasto"
    MasterPageFile="~/GestionGastosMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterPagePlaceHolder1" runat="server">
    
    <div style="height: 3px">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:ObjectDataSource ID="TipoGastosDataSource" runat="server" SelectMethod="BuscarTipoGastoTodos"
            TypeName="PelsoftGastos.Back.TipoGastoDAC"></asp:ObjectDataSource>
    </div>
    <div style="height: 218px; width: 713px;">
        <table style="border: thin double #800000; width: 70%; height: 100%;">
            <tr>
                <td style="height: 141px">
                    Tipo Gasto
                </td>
                <td style="height: 141px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    </asp:UpdatePanel>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="TipoGastosDataSource"
                        DataTextField="Nombre" DataValueField="IdTipoGasto" Width="316px" 
                        Height="61px">
                    </asp:DropDownList>
                </td>
                <td style="height: 141px">
                    &nbsp; Fecha
                </td>
                <td class="" style="height: 141px">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            
                             <asp:TextBox ID="txtFecha" runat="server" Width="0px"  Height="0px"></asp:TextBox>
                              <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                 ControlToValidate="txtFecha" ErrorMessage="Debe establecer una fecha"></asp:CompareValidator>
                                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999"
                                CellPadding="4" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px"
                                Width="200px" onselectionchanged="Calendar1_SelectionChanged">
                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                <SelectorStyle BackColor="#CCCCCC" />
                                <WeekendDayStyle BackColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <OtherMonthDayStyle ForeColor="#808080" />
                                <NextPrevStyle VerticalAlign="Bottom" />
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            </asp:Calendar>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <p></p>
                        Monto<td class="clear">
                    <p>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_Monto" runat="server" ErrorMessage="El valor monto es requerido"
                        ControlToValidate="txtMonto" SetFocusOnError="true" ForeColor="Maroon">El valor monto es requerido</asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtMonto" runat="server" Width="298px"></asp:TextBox>
                    </p>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
               <td>
                    Descripcion
                </td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="306px" CausesValidation="True"></asp:TextBox>
                </td>
               <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td >
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;
                </td>
                <td >
                    &nbsp;
                </td>
                <td >
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;
                </td>
                <td >
                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar"
                        Width="125px" Height="16px" />
                </td>
                <td ">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <p>
        &nbsp;</p>
    
</asp:Content>

