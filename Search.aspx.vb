
Imports Google.Apis.QPXExpress.v1
Imports Google.Apis.QPXExpress.v1.Data
Imports Google.Apis.Services

Public Class Search
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            '   CreatedCookies()
            ' Authen()
            txt_FlightDate.Text = Date.Now.AddDays(10).ToString("yyyy-MM-dd")
        End If
    End Sub


    Private Sub SearchFl(ByVal ADT As String, ByVal Origin As String, ByVal Destination As String, ByVal FlightDate As String)

        Dim service As New QPXExpressService(New BaseClientService.Initializer() With {
            .ApiKey = "AIzaSyB6_MDhUWoFbvYNaROKrSJ9_CaxUMB4pfA",
            .ApplicationName = "API key 1"
            })


        Dim x As New TripsSearchRequest With {
            .Request = New TripOptionsRequest()
        }
        x.Request.Passengers = New PassengerCounts() With {
            .AdultCount = ADT
        }
        x.Request.Slice = New List(Of SliceInput) From {
            New SliceInput() With {
            .Origin = Origin,
            .Destination = Destination,
            .[Date] = FlightDate,
            .MaxStops = False
        }
        }
        x.Request.Solutions = txt_Limit.Text.Trim
        Dim result = service.Trips.Search(x).Execute()

        'SHOW RESULT
        For Each aircraft In result.Trips.Data.Aircraft
            Response.Write(aircraft.Name & aircraft.Code & "<br />")
            '  Console.WriteLine(aircraft.Name + aircraft.Code)
        Next

        ' Airport
        For Each airport In result.Trips.Data.Airport
            Response.Write(airport.Name & " - " & airport.City & "<br />")
        Next
        For Each carrier In result.Trips.Data.Carrier
            Response.Write(carrier.Name & "<br />")
        Next


        For Each trip In result.Trips.TripOption

            Response.Write("Flight: " & trip.Slice.FirstOrDefault().Segment.FirstOrDefault().Flight.Carrier & trip.Slice.FirstOrDefault().Segment.FirstOrDefault().Flight.Number & "||")
            Response.Write(" From: " & trip.Slice.FirstOrDefault().Segment.FirstOrDefault().Leg.FirstOrDefault().Origin & "(" & trip.Slice.FirstOrDefault().Segment.FirstOrDefault().Leg.FirstOrDefault().DepartureTime & ")" & " => ")

            Response.Write(trip.Slice.FirstOrDefault().Segment.FirstOrDefault().Leg.FirstOrDefault().Destination & "(" & trip.Slice.FirstOrDefault().Segment.FirstOrDefault().Leg.FirstOrDefault().ArrivalTime & ")" & "||")

            Response.Write(" Duration: " & trip.Slice.FirstOrDefault().Duration & "||")
            'Response.Write(" Cabin: " & trip.Slice.FirstOrDefault().Segment.FirstOrDefault().Cabin & "||")
            Response.Write(" price: " & trip.Pricing.FirstOrDefault().BaseFareTotal.ToString() & "<br /><br />")
        Next
    End Sub

    Public Function CreatedCookies() As HttpCookie
        Dim cookie As HttpCookie = New HttpCookie("userlang") With {
            .HttpOnly = True,
            .Secure = True,
            .Path = "/test",
            .Value = "fr"
        }
        Return cookie

    End Function

    Protected Sub Btn_GetFlight_Click(sender As Object, e As EventArgs) Handles Btn_GetFlight.Click
        SearchFl(txt_ADT.Text, txt_Origin.Text, txt_Destination.Text, txt_FlightDate.Text)
    End Sub

End Class