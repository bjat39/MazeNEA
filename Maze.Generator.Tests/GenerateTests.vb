Imports NUnit.Framework

<TestFixture>
Public Class GenerateTests
    <Test>
    Sub TestValidMazeReturned()

        Dim m As Generate = New Generate()
        Debug.WriteLine(m.InitialiseGrid(1, 2, 3))
        Assert.That(m.InitialiseGrid(10, 10, 10), [Is].EqualTo("<Maze></Maze>"))
    End Sub
End Class

