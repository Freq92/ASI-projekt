<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SkiForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <title>Google Maps API Sample</title>
    <script src="http://maps.google.com/maps/api/js?sensor=true" type="text/javascript"></script>
    <script type="text/javascript">

    var map = null;
    var geocoder = null;
    var gmarkers = [];
    var marker = null;
    
   
    

    
    
    function initialize() {
        var gmarkers = [];
        var marker;
        google.maps.visualRefresh = true;
        var Wroclaw = new google.maps.LatLng(51.107969, 17.038571);
        var infowindow = new google.maps.InfoWindow(
        {
            size: new google.maps.Size(150, 50)
        });

        var mapOptions = {
            zoom: 8,
            center: Wroclaw,
            mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
        };

        var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
        google.maps.event.addListener(map, 'click', function (event) {
            removeMarkers();
            placeMarker(event.latLng);
            getXml(event.latLng);
            
           
        });
        function getXml(location) {
            var lat = location.lat();
            var lng=location.lng();
            $.ajax({
                type: "POST",
                url: "Default.aspx/getSki",
                data: JSON.stringify({ cordinates: lat+','+lng}),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: "+lat+lng + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    document.getElementById('<%=skiOutput.ClientID %>').value = result.d;
                }
            });
            $.ajax({
                type: "POST",
                url: "Default.aspx/getMarine",
                data: JSON.stringify({ cordinates: lat + ',' + lng}),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + lat + lng + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    document.getElementById('<%=marineOutput.ClientID %>').value = result.d;
                }
            });
        }
        function placeMarker(location) {
            marker = new google.maps.Marker({
                position: location,
                map: map

            });



            gmarkers.push(marker);
            marker.info = new google.maps.InfoWindow({
                content: "<div style='height:60px;width:150px;'>" + "<br>Współrzędne: " + marker.getPosition().toUrlValue(6) + "</div>"
            });
            google.maps.event.addListener(marker, 'mouseover', function () {

                marker.info.open(map, marker);
            });
            marker.addListener('mouseout', function () {
                marker.info.close();
            });

        }
        function removeMarkers() {
            for (i = 0; i < gmarkers.length; i++) {
                gmarkers[i].setMap(null);
            }
        }
    }
    
    
    

    </script>
  </head>
  <body onload="initialize()" onunload="GUnload()" style="font-family: Arial;border: 0 none;">
   
       <div id="map_canvas" style="width: 1000px; height: 600px"></div>
      <br />
        <asp:TextBox ID="skiOutput" runat="server" TextMode="MultiLine" Width="500px" Height="200px" visible=true></asp:TextBox>
        <asp:TextBox ID="marineOutput" runat="server" TextMode="MultiLine" Width="500px" Height="200px" visible=true></asp:TextBox>
        <br />
  </body>
    

</asp:Content>
