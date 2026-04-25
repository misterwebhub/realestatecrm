<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CallRecordingByCallId.aspx.cs" Inherits="CallRecordingByCallId" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="width: 100%; overflow: auto;">
                <asp:GridView ID="grd_call_recording_by_call_id" runat="server" AutoGenerateColumns="False" CssClass=""
                    EmptyDataText="Record Not Found !" PageSize="100">
                    <Columns>
                        <asp:BoundField DataField="caller_id" HeaderText="Caller Id" />
                        <asp:TemplateField HeaderText="Recording">
                           <ItemTemplate>
                                <audio controls>
                                    <source src="<%# Eval("recording_data") %>" type="audio/mp3">
                                </audio>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Download">
                           <ItemTemplate>
                               <a href="<%# Eval("recording_data") %>">Download</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:BoundField DataField="call_status" HeaderText="Call Status" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
    
</body>
</html>
