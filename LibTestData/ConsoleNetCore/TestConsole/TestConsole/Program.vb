'Imports System

Module Program
    Sub Main(args As String())
        Console.Write("Nhap ten cua ban: ")
        Dim hoTen = Console.ReadLine()
        Console.WriteLine($"Xin chao ban: {hoTen}")
        Console.WriteLine("Xin chao ban tiep: {0}", hoTen)
        Console.Write("Nhap vao nam sinh = ")
        Dim namSinh = Console.ReadLine()
        Console.WriteLine("Nam sinh cua ban: {0}", namSinh)
    End Sub
End Module
