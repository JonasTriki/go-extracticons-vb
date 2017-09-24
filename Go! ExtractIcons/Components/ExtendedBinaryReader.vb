Imports System.IO

Public Class ExtendedBinaryReader
    Inherits BinaryReader
    ''' <summary>
    '''   Creates a new instance of the <c>ExtendedBinaryReader</c> class.
    ''' </summary>
    ''' <param name="Input">A stream.</param>
    Public Sub New(ByVal Input As Stream)
        MyBase.New(Input)
    End Sub
    ''' <summary>
    '''   Creates a new instance of the <c>ExtendedBinaryReader</c> class.
    ''' </summary>
    ''' <param name="Input">The provided stream.</param>
    ''' <param name="Encoding">The character encoding.</param>
    Public Sub New(ByVal Input As Stream, ByVal Encoding As System.Text.Encoding)
        MyBase.New(Input, Encoding)
    End Sub
    ''' <summary>
    '''   Reads the whole data in the base stream and returns it in an
    '''   array of bytes.
    ''' </summary>
    ''' <returns>The streams whole binary data.</returns>
    Public Function ReadToEnd() As Byte()
        Return ReadToEnd(Short.MaxValue)
    End Function
    ''' <summary>
    '''   Reads the whole data in the base stream and returns it in an array of bytes.
    ''' </summary>
    ''' <param name="InitialLength">The initial buffer length.</param>
    ''' <returns>The stream's whole binary data.</returns>
    Public Function ReadToEnd(ByVal InitialLength As Integer) As Byte()
        ' If an unhelpful initial length was passed, just use 32K.
        If InitialLength < 1 Then
            InitialLength = Short.MaxValue
        End If
        Dim Buffer(InitialLength - 1) As Byte
        Dim Read As Integer
        Dim Chunk As Integer = _
            Me.BaseStream.Read(Buffer, Read, Buffer.Length - Read)
        Do While Chunk > 0
            Read = Read + Chunk
            ' If the end of the buffer is reached, check to see if there is
            ' any more data.
            If Read = Buffer.Length Then
                Dim NextByte As Integer = Me.BaseStream.ReadByte()
                ' If the end of the stream is reached, we are done.
                If NextByte = -1 Then
                    Return Buffer
                End If
                ' Nope.  Resize the buffer, put in the byte we have just
                ' read, and continue.
                Dim NewBuffer(Buffer.Length * 2 - 1) As Byte
                System.Buffer.BlockCopy( _
                    Buffer, _
                    0, _
                    NewBuffer, _
                    0, _
                    Buffer.Length _
                )
                'Array.Copy(Buffer, NewBuffer, Buffer.Length)
                NewBuffer(Read) = CByte(NextByte)
                Buffer = NewBuffer
                Read = Read + 1
            End If
            Chunk = Me.BaseStream.Read(Buffer, Read, Buffer.Length - Read)
        Loop
        ' The buffer is now too big.  Shrink it.
        Dim ReturnBuffer(Read - 1) As Byte
        System.Buffer.BlockCopy(Buffer, 0, ReturnBuffer, 0, Read)
        'Array.Copy(Buffer, ReturnBuffer, Read)
        Return ReturnBuffer
    End Function
End Class