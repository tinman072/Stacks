Module Module1

    Public Structure Stack

        Public Structure StackNode
            Dim DATA As String
            Dim PTR As Integer
        End Structure

        Const nullPTR = -1

        Dim topPTR As Integer
        Dim basePTR As Integer

        Dim freelistPTR As Integer

        Dim s() As StackNode

        Sub initialize(ByVal size As Integer)
            topPTR = nullPTR
            basePTR = nullPTR

            freelistPTR = 0

            ReDim s(size - 1)

            For i = 0 To size - 2
                s(i).DATA = ""
                s(i).PTR = i + 1
            Next

            s(size - 1).DATA = ""
            s(size - 1).PTR = nullPTR

        End Sub

        Function top()
            Return s(topPTR).DATA
        End Function

        Sub push(ByVal dataItem As String)
            If freelistPTR = nullPTR Then
                Console.WriteLine("There is no more room in the Stack")
                Exit Sub
            End If

            Dim newNodePTR As Integer
            newNodePTR = freelistPTR
            s(newNodePTR).DATA = dataItem
            freelistPTR = s(freelistPTR).PTR

            If basePTR = nullPTR Then
                basePTR = newNodePTR
                topPTR = newNodePTR
                s(newNodePTR).PTR = nullPTR
                Exit Sub
            End If

            s(newNodePTR).PTR = topPTR
            topPTR = newNodePTR
        End Sub

        Sub pop()
            If basePTR = nullPTR Then
                Console.WriteLine("There are no nodes to remove")
                Exit Sub
            End If

            If topPTR = basePTR Then
                s(topPTR).PTR = freelistPTR
                topPTR = nullPTR
                basePTR = nullPTR
                Exit Sub
            End If

            Dim TNP As Integer = topPTR
            topPTR = s(topPTR).PTR
            s(TNP).PTR = freelistPTR
            freelistPTR = TNP
        End Sub

        Sub printStack()

            If basePTR = nullPTR Then
                Console.WriteLine("There are no nodes to print")
            End If

            Dim TNP As Integer = topPTR

            While TNP <> nullPTR
                Console.Write(s(TNP).DATA & " ")
                TNP = s(TNP).PTR
            End While
            Console.WriteLine("")
        End Sub
    End Structure



    Sub Main()

        Dim s As Stack

        s.initialize(5)

        s.push("A")
        s.push("B")
        s.push("C")
        s.push("D")

        s.printStack()

        Console.WriteLine(s.top())

        s.pop()

        Console.WriteLine(s.top())

        s.pop()
        s.pop()
        s.pop()

        s.printStack()

    End Sub

End Module
