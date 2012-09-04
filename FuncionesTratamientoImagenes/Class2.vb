Imports WindowsApplication1.Class1
Imports System.IO



Public Class Class2
    Public Class trataformu
        Dim objeto As New tratamiento
        Sub cursor()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        End Sub
        Sub salir()
            Dim respuesta As DialogResult = MessageBox.Show("¿Desea guardar la imagen antes de salir?", "Apolo v 0.9", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Select Case respuesta
                Case Windows.Forms.DialogResult.Yes
                    objeto.guardarcomo(bmpGuardar)
                    End
                Case Windows.Forms.DialogResult.No
                    End
                Case Windows.Forms.DialogResult.Cancel
                    Exit Sub

            End Select
        End Sub
        Sub GuardarSalir(ByVal bmp As Bitmap)
            Dim folder As New DirectoryInfo("ImagenesRecientes\")
            Dim contador As Integer
            For Each file As FileInfo In folder.GetFiles()
                contador = contador + 1
            Next

            Dim auxiliar, auxiliar2, nombre_imagen As String
            Dim nombre_imagen2() As String
            auxiliar = ruta2
            nombre_imagen2 = Split(auxiliar, "\")
            auxiliar2 = UBound(nombre_imagen2)
            nombre_imagen = nombre_imagen2(auxiliar2)
            nombre_imagen2 = Split(nombre_imagen, ".")
            auxiliar2 = ""
            For i = 0 To UBound(nombre_imagen2) - 1
                auxiliar2 = auxiliar2 & nombre_imagen2(i)
            Next
            Dim fic As String = "ImagenesRecientes\" & contador & auxiliar2 & ".jpg"
            bmp.Save(fic, System.Drawing.Imaging.ImageFormat.Jpeg)
        End Sub
        Sub ajustarpantalla(pict As PictureBox, panel As Panel)
            Dim alto, ancho As Integer
            alto = panel.Height
            ancho = panel.Width
            Dim bmp As New Bitmap(pict.Image, ancho, alto)

            pict.Width = ancho
            pict.Height = alto
            pict.Image = bmp
            refrescar(pict, Principal.Panel1) 'Refrescamos Picture y Panel
        End Sub
        Sub refrescar(ByVal pic As PictureBox, ByVal panel2 As Panel)
            Try
                panel2.AutoScrollMinSize = pic.Image.Size
                panel2.AutoScroll = True
            Catch
            End Try
        End Sub

        Sub pintar(ByVal bmp As Bitmap, ByVal modificacion As String)
            Dim objeto As New tratamiento
            Dim objetomas As New tratamiento.mascaras
            Dim objetoform As New trataformu
            If My.Settings.vistapr = True Then
                Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
                Select Case modificacion
                    Case "grises"
                        VistaPrevia.PictureBox1.Image = objeto.grises(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "invertir"
                        VistaPrevia.PictureBox1.Image = objeto.invertir(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "invertirrojo"
                        VistaPrevia.PictureBox1.Image = objeto.invertirrojo(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "invertirverde"
                        VistaPrevia.PictureBox1.Image = objeto.invertirverde(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "invertirazul"
                        VistaPrevia.PictureBox1.Image = objeto.invertirazul(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "sepia"
                        VistaPrevia.PictureBox1.Image = objeto.sepia(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "filtro rojo"
                        VistaPrevia.PictureBox1.Image = objeto.filtrorojo(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "filtro verde"
                        VistaPrevia.PictureBox1.Image = objeto.filtroverde(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "filtro azul"
                        VistaPrevia.PictureBox1.Image = objeto.filtroazul(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "BGR"
                        VistaPrevia.PictureBox1.Image = objeto.RGBtoBGR(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "GRB"
                        VistaPrevia.PictureBox1.Image = objeto.RGBtoGRB(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "RBG"
                        VistaPrevia.PictureBox1.Image = objeto.RGBtoRBG(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "2defecto"
                        VistaPrevia.PictureBox1.Image = objeto.doscolorescanaldefecto(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "2exceso"
                        VistaPrevia.PictureBox1.Image = objeto.doscolorescanalexceso(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "4defecto"
                        VistaPrevia.PictureBox1.Image = objeto.cuatrocolorescanaldefecto(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "4exceso"
                        VistaPrevia.PictureBox1.Image = objeto.cuatrocolorescanalexceso(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "8defecto"
                        VistaPrevia.PictureBox1.Image = objeto.ochocolorescanaldefecto(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "8exceso"
                        VistaPrevia.PictureBox1.Image = objeto.ochocolorescanalexceso(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "16defecto"
                        VistaPrevia.PictureBox1.Image = objeto.dieciseiscolorescanaldefecto(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "16exceso"
                        VistaPrevia.PictureBox1.Image = objeto.dieciseiscolorescanalexceso(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "ruido"
                        VistaPrevia.PictureBox1.Image = objeto.ruido(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "ruidoaleatorio"
                        VistaPrevia.PictureBox1.Image = objeto.ruidoaleatorio(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "pixelarx3"
                        VistaPrevia.PictureBox1.Image = objeto.pixelarX3(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "pixelarx5"
                        VistaPrevia.PictureBox1.Image = objeto.pixelarX5(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "pixelarx7"
                        VistaPrevia.PictureBox1.Image = objeto.pixelarX7(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "pixelarx3interpolado"
                        VistaPrevia.PictureBox1.Image = objeto.pixelarX3interpolado(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "oleo"
                        VistaPrevia.PictureBox1.Image = objeto.Oleo(bmpaux) 'Lazamos vista previa y asignamos imagen
                    
                    Case "LOW9"
                        VistaPrevia.PictureBox1.Image = objetomas.LowPasscoef9(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "LOW10"
                        VistaPrevia.PictureBox1.Image = objetomas.LowPasscoef10(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "LOW12"
                        VistaPrevia.PictureBox1.Image = objetomas.LowPasscoef12(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "LOW9g"
                        VistaPrevia.PictureBox1.Image = objetomas.LowPasscoef9(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "LOW10g"
                        VistaPrevia.PictureBox1.Image = objetomas.LowPasscoef10(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "LOW12g"
                        VistaPrevia.PictureBox1.Image = objetomas.LowPasscoef12(bmpaux, True) 'Lazamos vista previa y asignamos imagen

                    Case "HIG1a"
                        VistaPrevia.PictureBox1.Image = objetomas.HighPasscoef1a(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "HIG1b"
                        VistaPrevia.PictureBox1.Image = objetomas.HighPasscoef1b(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "HIG16"
                        VistaPrevia.PictureBox1.Image = objetomas.HighPasscoef16(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "HIG1ag"
                        VistaPrevia.PictureBox1.Image = objetomas.HighPasscoef1a(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "HIG1bg"
                        VistaPrevia.PictureBox1.Image = objetomas.HighPasscoef1b(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "HIG16g"
                        VistaPrevia.PictureBox1.Image = objetomas.HighPasscoef16(bmpaux, True) 'Lazamos vista previa y asignamos imagen

                    Case "REST1"
                        VistaPrevia.PictureBox1.Image = objetomas.RealceBordesResta1(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "REST2"
                        VistaPrevia.PictureBox1.Image = objetomas.RealceBordesResta2(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "REST3"
                        VistaPrevia.PictureBox1.Image = objetomas.RealceBordesResta3(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "REST1G"
                        VistaPrevia.PictureBox1.Image = objetomas.RealceBordesResta1(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "REST2G"
                        VistaPrevia.PictureBox1.Image = objetomas.RealceBordesResta2(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "REST3G"
                        VistaPrevia.PictureBox1.Image = objetomas.RealceBordesResta3(bmpaux, True) 'Lazamos vista previa y asignamos imagen

                    Case "LAP1"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplaciano1(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "LAP2"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplaciano2(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "LAP3"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplaciano3(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "LAP4"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplaciano4(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "LAP1g"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplaciano1(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "LAP2g"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplaciano2(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "LAP3g"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplaciano3(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "LAP4g"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplaciano4(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "LAPD"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplacianoDiagon(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "LAPV"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplacianoVertic(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "LAPH"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplacianoHoriz(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "LAPDg"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplacianoDiagon(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "LAPVg"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplacianoVertic(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "LAPHg"
                        VistaPrevia.PictureBox1.Image = objetomas.BordeLaplacianoHoriz(bmpaux, True) 'Lazamos vista previa y asignamos imagen

                    Case "Geste"
                        VistaPrevia.PictureBox1.Image = objetomas.ContornoGradienteEste(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "Gsud"
                        VistaPrevia.PictureBox1.Image = objetomas.ContornoGradienteSudeste(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "Gsur"
                        VistaPrevia.PictureBox1.Image = objetomas.ContornoGradienteSur(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "Goeste"
                        VistaPrevia.PictureBox1.Image = objetomas.ContornoGradienteOeste(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "Gnore"
                        VistaPrevia.PictureBox1.Image = objetomas.ContornoGradienteNoroeste(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "Gnor"
                        VistaPrevia.PictureBox1.Image = objetomas.ContornoGradienteNorte(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "Gesteg"
                        VistaPrevia.PictureBox1.Image = objetomas.ContornoGradienteEste(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "Gsudg"
                        VistaPrevia.PictureBox1.Image = objetomas.ContornoGradienteSudeste(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "Gsurg"
                        VistaPrevia.PictureBox1.Image = objetomas.ContornoGradienteSur(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "Goesteg"
                        VistaPrevia.PictureBox1.Image = objetomas.ContornoGradienteOeste(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "Gnoreg"
                        VistaPrevia.PictureBox1.Image = objetomas.ContornoGradienteNoroeste(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "Gnorg"
                        VistaPrevia.PictureBox1.Image = objetomas.ContornoGradienteNorte(bmpaux, True) 'Lazamos vista previa y asignamos imagen



                    Case "Eeste"
                        VistaPrevia.PictureBox1.Image = objetomas.RelieveBordeEste(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "Esud"
                        VistaPrevia.PictureBox1.Image = objetomas.RelieveBordeSudeste(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "Esur"
                        VistaPrevia.PictureBox1.Image = objetomas.RelieveBordeSur(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "Eoeste"
                        VistaPrevia.PictureBox1.Image = objetomas.RelieveBordeOeste(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "Enore"
                        VistaPrevia.PictureBox1.Image = objetomas.RelieveBordeNoreste(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "Enor"
                        VistaPrevia.PictureBox1.Image = objetomas.RelieveBordeNorte(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "Eesteg"
                        VistaPrevia.PictureBox1.Image = objetomas.RelieveBordeEste(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "Esudg"
                        VistaPrevia.PictureBox1.Image = objetomas.RelieveBordeSudeste(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "Esurg"
                        VistaPrevia.PictureBox1.Image = objetomas.RelieveBordeSur(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "Eoesteg"
                        VistaPrevia.PictureBox1.Image = objetomas.RelieveBordeOeste(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "Enoreg"
                        VistaPrevia.PictureBox1.Image = objetomas.RelieveBordeNoreste(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "Enorg"
                        VistaPrevia.PictureBox1.Image = objetomas.RelieveBordeNorte(bmpaux, True) 'Lazamos vista previa y asignamos imagen

                    Case "SobelH"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelHorizontal(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "SobelV"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelVertical(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD1"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelDiagonal1a(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD2"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelDiagonal2a(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "SobelHg"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelHorizontal(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "SobelVg"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelVertical(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD1g"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelDiagonal1a(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD2g"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelDiagonal2a(bmpaux, True) 'Lazamos vista previa y asignamos imagen


                    Case "SobelH2"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelHorizontal2(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "SobelV2"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelVertical2(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD12"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelDiagonal1b(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD22"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelDiagonal2b(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "SobelHg2"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelHorizontal2(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "SobelVg2"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelVertical2(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD1g2"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelDiagonal1b(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD2g2"
                        VistaPrevia.PictureBox1.Image = objetomas.SobelDiagonal2b(bmpaux, True) 'Lazamos vista previa y asignamos imagen

                    Case "PHH"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittHoriz(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "PHV"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittVert(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "PHD1"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittDiagonal1(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "PHD2"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittDiagonal2(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "PHHG"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittHoriz(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "PHVG"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittVert(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "PHD1G"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittDiagonal1(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "PHD20G"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittDiagonal2(bmpaux, True) 'Lazamos vista previa y asignamos imagen

                    Case "PHH2"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittHoriz2(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "PHV2"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittVert2(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "PHD12"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittDiagonal1b(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "PHD22"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittDiagonal2b(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "PHH2g"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittHoriz2(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "PHV2g"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittVert2(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "PHD12g"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittDiagonal1b(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "PHD22g"
                        VistaPrevia.PictureBox1.Image = objetomas.PrewittDiagonal2b(bmpaux, True) 'Lazamos vista previa y asignamos imagen


                    Case "LH"
                        VistaPrevia.PictureBox1.Image = objetomas.lineasHorizontales(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "LV"
                        VistaPrevia.PictureBox1.Image = objetomas.lineasVerticales(bmpaux) 'Lazamos vista previa y asignamos imagen

                    Case "LHg"
                        VistaPrevia.PictureBox1.Image = objetomas.lineasHorizontales(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "LVg"
                        VistaPrevia.PictureBox1.Image = objetomas.lineasVerticales(bmpaux, True) 'Lazamos vista previa y asignamos imagen

                    Case "Repujado"
                        VistaPrevia.PictureBox1.Image = objetomas.repujado(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "Repujadog"
                        VistaPrevia.PictureBox1.Image = objetomas.repujado(bmpaux, True) 'Lazamos vista previa y asignamos imagen

                    Case "KIR0"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch0º(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "KIR45"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch45º(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "KIR90"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch90º(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "KIR135"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch135º(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "KIR180"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch180º(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "KIR225"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch225º(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "KIR270"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch270º(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "KIR315"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch315º(bmpaux) 'Lazamos vista previa y asignamos imagen


                    Case "KIR0g"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch0º(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR45g"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch45º(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR90g"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch90º(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR135g"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch135º(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR180g"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch180º(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR225g"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch225º(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR270g"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch270º(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR315g"
                        VistaPrevia.PictureBox1.Image = objetomas.bordesKirsch315º(bmpaux, True) 'Lazamos vista previa y asignamos imagen

                    Case "FRH"
                        VistaPrevia.PictureBox1.Image = objetomas.FreiChenHori(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "FRV"
                        VistaPrevia.PictureBox1.Image = objetomas.FreiChenVert(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "FRHg"
                        VistaPrevia.PictureBox1.Image = objetomas.FreiChenHori(bmpaux, True) 'Lazamos vista previa y asignamos imagen
                    Case "FRHg"
                        VistaPrevia.PictureBox1.Image = objetomas.FreiChenVert(bmpaux, True) 'Lazamos vista previa y asignamos imagen

                    Case "conto"
                        VistaPrevia.PictureBox1.Image = objeto.contornos(bmpaux, 20) 'Lazamos vista previa y asignamos imagen

                    Case "redAncho"
                        VistaPrevia.PictureBox1.Image = objeto.reducirX2(bmpaux, True, False) 'Lazamos vista previa y asignamos imagen
                    Case "redAlto"
                        VistaPrevia.PictureBox1.Image = objeto.reducirX2(bmpaux, False, True) 'Lazamos vista previa y asignamos imagen
                    Case "redAmbos"
                        VistaPrevia.PictureBox1.Image = objeto.reducirX2(bmpaux) 'Lazamos vista previa y asignamos imagen

                    Case "redAnchoI"
                        VistaPrevia.PictureBox1.Image = objeto.reducirX2interpolado(bmpaux, True, False) 'Lazamos vista previa y asignamos imagen
                    Case "redAltoI"
                        VistaPrevia.PictureBox1.Image = objeto.reducirX2interpolado(bmpaux, False, True) 'Lazamos vista previa y asignamos imagen
                    Case "redAmbosI"
                        VistaPrevia.PictureBox1.Image = objeto.reducirX2interpolado(bmpaux) 'Lazamos vista previa y asignamos imagen

                    Case "aumAncho"
                        VistaPrevia.PictureBox1.Image = objeto.aumentarX2(bmpaux, True, False) 'Lazamos vista previa y asignamos imagen
                    Case "aumAlto"
                        VistaPrevia.PictureBox1.Image = objeto.aumentarX2(bmpaux, False, True) 'Lazamos vista previa y asignamos imagen
                    Case "aumAmbos"
                        VistaPrevia.PictureBox1.Image = objeto.aumentarX2(bmpaux) 'Lazamos vista previa y asignamos imagen


                    Case "aumAnchoI"
                        VistaPrevia.PictureBox1.Image = objeto.aumentarX2interpolado(bmpaux, True, False) 'Lazamos vista previa y asignamos imagen
                    Case "aumAltoI"
                        VistaPrevia.PictureBox1.Image = objeto.aumentarX2interpolado(bmpaux, False, True) 'Lazamos vista previa y asignamos imagen
                    Case "aumAmbosI"
                        VistaPrevia.PictureBox1.Image = objeto.aumentarX2interpolado(bmpaux) 'Lazamos vista previa y asignamos imagen


                    Case "etiopia"
                        VistaPrevia.PictureBox1.Image = objeto.etiopia(bmpaux) 'Lazamos vista previa y asignamos imagen
                    Case "etiopiaV"
                        VistaPrevia.PictureBox1.Image = objeto.etiopia(bmpaux, False) 'Lazamos vista previa y asignamos imagen

                End Select
                VistaPrevia.ShowDialog()
            End If
            If aceptar = True Or My.Settings.vistapr = False Then 'Si el usuario acepta
                Cargando.Show()
                Select Case modificacion
                    Case "grises"
                        Principal.PictureBox1.Image = objeto.grises(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "invertir"
                        Principal.PictureBox1.Image = objeto.invertir(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "invertirrojo"
                        Principal.PictureBox1.Image = objeto.invertirrojo(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "invertirverde"
                        Principal.PictureBox1.Image = objeto.invertirverde(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "invertirazul"
                        Principal.PictureBox1.Image = objeto.invertirazul(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "sepia"
                        Principal.PictureBox1.Image = objeto.sepia(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "filtro rojo"
                        Principal.PictureBox1.Image = objeto.filtrorojo(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "filtro verde"
                        Principal.PictureBox1.Image = objeto.filtroverde(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "filtro azul"
                        Principal.PictureBox1.Image = objeto.filtroazul(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "BGR"
                        Principal.PictureBox1.Image = objeto.RGBtoBGR(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "GRB"
                        Principal.PictureBox1.Image = objeto.RGBtoGRB(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "RBG"
                        Principal.PictureBox1.Image = objeto.RGBtoRBG(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "2defecto"
                        Principal.PictureBox1.Image = objeto.doscolorescanaldefecto(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "2exceso"
                        Principal.PictureBox1.Image = objeto.doscolorescanalexceso(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "4defecto"
                        Principal.PictureBox1.Image = objeto.cuatrocolorescanaldefecto(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "4exceso"
                        Principal.PictureBox1.Image = objeto.cuatrocolorescanalexceso(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "8defecto"
                        Principal.PictureBox1.Image = objeto.ochocolorescanaldefecto(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "8exceso"
                        Principal.PictureBox1.Image = objeto.ochocolorescanalexceso(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "16defecto"
                        Principal.PictureBox1.Image = objeto.dieciseiscolorescanaldefecto(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "16exceso"
                        Principal.PictureBox1.Image = objeto.dieciseiscolorescanalexceso(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "ruido"
                        Principal.PictureBox1.Image = objeto.ruido(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "ruidoaleatorio"
                        Principal.PictureBox1.Image = objeto.ruidoaleatorio(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "pixelarx3"
                        Principal.PictureBox1.Image = objeto.pixelarX3(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "pixelarx5"
                        Principal.PictureBox1.Image = objeto.pixelarX5(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "pixelarx7"
                        Principal.PictureBox1.Image = objeto.pixelarX7(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "pixelarx3interpolado"
                        Principal.PictureBox1.Image = objeto.pixelarX3interpolado(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "oleo"
                        Principal.PictureBox1.Image = objeto.Oleo(bmp) 'Lazamos vista previa y asignamos imagen


                    Case "LOW9"
                        Principal.PictureBox1.Image = objetomas.LowPasscoef9(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "LOW10"
                        Principal.PictureBox1.Image = objetomas.LowPasscoef10(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "LOW12"
                        Principal.PictureBox1.Image = objetomas.LowPasscoef12(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "LOW9g"
                        Principal.PictureBox1.Image = objetomas.LowPasscoef9(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "LOW10g"
                        Principal.PictureBox1.Image = objetomas.LowPasscoef10(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "LOW12g"
                        Principal.PictureBox1.Image = objetomas.LowPasscoef12(bmp, True) 'Lazamos vista previa y asignamos imagen

                    Case "HIG1a"
                        Principal.PictureBox1.Image = objetomas.HighPasscoef1a(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "HIG1b"
                        Principal.PictureBox1.Image = objetomas.HighPasscoef1b(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "HIG16"
                        Principal.PictureBox1.Image = objetomas.HighPasscoef16(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "HIG1ag"
                        Principal.PictureBox1.Image = objetomas.HighPasscoef1a(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "HIG1bg"
                        Principal.PictureBox1.Image = objetomas.HighPasscoef1b(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "HIG16g"
                        Principal.PictureBox1.Image = objetomas.HighPasscoef16(bmp, True) 'Lazamos vista previa y asignamos imagen

                    Case "REST1"
                        Principal.PictureBox1.Image = objetomas.RealceBordesResta1(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "REST2"
                        Principal.PictureBox1.Image = objetomas.RealceBordesResta2(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "REST3"
                        Principal.PictureBox1.Image = objetomas.RealceBordesResta3(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "REST1G"
                        Principal.PictureBox1.Image = objetomas.RealceBordesResta1(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "REST2G"
                        Principal.PictureBox1.Image = objetomas.RealceBordesResta2(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "REST3G"
                        Principal.PictureBox1.Image = objetomas.RealceBordesResta3(bmp, True) 'Lazamos vista previa y asignamos imagen

                    Case "LAP1"
                        Principal.PictureBox1.Image = objetomas.BordeLaplaciano1(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "LAP2"
                        Principal.PictureBox1.Image = objetomas.BordeLaplaciano2(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "LAP3"
                        Principal.PictureBox1.Image = objetomas.BordeLaplaciano3(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "LAP4"
                        Principal.PictureBox1.Image = objetomas.BordeLaplaciano4(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "LAP1g"
                        Principal.PictureBox1.Image = objetomas.BordeLaplaciano1(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "LAP2g"
                        Principal.PictureBox1.Image = objetomas.BordeLaplaciano2(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "LAP3g"
                        Principal.PictureBox1.Image = objetomas.BordeLaplaciano3(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "LAP4g"
                        Principal.PictureBox1.Image = objetomas.BordeLaplaciano4(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "LAPD"
                        Principal.PictureBox1.Image = objetomas.BordeLaplacianoDiagon(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "LAPV"
                        Principal.PictureBox1.Image = objetomas.BordeLaplacianoVertic(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "LAPH"
                        Principal.PictureBox1.Image = objetomas.BordeLaplacianoHoriz(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "LAPDg"
                        Principal.PictureBox1.Image = objetomas.BordeLaplacianoDiagon(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "LAPVg"
                        Principal.PictureBox1.Image = objetomas.BordeLaplacianoVertic(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "LAPHg"
                        Principal.PictureBox1.Image = objetomas.BordeLaplacianoHoriz(bmp, True) 'Lazamos vista previa y asignamos imagen

                    Case "Geste"
                        Principal.PictureBox1.Image = objetomas.ContornoGradienteEste(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "Gsud"
                        Principal.PictureBox1.Image = objetomas.ContornoGradienteSudeste(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "Gsur"
                        Principal.PictureBox1.Image = objetomas.ContornoGradienteSur(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "Goeste"
                        Principal.PictureBox1.Image = objetomas.ContornoGradienteOeste(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "Gnore"
                        Principal.PictureBox1.Image = objetomas.ContornoGradienteNoroeste(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "Gnor"
                        Principal.PictureBox1.Image = objetomas.ContornoGradienteNorte(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "Gesteg"
                        Principal.PictureBox1.Image = objetomas.ContornoGradienteEste(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "Gsudg"
                        Principal.PictureBox1.Image = objetomas.ContornoGradienteSudeste(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "Gsurg"
                        Principal.PictureBox1.Image = objetomas.ContornoGradienteSur(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "Goesteg"
                        Principal.PictureBox1.Image = objetomas.ContornoGradienteOeste(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "Gnoreg"
                        Principal.PictureBox1.Image = objetomas.ContornoGradienteNoroeste(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "Gnorg"
                        Principal.PictureBox1.Image = objetomas.ContornoGradienteNorte(bmp, True) 'Lazamos vista previa y asignamos imagen

                    Case "Eeste"
                        Principal.PictureBox1.Image = objetomas.RelieveBordeEste(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "Esud"
                        Principal.PictureBox1.Image = objetomas.RelieveBordeSudeste(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "Esur"
                        Principal.PictureBox1.Image = objetomas.RelieveBordeSur(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "Eoeste"
                        Principal.PictureBox1.Image = objetomas.RelieveBordeOeste(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "Enore"
                        Principal.PictureBox1.Image = objetomas.RelieveBordeNoreste(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "Enor"
                        Principal.PictureBox1.Image = objetomas.RelieveBordeNorte(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "Eesteg"
                        Principal.PictureBox1.Image = objetomas.RelieveBordeEste(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "Esudg"
                        Principal.PictureBox1.Image = objetomas.RelieveBordeSudeste(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "Esurg"
                        Principal.PictureBox1.Image = objetomas.RelieveBordeSur(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "Eoesteg"
                        Principal.PictureBox1.Image = objetomas.RelieveBordeOeste(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "Enoreg"
                        Principal.PictureBox1.Image = objetomas.RelieveBordeNoreste(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "Enorg"
                        Principal.PictureBox1.Image = objetomas.RelieveBordeNorte(bmp, True) 'Lazamos vista previa y asignamos imagen

                    Case "SobelH"
                        Principal.PictureBox1.Image = objetomas.SobelHorizontal(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "SobelV"
                        Principal.PictureBox1.Image = objetomas.SobelVertical(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD1"
                        Principal.PictureBox1.Image = objetomas.SobelDiagonal1a(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD2"
                        Principal.PictureBox1.Image = objetomas.SobelDiagonal2a(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "SobelHg"
                        Principal.PictureBox1.Image = objetomas.SobelHorizontal(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "SobelVg"
                        Principal.PictureBox1.Image = objetomas.SobelVertical(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD1g"
                        Principal.PictureBox1.Image = objetomas.SobelDiagonal1a(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD2g"
                        Principal.PictureBox1.Image = objetomas.SobelDiagonal2a(bmp, True) 'Lazamos vista previa y asignamos imagen

                    Case "SobelH2"
                        Principal.PictureBox1.Image = objetomas.SobelHorizontal2(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "SobelV2"
                        Principal.PictureBox1.Image = objetomas.SobelVertical2(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD12"
                        Principal.PictureBox1.Image = objetomas.SobelDiagonal1b(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD22"
                        Principal.PictureBox1.Image = objetomas.SobelDiagonal2b(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "SobelHg2"
                        Principal.PictureBox1.Image = objetomas.SobelHorizontal2(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "SobelVg2"
                        Principal.PictureBox1.Image = objetomas.SobelVertical2(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD1g2"
                        Principal.PictureBox1.Image = objetomas.SobelDiagonal1b(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "SobelD2g2"
                        Principal.PictureBox1.Image = objetomas.SobelDiagonal2b(bmp, True) 'Lazamos vista previa y asignamos imagen

                    Case "PHH"
                        Principal.PictureBox1.Image = objetomas.PrewittHoriz(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "PHV"
                        Principal.PictureBox1.Image = objetomas.PrewittVert(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "PHD1"
                        Principal.PictureBox1.Image = objetomas.PrewittDiagonal1(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "PHD2"
                        Principal.PictureBox1.Image = objetomas.PrewittDiagonal2(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "PHHG"
                        Principal.PictureBox1.Image = objetomas.PrewittHoriz(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "PHVG"
                        Principal.PictureBox1.Image = objetomas.PrewittVert(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "PHD1G"
                        Principal.PictureBox1.Image = objetomas.PrewittDiagonal1(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "PHD20G"
                        Principal.PictureBox1.Image = objetomas.PrewittDiagonal2(bmp, True) 'Lazamos vista previa y asignamos imagen

                    Case "PHH2"
                        Principal.PictureBox1.Image = objetomas.PrewittHoriz2(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "PHV2"
                        Principal.PictureBox1.Image = objetomas.PrewittVert2(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "PHD12"
                        Principal.PictureBox1.Image = objetomas.PrewittDiagonal1b(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "PHD22"
                        Principal.PictureBox1.Image = objetomas.PrewittDiagonal2b(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "PHH2g"
                        Principal.PictureBox1.Image = objetomas.PrewittHoriz2(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "PHV2g"
                        Principal.PictureBox1.Image = objetomas.PrewittVert2(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "PHD12g"
                        Principal.PictureBox1.Image = objetomas.PrewittDiagonal1b(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "PHD22g"
                        Principal.PictureBox1.Image = objetomas.PrewittDiagonal2b(bmp, True) 'Lazamos vista previa y asignamos imagen



                    Case "LH"
                        Principal.PictureBox1.Image = objetomas.lineasHorizontales(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "LV"
                        Principal.PictureBox1.Image = objetomas.lineasVerticales(bmp) 'Lazamos vista previa y asignamos imagen

                    Case "LHg"
                        Principal.PictureBox1.Image = objetomas.lineasHorizontales(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "LVg"
                        Principal.PictureBox1.Image = objetomas.lineasVerticales(bmp, True) 'Lazamos vista previa y asignamos imagen

                    Case "Repujado"
                        Principal.PictureBox1.Image = objetomas.repujado(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "Repujadog"
                        Principal.PictureBox1.Image = objetomas.repujado(bmp, True) 'Lazamos vista previa y asignamos imagen

                    Case "KIR0"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch0º(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "KIR45"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch45º(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "KIR90"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch90º(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "KIR135"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch135º(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "KIR180"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch180º(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "KIR225"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch225º(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "KIR270"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch270º(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "KIR315"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch315º(bmp) 'Lazamos vista previa y asignamos imagen


                    Case "KIR0g"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch0º(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR45g"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch45º(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR90g"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch90º(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR135g"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch135º(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR180g"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch180º(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR225g"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch225º(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR270g"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch270º(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "KIR315g"
                        Principal.PictureBox1.Image = objetomas.bordesKirsch315º(bmp, True) 'Lazamos vista previa y asignamos imagen


                    Case "FRH"
                        Principal.PictureBox1.Image = objetomas.FreiChenHori(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "FRV"
                        Principal.PictureBox1.Image = objetomas.FreiChenVert(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "FRHg"
                        Principal.PictureBox1.Image = objetomas.FreiChenHori(bmp, True) 'Lazamos vista previa y asignamos imagen
                    Case "FRHg"
                        Principal.PictureBox1.Image = objetomas.FreiChenVert(bmp, True) 'Lazamos vista previa y asignamos imagen

                    Case "conto"
                        Principal.PictureBox1.Image = objeto.contornos(bmp, 20) 'Lazamos vista previa y asignamos imagen


                    Case "redAncho"
                        Principal.PictureBox1.Image = objeto.reducirX2(bmp, True, False) 'Lazamos vista previa y asignamos imagen
                    Case "redAlto"
                        Principal.PictureBox1.Image = objeto.reducirX2(bmp, False, True) 'Lazamos vista previa y asignamos imagen
                    Case "redAmbos"
                        Principal.PictureBox1.Image = objeto.reducirX2(bmp) 'Lazamos vista previa y asignamos imagen

                    Case "redAnchoI"
                        Principal.PictureBox1.Image = objeto.reducirX2interpolado(bmp, True, False) 'Lazamos vista previa y asignamos imagen
                    Case "redAltoI"
                        Principal.PictureBox1.Image = objeto.reducirX2interpolado(bmp, False, True) 'Lazamos vista previa y asignamos imagen
                    Case "redAmbosI"
                        Principal.PictureBox1.Image = objeto.reducirX2interpolado(bmp) 'Lazamos vista previa y asignamos imagen


                    Case "aumAncho"
                        Principal.PictureBox1.Image = objeto.aumentarX2(bmp, True, False) 'Lazamos vista previa y asignamos imagen
                    Case "aumAlto"
                        Principal.PictureBox1.Image = objeto.aumentarX2(bmp, False, True) 'Lazamos vista previa y asignamos imagen
                    Case "aumAmbos"
                        Principal.PictureBox1.Image = objeto.aumentarX2(bmp) 'Lazamos vista previa y asignamos imagen


                    Case "aumAnchoI"
                        Principal.PictureBox1.Image = objeto.aumentarX2interpolado(bmp, True, False) 'Lazamos vista previa y asignamos imagen
                    Case "aumAltoI"
                        Principal.PictureBox1.Image = objeto.aumentarX2interpolado(bmp, False, True) 'Lazamos vista previa y asignamos imagen
                    Case "aumAmbosI"
                        Principal.PictureBox1.Image = objeto.aumentarX2interpolado(bmp) 'Lazamos vista previa y asignamos imagen

                    Case "etiopia"
                        Principal.PictureBox1.Image = objeto.etiopia(bmp) 'Lazamos vista previa y asignamos imagen
                    Case "etiopiaV"
                        Principal.PictureBox1.Image = objeto.etiopia(bmp, False) 'Lazamos vista previa y asignamos imagen

                End Select
                Cargando.Close()
            End If

            aceptar = False

        End Sub


        Function conexionInternet()
            If My.Computer.Network.IsAvailable = True Then
                Return True
            Else
                Return False
            End If
        End Function

        Sub actualizacion()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Try
                Dim archivo As String = "lastversion.txt"
                Kill(archivo)
            Catch
            End Try
            Try
                My.Computer.Network.DownloadFile("https://docs.google.com/document/d/1uvRsAJlRkPJYf2AKwdNDLYgy64h1b6Wjn7M8phcYx8Y/export?format=txt", "lastversion.txt")
                Dim objReader As New StreamReader("lastversion.txt")
                Dim sLine As String = ""
                Dim arrText As New ArrayList()
                Dim ultimaversion As String
                Do
                    sLine = objReader.ReadLine()
                    If Not sLine Is Nothing Then
                        arrText.Add(sLine)
                    End If
                Loop Until sLine Is Nothing
                objReader.Close()
                For Each sLine In arrText
                    ultimaversion = sLine
                Next


                Dim objReader2 As New StreamReader("actualversion.txt")
                Dim sLine2 As String = ""
                Dim arrText2 As New ArrayList()
                Dim versionactu As String

                Do
                    sLine2 = objReader2.ReadLine()
                    If Not sLine2 Is Nothing Then
                        arrText2.Add(sLine2)
                    End If
                Loop Until sLine2 Is Nothing
                objReader2.Close()
                For Each sLine2 In arrText2
                    versionactu = sLine2
                Next

                If versionactu = ultimaversion Then
                    MessageBox.Show("No actualizaciones disponibles.", "Actualizaciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim mensaje As DialogResult
                    mensaje = MessageBox.Show("Hay una actualización disponible. ¿Desea descargarla?", "Actualizaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If mensaje = DialogResult.Yes Then
                        Dim urlabrir As New System.Diagnostics.Process
                        urlabrir.StartInfo.FileName = "http://algoimagen.blogspot.com.es/t"
                        urlabrir.Start()
                    End If
                End If
                Dim archivo As String = "lastversion.txt"
                Kill(archivo)
            Catch
                MessageBox.Show("No se han podido comprobar automáticamente las actualizaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try

        End Sub

        Sub actualizacioninicio()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Try
                Dim archivo As String = "lastversion.txt"
                Kill(archivo)
            Catch
            End Try
            Try

                My.Computer.Network.DownloadFile("https://docs.google.com/document/d/1uvRsAJlRkPJYf2AKwdNDLYgy64h1b6Wjn7M8phcYx8Y/export?format=txt", "lastversion.txt")
                Dim objReader As New StreamReader("lastversion.txt")
                Dim sLine As String = ""
                Dim arrText As New ArrayList()
                Dim ultimaversion As String
                Do
                    sLine = objReader.ReadLine()
                    If Not sLine Is Nothing Then
                        arrText.Add(sLine)
                    End If
                Loop Until sLine Is Nothing
                objReader.Close()
                For Each sLine In arrText
                    ultimaversion = sLine
                Next


                Dim objReader2 As New StreamReader("actualversion.txt")
                Dim sLine2 As String = ""
                Dim arrText2 As New ArrayList()
                Dim versionactu As String

                Do
                    sLine2 = objReader2.ReadLine()
                    If Not sLine2 Is Nothing Then
                        arrText2.Add(sLine2)
                    End If
                Loop Until sLine2 Is Nothing
                objReader2.Close()
                For Each sLine2 In arrText2
                    versionactu = sLine2
                Next

                If versionactu = ultimaversion Then

                Else
                    Dim mensaje As DialogResult
                    mensaje = MessageBox.Show("Hay una actualización disponible. ¿Desea descargarla?", "Actualizaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If mensaje = DialogResult.Yes Then
                        Dim urlabrir As New System.Diagnostics.Process
                        urlabrir.StartInfo.FileName = "http://algoimagen.blogspot.com.es/t"
                        urlabrir.Start()
                    End If
                End If
                Dim archivo As String = "lastversion.txt"
                Kill(archivo)
            Catch
                MessageBox.Show("No se han podido comprobar automáticamente las actualizaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try

        End Sub


        Function PasarExcel(ByVal ElGrid As DataGridView) As Boolean  'Función disponible en http://programaciontotal.blogspot.com.es/2009/06/vbnet-exportar-datagridview-excel.html

            'Creamos las variables
            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

            Try
                'Añadimos el Libro al programa, y la hoja al libro
                exLibro = exApp.Workbooks.Add
                exHoja = exLibro.Worksheets.Add()

                ' ¿Cuantas columnas y cuantas filas?
                Dim NCol As Integer = ElGrid.ColumnCount
                Dim NRow As Integer = ElGrid.RowCount

                'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
                For i As Integer = 1 To NCol
                    exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString
                    'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
                Next

                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                    Next
                Next
                'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
                exHoja.Rows.Item(1).Font.Bold = 1
                exHoja.Rows.Item(1).HorizontalAlignment = 3
                exHoja.Columns.AutoFit()


                'Aplicación visible
                exApp.Application.Visible = True

                exHoja = Nothing
                exLibro = Nothing
                exApp = Nothing

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                Return False
            End Try

            Return True

        End Function

        Function RecortarImagen(ByRef bmp As Bitmap, ByVal rectanguloR As Rectangle)
            Dim bmprecor As Bitmap
            If rectanguloR.X <> 0 And rectanguloRec.Y <> 0 Then
                bmprecor = bmp.Clone(rectanguloR, bmp.PixelFormat)
            Else
                bmprecor = bmp
            End If
            Return bmprecor
        End Function

        
    End Class
    

    Public Class RectanguloRecortar

        Private m_point1 As New Point(0, 0)
        Private m_point2 As New Point(0, 0)
        Private color_trazo As Color = color.Red
        Private ancho_trazo As Integer = 3



        Public Property Point1() As Point
            Get
                Return m_point1
            End Get
            Set(ByVal value As Point)
                m_point1 = value
            End Set
        End Property

        Public Property Point2() As Point
            Get
                Return m_point2
            End Get
            Set(ByVal value As Point)
                m_point2 = value
            End Set
        End Property
        Public Property color() As Color
            Get
                Return color_trazo
            End Get
            Set(ByVal value As Color)
                color_trazo = value
            End Set
        End Property

        Public Property ancho() As Integer
            Get
                Return ancho_trazo
            End Get
            Set(ByVal value As Integer)
                ancho_trazo = value
            End Set
        End Property


        Public Sub Draw(ByVal grfx As Graphics)

            If (grfx Is Nothing) Then _
                Throw New ArgumentNullException("grfx")

            ' Dibujamos la línea.
            '
            Dim ancho, alto As Integer
            ancho = m_point2.X - m_point1.X
            alto = m_point2.Y - m_point1.Y


            Dim lapiz As New Pen(color_trazo, ancho_trazo)


            rectanguloRec = New Rectangle(m_point1, New Size(ancho, alto))
            If ancho < 0 And alto < 0 Then
                rectanguloRec = New Rectangle(m_point2.X, m_point2.Y, Math.Abs(ancho), Math.Abs(alto))
                grfx.DrawRectangle(lapiz, m_point2.X, m_point2.Y, Math.Abs(ancho), Math.Abs(alto))
            End If
            If ancho < 0 And alto > 0 Then
                rectanguloRec = New Rectangle(m_point2.X, m_point1.Y, Math.Abs(ancho), Math.Abs(alto))
                grfx.DrawRectangle(lapiz, m_point2.X, m_point1.Y, Math.Abs(ancho), Math.Abs(alto))
            End If
            If ancho > 0 And alto < 0 Then
                grfx.DrawRectangle(lapiz, m_point1.X, m_point2.Y, Math.Abs(ancho), Math.Abs(alto))
                rectanguloRec = New Rectangle(m_point1.X, m_point2.Y, Math.Abs(ancho), Math.Abs(alto))
            End If
            If ancho > 0 And alto > 0 Then
                grfx.DrawRectangle(lapiz, m_point1.X, m_point1.Y, Math.Abs(ancho), Math.Abs(alto))
                rectanguloRec = New Rectangle(m_point1.X, m_point1.Y, Math.Abs(ancho), Math.Abs(alto))
            End If
            grfx.DrawRectangle(lapiz, New Rectangle(m_point1, New Size(ancho, alto)))

        End Sub
    End Class

    Public Class Lapiz

        Private m_point1 As New Point(0, 0)


        Public Property Point1() As Point
            Get
                Return m_point1
            End Get
            Set(ByVal value As Point)
                m_point1 = value
            End Set
        End Property



        Public Sub Draw(ByVal grfx As Graphics)

            If (grfx Is Nothing) Then _
                Throw New ArgumentNullException("grfx")

            ' Dibujamos la línea.
            '            

            grfx.DrawEllipse(Pens.Black, New Rectangle(m_point1, New Size(2, 2)))
            grfx.FillEllipse(Brushes.Black, New Rectangle(m_point1, New Size(2, 2)))

        End Sub

    End Class



    Public Class Linea

        Private m_point1 As New Point(0, 0)
        Private m_point2 As New Point(0, 0)
        Private color_trazo As Color = color.Black
        Private ancho_trazo As Integer = 1
        Private formato_trazo As String = "normal"

        Public Property formatoLinea() As String
            Get
                Return formato_trazo
            End Get
            Set(ByVal value As String)
                formato_trazo = value
            End Set
        End Property

        Public Property Point1() As Point
            Get
                Return m_point1
            End Get
            Set(ByVal value As Point)
                m_point1 = value
            End Set
        End Property

        Public Property Point2() As Point
            Get
                Return m_point2
            End Get
            Set(ByVal value As Point)
                m_point2 = value
            End Set
        End Property

        Public Property color() As Color
            Get
                Return color_trazo
            End Get
            Set(ByVal value As Color)
                color_trazo = value
            End Set
        End Property

        Public Property ancho() As Integer
            Get
                Return ancho_trazo
            End Get
            Set(ByVal value As Integer)
                ancho_trazo = value
            End Set
        End Property

        Public Sub Draw(ByVal grfx As Graphics)

            If (grfx Is Nothing) Then _
                Throw New ArgumentNullException("grfx")

            ' Dibujamos la línea.
            '
            Dim dashValues As Single()
            Select Case formato_trazo
                Case "normal"
                    dashValues = {9999, 1, 1, 1}
                Case "disc1"
                    dashValues = {5, 2, 15, 4}
                Case "disc2"
                    dashValues = {1, 2, 1, 2}
                Case "disc3"
                    dashValues = {5, 1, 5, 1}
                Case "disc4"
                    dashValues = {10, 1, 1, 1}
                Case "disc5"
                    dashValues = {2, 3, 15, 9}

                Case Else
                    dashValues = {9999, 1, 1, 1}
            End Select

            Dim lapiz As New Pen(color_trazo, ancho_trazo)
            lapiz.DashPattern = dashValues
            grfx.DrawLine(lapiz, m_point1, m_point2)

        End Sub

    End Class



    Public Class Polilinea
        Private color_trazo As Color = color.Black
        Private ancho_trazo As Integer = 1
        Private formato_trazo As String = "normal"



        Public Property formatoLinea() As String
            Get
                Return formato_trazo
            End Get
            Set(ByVal value As String)
                formato_trazo = value
            End Set
        End Property

        Public Property color() As Color
            Get
                Return color_trazo
            End Get
            Set(ByVal value As Color)
                color_trazo = value
            End Set
        End Property

        Public Property ancho() As Integer
            Get
                Return ancho_trazo
            End Get
            Set(ByVal value As Integer)
                ancho_trazo = value
            End Set
        End Property

        Public Sub Draw(ByVal grfx As Graphics)

            If (grfx Is Nothing) Then _
                Throw New ArgumentNullException("grfx")

            ' Dibujamos la línea.
            '
            Dim dashValues As Single()
            Select Case formato_trazo
                Case "normal"
                    dashValues = {9999, 1, 1, 1}
                Case "disc1"
                    dashValues = {5, 2, 15, 4}
                Case "disc2"
                    dashValues = {1, 2, 1, 2}
                Case "disc3"
                    dashValues = {5, 1, 5, 1}
                Case "disc4"
                    dashValues = {10, 1, 1, 1}
                Case "disc5"
                    dashValues = {2, 3, 15, 9}

                Case Else
                    dashValues = {9999, 1, 1, 1}
            End Select

            Dim lapiz As New Pen(color_trazo, ancho_trazo)
            lapiz.DashPattern = dashValues
            If contadorPoli > 1 Then
                Dim puntospolaux(contadorPoli - 1) As Point
                For i = 0 To contadorPoli - 1
                    puntospolaux(i) = puntosPol(i)
                Next
                grfx.DrawLines(lapiz, puntospolaux)

            End If




        End Sub

    End Class


    Public Class Rectangulo

        Private m_point1 As New Point(0, 0)
        Private m_point2 As New Point(0, 0)
        Private color_trazo As Color = color.Black
        Private ancho_trazo As Integer = 1
        Private formato_trazo As String = "normal"
        Private color_interior As String = "Transparent"

        Public Property formatoLinea() As String
            Get
                Return formato_trazo
            End Get
            Set(ByVal value As String)
                formato_trazo = value
            End Set
        End Property

        Public Property Point1() As Point
            Get
                Return m_point1
            End Get
            Set(ByVal value As Point)
                m_point1 = value
            End Set
        End Property

        Public Property Point2() As Point
            Get
                Return m_point2
            End Get
            Set(ByVal value As Point)
                m_point2 = value
            End Set
        End Property
        Public Property color() As Color
            Get
                Return color_trazo
            End Get
            Set(ByVal value As Color)
                color_trazo = value
            End Set
        End Property

        Public Property ancho() As Integer
            Get
                Return ancho_trazo
            End Get
            Set(ByVal value As Integer)
                ancho_trazo = value
            End Set
        End Property

        Public Property colorInt() As String
            Get
                Return color_interior
            End Get
            Set(ByVal value As String)
                color_interior = value
            End Set
        End Property


        Public Sub Draw(ByVal grfx As Graphics)

            If (grfx Is Nothing) Then _
                Throw New ArgumentNullException("grfx")

            ' Dibujamos la línea.
            '
            Dim ancho, alto As Integer
            ancho = m_point2.X - m_point1.X
            alto = m_point2.Y - m_point1.Y
            Dim dashValues As Single()
            Select Case formato_trazo
                Case "normal"
                    dashValues = {9999, 1, 1, 1}
                Case "disc1"
                    dashValues = {5, 2, 15, 4}
                Case "disc2"
                    dashValues = {1, 2, 1, 2}
                Case "disc3"
                    dashValues = {5, 1, 5, 1}
                Case "disc4"
                    dashValues = {10, 1, 1, 1}
                Case "disc5"
                    dashValues = {2, 3, 15, 9}

                Case Else
                    dashValues = {9999, 1, 1, 1}
            End Select

            Dim lapiz As New Pen(color_trazo, ancho_trazo)
            lapiz.DashPattern = dashValues
            Dim rectangulo As New Rectangle
            rectangulo = New Rectangle(m_point1, New Size(ancho, alto))
            If ancho < 0 And alto < 0 Then
                rectangulo = New Rectangle(m_point2.X, m_point2.Y, Math.Abs(ancho), Math.Abs(alto))
                grfx.DrawRectangle(lapiz, m_point2.X, m_point2.Y, Math.Abs(ancho), Math.Abs(alto))
            End If
            If ancho < 0 And alto > 0 Then
                rectangulo = New Rectangle(m_point2.X, m_point1.Y, Math.Abs(ancho), Math.Abs(alto))
                grfx.DrawRectangle(lapiz, m_point2.X, m_point1.Y, Math.Abs(ancho), Math.Abs(alto))
            End If
            If ancho > 0 And alto < 0 Then
                grfx.DrawRectangle(lapiz, m_point1.X, m_point2.Y, Math.Abs(ancho), Math.Abs(alto))
                rectangulo = New Rectangle(m_point1.X, m_point2.Y, Math.Abs(ancho), Math.Abs(alto))
            End If
            If ancho > 0 And alto > 0 Then
                grfx.DrawRectangle(lapiz, m_point1.X, m_point1.Y, Math.Abs(ancho), Math.Abs(alto))
                rectangulo = New Rectangle(m_point1.X, m_point1.Y, Math.Abs(ancho), Math.Abs(alto))
            End If
            grfx.DrawRectangle(lapiz, New Rectangle(m_point1, New Size(ancho, alto)))







            Select Case color_interior
                Case "AliceBlue"
                    grfx.FillRectangle(Brushes.AliceBlue, rectangulo)
                Case "AntiqueWhite"
                    grfx.FillRectangle(Brushes.AntiqueWhite, rectangulo)
                Case "Aqua"
                    grfx.FillRectangle(Brushes.Aqua, rectangulo)
                Case "Aquamarine"
                    grfx.FillRectangle(Brushes.Aquamarine, rectangulo)
                Case "Azure"
                    grfx.FillRectangle(Brushes.Azure, rectangulo)
                Case "Beige"
                    grfx.FillRectangle(Brushes.Beige, rectangulo)
                Case "Bisque"
                    grfx.FillRectangle(Brushes.Bisque, rectangulo)
                Case "Black"
                    grfx.FillRectangle(Brushes.Black, rectangulo)
                Case "BlanchedAlmond"
                    grfx.FillRectangle(Brushes.BlanchedAlmond, rectangulo)
                Case "Blue"
                    grfx.FillRectangle(Brushes.Blue, rectangulo)
                Case "BlueViolet"
                    grfx.FillRectangle(Brushes.BlueViolet, rectangulo)
                Case "Brown"
                    grfx.FillRectangle(Brushes.Brown, rectangulo)
                Case "BurlyWood"
                    grfx.FillRectangle(Brushes.BurlyWood, rectangulo)
                Case "CadetBlue"
                    grfx.FillRectangle(Brushes.CadetBlue, rectangulo)
                Case "Chartreuse"
                    grfx.FillRectangle(Brushes.Chartreuse, rectangulo)
                Case "Chocolate"
                    grfx.FillRectangle(Brushes.Chocolate, rectangulo)
                Case "Coral"
                    grfx.FillRectangle(Brushes.Coral, rectangulo)
                Case "CornflowerBlue"
                    grfx.FillRectangle(Brushes.CornflowerBlue, rectangulo)
                Case "Cornsilk"
                    grfx.FillRectangle(Brushes.Cornsilk, rectangulo)
                Case "Crimson"
                    grfx.FillRectangle(Brushes.Crimson, rectangulo)
                Case "Cyan"
                    grfx.FillRectangle(Brushes.Cyan, rectangulo)
                Case "DarkCyan"
                    grfx.FillRectangle(Brushes.DarkCyan, rectangulo)
                Case "DarkGoldenrod"
                    grfx.FillRectangle(Brushes.DarkGoldenrod, rectangulo)
                Case "DarkGray"
                    grfx.FillRectangle(Brushes.DarkGray, rectangulo)
                Case "DarkGreen"
                    grfx.FillRectangle(Brushes.DarkGreen, rectangulo)
                Case "DarkKhaki"
                    grfx.FillRectangle(Brushes.DarkKhaki, rectangulo)
                Case "DarkMagenta"
                    grfx.FillRectangle(Brushes.DarkMagenta, rectangulo)
                Case "DarkOliveGreen"
                    grfx.FillRectangle(Brushes.DarkOliveGreen, rectangulo)
                Case "DarkOrange"
                    grfx.FillRectangle(Brushes.DarkOrange, rectangulo)
                Case "DarkOrchid"
                    grfx.FillRectangle(Brushes.DarkOrchid, rectangulo)
                Case "DarkRed"
                    grfx.FillRectangle(Brushes.DarkRed, rectangulo)
                Case "DarkSalmon"
                    grfx.FillRectangle(Brushes.DarkSalmon, rectangulo)
                Case "DarkSeaGreen"
                    grfx.FillRectangle(Brushes.DarkSeaGreen, rectangulo)
                Case "DarkSlateBlue"
                    grfx.FillRectangle(Brushes.DarkSlateBlue, rectangulo)
                Case "DarkSlateGray"
                    grfx.FillRectangle(Brushes.DarkSlateGray, rectangulo)
                Case "DarkTurquoise"
                    grfx.FillRectangle(Brushes.DarkTurquoise, rectangulo)
                Case "DarkViolet"
                    grfx.FillRectangle(Brushes.DarkViolet, rectangulo)
                Case "DeepPink"
                    grfx.FillRectangle(Brushes.DeepPink, rectangulo)
                Case "DeepSkyBlue"
                    grfx.FillRectangle(Brushes.DeepSkyBlue, rectangulo)
                Case "DimGray"
                    grfx.FillRectangle(Brushes.DimGray, rectangulo)
                Case "DodgerBlue"
                    grfx.FillRectangle(Brushes.DodgerBlue, rectangulo)
                Case "Firebrick"
                    grfx.FillRectangle(Brushes.Firebrick, rectangulo)
                Case "FloralWhite"
                    grfx.FillRectangle(Brushes.FloralWhite, rectangulo)
                Case "ForestGreen"
                    grfx.FillRectangle(Brushes.ForestGreen, rectangulo)
                Case "Fuchsia"
                    grfx.FillRectangle(Brushes.Fuchsia, rectangulo)
                Case "Gainsboro"
                    grfx.FillRectangle(Brushes.Gainsboro, rectangulo)
                Case "GhostWhite"
                    grfx.FillRectangle(Brushes.GhostWhite, rectangulo)
                Case "Gold"
                    grfx.FillRectangle(Brushes.Gold, rectangulo)
                Case "Goldenrod"
                    grfx.FillRectangle(Brushes.Goldenrod, rectangulo)
                Case "Gray"
                    grfx.FillRectangle(Brushes.Gray, rectangulo)
                Case "Green"
                    grfx.FillRectangle(Brushes.Green, rectangulo)
                Case "GreenYellow"
                    grfx.FillRectangle(Brushes.GreenYellow, rectangulo)
                Case "Honeydew"
                    grfx.FillRectangle(Brushes.Honeydew, rectangulo)
                Case "HotPink"
                    grfx.FillRectangle(Brushes.HotPink, rectangulo)
                Case "IndianRed"
                    grfx.FillRectangle(Brushes.IndianRed, rectangulo)
                Case "Indigo"
                    grfx.FillRectangle(Brushes.Indigo, rectangulo)
                Case "Ivory"
                    grfx.FillRectangle(Brushes.Ivory, rectangulo)
                Case "Khaki"
                    grfx.FillRectangle(Brushes.Khaki, rectangulo)
                Case "Lavender"
                    grfx.FillRectangle(Brushes.Lavender, rectangulo)
                Case "LavenderBlush"
                    grfx.FillRectangle(Brushes.LavenderBlush, rectangulo)
                Case "LawnGreen"
                    grfx.FillRectangle(Brushes.LawnGreen, rectangulo)
                Case "LemonChiffon"
                    grfx.FillRectangle(Brushes.LemonChiffon, rectangulo)
                Case "LightBlue"
                    grfx.FillRectangle(Brushes.LightBlue, rectangulo)
                Case "LightCoral"
                    grfx.FillRectangle(Brushes.LightCoral, rectangulo)
                Case "LightCyan"
                    grfx.FillRectangle(Brushes.LightCyan, rectangulo)
                Case "LightGoldenrodYellow"
                    grfx.FillRectangle(Brushes.LightGoldenrodYellow, rectangulo)
                Case "LightGray"
                    grfx.FillRectangle(Brushes.LightGray, rectangulo)
                Case "LightGreen"
                    grfx.FillRectangle(Brushes.LightGreen, rectangulo)
                Case "LightPink"
                    grfx.FillRectangle(Brushes.LightPink, rectangulo)
                Case "LightSalmon"
                    grfx.FillRectangle(Brushes.LightSalmon, rectangulo)
                Case "LightSeaGreen"
                    grfx.FillRectangle(Brushes.LightSeaGreen, rectangulo)
                Case "LightSkyBlue"
                    grfx.FillRectangle(Brushes.LightSkyBlue, rectangulo)
                Case "LightSlateGray"
                    grfx.FillRectangle(Brushes.LightSlateGray, rectangulo)
                Case "LightSteelBlue"
                    grfx.FillRectangle(Brushes.LightSteelBlue, rectangulo)
                Case "LightYellow"
                    grfx.FillRectangle(Brushes.LightYellow, rectangulo)
                Case "Lime"
                    grfx.FillRectangle(Brushes.Lime, rectangulo)
                Case "LimeGreen"
                    grfx.FillRectangle(Brushes.LimeGreen, rectangulo)
                Case "Linen"
                    grfx.FillRectangle(Brushes.Linen, rectangulo)
                Case "Magenta"
                    grfx.FillRectangle(Brushes.Magenta, rectangulo)
                Case "Maroon"
                    grfx.FillRectangle(Brushes.Maroon, rectangulo)
                Case "MediumAquamarine"
                    grfx.FillRectangle(Brushes.MediumAquamarine, rectangulo)
                Case "MediumBlue"
                    grfx.FillRectangle(Brushes.MediumBlue, rectangulo)
                Case "MediumOrchid"
                    grfx.FillRectangle(Brushes.MediumOrchid, rectangulo)
                Case "MediumPurple"
                    grfx.FillRectangle(Brushes.MediumPurple, rectangulo)
                Case "MediumPurple"
                    grfx.FillRectangle(Brushes.MediumPurple, rectangulo)
                Case "MediumSeaGreen"
                    grfx.FillRectangle(Brushes.MediumSeaGreen, rectangulo)
                Case "MediumSlateBlue"
                    grfx.FillRectangle(Brushes.MediumSlateBlue, rectangulo)
                Case "MediumSpringGreen"
                    grfx.FillRectangle(Brushes.MediumSpringGreen, rectangulo)
                Case "MediumTurquoise"
                    grfx.FillRectangle(Brushes.MediumTurquoise, rectangulo)
                Case "MediumVioletRed"
                    grfx.FillRectangle(Brushes.MediumVioletRed, rectangulo)
                Case "MidnightBlue"
                    grfx.FillRectangle(Brushes.MidnightBlue, rectangulo)
                Case "MintCream"
                    grfx.FillRectangle(Brushes.MintCream, rectangulo)
                Case "MistyRose"
                    grfx.FillRectangle(Brushes.MistyRose, rectangulo)
                Case "Moccasin"
                    grfx.FillRectangle(Brushes.Moccasin, rectangulo)
                Case "NavajoWhite"
                    grfx.FillRectangle(Brushes.NavajoWhite, rectangulo)
                Case "Navy"
                    grfx.FillRectangle(Brushes.Navy, rectangulo)
                Case "OldLace"
                    grfx.FillRectangle(Brushes.OldLace, rectangulo)
                Case "Olive"
                    grfx.FillRectangle(Brushes.Olive, rectangulo)
                Case "OliveDrab"
                    grfx.FillRectangle(Brushes.OliveDrab, rectangulo)
                Case "Orange"
                    grfx.FillRectangle(Brushes.Orange, rectangulo)
                Case "OrangeRed"
                    grfx.FillRectangle(Brushes.OrangeRed, rectangulo)
                Case "Orchid"
                    grfx.FillRectangle(Brushes.Orchid, rectangulo)
                Case "PaleGoldenrod"
                    grfx.FillRectangle(Brushes.PaleGoldenrod, rectangulo)
                Case "PaleGreen"
                    grfx.FillRectangle(Brushes.PaleGreen, rectangulo)
                Case "PaleTurquoise"
                    grfx.FillRectangle(Brushes.PaleTurquoise, rectangulo)
                Case "PaleVioletRed"
                    grfx.FillRectangle(Brushes.PaleVioletRed, rectangulo)
                Case "PapayaWhip"
                    grfx.FillRectangle(Brushes.PapayaWhip, rectangulo)
                Case "PeachPuff"
                    grfx.FillRectangle(Brushes.PeachPuff, rectangulo)
                Case "Peru"
                    grfx.FillRectangle(Brushes.Peru, rectangulo)
                Case "Pink"
                    grfx.FillRectangle(Brushes.Pink, rectangulo)
                Case "Plum"
                    grfx.FillRectangle(Brushes.Plum, rectangulo)
                Case "PowderBlue"
                    grfx.FillRectangle(Brushes.PowderBlue, rectangulo)
                Case "Purple"
                    grfx.FillRectangle(Brushes.Purple, rectangulo)
                Case "Red"
                    grfx.FillRectangle(Brushes.Red, rectangulo)
                Case "RosyBrown"
                    grfx.FillRectangle(Brushes.RosyBrown, rectangulo)
                Case "RoyalBlue"
                    grfx.FillRectangle(Brushes.RoyalBlue, rectangulo)
                Case "SaddleBrown"
                    grfx.FillRectangle(Brushes.SaddleBrown, rectangulo)
                Case "Salmon"
                    grfx.FillRectangle(Brushes.Salmon, rectangulo)
                Case "SandyBrown"
                    grfx.FillRectangle(Brushes.SandyBrown, rectangulo)
                Case "SeaGreen"
                    grfx.FillRectangle(Brushes.SeaGreen, rectangulo)
                Case "SeaShell"
                    grfx.FillRectangle(Brushes.SeaShell, rectangulo)
                Case "Sienna"
                    grfx.FillRectangle(Brushes.Sienna, rectangulo)
                Case "Silver"
                    grfx.FillRectangle(Brushes.Silver, rectangulo)
                Case "SkyBlue"
                    grfx.FillRectangle(Brushes.SkyBlue, rectangulo)
                Case "SlateBlue"
                    grfx.FillRectangle(Brushes.SlateBlue, rectangulo)
                Case "SlateGray"
                    grfx.FillRectangle(Brushes.SlateGray, rectangulo)
                Case "Snow"
                    grfx.FillRectangle(Brushes.Snow, rectangulo)
                Case "SpringGreen"
                    grfx.FillRectangle(Brushes.SpringGreen, rectangulo)
                Case "SteelBlue"
                    grfx.FillRectangle(Brushes.SteelBlue, rectangulo)
                Case "Tan"
                    grfx.FillRectangle(Brushes.Tan, rectangulo)
                Case "Teal"
                    grfx.FillRectangle(Brushes.Teal, rectangulo)
                Case "Thistle"
                    grfx.FillRectangle(Brushes.Thistle, rectangulo)
                Case "Tomato"
                    grfx.FillRectangle(Brushes.Tomato, rectangulo)
                Case "Transparent"
                    grfx.FillRectangle(Brushes.Transparent, rectangulo)
                Case "Turquoise"
                    grfx.FillRectangle(Brushes.Turquoise, rectangulo)
                Case "Violet"
                    grfx.FillRectangle(Brushes.Violet, rectangulo)
                Case "Wheat"
                    grfx.FillRectangle(Brushes.Wheat, rectangulo)
                Case "White"
                    grfx.FillRectangle(Brushes.White, rectangulo)
                Case "WhiteSmoke"
                    grfx.FillRectangle(Brushes.WhiteSmoke, rectangulo)
                Case "Yellow"
                    grfx.FillRectangle(Brushes.Yellow, rectangulo)
                Case "YellowGreen"
                    grfx.FillRectangle(Brushes.YellowGreen, rectangulo)

                Case Else
                    grfx.FillRectangle(Brushes.Transparent, rectangulo)
            End Select

            lapiz.DashPattern = dashValues
            rectangulo = New Rectangle(m_point1, New Size(ancho, alto))
            If ancho < 0 And alto < 0 Then
                rectangulo = New Rectangle(m_point2.X, m_point2.Y, Math.Abs(ancho), Math.Abs(alto))
                grfx.DrawRectangle(lapiz, m_point2.X, m_point2.Y, Math.Abs(ancho), Math.Abs(alto))
            End If
            If ancho < 0 And alto > 0 Then
                rectangulo = New Rectangle(m_point2.X, m_point1.Y, Math.Abs(ancho), Math.Abs(alto))
                grfx.DrawRectangle(lapiz, m_point2.X, m_point1.Y, Math.Abs(ancho), Math.Abs(alto))
            End If
            If ancho > 0 And alto < 0 Then
                grfx.DrawRectangle(lapiz, m_point1.X, m_point2.Y, Math.Abs(ancho), Math.Abs(alto))
                rectangulo = New Rectangle(m_point1.X, m_point2.Y, Math.Abs(ancho), Math.Abs(alto))
            End If
            If ancho > 0 And alto > 0 Then
                grfx.DrawRectangle(lapiz, m_point1.X, m_point1.Y, Math.Abs(ancho), Math.Abs(alto))
                rectangulo = New Rectangle(m_point1.X, m_point1.Y, Math.Abs(ancho), Math.Abs(alto))
            End If
            grfx.DrawRectangle(lapiz, New Rectangle(m_point1, New Size(ancho, alto)))


        End Sub
    End Class

    Public Class cuadrado

        Private m_point1 As New Point(0, 0)
        Private m_point2 As New Point(0, 0)
        Private color_trazo As Color = color.Black
        Private ancho_trazo As Integer = 1
        Private formato_trazo As String = "normal"
        Private color_interior As String = "Transparent"

        Public Property formatoLinea() As String
            Get
                Return formato_trazo
            End Get
            Set(ByVal value As String)
                formato_trazo = value
            End Set
        End Property

        Public Property Point1() As Point
            Get
                Return m_point1
            End Get
            Set(ByVal value As Point)
                m_point1 = value
            End Set
        End Property

        Public Property Point2() As Point
            Get
                Return m_point2
            End Get
            Set(ByVal value As Point)
                m_point2 = value
            End Set
        End Property
        Public Property color() As Color
            Get
                Return color_trazo
            End Get
            Set(ByVal value As Color)
                color_trazo = value
            End Set
        End Property

        Public Property ancho() As Integer
            Get
                Return ancho_trazo
            End Get
            Set(ByVal value As Integer)
                ancho_trazo = value
            End Set
        End Property

        Public Property colorInt() As String
            Get
                Return color_interior
            End Get
            Set(ByVal value As String)
                color_interior = value
            End Set
        End Property


        Public Sub Draw(ByVal grfx As Graphics)

            If (grfx Is Nothing) Then _
                Throw New ArgumentNullException("grfx")

            ' Dibujamos la línea.
            '
            Dim ancho, alto As Integer
            ancho = m_point2.X - m_point1.X
            alto = m_point2.Y - m_point1.Y
            Dim dashValues As Single()
            Select Case formato_trazo
                Case "normal"
                    dashValues = {9999, 1, 1, 1}
                Case "disc1"
                    dashValues = {5, 2, 15, 4}
                Case "disc2"
                    dashValues = {1, 2, 1, 2}
                Case "disc3"
                    dashValues = {5, 1, 5, 1}
                Case "disc4"
                    dashValues = {10, 1, 1, 1}
                Case "disc5"
                    dashValues = {2, 3, 15, 9}

                Case Else
                    dashValues = {9999, 1, 1, 1}
            End Select

            Dim lapiz As New Pen(color_trazo, ancho_trazo)
            lapiz.DashPattern = dashValues
            Dim rectangulo As New Rectangle

            If ancho < 0 And alto < 0 Then
                rectangulo = New Rectangle(m_point2.X, m_point2.Y, Math.Abs(alto), Math.Abs(alto))
                grfx.DrawRectangle(lapiz, m_point2.X, m_point2.Y, Math.Abs(alto), Math.Abs(alto))
            End If
            If ancho < 0 And alto > 0 Then
                rectangulo = New Rectangle(m_point2.X, m_point1.Y, Math.Abs(alto), Math.Abs(alto))
                grfx.DrawRectangle(lapiz, m_point2.X, m_point1.Y, Math.Abs(alto), Math.Abs(alto))
            End If
            If ancho > 0 And alto < 0 Then
                grfx.DrawRectangle(lapiz, m_point1.X, m_point2.Y, Math.Abs(alto), Math.Abs(alto))
                rectangulo = New Rectangle(m_point1.X, m_point2.Y, Math.Abs(alto), Math.Abs(alto))
            End If
            If ancho > 0 And alto > 0 Then
                grfx.DrawRectangle(lapiz, m_point1.X, m_point1.Y, Math.Abs(alto), Math.Abs(alto))
                rectangulo = New Rectangle(m_point1.X, m_point1.Y, Math.Abs(alto), Math.Abs(alto))
            End If



            Select Case color_interior
                Case "AliceBlue"
                    grfx.FillRectangle(Brushes.AliceBlue, rectangulo)
                Case "AntiqueWhite"
                    grfx.FillRectangle(Brushes.AntiqueWhite, rectangulo)
                Case "Aqua"
                    grfx.FillRectangle(Brushes.Aqua, rectangulo)
                Case "Aquamarine"
                    grfx.FillRectangle(Brushes.Aquamarine, rectangulo)
                Case "Azure"
                    grfx.FillRectangle(Brushes.Azure, rectangulo)
                Case "Beige"
                    grfx.FillRectangle(Brushes.Beige, rectangulo)
                Case "Bisque"
                    grfx.FillRectangle(Brushes.Bisque, rectangulo)
                Case "Black"
                    grfx.FillRectangle(Brushes.Black, rectangulo)
                Case "BlanchedAlmond"
                    grfx.FillRectangle(Brushes.BlanchedAlmond, rectangulo)
                Case "Blue"
                    grfx.FillRectangle(Brushes.Blue, rectangulo)
                Case "BlueViolet"
                    grfx.FillRectangle(Brushes.BlueViolet, rectangulo)
                Case "Brown"
                    grfx.FillRectangle(Brushes.Brown, rectangulo)
                Case "BurlyWood"
                    grfx.FillRectangle(Brushes.BurlyWood, rectangulo)
                Case "CadetBlue"
                    grfx.FillRectangle(Brushes.CadetBlue, rectangulo)
                Case "Chartreuse"
                    grfx.FillRectangle(Brushes.Chartreuse, rectangulo)
                Case "Chocolate"
                    grfx.FillRectangle(Brushes.Chocolate, rectangulo)
                Case "Coral"
                    grfx.FillRectangle(Brushes.Coral, rectangulo)
                Case "CornflowerBlue"
                    grfx.FillRectangle(Brushes.CornflowerBlue, rectangulo)
                Case "Cornsilk"
                    grfx.FillRectangle(Brushes.Cornsilk, rectangulo)
                Case "Crimson"
                    grfx.FillRectangle(Brushes.Crimson, rectangulo)
                Case "Cyan"
                    grfx.FillRectangle(Brushes.Cyan, rectangulo)
                Case "DarkCyan"
                    grfx.FillRectangle(Brushes.DarkCyan, rectangulo)
                Case "DarkGoldenrod"
                    grfx.FillRectangle(Brushes.DarkGoldenrod, rectangulo)
                Case "DarkGray"
                    grfx.FillRectangle(Brushes.DarkGray, rectangulo)
                Case "DarkGreen"
                    grfx.FillRectangle(Brushes.DarkGreen, rectangulo)
                Case "DarkKhaki"
                    grfx.FillRectangle(Brushes.DarkKhaki, rectangulo)
                Case "DarkMagenta"
                    grfx.FillRectangle(Brushes.DarkMagenta, rectangulo)
                Case "DarkOliveGreen"
                    grfx.FillRectangle(Brushes.DarkOliveGreen, rectangulo)
                Case "DarkOrange"
                    grfx.FillRectangle(Brushes.DarkOrange, rectangulo)
                Case "DarkOrchid"
                    grfx.FillRectangle(Brushes.DarkOrchid, rectangulo)
                Case "DarkRed"
                    grfx.FillRectangle(Brushes.DarkRed, rectangulo)
                Case "DarkSalmon"
                    grfx.FillRectangle(Brushes.DarkSalmon, rectangulo)
                Case "DarkSeaGreen"
                    grfx.FillRectangle(Brushes.DarkSeaGreen, rectangulo)
                Case "DarkSlateBlue"
                    grfx.FillRectangle(Brushes.DarkSlateBlue, rectangulo)
                Case "DarkSlateGray"
                    grfx.FillRectangle(Brushes.DarkSlateGray, rectangulo)
                Case "DarkTurquoise"
                    grfx.FillRectangle(Brushes.DarkTurquoise, rectangulo)
                Case "DarkViolet"
                    grfx.FillRectangle(Brushes.DarkViolet, rectangulo)
                Case "DeepPink"
                    grfx.FillRectangle(Brushes.DeepPink, rectangulo)
                Case "DeepSkyBlue"
                    grfx.FillRectangle(Brushes.DeepSkyBlue, rectangulo)
                Case "DimGray"
                    grfx.FillRectangle(Brushes.DimGray, rectangulo)
                Case "DodgerBlue"
                    grfx.FillRectangle(Brushes.DodgerBlue, rectangulo)
                Case "Firebrick"
                    grfx.FillRectangle(Brushes.Firebrick, rectangulo)
                Case "FloralWhite"
                    grfx.FillRectangle(Brushes.FloralWhite, rectangulo)
                Case "ForestGreen"
                    grfx.FillRectangle(Brushes.ForestGreen, rectangulo)
                Case "Fuchsia"
                    grfx.FillRectangle(Brushes.Fuchsia, rectangulo)
                Case "Gainsboro"
                    grfx.FillRectangle(Brushes.Gainsboro, rectangulo)
                Case "GhostWhite"
                    grfx.FillRectangle(Brushes.GhostWhite, rectangulo)
                Case "Gold"
                    grfx.FillRectangle(Brushes.Gold, rectangulo)
                Case "Goldenrod"
                    grfx.FillRectangle(Brushes.Goldenrod, rectangulo)
                Case "Gray"
                    grfx.FillRectangle(Brushes.Gray, rectangulo)
                Case "Green"
                    grfx.FillRectangle(Brushes.Green, rectangulo)
                Case "GreenYellow"
                    grfx.FillRectangle(Brushes.GreenYellow, rectangulo)
                Case "Honeydew"
                    grfx.FillRectangle(Brushes.Honeydew, rectangulo)
                Case "HotPink"
                    grfx.FillRectangle(Brushes.HotPink, rectangulo)
                Case "IndianRed"
                    grfx.FillRectangle(Brushes.IndianRed, rectangulo)
                Case "Indigo"
                    grfx.FillRectangle(Brushes.Indigo, rectangulo)
                Case "Ivory"
                    grfx.FillRectangle(Brushes.Ivory, rectangulo)
                Case "Khaki"
                    grfx.FillRectangle(Brushes.Khaki, rectangulo)
                Case "Lavender"
                    grfx.FillRectangle(Brushes.Lavender, rectangulo)
                Case "LavenderBlush"
                    grfx.FillRectangle(Brushes.LavenderBlush, rectangulo)
                Case "LawnGreen"
                    grfx.FillRectangle(Brushes.LawnGreen, rectangulo)
                Case "LemonChiffon"
                    grfx.FillRectangle(Brushes.LemonChiffon, rectangulo)
                Case "LightBlue"
                    grfx.FillRectangle(Brushes.LightBlue, rectangulo)
                Case "LightCoral"
                    grfx.FillRectangle(Brushes.LightCoral, rectangulo)
                Case "LightCyan"
                    grfx.FillRectangle(Brushes.LightCyan, rectangulo)
                Case "LightGoldenrodYellow"
                    grfx.FillRectangle(Brushes.LightGoldenrodYellow, rectangulo)
                Case "LightGray"
                    grfx.FillRectangle(Brushes.LightGray, rectangulo)
                Case "LightGreen"
                    grfx.FillRectangle(Brushes.LightGreen, rectangulo)
                Case "LightPink"
                    grfx.FillRectangle(Brushes.LightPink, rectangulo)
                Case "LightSalmon"
                    grfx.FillRectangle(Brushes.LightSalmon, rectangulo)
                Case "LightSeaGreen"
                    grfx.FillRectangle(Brushes.LightSeaGreen, rectangulo)
                Case "LightSkyBlue"
                    grfx.FillRectangle(Brushes.LightSkyBlue, rectangulo)
                Case "LightSlateGray"
                    grfx.FillRectangle(Brushes.LightSlateGray, rectangulo)
                Case "LightSteelBlue"
                    grfx.FillRectangle(Brushes.LightSteelBlue, rectangulo)
                Case "LightYellow"
                    grfx.FillRectangle(Brushes.LightYellow, rectangulo)
                Case "Lime"
                    grfx.FillRectangle(Brushes.Lime, rectangulo)
                Case "LimeGreen"
                    grfx.FillRectangle(Brushes.LimeGreen, rectangulo)
                Case "Linen"
                    grfx.FillRectangle(Brushes.Linen, rectangulo)
                Case "Magenta"
                    grfx.FillRectangle(Brushes.Magenta, rectangulo)
                Case "Maroon"
                    grfx.FillRectangle(Brushes.Maroon, rectangulo)
                Case "MediumAquamarine"
                    grfx.FillRectangle(Brushes.MediumAquamarine, rectangulo)
                Case "MediumBlue"
                    grfx.FillRectangle(Brushes.MediumBlue, rectangulo)
                Case "MediumOrchid"
                    grfx.FillRectangle(Brushes.MediumOrchid, rectangulo)
                Case "MediumPurple"
                    grfx.FillRectangle(Brushes.MediumPurple, rectangulo)
                Case "MediumPurple"
                    grfx.FillRectangle(Brushes.MediumPurple, rectangulo)
                Case "MediumSeaGreen"
                    grfx.FillRectangle(Brushes.MediumSeaGreen, rectangulo)
                Case "MediumSlateBlue"
                    grfx.FillRectangle(Brushes.MediumSlateBlue, rectangulo)
                Case "MediumSpringGreen"
                    grfx.FillRectangle(Brushes.MediumSpringGreen, rectangulo)
                Case "MediumTurquoise"
                    grfx.FillRectangle(Brushes.MediumTurquoise, rectangulo)
                Case "MediumVioletRed"
                    grfx.FillRectangle(Brushes.MediumVioletRed, rectangulo)
                Case "MidnightBlue"
                    grfx.FillRectangle(Brushes.MidnightBlue, rectangulo)
                Case "MintCream"
                    grfx.FillRectangle(Brushes.MintCream, rectangulo)
                Case "MistyRose"
                    grfx.FillRectangle(Brushes.MistyRose, rectangulo)
                Case "Moccasin"
                    grfx.FillRectangle(Brushes.Moccasin, rectangulo)
                Case "NavajoWhite"
                    grfx.FillRectangle(Brushes.NavajoWhite, rectangulo)
                Case "Navy"
                    grfx.FillRectangle(Brushes.Navy, rectangulo)
                Case "OldLace"
                    grfx.FillRectangle(Brushes.OldLace, rectangulo)
                Case "Olive"
                    grfx.FillRectangle(Brushes.Olive, rectangulo)
                Case "OliveDrab"
                    grfx.FillRectangle(Brushes.OliveDrab, rectangulo)
                Case "Orange"
                    grfx.FillRectangle(Brushes.Orange, rectangulo)
                Case "OrangeRed"
                    grfx.FillRectangle(Brushes.OrangeRed, rectangulo)
                Case "Orchid"
                    grfx.FillRectangle(Brushes.Orchid, rectangulo)
                Case "PaleGoldenrod"
                    grfx.FillRectangle(Brushes.PaleGoldenrod, rectangulo)
                Case "PaleGreen"
                    grfx.FillRectangle(Brushes.PaleGreen, rectangulo)
                Case "PaleTurquoise"
                    grfx.FillRectangle(Brushes.PaleTurquoise, rectangulo)
                Case "PaleVioletRed"
                    grfx.FillRectangle(Brushes.PaleVioletRed, rectangulo)
                Case "PapayaWhip"
                    grfx.FillRectangle(Brushes.PapayaWhip, rectangulo)
                Case "PeachPuff"
                    grfx.FillRectangle(Brushes.PeachPuff, rectangulo)
                Case "Peru"
                    grfx.FillRectangle(Brushes.Peru, rectangulo)
                Case "Pink"
                    grfx.FillRectangle(Brushes.Pink, rectangulo)
                Case "Plum"
                    grfx.FillRectangle(Brushes.Plum, rectangulo)
                Case "PowderBlue"
                    grfx.FillRectangle(Brushes.PowderBlue, rectangulo)
                Case "Purple"
                    grfx.FillRectangle(Brushes.Purple, rectangulo)
                Case "Red"
                    grfx.FillRectangle(Brushes.Red, rectangulo)
                Case "RosyBrown"
                    grfx.FillRectangle(Brushes.RosyBrown, rectangulo)
                Case "RoyalBlue"
                    grfx.FillRectangle(Brushes.RoyalBlue, rectangulo)
                Case "SaddleBrown"
                    grfx.FillRectangle(Brushes.SaddleBrown, rectangulo)
                Case "Salmon"
                    grfx.FillRectangle(Brushes.Salmon, rectangulo)
                Case "SandyBrown"
                    grfx.FillRectangle(Brushes.SandyBrown, rectangulo)
                Case "SeaGreen"
                    grfx.FillRectangle(Brushes.SeaGreen, rectangulo)
                Case "SeaShell"
                    grfx.FillRectangle(Brushes.SeaShell, rectangulo)
                Case "Sienna"
                    grfx.FillRectangle(Brushes.Sienna, rectangulo)
                Case "Silver"
                    grfx.FillRectangle(Brushes.Silver, rectangulo)
                Case "SkyBlue"
                    grfx.FillRectangle(Brushes.SkyBlue, rectangulo)
                Case "SlateBlue"
                    grfx.FillRectangle(Brushes.SlateBlue, rectangulo)
                Case "SlateGray"
                    grfx.FillRectangle(Brushes.SlateGray, rectangulo)
                Case "Snow"
                    grfx.FillRectangle(Brushes.Snow, rectangulo)
                Case "SpringGreen"
                    grfx.FillRectangle(Brushes.SpringGreen, rectangulo)
                Case "SteelBlue"
                    grfx.FillRectangle(Brushes.SteelBlue, rectangulo)
                Case "Tan"
                    grfx.FillRectangle(Brushes.Tan, rectangulo)
                Case "Teal"
                    grfx.FillRectangle(Brushes.Teal, rectangulo)
                Case "Thistle"
                    grfx.FillRectangle(Brushes.Thistle, rectangulo)
                Case "Tomato"
                    grfx.FillRectangle(Brushes.Tomato, rectangulo)
                Case "Transparent"
                    grfx.FillRectangle(Brushes.Transparent, rectangulo)
                Case "Turquoise"
                    grfx.FillRectangle(Brushes.Turquoise, rectangulo)
                Case "Violet"
                    grfx.FillRectangle(Brushes.Violet, rectangulo)
                Case "Wheat"
                    grfx.FillRectangle(Brushes.Wheat, rectangulo)
                Case "White"
                    grfx.FillRectangle(Brushes.White, rectangulo)
                Case "WhiteSmoke"
                    grfx.FillRectangle(Brushes.WhiteSmoke, rectangulo)
                Case "Yellow"
                    grfx.FillRectangle(Brushes.Yellow, rectangulo)
                Case "YellowGreen"
                    grfx.FillRectangle(Brushes.YellowGreen, rectangulo)

                Case Else
                    grfx.FillRectangle(Brushes.Transparent, rectangulo)
            End Select

            lapiz.DashPattern = dashValues

            If ancho < 0 And alto < 0 Then
                rectangulo = New Rectangle(m_point2.X, m_point2.Y, Math.Abs(alto), Math.Abs(alto))
                grfx.DrawRectangle(lapiz, m_point2.X, m_point2.Y, Math.Abs(alto), Math.Abs(alto))
            End If
            If ancho < 0 And alto > 0 Then
                rectangulo = New Rectangle(m_point2.X, m_point1.Y, Math.Abs(alto), Math.Abs(alto))
                grfx.DrawRectangle(lapiz, m_point2.X, m_point1.Y, Math.Abs(alto), Math.Abs(alto))
            End If
            If ancho > 0 And alto < 0 Then
                grfx.DrawRectangle(lapiz, m_point1.X, m_point2.Y, Math.Abs(alto), Math.Abs(alto))
                rectangulo = New Rectangle(m_point1.X, m_point2.Y, Math.Abs(alto), Math.Abs(alto))
            End If
            If ancho > 0 And alto > 0 Then
                grfx.DrawRectangle(lapiz, m_point1.X, m_point1.Y, Math.Abs(alto), Math.Abs(alto))
                rectangulo = New Rectangle(m_point1.X, m_point1.Y, Math.Abs(alto), Math.Abs(alto))
            End If
        End Sub
    End Class


    Public Class elipse

        Private m_point1 As New Point(0, 0)
        Private m_point2 As New Point(0, 0)
        Private color_trazo As Color = color.Black
        Private ancho_trazo As Integer = 1
        Private formato_trazo As String = "normal"
        Private color_interior As String = "Transparent"

        Public Property formatoLinea() As String
            Get
                Return formato_trazo
            End Get
            Set(ByVal value As String)
                formato_trazo = value
            End Set
        End Property

        Public Property Point1() As Point
            Get
                Return m_point1
            End Get
            Set(ByVal value As Point)
                m_point1 = value
            End Set
        End Property

        Public Property Point2() As Point
            Get
                Return m_point2
            End Get
            Set(ByVal value As Point)
                m_point2 = value
            End Set
        End Property

        Public Property color() As Color
            Get
                Return color_trazo
            End Get
            Set(ByVal value As Color)
                color_trazo = value
            End Set
        End Property

        Public Property ancho() As Integer
            Get
                Return ancho_trazo
            End Get
            Set(ByVal value As Integer)
                ancho_trazo = value
            End Set
        End Property

        Public Property colorInt() As String
            Get
                Return color_interior
            End Get
            Set(ByVal value As String)
                color_interior = value
            End Set
        End Property

        Public Sub Draw(ByVal grfx As Graphics)

            If (grfx Is Nothing) Then _
                Throw New ArgumentNullException("grfx")

            ' Dibujamos la línea.
            '
            Dim dashValues As Single()
            Select Case formato_trazo
                Case "normal"
                    dashValues = {9999, 1, 1, 1}
                Case "disc1"
                    dashValues = {5, 2, 15, 4}
                Case "disc2"
                    dashValues = {1, 2, 1, 2}
                Case "disc3"
                    dashValues = {5, 1, 5, 1}
                Case "disc4"
                    dashValues = {10, 1, 1, 1}
                Case "disc5"
                    dashValues = {2, 3, 15, 9}

                Case Else
                    dashValues = {9999, 1, 1, 1}
            End Select

            Dim lapiz As New Pen(color_trazo, ancho_trazo)
            lapiz.DashPattern = dashValues
            Dim rectangulo As New Rectangle(New Point(m_point1.X, m_point1.Y), New Size(m_point2.X - m_point1.X, m_point2.Y - m_point1.Y))
            grfx.DrawEllipse(lapiz, rectangulo)
            Select Case color_interior
                Case "AliceBlue"
                    grfx.FillEllipse(Brushes.AliceBlue, rectangulo)
                Case "AntiqueWhite"
                    grfx.FillEllipse(Brushes.AntiqueWhite, rectangulo)
                Case "Aqua"
                    grfx.FillEllipse(Brushes.Aqua, rectangulo)
                Case "Aquamarine"
                    grfx.FillEllipse(Brushes.Aquamarine, rectangulo)
                Case "Azure"
                    grfx.FillEllipse(Brushes.Azure, rectangulo)
                Case "Beige"
                    grfx.FillEllipse(Brushes.Beige, rectangulo)
                Case "Bisque"
                    grfx.FillEllipse(Brushes.Bisque, rectangulo)
                Case "Black"
                    grfx.FillEllipse(Brushes.Black, rectangulo)
                Case "BlanchedAlmond"
                    grfx.FillEllipse(Brushes.BlanchedAlmond, rectangulo)
                Case "Blue"
                    grfx.FillEllipse(Brushes.Blue, rectangulo)
                Case "BlueViolet"
                    grfx.FillEllipse(Brushes.BlueViolet, rectangulo)
                Case "Brown"
                    grfx.FillEllipse(Brushes.Brown, rectangulo)
                Case "BurlyWood"
                    grfx.FillEllipse(Brushes.BurlyWood, rectangulo)
                Case "CadetBlue"
                    grfx.FillEllipse(Brushes.CadetBlue, rectangulo)
                Case "Chartreuse"
                    grfx.FillEllipse(Brushes.Chartreuse, rectangulo)
                Case "Chocolate"
                    grfx.FillEllipse(Brushes.Chocolate, rectangulo)
                Case "Coral"
                    grfx.FillEllipse(Brushes.Coral, rectangulo)
                Case "CornflowerBlue"
                    grfx.FillEllipse(Brushes.CornflowerBlue, rectangulo)
                Case "Cornsilk"
                    grfx.FillEllipse(Brushes.Cornsilk, rectangulo)
                Case "Crimson"
                    grfx.FillEllipse(Brushes.Crimson, rectangulo)
                Case "Cyan"
                    grfx.FillEllipse(Brushes.Cyan, rectangulo)
                Case "DarkCyan"
                    grfx.FillEllipse(Brushes.DarkCyan, rectangulo)
                Case "DarkGoldenrod"
                    grfx.FillEllipse(Brushes.DarkGoldenrod, rectangulo)
                Case "DarkGray"
                    grfx.FillEllipse(Brushes.DarkGray, rectangulo)
                Case "DarkGreen"
                    grfx.FillEllipse(Brushes.DarkGreen, rectangulo)
                Case "DarkKhaki"
                    grfx.FillEllipse(Brushes.DarkKhaki, rectangulo)
                Case "DarkMagenta"
                    grfx.FillEllipse(Brushes.DarkMagenta, rectangulo)
                Case "DarkOliveGreen"
                    grfx.FillEllipse(Brushes.DarkOliveGreen, rectangulo)
                Case "DarkOrange"
                    grfx.FillEllipse(Brushes.DarkOrange, rectangulo)
                Case "DarkOrchid"
                    grfx.FillEllipse(Brushes.DarkOrchid, rectangulo)
                Case "DarkRed"
                    grfx.FillEllipse(Brushes.DarkRed, rectangulo)
                Case "DarkSalmon"
                    grfx.FillEllipse(Brushes.DarkSalmon, rectangulo)
                Case "DarkSeaGreen"
                    grfx.FillEllipse(Brushes.DarkSeaGreen, rectangulo)
                Case "DarkSlateBlue"
                    grfx.FillEllipse(Brushes.DarkSlateBlue, rectangulo)
                Case "DarkSlateGray"
                    grfx.FillEllipse(Brushes.DarkSlateGray, rectangulo)
                Case "DarkTurquoise"
                    grfx.FillEllipse(Brushes.DarkTurquoise, rectangulo)
                Case "DarkViolet"
                    grfx.FillEllipse(Brushes.DarkViolet, rectangulo)
                Case "DeepPink"
                    grfx.FillEllipse(Brushes.DeepPink, rectangulo)
                Case "DeepSkyBlue"
                    grfx.FillEllipse(Brushes.DeepSkyBlue, rectangulo)
                Case "DimGray"
                    grfx.FillEllipse(Brushes.DimGray, rectangulo)
                Case "DodgerBlue"
                    grfx.FillEllipse(Brushes.DodgerBlue, rectangulo)
                Case "Firebrick"
                    grfx.FillEllipse(Brushes.Firebrick, rectangulo)
                Case "FloralWhite"
                    grfx.FillEllipse(Brushes.FloralWhite, rectangulo)
                Case "ForestGreen"
                    grfx.FillEllipse(Brushes.ForestGreen, rectangulo)
                Case "Fuchsia"
                    grfx.FillEllipse(Brushes.Fuchsia, rectangulo)
                Case "Gainsboro"
                    grfx.FillEllipse(Brushes.Gainsboro, rectangulo)
                Case "GhostWhite"
                    grfx.FillEllipse(Brushes.GhostWhite, rectangulo)
                Case "Gold"
                    grfx.FillEllipse(Brushes.Gold, rectangulo)
                Case "Goldenrod"
                    grfx.FillEllipse(Brushes.Goldenrod, rectangulo)
                Case "Gray"
                    grfx.FillEllipse(Brushes.Gray, rectangulo)
                Case "Green"
                    grfx.FillEllipse(Brushes.Green, rectangulo)
                Case "GreenYellow"
                    grfx.FillEllipse(Brushes.GreenYellow, rectangulo)
                Case "Honeydew"
                    grfx.FillEllipse(Brushes.Honeydew, rectangulo)
                Case "HotPink"
                    grfx.FillEllipse(Brushes.HotPink, rectangulo)
                Case "IndianRed"
                    grfx.FillEllipse(Brushes.IndianRed, rectangulo)
                Case "Indigo"
                    grfx.FillEllipse(Brushes.Indigo, rectangulo)
                Case "Ivory"
                    grfx.FillEllipse(Brushes.Ivory, rectangulo)
                Case "Khaki"
                    grfx.FillEllipse(Brushes.Khaki, rectangulo)
                Case "Lavender"
                    grfx.FillEllipse(Brushes.Lavender, rectangulo)
                Case "LavenderBlush"
                    grfx.FillEllipse(Brushes.LavenderBlush, rectangulo)
                Case "LawnGreen"
                    grfx.FillEllipse(Brushes.LawnGreen, rectangulo)
                Case "LemonChiffon"
                    grfx.FillEllipse(Brushes.LemonChiffon, rectangulo)
                Case "LightBlue"
                    grfx.FillEllipse(Brushes.LightBlue, rectangulo)
                Case "LightCoral"
                    grfx.FillEllipse(Brushes.LightCoral, rectangulo)
                Case "LightCyan"
                    grfx.FillEllipse(Brushes.LightCyan, rectangulo)
                Case "LightGoldenrodYellow"
                    grfx.FillEllipse(Brushes.LightGoldenrodYellow, rectangulo)
                Case "LightGray"
                    grfx.FillEllipse(Brushes.LightGray, rectangulo)
                Case "LightGreen"
                    grfx.FillEllipse(Brushes.LightGreen, rectangulo)
                Case "LightPink"
                    grfx.FillEllipse(Brushes.LightPink, rectangulo)
                Case "LightSalmon"
                    grfx.FillEllipse(Brushes.LightSalmon, rectangulo)
                Case "LightSeaGreen"
                    grfx.FillEllipse(Brushes.LightSeaGreen, rectangulo)
                Case "LightSkyBlue"
                    grfx.FillEllipse(Brushes.LightSkyBlue, rectangulo)
                Case "LightSlateGray"
                    grfx.FillEllipse(Brushes.LightSlateGray, rectangulo)
                Case "LightSteelBlue"
                    grfx.FillEllipse(Brushes.LightSteelBlue, rectangulo)
                Case "LightYellow"
                    grfx.FillEllipse(Brushes.LightYellow, rectangulo)
                Case "Lime"
                    grfx.FillEllipse(Brushes.Lime, rectangulo)
                Case "LimeGreen"
                    grfx.FillEllipse(Brushes.LimeGreen, rectangulo)
                Case "Linen"
                    grfx.FillEllipse(Brushes.Linen, rectangulo)
                Case "Magenta"
                    grfx.FillEllipse(Brushes.Magenta, rectangulo)
                Case "Maroon"
                    grfx.FillEllipse(Brushes.Maroon, rectangulo)
                Case "MediumAquamarine"
                    grfx.FillEllipse(Brushes.MediumAquamarine, rectangulo)
                Case "MediumBlue"
                    grfx.FillEllipse(Brushes.MediumBlue, rectangulo)
                Case "MediumOrchid"
                    grfx.FillEllipse(Brushes.MediumOrchid, rectangulo)
                Case "MediumPurple"
                    grfx.FillEllipse(Brushes.MediumPurple, rectangulo)
                Case "MediumPurple"
                    grfx.FillEllipse(Brushes.MediumPurple, rectangulo)
                Case "MediumSeaGreen"
                    grfx.FillEllipse(Brushes.MediumSeaGreen, rectangulo)
                Case "MediumSlateBlue"
                    grfx.FillEllipse(Brushes.MediumSlateBlue, rectangulo)
                Case "MediumSpringGreen"
                    grfx.FillEllipse(Brushes.MediumSpringGreen, rectangulo)
                Case "MediumTurquoise"
                    grfx.FillEllipse(Brushes.MediumTurquoise, rectangulo)
                Case "MediumVioletRed"
                    grfx.FillEllipse(Brushes.MediumVioletRed, rectangulo)
                Case "MidnightBlue"
                    grfx.FillEllipse(Brushes.MidnightBlue, rectangulo)
                Case "MintCream"
                    grfx.FillEllipse(Brushes.MintCream, rectangulo)
                Case "MistyRose"
                    grfx.FillEllipse(Brushes.MistyRose, rectangulo)
                Case "Moccasin"
                    grfx.FillEllipse(Brushes.Moccasin, rectangulo)
                Case "NavajoWhite"
                    grfx.FillEllipse(Brushes.NavajoWhite, rectangulo)
                Case "Navy"
                    grfx.FillEllipse(Brushes.Navy, rectangulo)
                Case "OldLace"
                    grfx.FillEllipse(Brushes.OldLace, rectangulo)
                Case "Olive"
                    grfx.FillEllipse(Brushes.Olive, rectangulo)
                Case "OliveDrab"
                    grfx.FillEllipse(Brushes.OliveDrab, rectangulo)
                Case "Orange"
                    grfx.FillEllipse(Brushes.Orange, rectangulo)
                Case "OrangeRed"
                    grfx.FillEllipse(Brushes.OrangeRed, rectangulo)
                Case "Orchid"
                    grfx.FillEllipse(Brushes.Orchid, rectangulo)
                Case "PaleGoldenrod"
                    grfx.FillEllipse(Brushes.PaleGoldenrod, rectangulo)
                Case "PaleGreen"
                    grfx.FillEllipse(Brushes.PaleGreen, rectangulo)
                Case "PaleTurquoise"
                    grfx.FillEllipse(Brushes.PaleTurquoise, rectangulo)
                Case "PaleVioletRed"
                    grfx.FillEllipse(Brushes.PaleVioletRed, rectangulo)
                Case "PapayaWhip"
                    grfx.FillEllipse(Brushes.PapayaWhip, rectangulo)
                Case "PeachPuff"
                    grfx.FillEllipse(Brushes.PeachPuff, rectangulo)
                Case "Peru"
                    grfx.FillEllipse(Brushes.Peru, rectangulo)
                Case "Pink"
                    grfx.FillEllipse(Brushes.Pink, rectangulo)
                Case "Plum"
                    grfx.FillEllipse(Brushes.Plum, rectangulo)
                Case "PowderBlue"
                    grfx.FillEllipse(Brushes.PowderBlue, rectangulo)
                Case "Purple"
                    grfx.FillEllipse(Brushes.Purple, rectangulo)
                Case "Red"
                    grfx.FillEllipse(Brushes.Red, rectangulo)
                Case "RosyBrown"
                    grfx.FillEllipse(Brushes.RosyBrown, rectangulo)
                Case "RoyalBlue"
                    grfx.FillEllipse(Brushes.RoyalBlue, rectangulo)
                Case "SaddleBrown"
                    grfx.FillEllipse(Brushes.SaddleBrown, rectangulo)
                Case "Salmon"
                    grfx.FillEllipse(Brushes.Salmon, rectangulo)
                Case "SandyBrown"
                    grfx.FillEllipse(Brushes.SandyBrown, rectangulo)
                Case "SeaGreen"
                    grfx.FillEllipse(Brushes.SeaGreen, rectangulo)
                Case "SeaShell"
                    grfx.FillEllipse(Brushes.SeaShell, rectangulo)
                Case "Sienna"
                    grfx.FillEllipse(Brushes.Sienna, rectangulo)
                Case "Silver"
                    grfx.FillEllipse(Brushes.Silver, rectangulo)
                Case "SkyBlue"
                    grfx.FillEllipse(Brushes.SkyBlue, rectangulo)
                Case "SlateBlue"
                    grfx.FillEllipse(Brushes.SlateBlue, rectangulo)
                Case "SlateGray"
                    grfx.FillEllipse(Brushes.SlateGray, rectangulo)
                Case "Snow"
                    grfx.FillEllipse(Brushes.Snow, rectangulo)
                Case "SpringGreen"
                    grfx.FillEllipse(Brushes.SpringGreen, rectangulo)
                Case "SteelBlue"
                    grfx.FillEllipse(Brushes.SteelBlue, rectangulo)
                Case "Tan"
                    grfx.FillEllipse(Brushes.Tan, rectangulo)
                Case "Teal"
                    grfx.FillEllipse(Brushes.Teal, rectangulo)
                Case "Thistle"
                    grfx.FillEllipse(Brushes.Thistle, rectangulo)
                Case "Tomato"
                    grfx.FillEllipse(Brushes.Tomato, rectangulo)
                Case "Transparent"
                    grfx.FillEllipse(Brushes.Transparent, rectangulo)
                Case "Turquoise"
                    grfx.FillEllipse(Brushes.Turquoise, rectangulo)
                Case "Violet"
                    grfx.FillEllipse(Brushes.Violet, rectangulo)
                Case "Wheat"
                    grfx.FillEllipse(Brushes.Wheat, rectangulo)
                Case "White"
                    grfx.FillEllipse(Brushes.White, rectangulo)
                Case "WhiteSmoke"
                    grfx.FillEllipse(Brushes.WhiteSmoke, rectangulo)
                Case "Yellow"
                    grfx.FillEllipse(Brushes.Yellow, rectangulo)
                Case "YellowGreen"
                    grfx.FillEllipse(Brushes.YellowGreen, rectangulo)

                Case Else
                    grfx.FillEllipse(Brushes.Transparent, rectangulo)
            End Select


        End Sub
    End Class

    Public Class circulo

        Private m_point1 As New Point(0, 0)
        Private m_point2 As New Point(0, 0)
        Private color_trazo As Color = color.Black
        Private ancho_trazo As Integer = 1
        Private formato_trazo As String = "normal"
        Private color_interior As String = "Transparent"

        Public Property formatoLinea() As String
            Get
                Return formato_trazo
            End Get
            Set(ByVal value As String)
                formato_trazo = value
            End Set
        End Property

        Public Property Point1() As Point
            Get
                Return m_point1
            End Get
            Set(ByVal value As Point)
                m_point1 = value
            End Set
        End Property

        Public Property Point2() As Point
            Get
                Return m_point2
            End Get
            Set(ByVal value As Point)
                m_point2 = value
            End Set
        End Property

        Public Property color() As Color
            Get
                Return color_trazo
            End Get
            Set(ByVal value As Color)
                color_trazo = value
            End Set
        End Property

        Public Property ancho() As Integer
            Get
                Return ancho_trazo
            End Get
            Set(ByVal value As Integer)
                ancho_trazo = value
            End Set
        End Property

        Public Property colorInt() As String
            Get
                Return color_interior
            End Get
            Set(ByVal value As String)
                color_interior = value
            End Set
        End Property

        Public Sub Draw(ByVal grfx As Graphics)

            If (grfx Is Nothing) Then _
                Throw New ArgumentNullException("grfx")

            ' Dibujamos la línea.
            '
            Dim dashValues As Single()
            Select Case formato_trazo
                Case "normal"
                    dashValues = {9999, 1, 1, 1}
                Case "disc1"
                    dashValues = {5, 2, 15, 4}
                Case "disc2"
                    dashValues = {1, 2, 1, 2}
                Case "disc3"
                    dashValues = {5, 1, 5, 1}
                Case "disc4"
                    dashValues = {10, 1, 1, 1}
                Case "disc5"
                    dashValues = {2, 3, 15, 9}

                Case Else
                    dashValues = {9999, 1, 1, 1}
            End Select

            Dim lapiz As New Pen(color_trazo, ancho_trazo)
            lapiz.DashPattern = dashValues
            Dim rectangulo As New Rectangle(New Point(m_point1.X, m_point1.Y), New Size(m_point2.Y - m_point1.Y, m_point2.Y - m_point1.Y))

            grfx.DrawEllipse(lapiz, rectangulo)
            Select Case color_interior
                Case "AliceBlue"
                    grfx.FillEllipse(Brushes.AliceBlue, rectangulo)
                Case "AntiqueWhite"
                    grfx.FillEllipse(Brushes.AntiqueWhite, rectangulo)
                Case "Aqua"
                    grfx.FillEllipse(Brushes.Aqua, rectangulo)
                Case "Aquamarine"
                    grfx.FillEllipse(Brushes.Aquamarine, rectangulo)
                Case "Azure"
                    grfx.FillEllipse(Brushes.Azure, rectangulo)
                Case "Beige"
                    grfx.FillEllipse(Brushes.Beige, rectangulo)
                Case "Bisque"
                    grfx.FillEllipse(Brushes.Bisque, rectangulo)
                Case "Black"
                    grfx.FillEllipse(Brushes.Black, rectangulo)
                Case "BlanchedAlmond"
                    grfx.FillEllipse(Brushes.BlanchedAlmond, rectangulo)
                Case "Blue"
                    grfx.FillEllipse(Brushes.Blue, rectangulo)
                Case "BlueViolet"
                    grfx.FillEllipse(Brushes.BlueViolet, rectangulo)
                Case "Brown"
                    grfx.FillEllipse(Brushes.Brown, rectangulo)
                Case "BurlyWood"
                    grfx.FillEllipse(Brushes.BurlyWood, rectangulo)
                Case "CadetBlue"
                    grfx.FillEllipse(Brushes.CadetBlue, rectangulo)
                Case "Chartreuse"
                    grfx.FillEllipse(Brushes.Chartreuse, rectangulo)
                Case "Chocolate"
                    grfx.FillEllipse(Brushes.Chocolate, rectangulo)
                Case "Coral"
                    grfx.FillEllipse(Brushes.Coral, rectangulo)
                Case "CornflowerBlue"
                    grfx.FillEllipse(Brushes.CornflowerBlue, rectangulo)
                Case "Cornsilk"
                    grfx.FillEllipse(Brushes.Cornsilk, rectangulo)
                Case "Crimson"
                    grfx.FillEllipse(Brushes.Crimson, rectangulo)
                Case "Cyan"
                    grfx.FillEllipse(Brushes.Cyan, rectangulo)
                Case "DarkCyan"
                    grfx.FillEllipse(Brushes.DarkCyan, rectangulo)
                Case "DarkGoldenrod"
                    grfx.FillEllipse(Brushes.DarkGoldenrod, rectangulo)
                Case "DarkGray"
                    grfx.FillEllipse(Brushes.DarkGray, rectangulo)
                Case "DarkGreen"
                    grfx.FillEllipse(Brushes.DarkGreen, rectangulo)
                Case "DarkKhaki"
                    grfx.FillEllipse(Brushes.DarkKhaki, rectangulo)
                Case "DarkMagenta"
                    grfx.FillEllipse(Brushes.DarkMagenta, rectangulo)
                Case "DarkOliveGreen"
                    grfx.FillEllipse(Brushes.DarkOliveGreen, rectangulo)
                Case "DarkOrange"
                    grfx.FillEllipse(Brushes.DarkOrange, rectangulo)
                Case "DarkOrchid"
                    grfx.FillEllipse(Brushes.DarkOrchid, rectangulo)
                Case "DarkRed"
                    grfx.FillEllipse(Brushes.DarkRed, rectangulo)
                Case "DarkSalmon"
                    grfx.FillEllipse(Brushes.DarkSalmon, rectangulo)
                Case "DarkSeaGreen"
                    grfx.FillEllipse(Brushes.DarkSeaGreen, rectangulo)
                Case "DarkSlateBlue"
                    grfx.FillEllipse(Brushes.DarkSlateBlue, rectangulo)
                Case "DarkSlateGray"
                    grfx.FillEllipse(Brushes.DarkSlateGray, rectangulo)
                Case "DarkTurquoise"
                    grfx.FillEllipse(Brushes.DarkTurquoise, rectangulo)
                Case "DarkViolet"
                    grfx.FillEllipse(Brushes.DarkViolet, rectangulo)
                Case "DeepPink"
                    grfx.FillEllipse(Brushes.DeepPink, rectangulo)
                Case "DeepSkyBlue"
                    grfx.FillEllipse(Brushes.DeepSkyBlue, rectangulo)
                Case "DimGray"
                    grfx.FillEllipse(Brushes.DimGray, rectangulo)
                Case "DodgerBlue"
                    grfx.FillEllipse(Brushes.DodgerBlue, rectangulo)
                Case "Firebrick"
                    grfx.FillEllipse(Brushes.Firebrick, rectangulo)
                Case "FloralWhite"
                    grfx.FillEllipse(Brushes.FloralWhite, rectangulo)
                Case "ForestGreen"
                    grfx.FillEllipse(Brushes.ForestGreen, rectangulo)
                Case "Fuchsia"
                    grfx.FillEllipse(Brushes.Fuchsia, rectangulo)
                Case "Gainsboro"
                    grfx.FillEllipse(Brushes.Gainsboro, rectangulo)
                Case "GhostWhite"
                    grfx.FillEllipse(Brushes.GhostWhite, rectangulo)
                Case "Gold"
                    grfx.FillEllipse(Brushes.Gold, rectangulo)
                Case "Goldenrod"
                    grfx.FillEllipse(Brushes.Goldenrod, rectangulo)
                Case "Gray"
                    grfx.FillEllipse(Brushes.Gray, rectangulo)
                Case "Green"
                    grfx.FillEllipse(Brushes.Green, rectangulo)
                Case "GreenYellow"
                    grfx.FillEllipse(Brushes.GreenYellow, rectangulo)
                Case "Honeydew"
                    grfx.FillEllipse(Brushes.Honeydew, rectangulo)
                Case "HotPink"
                    grfx.FillEllipse(Brushes.HotPink, rectangulo)
                Case "IndianRed"
                    grfx.FillEllipse(Brushes.IndianRed, rectangulo)
                Case "Indigo"
                    grfx.FillEllipse(Brushes.Indigo, rectangulo)
                Case "Ivory"
                    grfx.FillEllipse(Brushes.Ivory, rectangulo)
                Case "Khaki"
                    grfx.FillEllipse(Brushes.Khaki, rectangulo)
                Case "Lavender"
                    grfx.FillEllipse(Brushes.Lavender, rectangulo)
                Case "LavenderBlush"
                    grfx.FillEllipse(Brushes.LavenderBlush, rectangulo)
                Case "LawnGreen"
                    grfx.FillEllipse(Brushes.LawnGreen, rectangulo)
                Case "LemonChiffon"
                    grfx.FillEllipse(Brushes.LemonChiffon, rectangulo)
                Case "LightBlue"
                    grfx.FillEllipse(Brushes.LightBlue, rectangulo)
                Case "LightCoral"
                    grfx.FillEllipse(Brushes.LightCoral, rectangulo)
                Case "LightCyan"
                    grfx.FillEllipse(Brushes.LightCyan, rectangulo)
                Case "LightGoldenrodYellow"
                    grfx.FillEllipse(Brushes.LightGoldenrodYellow, rectangulo)
                Case "LightGray"
                    grfx.FillEllipse(Brushes.LightGray, rectangulo)
                Case "LightGreen"
                    grfx.FillEllipse(Brushes.LightGreen, rectangulo)
                Case "LightPink"
                    grfx.FillEllipse(Brushes.LightPink, rectangulo)
                Case "LightSalmon"
                    grfx.FillEllipse(Brushes.LightSalmon, rectangulo)
                Case "LightSeaGreen"
                    grfx.FillEllipse(Brushes.LightSeaGreen, rectangulo)
                Case "LightSkyBlue"
                    grfx.FillEllipse(Brushes.LightSkyBlue, rectangulo)
                Case "LightSlateGray"
                    grfx.FillEllipse(Brushes.LightSlateGray, rectangulo)
                Case "LightSteelBlue"
                    grfx.FillEllipse(Brushes.LightSteelBlue, rectangulo)
                Case "LightYellow"
                    grfx.FillEllipse(Brushes.LightYellow, rectangulo)
                Case "Lime"
                    grfx.FillEllipse(Brushes.Lime, rectangulo)
                Case "LimeGreen"
                    grfx.FillEllipse(Brushes.LimeGreen, rectangulo)
                Case "Linen"
                    grfx.FillEllipse(Brushes.Linen, rectangulo)
                Case "Magenta"
                    grfx.FillEllipse(Brushes.Magenta, rectangulo)
                Case "Maroon"
                    grfx.FillEllipse(Brushes.Maroon, rectangulo)
                Case "MediumAquamarine"
                    grfx.FillEllipse(Brushes.MediumAquamarine, rectangulo)
                Case "MediumBlue"
                    grfx.FillEllipse(Brushes.MediumBlue, rectangulo)
                Case "MediumOrchid"
                    grfx.FillEllipse(Brushes.MediumOrchid, rectangulo)
                Case "MediumPurple"
                    grfx.FillEllipse(Brushes.MediumPurple, rectangulo)
                Case "MediumPurple"
                    grfx.FillEllipse(Brushes.MediumPurple, rectangulo)
                Case "MediumSeaGreen"
                    grfx.FillEllipse(Brushes.MediumSeaGreen, rectangulo)
                Case "MediumSlateBlue"
                    grfx.FillEllipse(Brushes.MediumSlateBlue, rectangulo)
                Case "MediumSpringGreen"
                    grfx.FillEllipse(Brushes.MediumSpringGreen, rectangulo)
                Case "MediumTurquoise"
                    grfx.FillEllipse(Brushes.MediumTurquoise, rectangulo)
                Case "MediumVioletRed"
                    grfx.FillEllipse(Brushes.MediumVioletRed, rectangulo)
                Case "MidnightBlue"
                    grfx.FillEllipse(Brushes.MidnightBlue, rectangulo)
                Case "MintCream"
                    grfx.FillEllipse(Brushes.MintCream, rectangulo)
                Case "MistyRose"
                    grfx.FillEllipse(Brushes.MistyRose, rectangulo)
                Case "Moccasin"
                    grfx.FillEllipse(Brushes.Moccasin, rectangulo)
                Case "NavajoWhite"
                    grfx.FillEllipse(Brushes.NavajoWhite, rectangulo)
                Case "Navy"
                    grfx.FillEllipse(Brushes.Navy, rectangulo)
                Case "OldLace"
                    grfx.FillEllipse(Brushes.OldLace, rectangulo)
                Case "Olive"
                    grfx.FillEllipse(Brushes.Olive, rectangulo)
                Case "OliveDrab"
                    grfx.FillEllipse(Brushes.OliveDrab, rectangulo)
                Case "Orange"
                    grfx.FillEllipse(Brushes.Orange, rectangulo)
                Case "OrangeRed"
                    grfx.FillEllipse(Brushes.OrangeRed, rectangulo)
                Case "Orchid"
                    grfx.FillEllipse(Brushes.Orchid, rectangulo)
                Case "PaleGoldenrod"
                    grfx.FillEllipse(Brushes.PaleGoldenrod, rectangulo)
                Case "PaleGreen"
                    grfx.FillEllipse(Brushes.PaleGreen, rectangulo)
                Case "PaleTurquoise"
                    grfx.FillEllipse(Brushes.PaleTurquoise, rectangulo)
                Case "PaleVioletRed"
                    grfx.FillEllipse(Brushes.PaleVioletRed, rectangulo)
                Case "PapayaWhip"
                    grfx.FillEllipse(Brushes.PapayaWhip, rectangulo)
                Case "PeachPuff"
                    grfx.FillEllipse(Brushes.PeachPuff, rectangulo)
                Case "Peru"
                    grfx.FillEllipse(Brushes.Peru, rectangulo)
                Case "Pink"
                    grfx.FillEllipse(Brushes.Pink, rectangulo)
                Case "Plum"
                    grfx.FillEllipse(Brushes.Plum, rectangulo)
                Case "PowderBlue"
                    grfx.FillEllipse(Brushes.PowderBlue, rectangulo)
                Case "Purple"
                    grfx.FillEllipse(Brushes.Purple, rectangulo)
                Case "Red"
                    grfx.FillEllipse(Brushes.Red, rectangulo)
                Case "RosyBrown"
                    grfx.FillEllipse(Brushes.RosyBrown, rectangulo)
                Case "RoyalBlue"
                    grfx.FillEllipse(Brushes.RoyalBlue, rectangulo)
                Case "SaddleBrown"
                    grfx.FillEllipse(Brushes.SaddleBrown, rectangulo)
                Case "Salmon"
                    grfx.FillEllipse(Brushes.Salmon, rectangulo)
                Case "SandyBrown"
                    grfx.FillEllipse(Brushes.SandyBrown, rectangulo)
                Case "SeaGreen"
                    grfx.FillEllipse(Brushes.SeaGreen, rectangulo)
                Case "SeaShell"
                    grfx.FillEllipse(Brushes.SeaShell, rectangulo)
                Case "Sienna"
                    grfx.FillEllipse(Brushes.Sienna, rectangulo)
                Case "Silver"
                    grfx.FillEllipse(Brushes.Silver, rectangulo)
                Case "SkyBlue"
                    grfx.FillEllipse(Brushes.SkyBlue, rectangulo)
                Case "SlateBlue"
                    grfx.FillEllipse(Brushes.SlateBlue, rectangulo)
                Case "SlateGray"
                    grfx.FillEllipse(Brushes.SlateGray, rectangulo)
                Case "Snow"
                    grfx.FillEllipse(Brushes.Snow, rectangulo)
                Case "SpringGreen"
                    grfx.FillEllipse(Brushes.SpringGreen, rectangulo)
                Case "SteelBlue"
                    grfx.FillEllipse(Brushes.SteelBlue, rectangulo)
                Case "Tan"
                    grfx.FillEllipse(Brushes.Tan, rectangulo)
                Case "Teal"
                    grfx.FillEllipse(Brushes.Teal, rectangulo)
                Case "Thistle"
                    grfx.FillEllipse(Brushes.Thistle, rectangulo)
                Case "Tomato"
                    grfx.FillEllipse(Brushes.Tomato, rectangulo)
                Case "Transparent"
                    grfx.FillEllipse(Brushes.Transparent, rectangulo)
                Case "Turquoise"
                    grfx.FillEllipse(Brushes.Turquoise, rectangulo)
                Case "Violet"
                    grfx.FillEllipse(Brushes.Violet, rectangulo)
                Case "Wheat"
                    grfx.FillEllipse(Brushes.Wheat, rectangulo)
                Case "White"
                    grfx.FillEllipse(Brushes.White, rectangulo)
                Case "WhiteSmoke"
                    grfx.FillEllipse(Brushes.WhiteSmoke, rectangulo)
                Case "Yellow"
                    grfx.FillEllipse(Brushes.Yellow, rectangulo)
                Case "YellowGreen"
                    grfx.FillEllipse(Brushes.YellowGreen, rectangulo)

                Case Else
                    grfx.FillEllipse(Brushes.Transparent, rectangulo)
            End Select
        End Sub
    End Class

    Public Class Texto

        Private m_point1 As New Point(0, 0)
        Private t_texto As String = ""
        Private t_fuente As New Font("Arial", 16)
        Dim t_color As Color = Color.Black

        Public Property Point1() As Point

            Get
                Return m_point1
            End Get
            Set(ByVal value As Point)
                m_point1 = value
            End Set
        End Property
        Public Property texto_() As String
            Get
                Return t_texto
            End Get
            Set(ByVal value As String)
                t_texto = value
            End Set
        End Property
        Public Property fuente_() As Font
            Get
                Return t_fuente
            End Get
            Set(ByVal value As Font)
                t_fuente = value
            End Set
        End Property
        Public Property color_() As Color
            Get
                Return t_color
            End Get
            Set(ByVal value As Color)
                t_color = value
            End Set
        End Property


        Public Sub Draw(ByVal grfx As Graphics)

            If (grfx Is Nothing) Then _
                 Throw New ArgumentNullException("grfx")
            Dim br As Brush
            If t_color = Nothing Then
                br = New SolidBrush(Color.Black)
            Else
                Dim c As Color = t_color
                br = New SolidBrush(c)
            End If
            grfx.DrawString(t_texto, t_fuente, br, m_point1)


        End Sub
    End Class

End Class



