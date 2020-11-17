Imports System
Imports System.Linq
Imports System.Collections.Generic

Class Food     
    Public Property Name() As String = ""
    
    Public Property Calorie() As Integer = 0
    
    Public Overrides Function ToString() as String
        Return String.Format("Name: {0}, Calories: {1}", Name, Calorie)
    End Function
End Class
Module Application
    Sub Print(result as IEnumerable(Of Food), query as String)
        Console.WriteLine("[QUERY] {0}", query)
        For Each i as Food in result
            Console.WriteLine("[OUTPUT] {0}", i)
        Next
    End Sub
    Sub GreaterThan(values as List(Of Food))
        Dim result as IEnumerable(Of Food) = from v in values
                     where v.Calorie > 100
                     select v
        
        Print(result, "SELECT * FROM values AS v WHERE v.Calorie > 100")
    End Sub
    Sub LessThan(values as List(Of Food))
        Dim result as IEnumerable(Of Food) = from v in values
                     where v.Calorie < 50
                     select v
        
        Print(result, "SELECT * FROM values AS v WHERE v.Calorie < 50")
    End Sub
    Sub EqualTo(values as List(Of Food))
        Dim result as IEnumerable(Of Food) = from v in values
                     where v.Calorie = 100
                     select v
        
        Print(result, "SELECT * FROM values AS v WHERE v.Calorie = 100")
    End Sub
	Sub Main()
        Dim list as New List(Of Food) 
        list.Add(new Food() with {.Name="Cheese Burger", .Calorie=250})
        list.Add(new Food() with {.Name="Cracker", .Calorie=25})
        list.Add(new Food() with {.Name="BLT", .Calorie=100})
		Console.WriteLine("[INPUT] {0}", String.Join(Of Food)(", ", list.ToArray()))
        
        GreaterThan(list)
        LessThan(list)
        EqualTo(list)
	End Sub
End Module