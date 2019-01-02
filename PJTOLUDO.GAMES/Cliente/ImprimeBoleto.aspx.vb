Imports BoletoNet
Imports System
Public Class ImprimeBoleto

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MontaBoleto()
    End Sub
    Private Sub MontaBoleto()

        Dim NomeC As String = Protege.Descriptografar(Request.Cookies("pDados")("Nome")) & " " & Protege.Descriptografar(Request.Cookies("pDados")("Sobrenome"))
        Dim CPFC As String = Protege.Descriptografar(Request.Cookies("pDados")("CPF"))

        'Informa os dados do cedente
        Dim vencimento As DateTime = DateTime.Now.AddDays(1)

        Dim item1 As New Instrucao_Itau(9, 5)
        Dim item2 As New Instrucao_Itau(81, 10)
        Dim c As New Cedente("10.823.650/0001-90", "PJLudo", "4406", "22324")
        'Na carteira 198 o código do Cedente é a conta bancária
        c.Codigo = 13000

        Dim b As New Boleto(vencimento, CDbl(Session("Total")), "176", "00000001", c, New EspecieDocumento(341, 1))
        b.NumeroDocumento = Format(Session("IDNPDV"), "00000000")

        b.Sacado = New Sacado(CPFC, NomeC)

        item2.Descricao += " " & item2.QuantidadeDias.ToString() & " dias corridos do vencimento."
        b.Instrucoes.Add(item1)
        b.Instrucoes.Add(item2)

        ' juros/descontos

        If b.ValorDesconto = 0 Then
            Dim item3 As New Instrucao_Itau(999, 1)
            item3.Descricao += ("1,00 por dia de antecipação.")
            b.Instrucoes.Add(item3)
        End If


        Dim bb As New BoletoBancario()
        bb.CodigoBanco = 341 '-> Referente ao código doItau
        bb.Boleto = b
        bb.MostrarCodigoCarteira = True
        bb.Boleto.Valida()
        bb.MostrarComprovanteEntrega = False
        panelBoleto.Controls.Add(bb)

    End Sub
End Class