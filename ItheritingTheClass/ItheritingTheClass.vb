Imports System

Module ItheritingTheClass
    Sub Main()
        Dim birth As New EnhancedDate(1953, 2, 2)
        Dim today As New EnhancedDate(2002, 8, 29)

        Console.WriteLine("Birthday = {0}", birth)
        Console.WriteLine("Today = " & today.ToString())
        Console.WriteLine("Days since birthday = {0}", today.Subtract(birth))
    End Sub
End Module

Class EnhancedDate
    Inherits CalendarDate

    'Private field
    Private Shared ReadOnly Str() As String = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}

    'Public Constructor
    Sub New(ByVal yr As Integer, ByVal mn As Integer, ByVal dy As Integer)
        MyBase.New(yr, mn, dy)
    End Sub

    'Public Properties
    ReadOnly Property DaySince1600() As Integer
        Get
            Return 365 * (Year() - 1600) +
                        (Year() - 1597) \ 4 -
                        (Year() - 1601) \ 100 +
                        (Year() - 1601) \ 400 + DayOfYear
        End Get
    End Property

    Overrides Function ToString() As String
        Return String.Format("{0} {1} {2}", Day, Str(Month() - 1), Year)
    End Function

    Function Subtract(ByVal subtrahend As EnhancedDate) As Integer
        Return DaySince1600 - subtrahend.DaySince1600
    End Function
End Class