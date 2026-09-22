Imports Capa_Entidades
Imports Capa_Negocios
Module ModCapas
    Public c_Neg_mnProve As New Neg_MnProve : Public c_Neg_MnProveDet As New Neg_MnProveDet
    Public c_Neg_MnTblGral As New Neg_MnTblGral
    Public c_Neg_MnCaidas As New Neg_MnCaidas
    Public c_Neg_MnScaidas As New Neg_Scaidas
    Public c_Neg_MnOQSerie As New Neg_MnOQSerie
    Public c_Neg_OCSerie As New Neg_MnOcSerie
    Public c_Neg_MnAreas As New Neg_MnAreas
    Public c_Neg_MnUniMed As New Neg_MnUniMed
    Public c_Neg_MnMoneda As New Neg_MnMonedas
    Public c_Neg_TpoCambio As New Neg_MnTpoCambio
    Public c_Neg_MnTblDetraccion As New Neg_MnTblDetraccion
    Public c_Neg_MnTpoPago As New Neg_MnTpoPago
    Public c_Neg_MnTpoDoc As New Neg_MnTpoDoc
    Public c_Neg_MnEmpresa As New Neg_MnEmpresa
    Public c_Neg_MnPresenta As New Neg_MnPresenta
    Public c_Neg_Igv As New Neg_MnIgv
    Public c_Neg_MnMtMov As New Neg_MnMtMov
    Public c_Neg_MnAlmacen As New Neg_MnAlmacen
    Public c_Neg_MnArticulo As New Neg_MnArticulos
    Public c_Neg_MnCliente As New Neg_MnCliente

    Public c_Neg_MnLineas As New Neg_MnLinea
    Public c_Neg_MnFamilias As New Neg_MnFamilia
    Public c_Neg_MnSFamilias As New Neg_MnSFamilia
    Public c_Neg_MnMonedas As New Neg_MnMonedas
    Public c_Neg_MnArticulos As New Neg_MnArticulos
    
    Public c_Neg_OQ As New Neg_OQ : Public c_Neg_OQDet As New Neg_OQDet
    Public c_Neg_LeasingCab As New Neg_Leasing : Public c_Neg_LeasingDet As New Neg_LeasingDet
    Public c_Neg_DuasCab As New Neg_DuasCab : Public c_Neg_DuasDet As New Neg_DuasDet
    Public c_Neg_AlmTransforCab As New Neg_AlmTransforCab : Public c_Neg_AlmTransfordet As New Neg_AlmTransforDet
    Public c_Neg_OC As New Neg_OC
    Public c_Neg_OCDet As New Neg_OCDet
    Public c_Neg_IngAlmIQ As New Neg_IngAlmIQ
    Public c_Neg_IngAlmIQDet As New Neg_IngAlmIQDet
    Public c_Neg_RptStockIQ As New Neg_RptStockIQ
    Public c_Neg_RptKardexIQ As New Neg_RptKardexIQ
    Public c_Neg_IngComp As New Neg_IngComp
    Public c_Neg_IngCompDet As New Neg_IngCompDet
    Public c_Neg_AlmSal As New Neg_AlmSalTa : Public c_Neg_AlmSalDet As New Neg_AlmSalTaDet

    Public c_Neg_RptRegCompras As New Neg_RptRegCompras
    ' Detracciones '
    Public c_Neg_RetenCab As New Neg_RetenCab
    Public c_Neg_RetenDet As New Neg_RetenDet
    Public c_Neg_Retencion As New Neg_Retencion
    Public c_Neg_MnSeries As New Neg_MnSeries
    ' Letras '
    Public c_Neg_LetCab As New Neg_LetCab
    Public c_Neg_LetDet As New Neg_LetDet
    Public c_Neg_MnBcos As New Neg_MnBcos
    Public c_Neg_StatusLetra As New Neg_MnStatusLetra
    ' Letras '
    Public c_Neg_NotaC As New Neg_NotaC
    Public c_Neg_NotaCDet As New Neg_NotaCDet
    'Detracciones '
    Public c_Neg_Detrac As New Neg_Detrac
    Public c_Neg_DetracDet As New Neg_DetracDet
    'Costos
    Public c_Neg_CostosCab As New Neg_CostosCab : Public c_Neg_CostosDet As New Neg_CostosDet : Public c_Neg_CostosDocs As New Neg_CostosDocs

    ' Leasing

    ' Usuarios '' Modulos '
    Public c_Neg_Usuario As New Neg_Usuario
    Public c_Neg_Modulos As New Neg_Modulos
    ' Contabilidad '
    Public c_Neg_Asientos_Cab As New Neg_Asientos_Cab
    Public c_Neg_Asientos_Det As New Neg_Asientos_Det
    Public c_Neg_Asientos_Anexos As New Neg_Asientos_Anexos

    Public c_Ent_MnProve As New Ent_MnProve : Public c_Ent_MnProveDet As New Ent_MnProveDet
    Public c_Ent_MnTblGral As New Ent_MnTblGral
    Public c_Ent_MnCaidas As New Ent_MnCaidas
    Public c_Ent_MnArticulos As New Ent_MnArticulo : Public c_Ent_MnArtPrecio As New Ent_MnArtPrecio
    Public c_Ent_MnUnidMed As New Ent_MnUniMed
    Public c_Ent_MnAlmacen As New Ent_MnAlmacen

    Public c_Ent_MnScaidas As New Ent_MnSCaidas
    Public c_Ent_MnTpoDoc As New Ent_MnTpoDoc
    Public c_Ent_MnMtMov As New Ent_MnMtMov

    Public c_Ent_OQ As New Ent_OQ : Public c_Ent_OQDet As New Ent_OQDet
    Public c_Ent_OC As New Ent_OC : Public c_Ent_OcDet As New Ent_OCDet
    Public c_Ent_LeasingCab As New Ent_LeasingCab : Public c_Ent_LeasingDet As New Ent_LeasingDet
    Public c_Ent_DuasCab As New Ent_DuasCab : Public c_Ent_DuasDet As New Ent_DuasDet
    ' costos
    Public c_Ent_CostosCab As New Ent_CostosCab : Public c_Ent_CostosDet As New Ent_CostosDet : Public c_Ent_CostosDocs As New Ent_CostosDocs

    Public c_Ent_IngAlmIQ As New Ent_IngAlmIQ
    Public c_Ent_IngAlmIQDet As New Ent_IngAlmIQDet
    Public c_Ent_IngComp As New Ent_IngComp
    Public c_Ent_ingCompDet As New Ent_IngCompDet
    Public c_Ent_IngCompOC As New Ent_IngCompOC
    Public c_Ent_MnTblDetraccion As New Ent_MnTblDetraccion
    Public c_Ent_DetracCancel As New Ent_DetracCancel
    Public c_Ent_MnPresenta As New Ent_MnPresenta
    Public c_Ent_AlmTransforCab As New Ent_AlmTransforCab : Public c_Ent_AlmTransfordet As New Ent_AlmTransforDet

    Public c_Ent_LetCab As New Ent_LetCab
    Public c_Ent_LetDet As New Ent_LetDet
    ' Nota de Credito '
    Public c_Ent_NotaCDet As New Ent_NotaCDet
    Public c_Ent_NotaC As New Ent_NotaC
    ' Detracciones '
    Public c_Ent_Detrac As New Ent_Detrac
    Public c_Ent_DetracDet As New Ent_DetracDet
    ' Retenciones '
    Public c_Ent_SeriesDoc As New Ent_SeriesDoc
    Public c_Ent_RetenCab As New Ent_RetenCab
    Public c_Ent_RetenDet As New Ent_RetenDet
    ' Administracion '
    Public c_Ent_Usuarios As New Ent_Usuario
    Public c_Ent_UsuaPermiso As New Ent_UsuaPermiso
    ' Modulos '
    Public c_Ent_Modulos As New Ent_Modulos
    ' Contabilidad '
    Public c_Ent_Asientos_Anexos As New Ent_Asientos_Anexos
End Module
