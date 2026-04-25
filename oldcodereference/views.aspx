<%@ Page Title="" Language="C#" MasterPageFile="~/chain system/admin/homemaster.master" AutoEventWireup="true" CodeFile="views.aspx.cs" Inherits="chain_system_admin_views" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
 <style type="text/css">
        
        #chart
        {
            width: 900px;
            height: 500px;
        }
        #chart div
        {
            width: 100px;
        }
       
    </style>
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["orgchart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            $.ajax({
                type: "POST",
                url: "CS.aspx/GetChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = new google.visualization.DataTable();
                    data.addColumn('string', 'Entity');
                    data.addColumn('string', 'ParentEntity');
                    data.addColumn('string', 'ToolTip');
                    for (var i = 0; i < r.d.length; i++) {
                        var memberId = r.d[i][0].toString();
                        var memberName = r.d[i][1];
                        var parentId = r.d[i][2] != null ? r.d[i][2].toString() : '';
                        data.addRows([[{ v: memberId,
                            f: memberName, 
                        }, parentId, memberName]]);
                    }
                    var chart = new google.visualization.OrgChart($("#chart")[0]);
                    chart.draw(data, { allowHtml: true });
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="chart">
    </div>
</asp:Content>

