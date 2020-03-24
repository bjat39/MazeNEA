Imports NUnit.Framework

<TestFixture>
Public Class GenerateTests
    <Test>
    Sub TestAbsoluteSeed()

        Dim m As Generate = New Generate()

        Dim positiveMaze = m.InitialiseGrid(10, 10, 1234, MazeGenerationAlgorithms.Prims)
        Dim negativeMaze = m.InitialiseGrid(10, 10, -1234, MazeGenerationAlgorithms.Prims)
        'Test the layout of the walls
        negativeMaze = negativeMaze.Replace("<Seed>-1234</Seed>", "<Seed>1234</Seed>") 
        Assert.That(positiveMaze, [Is].EqualTo(negativeMaze))
    End Sub

    <Test>
    Sub TestZeroByZero()

        Dim m As Generate = New Generate()
        Try
            m.InitialiseGrid(0, 0, 1234, MazeGenerationAlgorithms.Prims)
        Catch ex As ArgumentException
            Return
        End Try
        Assert.Fail("Didn't throw argument exception")
    End Sub
End Class

